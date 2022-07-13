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
                new Member { MemberId = 1, FullName = "Chase Switzer" },
                new Member { MemberId = 2, FullName = "John Taylor" },
                new Member { MemberId = 3, FullName = "Angie Smith" },
                new Member { MemberId = 4, FullName = "Maria Garcia" },
                new Member { MemberId = 5, FullName = "David Jones" },
                new Member { MemberId = 6, FullName = "Mary Smith" },
                new Member { MemberId = 7, FullName = "Bruce Lee" },
                new Member { MemberId = 8, FullName = "James Johnson" },
                new Member { MemberId = 9, FullName = "Sam Richter" },
                new Member { MemberId = 10, FullName = "Nancy Chen" },
                new Member { MemberId = 11, FullName = "Paul Henry" },
            };

            foreach(Member m in members)
            {
                context.Member.Add(m);
            }

            context.SaveChanges();
        }
    }
}
