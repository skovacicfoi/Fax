using Core.Faculties;
using Core.Interfaces;
using Core.Subjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class User : IdentityUser
    {
        //[MinLength(2)]
        //[Required]
        public string Name { get; set; }

        //[MinLength(2)]
        //[Required]
        public string LastName { get; set; }
        public int Semester { get; set; }
        public List<Schedule> Schedules { get; set; }

    }
}
