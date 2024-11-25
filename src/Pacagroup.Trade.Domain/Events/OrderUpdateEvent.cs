
using Pacagroup.Trade.Domain.Commons;
using Pacagroup.Trade.Domain.Enums;

namespace Pacagroup.Trade.Domain.Events;

public class OrderUpdateEvent:BaseEvent
{
    public int Id { get; set; }
    public int Quanty { get; set; }
    public OrderType Type { get; set; }
    public decimal Price { get; set; }

    public string Currency { get; set; }
    public string? Text { get; set; }
}

