using System;
using System.Text;
using Autofac;
using EfCoreTask.Data;
using EfCoreTask.Data.Model;
using EfCoreTask.Data.Repositories;
using EfCoreTask.Services;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTask
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Starting application...");
            Container = BuildContainer();

            Console.WriteLine("Creating database...");
            var dbManager = Container.Resolve<IDbManager>();
            dbManager.ReCreate();

            var teamService = Container.Resolve<ITeamService>();
            var teamMemberService = Container.Resolve<ITeamMemberService>();
            bool canContinue = true;
            ShowMenu();
            while (canContinue)
            {
                var option = Console.ReadLine();
                if (!int.TryParse(option, out int optionValue))
                {
                    Console.WriteLine("Nieznana operacja.");
                    continue;
                }

                switch (optionValue)
                {
                    case 1:
                        teamMemberService.Add();
                        break;
                    case 2:
                        teamService.Add();
                        break;
                    case 3:
                        teamMemberService.ShowAll();
                        break;
                    case 4:
                        teamService.ShowAll();
                        break;
                    case 5:
                        teamService.ShowAllWithDetails();
                        break;
                    case 6:
                        teamMemberService.Delete();
                        break;
                    case 7:
                        teamService.DeleteWithMembers();
                        break;
                    case 8:
                        teamService.Delete();
                        break;
                    case 9:
                        ShowMenu();
                        break;
                    case 10:
                        canContinue = false;
                        Console.WriteLine("Closing application...");
                        break;
                }
            }
        }

        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TeamDbContext>().As<DbContext>().WithParameter("isLoggerEnabled",false).InstancePerLifetimeScope(); //switch "isLoggerEnabled" to true if you want enable ef core console logger
            builder.RegisterType<DbManager>().As<IDbManager>();
            builder.RegisterType<TeamRepository>().As<IRepository<Team>>();
            builder.RegisterType<TeamMemberRepository>().As<IRepository<TeamMember>>();
            builder.RegisterType<TeamService>().As<ITeamService>();
            builder.RegisterType<TeamMemberService>().As<ITeamMemberService>();
            return builder.Build();
        }

        static void ShowMenu()
        {
            var stringBuilder = new StringBuilder()
                .AppendLine("1. Add team member.")
                .AppendLine("2. Add team.")
                .AppendLine("3. Show all team members.")
                .AppendLine("4. Show all teams.")
                .AppendLine("5. Show all teams with members.")
                .AppendLine("6. Remove team member.")
                .AppendLine("7. Remove team with all members.")
                .AppendLine("8. Remove team.")
                .AppendLine("9. Show menu.")
                .AppendLine("10. Close.");

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
