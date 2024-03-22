using System;

namespace ClassBook.Data
{
    public class ApplicationContext : IdentityDbContext<User>
	{
		public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Class> Classes { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
    }
}

