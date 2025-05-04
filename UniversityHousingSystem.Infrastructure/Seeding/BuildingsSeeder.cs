using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.Context;

namespace MovieReservationSystem.Infrastructure.Seeding
{
    public class BuildingsSeeder
    {
        private readonly AppDbContext _context;
        public BuildingsSeeder(AppDbContext context)
        {
            _context = context;
        }
        public async Task SeedBuildingsAsync()
        {
            var buildings = new List<Building>
            {
                new Building { Name = "مبنى طلاب أ",
                    Description = "مبني يتكون من ستة ادوار به 67 غرفة إقامة وكل غرفة تسع لأربع طلاب",
                    Type = EnBuildingType.Normal,
                    AddressInDetails = "امتداد شارع كلية التجارة ببنها بالقرب من قرية كفر سعد",
                    MapIFrame = @"<iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d4088.91935646136!2d31.193337079962124!3d30.482627870062302!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14f7df15096a3a8f%3A0x16bd0917e5a603a1!2sUniversity%20City!5e0!3m2!1sen!2seg!4v1746332284800!5m2!1sen!2seg"" width=""600"" height=""450"" style=""border:0;"" allowfullscreen="""" loading=""lazy"" referrerpolicy=""no-referrer-when-downgrade""></iframe>",
                    VillageId = 4396
                },
                new Building { Name = "مبنى طلاب ب",
                    Description = "مبني يتكون من ستة ادوار به 67 غرفة إقامة وكل غرفة تسع لأربع طلاب",
                    Type = EnBuildingType.Normal,
                    AddressInDetails = "امتداد شارع كلية التجارة ببنها بالقرب من قرية كفر سعد",
                    MapIFrame = @"<iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d4088.91935646136!2d31.193337079962124!3d30.482627870062302!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14f7df15096a3a8f%3A0x16bd0917e5a603a1!2sUniversity%20City!5e0!3m2!1sen!2seg!4v1746332284800!5m2!1sen!2seg"" width=""600"" height=""450"" style=""border:0;"" allowfullscreen="""" loading=""lazy"" referrerpolicy=""no-referrer-when-downgrade""></iframe>",
                    VillageId = 4396
                },
                new Building { Name = "مبنى طالبات أ",
                    Description = "مبني يتكون من خمسة ادوار به 74 غرفة إقامة وكل غرفة تسع لأربع طالبات",
                    Type = EnBuildingType.Normal,
                    AddressInDetails = "امتداد شارع كلية التجارة ببنها بالقرب من قرية كفر سعد",
                    MapIFrame = @"<iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d4088.91935646136!2d31.193337079962124!3d30.482627870062302!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14f7df15096a3a8f%3A0x16bd0917e5a603a1!2sUniversity%20City!5e0!3m2!1sen!2seg!4v1746332284800!5m2!1sen!2seg"" width=""600"" height=""450"" style=""border:0;"" allowfullscreen="""" loading=""lazy"" referrerpolicy=""no-referrer-when-downgrade""></iframe>",
                    VillageId = 4396
                },
                new Building { Name = "مبنى طالبات ب",
                    Description = "مبني يتكون من خمسة ادوار به 74 غرفة إقامة وكل غرفة تسع لأربع طالبات",
                    Type = EnBuildingType.Normal,
                    AddressInDetails = "امتداد شارع كلية التجارة ببنها بالقرب من قرية كفر سعد",
                    MapIFrame = @"<iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d4088.91935646136!2d31.193337079962124!3d30.482627870062302!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14f7df15096a3a8f%3A0x16bd0917e5a603a1!2sUniversity%20City!5e0!3m2!1sen!2seg!4v1746332284800!5m2!1sen!2seg"" width=""600"" height=""450"" style=""border:0;"" allowfullscreen="""" loading=""lazy"" referrerpolicy=""no-referrer-when-downgrade""></iframe>",
                    VillageId = 4396
                },
                new Building { Name = "مبنى بنها الفندقى",
                    Description = "مبني للطلاب الذين لا تنطبق عليهم الشروط الأساسية للإسكان العادى بالمدن الجامعية",
                    Type = EnBuildingType.Normal,
                    AddressInDetails = "امتداد شارع كلية التجارة ببنها بالقرب من قرية كفر سعد",
                    MapIFrame = @"<iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d4088.91935646136!2d31.193337079962124!3d30.482627870062302!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14f7df15096a3a8f%3A0x16bd0917e5a603a1!2sUniversity%20City!5e0!3m2!1sen!2seg!4v1746332284800!5m2!1sen!2seg"" width=""600"" height=""450"" style=""border:0;"" allowfullscreen="""" loading=""lazy"" referrerpolicy=""no-referrer-when-downgrade""></iframe>",
                    VillageId = 4396
                }
            };

            if (!_context.Buildings.Any())
            {
                await _context.Buildings.AddRangeAsync(buildings);
                await _context.SaveChangesAsync();
            }
        }
    }
}
