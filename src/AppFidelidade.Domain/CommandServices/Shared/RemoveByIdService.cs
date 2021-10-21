using System;
using AppFidelidade.Core.CommandServices.Contracts;
using AppFidelidade.Core.Constants;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppFidelidade.Core.CommandServices.Shared
{
    public class RemoveByIdService : Notifiable, IValidator
    {
            
        public RemoveByIdService(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", GlobalMessageConstants.FieldInvalidOrNonExistent)
            );
        }
    }
}