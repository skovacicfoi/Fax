using Core;
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
        public UserManager<User> Users { get; private set; }

        public UnitOfWork(FaxDbContext faxDbContext, UserManager<User> userManager)
        {
            _faxDbContext = faxDbContext;
            Users = userManager;
        }

        public void Complete()
        {
            _faxDbContext.SaveChanges();
        }

    }
}
