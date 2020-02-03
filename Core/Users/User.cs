using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace Core
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Semester { get; set; }
    }
}
