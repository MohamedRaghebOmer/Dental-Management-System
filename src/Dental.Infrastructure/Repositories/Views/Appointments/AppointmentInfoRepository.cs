using Dental.Domain.Enums;
using Dental.Domain.Repositories.Views.Appointments;
using Dental.Domain.ValueObjects;
using Dental.Domain.Views.Appointment;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;

namespace Dental.Infrastructure.Repositories.Views.Appointment;

public sealed class AppointmentInfoRepository : IAppointmentInfoRepository
{
    private readonly DentalDbContext _dbContext;

    public AppointmentInfoRepository(DentalDbContext dbContext) =>
        _dbContext = dbContext;

    public Task<AppointmentInfo?> GetAppointmentInfoAsync(
        Id appointmentId, CancellationToken cancellationToken = default)
    {
        return _dbContext.Appointments
            .AsNoTracking()
            .Where(a => a.Id == appointmentId)
            .Include(a => a.Patient)
            .Select(a => new AppointmentInfo
            {
                Id = a.Id.Value,
                PatientId = a.PatientId.Value,
                PatientName = a.Patient.Name,
                CreatedAt = a.CreatedAt,
                ScheduledVisitDateTime = a.ScheduledVisitDateTime,
                ActualVisitDateTime = a.ActualVisitDateTime,
                Status = a.Status,
                Notes = a.Notes
            })
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<AppointmentInfo>> GetAllAppointmentsInfoAsync(
        AppointmentInfo? filterInfo,
        CancellationToken cancellationToken = default)
    {
        var whereClauses = new List<string>();
        var parameters = new List<(string Name, object Value)>();

        if (filterInfo is not null)
        {
            if (filterInfo.Id is { } id)
            {
                whereClauses.Add("a.Id = @Id");
                parameters.Add(("@Id", id));
            }

            if (filterInfo.PatientId is { } patientId)
            {
                whereClauses.Add("a.PatientId = @PatientId");
                parameters.Add(("@PatientId", patientId));
            }

            if (!string.IsNullOrWhiteSpace(filterInfo.PatientName))
            {
                whereClauses.Add("p.Name LIKE @PatientName ESCAPE '\\'");
                parameters.Add(("@PatientName", $"%{EscapeLike(filterInfo.PatientName.Trim())}%"));
            }

            // Match the hole day for CreatedAt filter not just the exact time.
            if (filterInfo.CreatedAt is { } createdAt)
            {
                whereClauses.Add("a.CreatedAt >= @CreatedAtFrom AND a.CreatedAt < @CreatedAtTo");
                parameters.Add(("@CreatedAtFrom", createdAt.Date));
                parameters.Add(("@CreatedAtTo", createdAt.Date.AddDays(1)));
            }
            else if (filterInfo.GetAfter is { } getAfter)
            {
                whereClauses.Add("a.CreatedAt >= @GetAfter");
                parameters.Add(("@GetAfter", getAfter.Date));
            }

            // Match the hole day for ScheduledVisitDateTime filter not just the exact time.
            if (filterInfo.ScheduledVisitDateTime is { } scheduledVisitDateTime)
            {
                whereClauses.Add("a.ScheduledVisitDateTime >= @ScheduledVisitDateTimeFrom AND a.ScheduledVisitDateTime < @ScheduledVisitDateTimeTo");
                parameters.Add(("@ScheduledVisitDateTimeFrom", scheduledVisitDateTime.Date));
                parameters.Add(("@ScheduledVisitDateTimeTo", scheduledVisitDateTime.Date.AddDays(1)));
            }

            // Match the hole day for ActualVisitDateTime filter not just the exact time.
            if (filterInfo.ActualVisitDateTime is { } actualVisitDateTime)
            {
                whereClauses.Add("a.ActualVisitDateTime >= @ActualVisitDateTimeFrom AND a.ActualVisitDateTime < @ActualVisitDateTimeTo");
                parameters.Add(("@ActualVisitDateTimeFrom", actualVisitDateTime.Date));
                parameters.Add(("@ActualVisitDateTimeTo", actualVisitDateTime.Date.AddDays(1)));
            }

            if (filterInfo.Status is { } status)
            {
                if (status == AppointmentStatus.Pending)
                {
                    whereClauses.Add(
                        $"a.Status = {(byte)AppointmentStatus.Pending} AND a.ScheduledVisitDateTime > @CurrentTime AND a.ActualVisitDateTime IS NULL");

                    parameters.Add(("@CurrentTime", DateTime.Now));
                }
                else if (status == AppointmentStatus.Missed)
                {
                    whereClauses.Add(
                        $"a.Status = {(byte)AppointmentStatus.Pending} AND a.ScheduledVisitDateTime < @CurrentTime AND a.ActualVisitDateTime IS NULL");
                    parameters.Add(("@CurrentTime", DateTime.Now));
                }
                else
                {
                    whereClauses.Add("a.Status = @Status");
                    parameters.Add(("@Status", (byte)status));
                }
            }
        }


        var sql = new StringBuilder(@"
            SELECT 
                a.Id,
                a.PatientId,
                p.Name AS PatientName,
                a.CreatedAt,
                a.ScheduledVisitDateTime,
                a.ActualVisitDateTime,
                a.Status,
                a.Notes
            FROM Appointments AS a
            INNER JOIN Patients AS p ON a.PatientId = p.Id");

        if (whereClauses.Count > 0)
            sql.Append(" WHERE ").Append(string.Join(" AND ", whereClauses));

        sql.Append(" ORDER BY a.CreatedAt DESC");

        var results = new List<AppointmentInfo>();
        var connection = _dbContext.Database.GetDbConnection();
        var wasClosed = connection.State != ConnectionState.Open;
        if (wasClosed)
            await connection.OpenAsync(cancellationToken);

        try
        {
            await using var command = connection.CreateCommand();
            command.CommandText = sql.ToString();

            foreach (var (name, value) in parameters)
            {
                var p = command.CreateParameter();
                p.ParameterName = name;
                p.Value = value;
                command.Parameters.Add(p);
            }

            await using var reader = await command.ExecuteReaderAsync(
                CommandBehavior.SequentialAccess, cancellationToken);

            int oId = reader.GetOrdinal("Id");
            int oPatientId = reader.GetOrdinal("PatientId");
            int oPatientName = reader.GetOrdinal("PatientName");
            int oCreatedAt = reader.GetOrdinal("CreatedAt");
            int oScheduledVisitDateTime = reader.GetOrdinal("ScheduledVisitDateTime");
            int oActualVisitDateTime = reader.GetOrdinal("ActualVisitDateTime");
            int oStatus = reader.GetOrdinal("Status");

            while (await reader.ReadAsync(cancellationToken))
            {
                results.Add(new AppointmentInfo
                {
                    Id = reader.GetInt32(oId),
                    PatientId = reader.GetInt32(oPatientId),
                    PatientName = reader.GetString(oPatientName),
                    CreatedAt = reader.GetDateTime(oCreatedAt),
                    ScheduledVisitDateTime = reader.GetDateTime(oScheduledVisitDateTime),
                    ActualVisitDateTime = reader.IsDBNull(oActualVisitDateTime) ? null : reader.GetDateTime(oActualVisitDateTime),
                    Status = (AppointmentStatus)reader.GetByte(oStatus),
                    Notes = null // No need to read Notes for this query, as it's not used in the filter or display.
                });
            }
        }
        finally
        {
            if (wasClosed)
                await connection.CloseAsync();
        }

        return results;
    }

    public async Task<List<ShortAppointmentInfo>> GetAllShortAppointmentsInfoAsync(
        ShortAppointmentInfo? filterInfo = null,
        CancellationToken cancellationToken = default)
    {
        var whereClauses = new List<string>();
        var parameters = new List<(string Name, object Value)>();

        if (filterInfo is not null)
        {
            if (filterInfo.AppointmentId is { } appointmentId)
            {
                whereClauses.Add("a.Id = @AppointmentId");
                parameters.Add(("@AppointmentId", appointmentId));
            }

            if (filterInfo.PatientId is { } patientId)
            {
                whereClauses.Add("a.PatientId = @PatientId");
                parameters.Add(("@PatientId", patientId));
            }

            if (!string.IsNullOrWhiteSpace(filterInfo.PatientName))
            {
                whereClauses.Add("p.Name LIKE @PatientName ESCAPE '\\'");
                parameters.Add(("@PatientName", $"%{EscapeLike(filterInfo.PatientName.Trim())}%"));
            }

            if (filterInfo.ScheduledVisitDateTime is { } scheduledVisitDateTime)
            {
                whereClauses.Add("a.ScheduledVisitDateTime >= @ScheduledVisitDateTimeFrom AND a.ScheduledVisitDateTime < @ScheduledVisitDateTimeTo");
                parameters.Add(("@ScheduledVisitDateTimeFrom", scheduledVisitDateTime.Date));
                parameters.Add(("@ScheduledVisitDateTimeTo",
                    scheduledVisitDateTime.Date.AddDays(1)));
            }

            if (filterInfo.Status is { } status)
            {
                if (status == AppointmentStatus.Pending)
                {
                    whereClauses.Add($"a.Status = {(byte)AppointmentStatus.Pending} AND a.ScheduledVisitDateTime > @CurrentTime AND a.ActualVisitDateTime IS NULL");
                    parameters.Add(("@CurrentTime", DateTime.Now));
                }
                else if (status == AppointmentStatus.Missed)
                {
                    whereClauses.Add($"a.Status = {(byte)AppointmentStatus.Pending} AND a.ScheduledVisitDateTime < @CurrentTime AND a.ActualVisitDateTime IS NULL");
                    parameters.Add(("@CurrentTime", DateTime.Now));
                }
                else
                {
                    whereClauses.Add("a.Status = @Status");
                    parameters.Add(("@Status", (byte)status));
                }
            }
        }

        var sql = new StringBuilder(@"
            SELECT 
                a.Id,
                a.PatientId,
                p.Name,
                a.ScheduledVisitDateTime,
                a.Status
            FROM Appointments a
            INNER JOIN Patients AS p ON a.PatientId = p.Id");

        if (whereClauses.Count > 0)
            sql.Append(" WHERE ").Append(string.Join(" AND ", whereClauses));

        sql.Append(" ORDER BY a.ScheduledVisitDateTime DESC");

        var results = new List<ShortAppointmentInfo>();
        var connection = _dbContext.Database.GetDbConnection();
        var wasClosed = connection.State != ConnectionState.Open;
        if (wasClosed)
            await connection.OpenAsync(cancellationToken);

        try
        {
            await using var command = connection.CreateCommand();
            command.CommandText = sql.ToString();

            foreach (var (name, value) in parameters)
            {
                var p = command.CreateParameter();
                p.ParameterName = name;
                p.Value = value;
                command.Parameters.Add(p);
            }

            await using var reader = await command.ExecuteReaderAsync(
                CommandBehavior.SequentialAccess, cancellationToken);

            int oId = reader.GetOrdinal("Id");
            int oPatientId = reader.GetOrdinal("PatientId");
            int oPatientName = reader.GetOrdinal("Name");
            int oScheduledVisitDateTime = reader.GetOrdinal("ScheduledVisitDateTime");
            int oStatus = reader.GetOrdinal("Status");

            while (await reader.ReadAsync(cancellationToken))
            {
                results.Add(new ShortAppointmentInfo
                {
                    AppointmentId = reader.GetInt32(oId),
                    PatientId = reader.GetInt32(oPatientId),
                    PatientName = reader.GetString(oPatientName),
                    ScheduledVisitDateTime = reader.GetDateTime(oScheduledVisitDateTime),
                    Status = (AppointmentStatus)reader.GetByte(oStatus)
                });
            }
        }
        finally
        {
            if (wasClosed)
                await connection.CloseAsync();
        }

        return results;
    }

    private static string EscapeLike(string input) =>
        input.Replace("\\", "\\\\").Replace("%", "\\%").Replace("_", "\\_");
}