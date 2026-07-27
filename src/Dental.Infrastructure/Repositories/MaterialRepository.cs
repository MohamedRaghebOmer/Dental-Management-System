using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.ValueObjects;
using Dental.Domain.Views.Material;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class MaterialRepository
    : Repository<Material>,
        IMaterialRepository
{
    private readonly DentalDbContext _dbContext;

    public MaterialRepository(
        DentalDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> ExistsByNameAsync(
        string name,
        Id? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Materials.AnyAsync(
            m => m.Name == name && m.Id != excludeId, cancellationToken);
    }

    public Task<List<MaterialFilterDto>> FilterAsync(
        MaterialFilterDto? filterDto = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<Material> query = _dbContext.Materials.AsNoTracking
            ();

        if (filterDto is not null)
        {
            if (filterDto.Id is { } id)
                query = query.Where(m => m.Id == Id.FromDatabase(id));

            if (!string.IsNullOrWhiteSpace(filterDto.Name))
                query = query.Where(m => m.Name.Contains(filterDto.Name.Trim()));

            if (filterDto.Quantity is { } quantity)
                query = query.Where(m => m.Quantity == quantity);

            if (filterDto.ReorderLevel is { } reorderLevel)
                query = query.Where(m => m.ReorderLevel == reorderLevel);

            if (filterDto.Price is { } price)
                query = query.Where(m => m.Price == price);

            if (filterDto.Status is { } status)
            {
                if (status == Domain.Enums.MaterialStatus.Available)
                    query = query.Where(m => m.Quantity > m.ReorderLevel);
                else if (status == Domain.Enums.MaterialStatus.LowStock)
                    query = query.Where(m => m.Quantity <= m.ReorderLevel && m.Quantity > 0);
                else if (status == Domain.Enums.MaterialStatus.OutOfStock)
                    query = query.Where(m => m.Quantity == 0);
            }
        }

        return query.Select(m => new MaterialFilterDto
        {
            Id = m.Id.Value,
            Name = m.Name,
            Quantity = m.Quantity,
            ReorderLevel = m.ReorderLevel,
            Price = m.Price,
            Status = m.Status
        }).ToListAsync(cancellationToken);
    }
}