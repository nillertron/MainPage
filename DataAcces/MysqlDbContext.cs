using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcces
{
    public class MysqlDbContext:DbContext
    {
        public MysqlDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<MS_Competence> MS_Competence { get; set; }
        public DbSet<MS_Portfolio> MS_Portfolio { get; set; }
        public DbSet<MS_Picture> MS_Picture { get; set; }
        public DbSet<MS_JobMessage> MS_JobMessages { get; set; }
        public DbSet<MS_FreeLanceMessage> MS_FreelanceMessages { get; set; }
        public DbSet<MS_User> MS_User { get; set; }
        public DbSet<MS_Message> MS_Messages { get; set; }

    }
}
