using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorCenter.Entities.EntityConfiguration
{
    public class EnvironmentConfiguration : IEntityTypeConfiguration<Environment>
    {
        public void Configure(EntityTypeBuilder<Environment> builder)
        {
            builder.ToTable("Environment");
            builder.HasKey(x => x.EnvironmentId);

            builder.Property(x => x.EnvironmentId)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.HasMany(x => x.Errors)
                .WithOne(x => x.Environment)
                .HasForeignKey(x => x.EnvironmentId)
                .HasPrincipalKey(x => x.EnvironmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}