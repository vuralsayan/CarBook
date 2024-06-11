using CarBook.Domain.Entities;
using System.Linq.Expressions;

namespace CarBook.Application.Interfaces.AppRoleInterfaces
{
    public interface IAppRoleRepository
    {
        Task<AppRole> GetByFilterAsync(Expression<Func<AppRole, bool>> filter);

    }
}
