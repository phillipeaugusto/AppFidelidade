using AppFidelidade.Domain.CommandServices.Contracts;
using AppFidelidade.Domain.Constants;
using AppFidelidade.Domain.Pagination;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppFidelidade.Domain.CommandServices.Shared;

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