using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentApi.Db.Entities;

namespace StudentApi.Db.Mapping
{
    public class GradeMap : IEntityTypeConfiguration<GradeEntity>
    {
        public void Configure(EntityTypeBuilder<GradeEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StudentId).IsRequired();
            builder.Property(x => x.SubjectId).IsRequired();
            builder.Property(x => x.Score).IsRequired();
        }
    }
}
