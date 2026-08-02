using Dental.Domain.Entities;
using Dental.Domain.Repositories.Views.Visits;
using Dental.Domain.ValueObjects;
using Dental.Domain.Views.Visit;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Dental.Infrastructure.Repositories.Views.Visits;

public sealed class VisitRadiographViewRepository : IVisitRadiographViewRepository
{
    private readonly DentalDbContext _dbContext;

    public VisitRadiographViewRepository(DentalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<VisitRadiographView>> GetAsync(
        VisitRadiographView? filterDto = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<VisitRadiograph> query = _dbContext
            .VisitRadiographs
            .AsNoTracking();

        if (filterDto is not null)
        {
            if (filterDto.VisitId is { } visitId)
            {
                query = query.Where(vr => vr.VisitId == Id.FromDatabase(visitId));
            }

            if (!string.IsNullOrWhiteSpace(filterDto.PatientName))
            {
                query = query.Where(vr => vr.Visit
                    .Patient.Name.Contains(filterDto.PatientName.Trim()));
            }

            if (filterDto.RadiographCreatedAt is { } radiographCreatedAt)
            {
                var start = radiographCreatedAt.Date;
                var end = start.AddDays(1);

                query = query.Where(
                    vr => vr.CreatedAt >= start
                    && vr.CreatedAt < end);

                Debug.WriteLine(start.ToString("yyyy-MM-dd HH:mm:s"));
                Debug.WriteLine(end.ToString("yyyy-MM-dd HH:mm:s"));
                Debug.WriteLine(
                    filterDto.RadiographCreatedAt?.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (filterDto.FilterAfter is { } filterAfter)
            {
                query = query.Where(vr => vr.CreatedAt >= filterAfter.Date);
            }

            if (filterDto.PatientId is { } patientId)
            {
                query = query.Where(vr => vr.Visit.PatientId == Id.FromDatabase(patientId));
            }

            if (filterDto.VisitRadiographId is { } visitRadiographId)
            {
                query = query.Where(vr => vr.Id == Id.FromDatabase(visitRadiographId));
            }

            if (!string.IsNullOrWhiteSpace(filterDto.ImagePath))
            {
                query = query.Where(vr => vr.ImagePath.Contains(filterDto.ImagePath.Trim()));
            }
        }

        var result = query.Select(vr => new VisitRadiographView
        {
            VisitId = vr.VisitId.Value,
            PatientName = vr.Visit.Patient.Name,
            RadiographCreatedAt = vr.CreatedAt,
            PatientId = vr.Visit.PatientId.Value,
            VisitRadiographId = vr.Id.Value,
            ImagePath = vr.ImagePath
        })
        .OrderByDescending(vr => vr.RadiographCreatedAt);

        return result.ToListAsync(cancellationToken);
    }
}