using ErrorCenter.Entities;
using System.Linq;

namespace ErrorCenter.Helpers
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Levels.Any() || !context.Environments.Any())
            {
                var levels = new Level[]
                {
                    new Level
                    {
                        Name = "Info"
                    },
                    new Level
                    {
                        Name = "Warning"
                    },
                    new Level
                    {
                        Name = "Error"
                    }
                };

                foreach (var lvls in levels)
                {
                    context.Levels.Add(lvls);
                }

                context.SaveChanges();

                var environments = new Environment[]
                {
                    new Environment
                    {
                        Name = "Development",
                    },
                    new Environment
                    {
                        Name = "Homologation",
                    },
                    new Environment
                    {
                        Name = "Production",
                    },
                };

                foreach (var envs in environments)
                {
                    context.Environments.Add(envs);
                }

                context.SaveChanges();
            }
        }
    }
}