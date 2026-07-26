using Dental.Domain.Entities;
using Dental.Domain.Repositories.Views.LabTransactions;
using Dental.Domain.ValueObjects;
using Dental.Domain.Views.LabTransactions;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories.Views.LabTransactions;

public sealed class LabTransactionViewRepository : ILabTransactionViewRepository
{
    private readonly DentalDbContext _dbContext;

    public LabTransactionViewRepository(DentalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<LabTransactionFilterDto>> GetAsync(
        LabTransactionFilterDto? filterDto = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<LabTransaction> query = _dbContext.LabTransactions.AsNoTracking();

        if (filterDto is not null)
        {
            if (filterDto.Id.HasValue)
            {
                query = query.Where(lt => lt.Id == Id.FromDatabase(filterDto.Id.Value));
            }

            if (!string.IsNullOrEmpty(filterDto.LabName))
            {
                query = query.Where(lt => lt.LabName.Contains(filterDto.LabName.Trim()));
            }

            if (filterDto.TranDateTime.HasValue)
            {
                query = query.Where(lt => lt.TranDateTime.Date >= filterDto.TranDateTime.Value.Date
                && lt.TranDateTime.Date < filterDto.TranDateTime.Value.Date.AddDays(1));
            }
            else if (filterDto.GetAfter.HasValue)
            {
                var after = filterDto.GetAfter.Value.Date;
                query = query.Where(lt => lt.TranDateTime >= after);
            }

            if (filterDto.PaidAmount.HasValue)
            {
                query =
                    query.Where(lt => lt.PaidAmount == Money.FromDatabase(filterDto.PaidAmount.Value));
            }

            if (filterDto.TotalAmount.HasValue)
            {
                query = query.Where(lt => lt.TotalAmount == Money.FromDatabase(filterDto.TotalAmount.Value));
            }

            if (filterDto.RemainingAmount.HasValue)
            {
                decimal remainingAmount = filterDto.RemainingAmount.Value;

                query = query.Where(lt =>
                    lt.TotalAmount.Value - lt.PaidAmount.Value == remainingAmount);
            }

            if (!string.IsNullOrWhiteSpace(filterDto.Treatments))
            {
                query = query.Where(
                    lt => lt.Treatments != null
                    && lt.Treatments.Contains(filterDto.Treatments));
            }
        }

        return query.Select(ld => new LabTransactionFilterDto
        {
            Id = ld.Id.Value,
            LabName = ld.LabName,
            TranDateTime = ld.TranDateTime,
            PaidAmount = ld.PaidAmount.Value,
            TotalAmount = ld.TotalAmount.Value,
            RemainingAmount = ld.RemainingAmount,
            Treatments = ld.Treatments
        }).ToListAsync(cancellationToken);
    }
}