using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Appointment;

public sealed record AppointmentRequestDto()
{
    [Range(1, int.MaxValue)]
    public required int PatientId { get; init; }

    public required DateTime AppointmentDate { get; init; }

    [MaxLength(Domain.Entities.Appointment.Constants.NotesMaxLength)]
    public string? Notes { get; init; }
}