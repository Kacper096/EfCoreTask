using EfCoreTask.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTask.Data.Repositories
{
    public class TeamRepository : BaseRepository<Team>
    {
        public TeamRepository(DbContext context) : base(context)
        {
        }
    }
}
