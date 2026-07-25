using Dental.Application.ViewsStuff.Interfaces.Appointments;
using Dental.Domain.Repositories.Views.Appointments;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Dental.Domain.Views.Appointment;
using Microsoft.Extensions.Logging;
using AppointmentStatus = Dental.Domain.Enums.AppointmentStatus;

namespace Dental.Application.ViewsStuff.Services.Appointments;

public sealed class AppointmentInfoService : IAppointmentInfoService
{
    private readonly IAppointmentInfoRepository _appointmentInfoRepository;
    private readonly ILogger<AppointmentInfoService> _logger;

    public AppointmentInfoService(
        IAppointmentInfoRepository appointmentInfoRepository,
        ILogger<AppointmentInfoService> logger)
    {
        _appointmentInfoRepository = appointmentInfoRepository;
        _logger = logger;
    }

    public async Task<Result<AppointmentInfo?>> GetAppointmentInfoAsync(
        int appointmentId, CancellationToken cancellationToken = default)
    {
        var idResult = Id.Create(appointmentId);
        if (idResult.IsFailure)
        {
            _logger.LogWarning("Invalid appointment ID: {AppointmentId}. Error: {Error}", appointmentId, idResult.Error);
            return Result.Failure<AppointmentInfo?>(idResult.Error);
        }

        var view = await _appointmentInfoRepository
            .GetAppointmentInfoAsync(idResult.Value, cancellationToken);

        if (view is { Status: AppointmentStatus.Pending, ActualVisitDateTime: null }
                && view.ScheduledVisitDateTime < DateTime.Now)
        {
            view = view with { Status = AppointmentStatus.Missed };
        }

        return Result.Success<AppointmentInfo?>(view);
    }

    public async Task<List<AppointmentInfo>> GetAllAppointmentsInfoAsync(
        AppointmentInfo? filterInfo,
        CancellationToken cancellationToken = default)
    {
        var appointments = await _appointmentInfoRepository.GetAllAppointmentsInfoAsync(filterInfo, cancellationToken);

        return appointments.Select(a =>
            a with
            {
                Status = a.Status == AppointmentStatus.Pending && a.ActualVisitDateTime == null && a.ScheduledVisitDateTime < DateTime.Now
                    ? AppointmentStatus.Missed
                    : a.Status
            }).ToList();
    }

    public async Task<List<ShortAppointmentInfo>> GetAllShortAppointmentsInfoAsync(
        ShortAppointmentInfo? filterInfo = null,
        CancellationToken cancellationToken = default)
    {
        var appoinments =
            await _appointmentInfoRepository.GetAllShortAppointmentsInfoAsync(
            filterInfo, cancellationToken);

        return appoinments.Select(a =>
            a with
            {
                Status = a.Status == AppointmentStatus.Pending && a.ScheduledVisitDateTime < DateTime.Now
                    ? AppointmentStatus.Missed
                    : a.Status
            }).ToList();
    }
}