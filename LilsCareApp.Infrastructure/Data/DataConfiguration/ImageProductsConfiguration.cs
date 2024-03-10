using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class ImageProductsConfiguration : IEntityTypeConfiguration<ImageProduct>
    {
        private readonly IEnumerable<ImageProduct> images = new List<ImageProduct>()
        {
                new ImageProduct
                {
                    Id = 1,
                    ProductId = 1,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_24a7b0d7f63d42048f5a05e97362f385~mv2.jpg/v1/fill/w_301,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_24a7b0d7f63d42048f5a05e97362f385~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 2,
                    ProductId = 1,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_263e877cdb774516bea29e2155049a0d~mv2.jpg/v1/fill/w_301,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_263e877cdb774516bea29e2155049a0d~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 3,
                    ProductId = 1,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_69a0f0f6f1cf4847983b2248749af6cc~mv2.jpg/v1/fill/w_301,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_69a0f0f6f1cf4847983b2248749af6cc~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 4,
                    ProductId = 1,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_57415abd6b2b4d1f86e4ed35cf155e0d~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_57415abd6b2b4d1f86e4ed35cf155e0d~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 5,
                    ProductId = 1,
                    ImagePath = "https://video.wixstatic.com/video/a6694c_b61f40bc476a43578be260fce9fa6efa/1080p/mp4/file.mp4"
                },
                new ImageProduct
                {
                    Id = 6,
                    ProductId = 2,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_75d8524a8fb046db82d0090671364c15~mv2.jpg/v1/fill/w_886,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_75d8524a8fb046db82d0090671364c15~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 7,
                    ProductId = 2,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_2f611f06e55346e5b3b22c94c0bb8077~mv2.jpg/v1/fill/w_887,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_2f611f06e55346e5b3b22c94c0bb8077~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 8,
                    ProductId = 2,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_1b60760d6a9e46f6ba0be663ab0cd432~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_1b60760d6a9e46f6ba0be663ab0cd432~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 9,
                    ProductId = 2,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_7ce163b0f3e4461d9ee3ef5c16b972f4~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_7ce163b0f3e4461d9ee3ef5c16b972f4~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 10,
                    ProductId = 2,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_8cf53b5caa60466b86d7e1e71035a5c1~mv2.jpg/v1/fill/w_886,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_8cf53b5caa60466b86d7e1e71035a5c1~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 11,
                    ProductId = 2,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_dbfcc272e90a48f89dfa6930ee2b0355~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_dbfcc272e90a48f89dfa6930ee2b0355~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 12,
                    ProductId = 2,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_44172c09d7974734aed4b4fa6474bac2~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_44172c09d7974734aed4b4fa6474bac2~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 13,
                    ProductId = 2,
                    ImagePath = "https://video.wixstatic.com/video/a6694c_688be81645b14d1f9707a985aad784fb/1080p/mp4/file.mp4"
                },
                new ImageProduct
                {
                    Id = 14,
                    ProductId = 3,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_40945dc6b1754f74ab2b9331a5d4c692~mv2.jpg/v1/fill/w_887,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_40945dc6b1754f74ab2b9331a5d4c692~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 15,
                    ProductId = 3,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_dcb7369410054c2b8ffc9fa2f7a7854c~mv2.jpg/v1/fill/w_374,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_dcb7369410054c2b8ffc9fa2f7a7854c~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 16,
                    ProductId = 3,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_5e4516f6b7294324b75d8577ed3b7112~mv2.jpg/v1/fill/w_374,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_5e4516f6b7294324b75d8577ed3b7112~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 17,
                    ProductId = 3,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_955cfb52005d4979a9d170045f3bf603~mv2.jpg/v1/fill/w_374,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_955cfb52005d4979a9d170045f3bf603~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 18,
                    ProductId = 3,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_22c2642fbcb14b9c83a1b7b5349cb654~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_22c2642fbcb14b9c83a1b7b5349cb654~mv2.png"
                },
                new ImageProduct
                {
                    Id = 19,
                    ProductId = 4,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_9feeef67f1174acb9d05de346a5380f3~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_9feeef67f1174acb9d05de346a5380f3~mv2.png"
                },
                new ImageProduct
                {
                    Id = 20,
                    ProductId = 4,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_331b7666ec214d1cb9eab348b23156e6~mv2.png/v1/fill/w_832,h_665,al_c,usm_0.66_1.00_0.01/a6694c_331b7666ec214d1cb9eab348b23156e6~mv2.png"
                },
                new ImageProduct
                {
                    Id = 21,
                    ProductId = 4,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_8c8ef3eb0c7b4c009a08aecabee93d26~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_8c8ef3eb0c7b4c009a08aecabee93d26~mv2.png"
                },
                new ImageProduct
                {
                    Id = 22,
                    ProductId = 4,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_f3173997361b4b1b83ad90f807bbaf85~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_f3173997361b4b1b83ad90f807bbaf85~mv2.png"
                },
                new ImageProduct
                {
                    Id = 23,
                    ProductId = 4,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_6180737a52184e20a160a44b8b00cbc6~mv2.png/v1/fill/w_832,h_665,al_c,usm_0.66_1.00_0.01/a6694c_6180737a52184e20a160a44b8b00cbc6~mv2.png"
                },
                new ImageProduct
                {
                    Id = 24,
                    ProductId = 4,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_0d7a1d6d29d0432b85ad84001ad13a9b~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_0d7a1d6d29d0432b85ad84001ad13a9b~mv2.png"
                },
                new ImageProduct
                {
                    Id = 25,
                    ProductId = 4,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_2485f5b6aa434f04a31a359a58f370ce~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_2485f5b6aa434f04a31a359a58f370ce~mv2.png"
                },
                new ImageProduct
                {
                    Id = 26,
                    ProductId = 4,
                    ImagePath = "https://video.wixstatic.com/video/a6694c_84516f7e298844d7954c342ceedba433/1080p/mp4/file.mp4"
                },
                new ImageProduct
                {
                    Id = 27,
                    ProductId = 5,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_c3e384c8ca434dc6b7c2920f660579e3~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_c3e384c8ca434dc6b7c2920f660579e3~mv2.png"
                },
                new ImageProduct
                {
                    Id = 28,
                    ProductId = 5,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_c4aefe2a5f294a0faf6a2f7c19af32db~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_c4aefe2a5f294a0faf6a2f7c19af32db~mv2.png"
                },
                new ImageProduct
                {
                    Id = 29,
                    ProductId = 5,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_a730f2e789864a9cb75ce1dde1e52b07~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_a730f2e789864a9cb75ce1dde1e52b07~mv2.png"
                },
                new ImageProduct
                {
                    Id = 30,
                    ProductId = 5,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_35eeecadd7f6495c99a3db846af81148~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_35eeecadd7f6495c99a3db846af81148~mv2.jpg"
                },
                new ImageProduct
                {
                    Id = 31,
                    ProductId = 5,
                    ImagePath = "https://video.wixstatic.com/video/a6694c_5b80835e03c94fd6b720fdd2ceaa8865/1080p/mp4/file.mp4"
                },
                new ImageProduct
                {
                    Id = 32,
                    ProductId = 6,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_e95ca1c8158d4caba5b6e7bedaa0eeab~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_e95ca1c8158d4caba5b6e7bedaa0eeab~mv2.png"
                },
                new ImageProduct
                {
                    Id = 33,
                    ProductId = 6,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_6381e01ae9c340d598e09ea221ff60f2~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_6381e01ae9c340d598e09ea221ff60f2~mv2.png"
                },
                new ImageProduct
                {
                    Id = 34,
                    ProductId = 6,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_48c50850bac34de3911eb25953af593d~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_48c50850bac34de3911eb25953af593d~mv2.png"
                },
                new ImageProduct
                {
                    Id = 35,
                    ProductId = 6,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_757ebf6a259740c19feb8b3a9a6bc8f5~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_757ebf6a259740c19feb8b3a9a6bc8f5~mv2.png"
                },
                new ImageProduct
                {
                    Id = 36,
                    ProductId = 7,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_dcd9e99fe4d44425b1f77612e83ac7c3~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_dcd9e99fe4d44425b1f77612e83ac7c3~mv2.png"
                },
                new ImageProduct
                {
                    Id = 37,
                    ProductId = 7,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_2fa731434bbc41df95694781b5de4092~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_2fa731434bbc41df95694781b5de4092~mv2.png"
                },
                new ImageProduct
                {
                    Id = 38,
                    ProductId = 7,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_1a21a0325bd2422081c51946789b8adf~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_1a21a0325bd2422081c51946789b8adf~mv2.png"
                },
                new ImageProduct
                {
                    Id = 39,
                    ProductId = 7,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_f5e3c9c920fe41f395dc3bbb35e0161d~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_f5e3c9c920fe41f395dc3bbb35e0161d~mv2.png"
                },
                new ImageProduct
                {
                    Id = 40,
                    ProductId = 7,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_ec1aa69e21ac48dc9cfd0bf0522f8caa~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_ec1aa69e21ac48dc9cfd0bf0522f8caa~mv2.png"
                },
                new ImageProduct
                {
                    Id = 41,
                    ProductId = 7,
                    ImagePath = "https://video.wixstatic.com/video/a6694c_8570c70283b14cce830d5da15331979c/480p/mp4/file.mp4"
                },
                new ImageProduct
                {
                    Id = 42,
                    ProductId = 7,
                    ImagePath = "https://video.wixstatic.com/video/a6694c_3e25a17da1ba451786a46aa4daee1698/480p/mp4/file.mp4"
                },
                new ImageProduct
                {
                    Id = 43,
                    ProductId = 7,
                    ImagePath = "https://static.wixstatic.com/media/a6694c_c198248097424ec09f04d600b3ee3a40~mv2.png/v1/fill/w_886,h_665,al_c,usm_0.66_1.00_0.01/a6694c_c198248097424ec09f04d600b3ee3a40~mv2.png"
                },
        };
        public void Configure(EntityTypeBuilder<ImageProduct> builder)
        {
            builder.HasData(images);
        }
    }
}