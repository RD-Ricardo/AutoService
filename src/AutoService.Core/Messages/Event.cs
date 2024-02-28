using MediatR;

namespace AutoService.Core.Messages
{
    public abstract class Event : Message, INotification
    {
    }
}
