using EfCoreTask.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTask.Data.Repositories
{
    public class TeamMemberRepository : BaseRepository<TeamMember>
    {
        public TeamMemberRepository(DbContext context) : base(context)
        {
        }
    }
}
