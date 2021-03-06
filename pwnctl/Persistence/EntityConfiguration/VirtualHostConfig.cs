using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pwnctl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pwnctl.Persistence.EntityConfiguration
{
    public class VirtualHostConfig : IEntityTypeConfiguration<VirtualHost>
    {
        public void Configure(EntityTypeBuilder<VirtualHost> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Service)
                .WithMany()
                .HasForeignKey(e => e.ServiceId);
        }
    }
    
}
