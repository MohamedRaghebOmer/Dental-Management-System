using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Appointment;

public sealed record AppointmentRequestDto()
{
    [Range(1, int.MaxValue)]
    [Required]
    public required int PatientId { get; init; }

    [DataType(DataType.DateTime)]
    [Required]
    public required DateTime ScheduledVisitDateTime { get; init; }

    [MaxLength(Domain.Entities.Appointment.Constants.NotesMaxLength)]
    public string? Notes { get; init; }
}