using MediatR;
using ProjectManager.CMD.Domain.DomainObjects;

namespace ProjectManager.CMD.Domain.DomainEvents.RequestRegistDomainEvent
{
    public class RequestRegistCreatedDomainEvent : INotification
    {
        public RequestRegistCreatedDomainEvent(RequestRegist _RequestRegist)
        {
            RequestRegist = _RequestRegist;
        }
        public RequestRegist RequestRegist { get; }
    }
}
