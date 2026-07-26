using Dental.Application.ViewsStuff.Interfaces.LabTransactions;
using Dental.Domain.Repositories.Views.LabTransactions;
using Dental.Domain.Views.LabTransactions;

namespace Dental.Application.ViewsStuff.Services.LabTransaction;

public sealed class LabTransactionViewService : ILabTransactionViewService
{
    private readonly ILabTransactionViewRepository _repo;

    public LabTransactionViewService(ILabTransactionViewRepository repo)
    {
        _repo = repo;
    }

    public Task<List<LabTransactionFilterDto>> GetAsync(
        LabTransactionFilterDto? filterDto = null,
        CancellationToken cancellationToken = default)
    {
        return _repo.GetAsync(filterDto, cancellationToken);
    }
}