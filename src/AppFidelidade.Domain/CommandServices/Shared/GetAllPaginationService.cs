using AppFidelidade.Core.CommandServices.Contracts;
using AppFidelidade.Core.Constants;
using AppFidelidade.Core.Dto.InputModelDto;
using AppFidelidade.Core.Pagination;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppFidelidade.Core.CommandServices.Shared
{
    public class GetAllPaginationService: Notifiable, IValidator
    {
        public GetAllPaginationService(PaginationParameters paginationParameters)
        {
            PaginationParameters = paginationParameters;
        }

        public PaginationParameters PaginationParameters { get; set;}
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsFalse(PaginationParameters.PageNumber <= 0, "PageNumber", GlobalMessageConstants.FieldInvalidOrNonExistent)
                    .IsFalse(PaginationParameters.PageSize <= 0, "PageSize", GlobalMessageConstants.FieldInvalidOrNonExistent)
                    .IsFalse(PaginationParameters.PageSize > 1000, "PageSize", GlobalMessageConstants.FieldInvalidOrNonExistent)
            );
        }
    }
}