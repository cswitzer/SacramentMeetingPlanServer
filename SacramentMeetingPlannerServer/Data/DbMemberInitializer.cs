using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SacramentMeetingPlannerServer.Models;
using SacramentMeetingPlannerServer.Data;

namespace SacramentMeetingPlannerServer.Data
{
    public class DbMemberInitializer
    {
        public static void Initialize(SacramentMeetingPlannerServerContext context)
        {
            if (context.Member.Any())
            {
                return;
            }

            var members = new Member[]
            {
                new Member { FullName = "Chase Switzer" },
                new Member { FullName = "John Taylor" },
                new Member { FullName = "Angie Smith" },
                new Member { FullName = "Maria Garcia" },
                new Member { FullName = "David Jones" },
                new Member { FullName = "Mary Smith" },
                new Member { FullName = "Bruce Lee" },
                new Member { FullName = "James Johnson" },
                new Member { FullName = "Sam Richter" },
                new Member { FullName = "Nancy Chen" },
                new Member { FullName = "Paul Henry" },
            };

            foreach(Member m in members)
            {
                context.Member.Add(m);
            }

            context.SaveChanges();
        }
    }
}
