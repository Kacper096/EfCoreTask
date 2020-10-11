using System;
using System.Linq;
using EfCoreTask.Data.Model;
using EfCoreTask.Data.Repositories;
using EfCoreTask.Utils;

namespace EfCoreTask.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> _teamRepository;
        private readonly IRepository<TeamMember> _teamMemberRepository;
        public TeamService(IRepository<Team> teamRepository, IRepository<TeamMember> teamMemberRepository)
        {
            _teamRepository = teamRepository;
            _teamMemberRepository = teamMemberRepository;
        }

        public void Add()
        {
            Console.WriteLine("Enter the necessary parameters to create a team");
            var team = new Team()
            {
                Name = ConsoleUtil.GetFieldFromUser<string>(" Name: ")
            };

            _teamRepository.Insert(team);
            Console.WriteLine("Team has been saved.\n");
        }
        
        public void ShowAll()
        {
            foreach (var team in _teamRepository.GetAll())
            {
                Console.WriteLine(team.ToString());
            }
        }

        public void ShowAllWithDetails()
        {
            foreach (var team in _teamRepository.GetAll())      //n+1 problem
            {
                Console.WriteLine(team.ToString());
                Console.WriteLine(" Members: ");
                foreach (var teamMember in team.Members)
                {
                    Console.WriteLine($"  Id: {teamMember.Id}, FirstName: {teamMember.FirstName}, LastName: {teamMember.LastName}");
                }
            }
        }

        public void Delete()
        {
            var teamId = ConsoleUtil.GetFieldFromUser<Guid>("Enter team id: ");

            if(teamId == Guid.Empty)
                Console.WriteLine("Cannot delete team.");

            _teamRepository.Delete(teamId);
            Console.WriteLine("Team has been deleted.\n");
        }

        public void DeleteWithMembers()
        {
            var teamId = ConsoleUtil.GetFieldFromUser<Guid>("Enter team id: ");

            if(teamId == Guid.Empty)
                Console.WriteLine("Cannot delete team.");

            var team = _teamRepository.Get(t => t.Id == teamId).First();
            foreach (var teamMembers in team.Members)
            {
                _teamMemberRepository.Delete(teamMembers.Id);
            }

            _teamRepository.Delete(team.Id);
            Console.WriteLine("Team with members has been deleted.\n");
        }
    }
}
