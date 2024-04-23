using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class StatusOrdersConfiguration : IEntityTypeConfiguration<StatusOrder>
    {
        private readonly IEnumerable<StatusOrder> statusOrders =
        [
            new () { Id = 1, NameId = 1 },
            new () { Id = 2, NameId = 2 },
            new () { Id = 3, NameId = 3 },
            new () { Id = 4, NameId = 4 },
            new () { Id = 5, NameId = 5 },
        ];

        public void Configure(EntityTypeBuilder<StatusOrder> builder)
        {
            builder.HasData(statusOrders);
        }
    }
}