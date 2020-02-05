using Application.Registries;
using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application
{
    public interface IUnitOfWork
    {
        UserManager<User> Users { get; }
        ISubjectsRepository Subjects { get; }
        void Complete();
    }
}