using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlannerServer.Models;

namespace SacramentMeetingPlannerServer.Data
{
    public class SacramentMeetingPlannerServerContext : DbContext
    {
        public SacramentMeetingPlannerServerContext (DbContextOptions<SacramentMeetingPlannerServerContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentMeetingPlan>? SacramentMeetingPlan { get; set; }
        public DbSet<Hymn> Hymn { get; set; }
        public DbSet<Speaker> Speaker { get; set; }
        public DbSet<Member> Member { get; set; }

        // credit to https://stackoverflow.com/questions/34768976/specifying-on-delete-no-action-in-entity-framework-7
        // this prevents entities in other tables from being deleted when entities are deleted
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }

    }
}
