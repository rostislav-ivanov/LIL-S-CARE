using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class PromoCodeNameConfiguration : IEntityTypeConfiguration<PromoCodeName>
    {
        private readonly IEnumerable<PromoCodeName> promoCodes =
        [
            new ()
            {
                Id = 1,
                NameEN = "-10 % for registration",
                NameBG = "-10 % за регистрация",
                NameRO = "-10 % pentru inregistrare",
                PromoCodeId = 1
            },
            new ()
            {
                Id = 2,
                NameEN = "-20 % discount",
                NameBG = "-20 % отстъпка",
                NameRO = "-20 % reducere",
                PromoCodeId = 2
            },
        ];
        public void Configure(EntityTypeBuilder<PromoCodeName> builder)
        {
            builder.HasData(promoCodes);
        }
    }
}