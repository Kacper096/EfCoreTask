namespace EfCoreTask.Services
{
    public interface ITeamService
    {
        void Add();
        void ShowAll();
        void ShowAllWithDetails();
        void Delete();
        void DeleteWithMembers();
    }
}