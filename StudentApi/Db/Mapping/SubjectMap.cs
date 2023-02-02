using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentApi.Db.Entities;

namespace StudentApi.Db.Mapping
{
    public class SubjectMap : IEntityTypeConfiguration<SubjectEntity>
    {
        public void Configure(EntityTypeBuilder<SubjectEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.SubjectName).IsRequired();
            builder.Property(t => t.Credits).HasMaxLength(11).IsRequired();
        }
    }
}
