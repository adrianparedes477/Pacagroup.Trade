
using AutoMapper;
using Grpc.Core;
using MediatR;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Commands.CancelOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Commands.CreateOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Commands.UpdateOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetAllOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetOrder;
using Pacagroup.Trade.Services.gRPC.Protos;
namespace Pacagroup.Trade.Services.gRPC.Services;



public class OrderService:Order.OrderBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public OrderService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public override async Task<GetAllOrderResponse> GetAllOrder(GetAllOrderRequest request, ServerCallContext context)
    {
        var orderDto = await _mediator.Send(new GetAllOrderQuery());
        var response = new GetAllOrderResponse();
        var serverResponse = new ServerResponse();

        if(orderDto.Any())
        {
            serverResponse.IsSuccess = true;
            serverResponse.Message = "Consulta Exitosa!!!";

            response.Data.AddRange(_mapper.Map<IEnumerable<OrderResponse>>(orderDto));
        }
        else
            serverResponse.Message = "No se encontraron Ordernes!!!";
        response.ServerResponse = serverResponse;

        return response;
    }

    public override async Task<GetOrderResponse> GetOrder(GetOrderRequest request, ServerCallContext context)
    {
        var orderDto = await _mediator.Send(new GetOrderQuery() { Id = request.Id });
        var response = new GetOrderResponse();
        var serverResponse = new ServerResponse();

        if (orderDto is null)
        {
            serverResponse.Message = $"No se encontro la Order # {request.Id}";
            return response;
        }

        response.Data = _mapper.Map<OrderResponse>(orderDto);
        serverResponse .IsSuccess = true;
        serverResponse.Message = "Consulta Exitosa!!!";

        response.ServerResponse = serverResponse;

        return response;
    }

    public override async Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request, ServerCallContext context)
    {
        var CreateOrderCommand = _mapper.Map<CreateOrderCommand>(request);
        var status = await _mediator.Send(CreateOrderCommand);
        var response = new CreateOrderResponse();
        var serverResponse = new ServerResponse();

        if (status.Equals(true))
        {
            var orderDto = await _mediator.Send(new GetOrderQuery() { Id = request.Id });
            response.Data = _mapper.Map<OrderResponse>(orderDto);
            serverResponse.IsSuccess = true;
            serverResponse.Message = "Registro Existoso!!!";
        }
        else
            serverResponse.Message  = $"Errores al crear la Order # { request.Id }";

        response.ServerResponse = serverResponse;
        return response;
    }

    public override async Task<UpdateOrderResponse> UpdateOrder(UpdateOrderRequest request, ServerCallContext context)
    {
        var updateOrderCommand = _mapper.Map<UpdateOrderCommand>(request);
        var status = await _mediator.Send(updateOrderCommand);
        var response = new UpdateOrderResponse();
        var serverResponse = new ServerResponse();

        if (status.Equals(true))
        {
            var orderDto = await _mediator.Send(new GetOrderQuery() { Id = request.Id });

            response.Data = _mapper.Map<OrderResponse>(orderDto);
            serverResponse.IsSuccess = true;
            serverResponse.Message = "Actualizacion Exitosa!!!";
        }
        else
            serverResponse.Message = $"Error al actulizar la Order #: {request.Id}";

        response.ServerResponse = serverResponse;
        return response;
    }

    public override async Task<CancelOrderResponse> CancelOrder(CancelOrderRequest request, ServerCallContext context)
    {
        var status = await _mediator.Send(new CancelOrderCommand() { Id = request.Id });
        var response = new CancelOrderResponse();
        var serverResponse = new ServerResponse();

        if (status.Equals(true))
        {
            serverResponse.IsSuccess= true;
            serverResponse.Message = "Eliminacion Exitosa!!!";
        }
        else
            serverResponse.Message =$"Errores al eliminar la Orden #: {request.Id}";
        response.ServerResponse = serverResponse;

        return response;
    }
}

