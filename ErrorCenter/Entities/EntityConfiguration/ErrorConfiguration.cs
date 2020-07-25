using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorCenter.Entities.EntityConfiguration
{
    public class ErrorConfiguration : IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> builder)
        {

            builder.ToTable("Error");

            builder.HasKey(x => x.ErrorId);

            builder.Property(x => x.ErrorId)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnType("datetime");

            builder.Property(x => x.Origin)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Details)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.EventId)
                 .IsRequired();
            
            builder.Property(x => x.EnvironmentId)
                .IsRequired();
            
            builder.Property(x => x.LevelId)
                .IsRequired();

            builder.HasOne<Environment>(x => x.Environment)
                .WithMany(x => x.Errors)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            builder.HasOne<Level>(x => x.Level)
                .WithMany(x => x.Errors)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}