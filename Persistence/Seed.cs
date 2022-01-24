using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Applications.Any()) return;

            var aplications = new List<Application>
            {
                new Application
                {
                    Url = "https://blog.counter-strike.net/",
                    PathLocal = @"C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive",
                    DebuggingMode = true,

                },
                new Application
                {
                   Url = "https://www.docker.com/",
                    PathLocal = @"C:\Program Files\Docker",
                    DebuggingMode = false,
                },
                 new Application
                {
                    Id = Guid.Parse("0E2A8CB4-6BF2-4C0E-1B35-08D9DCD754F0"),
                    Url = "https://www.WinRAR.com/",
                    PathLocal = @"C:\Program Files\WinRAR",
                    DebuggingMode = false,
                }
            };

            await context.Applications.AddRangeAsync(aplications);
            await context.SaveChangesAsync();
        }
    }
}