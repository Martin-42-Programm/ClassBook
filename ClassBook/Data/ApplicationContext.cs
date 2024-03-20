using System;

namespace ClassBook.Data
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Absence> Absences { get; set; }

        public DbSet<Subject> Subjects { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
    }
}

