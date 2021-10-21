using System.Threading.Tasks;
using AppFidelidade.Core.CommandServices.Contracts;
using AppFidelidade.Core.Shared.Contracts;

namespace AppFidelidade.Application.Services.Contracts
{
    public partial interface IService<in T> where T : IValidator
    {
        Task<IResult> Service(T action);
    }
}