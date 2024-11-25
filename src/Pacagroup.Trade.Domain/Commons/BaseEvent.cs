
namespace Pacagroup.Trade.Domain.Commons;

public abstract class BaseEvent
{
    public Guid MessegeId { get; set; }

    public DateTime PublishTime { get; set; }
}

