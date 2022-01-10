using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkplaceManagement.Domain.Context;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.API
{
    public static class Seed
    {
        public static async Task SeedTestData(RepositoryContext context)
        {
            try
            {
                if (context.Sites.Any() == false)
                {
                    Site site = new Site()
                    {
                        Name = "Test Site"
                    };
                    await context.Sites.AddAsync(site);
                    await context.SaveChangesAsync();
                }

                if(context.Floors.Any() == false)
                {
                    Floor floor = new Floor()
                    {
                        Name = "Test Floor",
                        Site = context.Sites.FirstOrDefault(x => x.Name == "Test Site")
                    };
                    await context.Floors.AddAsync(floor);
                    await context.SaveChangesAsync();
                }

                if(context.Workplaces.Any() == false)
                {
                    Workplace workplace = new Workplace()
                    {
                        Name = "Test Workplace",
                        Floor = context.Floors.FirstOrDefault(x => x.Name == "Test Floor")
                    };
                    await context.Workplaces.AddAsync(workplace);
                    await context.SaveChangesAsync();
                }

                if (context.Employees.Any() == false)
                {
                    Employee employee = new Employee()
                    {
                        FirstName = "FirstName",
                        LastName = "LastName",
                        Email = "FirstName.LastName@email.email"
                    };
                    await context.Employees.AddAsync(employee);
                    await context.SaveChangesAsync();
                }
                
                if (context.Reservations.Any() == false)
                {
                    Reservation reservation = new Reservation()
                    {
                        StartTimestamp = DateTime.Now.AddSeconds(1),
                        EndTimestamp = DateTime.Now.AddDays(1),

                        Workplace = context.Workplaces.FirstOrDefault(x => x.Name == "Test Workplace"),
                        Employee = context.Employees.FirstOrDefault(x => x.Email == "FirstName.LastName@email.email")
                    };
                    await context.Reservations.AddAsync(reservation);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
