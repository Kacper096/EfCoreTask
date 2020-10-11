using System;
using System.Collections.Generic;
using System.Text;
using EfCoreTask.Data.Model;
using EfCoreTask.Data.Repositories;
using EfCoreTask.Utils;

namespace EfCoreTask.Services
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly IRepository<TeamMember> _teamMemberRepository;

        public TeamMemberService(IRepository<TeamMember> teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }

        public void Add()
        {
            ShowTitles();
            Console.WriteLine("Enter the necessary parameters to create a team member");
            var teamMember = new TeamMember()
            {
                FirstName = ConsoleUtil.GetFieldFromUser<string>(" FirstName: "),
                LastName = ConsoleUtil.GetFieldFromUser<string>(" LastName: "),
                Title = ConsoleUtil.GetFieldFromUser<TitleType>(" Title: "),
                TeamId = ConsoleUtil.GetFieldFromUser<Guid?>(" Team id: ")
            };

            _teamMemberRepository.Insert(teamMember);
            Console.WriteLine("Team member has been saved.\n");
        }

        public void Delete()
        {
            var teamMemberId = ConsoleUtil.GetFieldFromUser<Guid>("Enter team member id: ");
            if(teamMemberId == Guid.Empty)
                Console.WriteLine("Cannot delete");

            _teamMemberRepository.Delete(teamMemberId);
            Console.WriteLine("Team member has been deleted.\n");
        }

        public void ShowAll()
        {
            var stringBuilder = new StringBuilder();
            foreach (var teamMember in _teamMemberRepository.GetAll())
            {
                stringBuilder.AppendLine(teamMember.ToString());
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        private void ShowTitles()
        {
            var stringBuilder = new StringBuilder()
                .AppendLine("--- Titles ---")
                .AppendLine("0 - Developer")
                .AppendLine("1 - Scrum Master")
                .AppendLine("2 - Project Manager");
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
