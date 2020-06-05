using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Customer: IdentityUser
    {
        public string NameSurname { get; set; }
        public string Adress { get; set; }
        public Gender Gender { get; set; }      
    }
}
