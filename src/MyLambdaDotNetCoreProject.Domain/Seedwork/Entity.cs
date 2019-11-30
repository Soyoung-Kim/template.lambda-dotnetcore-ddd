using MediatR;
using System;
using System.Collections.Generic;


namespace MyLambdaDotNetCoreProject.Domain.Seedwork
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid().ToString();
        }

        protected Entity(string id)
        {
            Id = id;
        }

        public string Id { get; protected set; }


        private List<INotification> _domainEvents = new List<INotification>();
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(INotification eventItem) => _domainEvents.Add(eventItem);

        public void RemoveDomainEvent(INotification eventItem) => _domainEvents.Remove(eventItem);
        public void ClearDomainEvents() => this._domainEvents.Clear();

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => "Id: " + Id;

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            Entity entity = (Entity)obj;

            return entity.Id == this.Id;
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (object.Equals(left, null))
            {
                return object.Equals(right, null);
            }
            else
            {
                return left.Equals(right);
            }
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
