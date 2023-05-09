using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CareConnect.Data.Models
{
    public class CareConnectContext : DbContext
    {
        public CareConnectContext(DbContextOptions<CareConnectContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=BlazorCrudDB;Trusted_Connection=true;TrustServerCertificate=true;");
        //}
        public DbSet<Client> Clients { get; set; }
        public DbSet<EntityAddress> EntityAddress { get; set; }
    }
}
