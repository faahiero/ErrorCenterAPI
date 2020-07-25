using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorCenter.Entities.EntityConfiguration
{
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.ToTable("Level");
            builder.HasKey(x => x.LevelId);

            builder.Property(x => x.LevelId)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.HasMany(x => x.Errors)
                .WithOne(x => x.Level)
                .HasForeignKey(x => x.LevelId)
                .HasPrincipalKey(x => x.LevelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}


