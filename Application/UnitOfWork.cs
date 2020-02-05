using Application.Registries;
using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FaxDbContext _faxDbContext;
        public ISubjectsRepository Subjects { get; private set; }
        public UserManager<User> Users { get; private set; }

        public UnitOfWork(FaxDbContext faxDbContext, UserManager<User> userManager, ISubjectsRepository subjectsRepository)
        {
            _faxDbContext = faxDbContext;
            Users = userManager;
            Subjects = subjectsRepository;
        }

        public void Complete()
        {
            _faxDbContext.SaveChanges();
        }

    }
}
