using Sat.Recruitment.Api.Repositories;

namespace Sat.Recruitment.Api.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
    }
}
