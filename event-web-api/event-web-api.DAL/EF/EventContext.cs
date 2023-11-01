using event_web_api.DAL.EF.EntityTypeConfigurations;
using event_web_api.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace event_web_api.DAL.EF
{
    public class EventContext : DbContext
    {
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Event> Events { get; set; } 
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SpeakerConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
        }
    }
}
