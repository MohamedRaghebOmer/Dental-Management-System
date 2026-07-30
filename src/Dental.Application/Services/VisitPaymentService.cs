using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.VisitPayment;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public sealed class VisitPaymentService
    : ServiceBase<VisitPayment, VisitPaymentResponseDto>
    , IVisitPaymentService
{
    private readonly IVisitPaymentRepository _repo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<VisitPaymentService> _logger;

    public VisitPaymentService(
        IVisitPaymentRepository repo, 
        IUnitOfWork unitOfWork, 
        ILogger<VisitPaymentService> logger) 
        : base(repo, unitOfWork, logger)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
}