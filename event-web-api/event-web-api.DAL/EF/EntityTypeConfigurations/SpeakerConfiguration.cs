﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace event_web_api.DAL.EF.EntityTypeConfigurations
{
    public class SpeakerConfiguration : IEntityTypeConfiguration<Speaker>
    {
        public void Configure(EntityTypeBuilder<Speaker> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.FirstName).IsRequired();
            builder.Property(s => s.LastName).IsRequired();

            builder.HasMany(s => s.Events)
                   .WithOne(e => e.Speaker)
                   .HasForeignKey(e => e.SpeakerId);
        }
    }
}
