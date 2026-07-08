using Dental.Domain.Primitives;

namespace Dental.Application.Abstractions;

public interface IResponseDto<TEntity, TSelf>
    where TEntity : Entity
    where TSelf : IResponseDto<TEntity, TSelf>
{
    static abstract TSelf ToResponseDto(TEntity entity);
}