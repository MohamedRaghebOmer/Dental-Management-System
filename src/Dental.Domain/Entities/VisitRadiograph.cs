using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class VisitRadiograph : Entity
{
    public static class Constants
    {
        public const int ImagePathMaxLength = 500;
    }

    public Id VisitId { get; private set; } = default!;
    public string ImagePath { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Visit Visit { get; private set; } = default!;


    private VisitRadiograph() { } // EF Core

    private VisitRadiograph(
        Id visitId,
        string imagePath,
        DateTime createdAt)
    {
        VisitId = visitId;
        ImagePath = imagePath;
        CreatedAt = createdAt;
    }


    internal static Result<VisitRadiograph> Create(
        Id visitId,
        string imagePath)
    {
        imagePath = imagePath.Trim();

        var validatResult = Validate(imagePath);
        if (validatResult.IsFailure)
            return Result.Failure<VisitRadiograph>(validatResult.Error);

        return new VisitRadiograph(
            visitId: visitId,
            imagePath: imagePath,
            createdAt: DateTime.Now);
    }

    internal Result Update(
        string imagePath)
    {
        imagePath = imagePath.Trim();

        var validationResult = Validate(imagePath);
        if (validationResult.IsFailure)
            return Result.Failure(validationResult.Error);

        ImagePath = imagePath;
        return Result.Success();
    }

    private static Result Validate(string imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath))
            return Result.Failure(DomainErrors.Entities.VisitRadioghraph.ImagePath.Empty);

        if (imagePath.Length > Constants.ImagePathMaxLength)
            return Result.Failure(DomainErrors.Entities.VisitRadioghraph.ImagePath.TooLong);

        return Result.Success();
    }
}