using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class StatusOrdersConfiguration : IEntityTypeConfiguration<StatusOrder>
    {
        private readonly IEnumerable<StatusOrder> statusOrders =
        [
            new () { Id = 1, Name = "Неизпълнена" },
            new () { Id = 2, Name = "Отменена" },
            new () { Id = 3, Name = "Изпълнена" },
            new () { Id = 4, Name = "Получена" },
            new () { Id = 5, Name = "Върната" },
        ];

        public void Configure(EntityTypeBuilder<StatusOrder> builder)
        {
            builder.HasData(statusOrders);
        }
    }
}