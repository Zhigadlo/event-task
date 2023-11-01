using event_web_api.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace event_web_api.DAL.EF.EntityTypeConfigurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Place).IsRequired();
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.Theme).IsRequired();

            builder.HasOne(e => e.Speaker)
                   .WithMany(s => s.Events)
                   .HasForeignKey(e => e.SpeakerId);
        }
    }
}
