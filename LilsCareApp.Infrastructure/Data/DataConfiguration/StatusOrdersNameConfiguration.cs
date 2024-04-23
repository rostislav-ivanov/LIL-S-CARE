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
            },
            new ()
            {
                Id = 2,
                NameEN = "Canceled",
                NameBG = "Отменена",
                NameRO = "Anulat",
            },
            new ()
            {
                Id = 3,
                NameEN = "Fulfilled",
                NameBG = "Изпълнена",
                NameRO = "Îndeplinit",
            },
            new ()
            {
                Id = 4,
                NameEN = "Received",
                NameBG = "Получена",
                NameRO = "Primit",
            },
            new ()
            {
                Id = 5,
                NameEN = "Returned",
                NameBG = "Върната",
                NameRO = "Returnat",
            },
        ];

        public void Configure(EntityTypeBuilder<StatusOrderName> builder)
        {
            builder.HasData(statusOrderNames);
        }
    }
}
