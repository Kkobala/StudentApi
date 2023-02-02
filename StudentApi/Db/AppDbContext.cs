using Microsoft.EntityFrameworkCore;
using StudentApi.Db.Entities;
using StudentApi.Db.Mapping;

namespace StudentApi.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<StudentEntity> studentEntities { get; set; }
        public DbSet<SubjectEntity> subjectEntities { get; set; }
        public DbSet<GradeEntity> gradeEntities { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StudentMap());
            builder.ApplyConfiguration(new SubjectMap());
            builder.ApplyConfiguration(new GradeMap());

            base.OnModelCreating(builder);
        }
    }
}
