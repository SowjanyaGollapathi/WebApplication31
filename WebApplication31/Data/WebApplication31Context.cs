using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication31.Models;

namespace WebApplication31.Data
{
    public class WebApplication31Context : DbContext
    {
        public WebApplication31Context (DbContextOptions<WebApplication31Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication31.Models.Shopping> Shopping { get; set; }
    }
}
