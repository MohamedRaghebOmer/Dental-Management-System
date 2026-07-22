using Dental.Application.ViewsStuff.Interfaces;
using Dental.Domain.Repositories.Views;
using Dental.Domain.ValueObjects;
using Dental.Domain.Views;
using System.Collections.ObjectModel;
using Dental.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace Dental.Application.ViewsStuff.Services;

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

        return Result.Success<AppointmentInfo?>
            (await _appointmentInfoRepository.GetAppointmentInfoAsync(
            idResult.Value, cancellationToken));
    }

    public Task<List<AppointmentInfo>> GetAllAppointmentsInfoAsync(
        AppointmentInfo? filterInfo, 
        CancellationToken cancellationToken = default)
    {
        return _appointmentInfoRepository.GetAllAppointmentsInfoAsync(filterInfo, cancellationToken);
    }
}