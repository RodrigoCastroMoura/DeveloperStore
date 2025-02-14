
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetProductHandler : IRequestHandler<GetProductCommand, GetProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetProductResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<GetProductResult>(product);
    }
}
