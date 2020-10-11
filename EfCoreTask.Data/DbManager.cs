using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTask.Data
{
    public class DbManager : IDbManager
    {
        private readonly DbContext _context;

        public DbManager(DbContext context)
        {
            _context = context;
        }

        public void CreateIfNotExsits()
        {
            if (File.Exists("team.db"))
                return;

            _context.Database.Migrate();
        }

        public void ReCreate()
        {
            if(File.Exists("team.db"))
                File.Delete("team.db");
            _context.Database.Migrate();
        }

        public void DisableLazyLoading()
        {
            _context.ChangeTracker.LazyLoadingEnabled = false;
        }

        public void EnableLazyLoading()
        {
            _context.ChangeTracker.LazyLoadingEnabled = true;
        }
    }
}
