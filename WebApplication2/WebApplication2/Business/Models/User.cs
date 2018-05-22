using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Business.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Role[] Roles { get; set; }
    }
}