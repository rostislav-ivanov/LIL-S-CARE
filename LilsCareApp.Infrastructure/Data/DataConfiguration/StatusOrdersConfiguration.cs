using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class StatusOrdersConfiguration : IEntityTypeConfiguration<StatusOrder>
    {
        private readonly IEnumerable<StatusOrder> statusOrders = new List<StatusOrder>
{
            new StatusOrder { Id = 1, Name = "Заявена" },
            new StatusOrder { Id = 2, Name = "Отменена" },
            new StatusOrder { Id = 3, Name = "Изпратена" },
            new StatusOrder { Id = 4, Name = "Получена" },
        };

        public void Configure(EntityTypeBuilder<StatusOrder> builder)
        {
            builder.HasData(statusOrders);
        }
    }
}