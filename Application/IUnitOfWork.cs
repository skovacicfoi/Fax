using Core;
using Microsoft.AspNetCore.Identity;

namespace Application
{
    public interface IUnitOfWork
    {
        UserManager<User> Users { get; }
        void Complete();
    }
}