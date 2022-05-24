using System.Threading.Tasks;
using AppFidelidade.Domain.CommandServices.Contracts;
using AppFidelidade.Domain.Shared.Contracts;

namespace AppFidelidade.Application.Services.Contracts;

public partial interface IService<in T> where T : IValidator
{
    Task<IResult> Service(T action);
}