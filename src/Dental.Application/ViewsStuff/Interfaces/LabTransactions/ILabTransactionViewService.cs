using Dental.Domain.Views.LabTransactions;

namespace Dental.Application.ViewsStuff.Interfaces.LabTransactions;

public interface ILabTransactionViewService
{
    Task<List<LabTransactionFilterDto>> GetAsync(
        LabTransactionFilterDto? filterDto = null,
        CancellationToken cancellationToken = default);
}