using Dental.Domain.Views.LabTransactions;

namespace Dental.Domain.Repositories.Views.LabTransactions;

public interface ILabTransactionViewRepository
{
    Task<List<LabTransactionFilterDto>> GetAsync(
        LabTransactionFilterDto? filterDto = null,
        CancellationToken cancellationToken = default);
}