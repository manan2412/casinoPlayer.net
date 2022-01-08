using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Models
{
    public class AuditContext:DbContext
    {
        public AuditContext(DbContextOptions<AuditContext> options) : base(options)
        {

        }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<AuditType> AuditTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audit>().HasData(
                new Audit
                {
                    AuditId = 1,
                    PlayerName = "Manan",
                    CreatedDate = DateTime.Now,
                    Amount = 1000.00,
                    AuditTypeId = 1

                },
                 new Audit
                 {
                     AuditId = 2,
                     PlayerName = "Kosha",
                     CreatedDate = DateTime.Now,
                     Amount = 9000.00,
                     AuditTypeId = 2
                 });
            modelBuilder.Entity<AuditType>().HasData(
                new AuditType
                {
                    AuditTypeId = 1,
                    Name = "Cash-In"
                },
                new AuditType
                {
                    AuditTypeId = 2,
                    Name = "Cash-Out"
                },
                new AuditType
                {
                    AuditTypeId = 3,
                    Name = "Win"

                },
                new AuditType
                {
                    AuditTypeId = 4,
                    Name = "Lose"
                });
        

            
        }

        
    }
}
