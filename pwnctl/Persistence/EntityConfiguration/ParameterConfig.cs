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
    public class ParameterConfig : IEntityTypeConfiguration<Parameter>
    {
        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Endpoint)
                .WithMany()
                .HasForeignKey(p => p.EndpointId);

            builder.HasOne(p => p.Request)
                .WithMany()
                .HasForeignKey(p => p.RequestId);
        }
    }
}
