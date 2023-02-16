using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentApi.Db.Entities;

namespace StudentApi.Db.Mapping
{
    public class StudentMap : IEntityTypeConfiguration<StudentEntity>
    {
        public void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.StudentName).IsRequired();
            builder.Property(t => t.IdNumber).HasMaxLength(11).IsRequired();
            builder.Property(t => t.StudentLastName).IsRequired();
            builder.Property(t => t.Course).IsRequired();
            builder.Property(t => t.StudentGPA).IsRequired();
        }
    }
}
