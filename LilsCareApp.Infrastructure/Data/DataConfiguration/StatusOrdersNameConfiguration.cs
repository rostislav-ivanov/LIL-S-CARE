using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class StatusOrdersNameConfiguration : IEntityTypeConfiguration<StatusOrderName>
    {
        private readonly IEnumerable<StatusOrderName> statusOrderNames =
        [
            new ()
            {
                Id = 1,
                NameEN = "Unfulfilled",
                NameBG = "Неизпълнена",
                NameRO = "Neîndeplinită",
                StatusOrderId = 1,
            },
            new ()
            {
                Id = 2,
                NameEN = "Canceled",
                NameBG = "Отменена",
                NameRO = "Anulat",
                StatusOrderId = 2,
            },
            new ()
            {
                Id = 3,
                NameEN = "Fulfilled",
                NameBG = "Изпълнена",
                NameRO = "Îndeplinit",
                StatusOrderId = 3,
            },
            new ()
            {
                Id = 4,
                NameEN = "Received",
                NameBG = "Получена",
                NameRO = "Primit",
                StatusOrderId = 4,
            },
            new ()
            {
                Id = 5,
                NameEN = "Returned",
                NameBG = "Върната",
                NameRO = "Returnat",
                StatusOrderId = 5,
            },
        ];

        public void Configure(EntityTypeBuilder<StatusOrderName> builder)
        {
            builder.HasData(statusOrderNames);
        }
    }
}
