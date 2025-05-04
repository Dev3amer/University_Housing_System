using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;

namespace UniversityHousingSystem.Infrastructure.Seeding
{
    public class CollegeDepartmentsSeeder
    {
        private readonly AppDbContext _context;
        public CollegeDepartmentsSeeder(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedCollagesDepartmentsAsync()
        {
            var departments = new List<CollegeDepartment>
            {
                // كلية الطب البشري (1)
                new CollegeDepartment { Name = "الأمراض العصبية", CollegeId = 1 },
                new CollegeDepartment { Name = "طب القلب والأوعية الدموية", CollegeId = 1 },
                new CollegeDepartment { Name = "الكبد والجهاز الهضمي والأمراض المعدية", CollegeId = 1 },
                new CollegeDepartment { Name = "الباثولوجيا الإكلينيكية", CollegeId = 1 },
                new CollegeDepartment { Name = "جراحة المسالك البولية والتناسلية", CollegeId = 1 },
                new CollegeDepartment { Name = "جراحة العظام", CollegeId = 1 },
                new CollegeDepartment { Name = "التخدير والعناية المركزة الجراحية", CollegeId = 1 },
                new CollegeDepartment { Name = "الأشعة التخصصية والتداخلية", CollegeId = 1 },
                new CollegeDepartment { Name = "جراحة القلب والصدر", CollegeId = 1 },
                new CollegeDepartment { Name = "جراحة المخ والأعصاب", CollegeId = 1 },
                new CollegeDepartment { Name = "الروماتيزم والتأهيل والطب الطبيعي", CollegeId = 1 },
                new CollegeDepartment { Name = "قسم الحالات الحرجة", CollegeId = 1 },
                new CollegeDepartment { Name = "قسم طب الأسرة", CollegeId = 1 },
                new CollegeDepartment { Name = "قسم الطب الرياضي", CollegeId = 1 },
                new CollegeDepartment { Name = "قسم طب الطوارئ", CollegeId = 1 },

                // كلية الطب البيطري (2)
                new CollegeDepartment { Name = "قسم التشريح والأجنة", CollegeId = 2 },
                new CollegeDepartment { Name = "قسم الصحة والرعاية البيطرية", CollegeId = 2 },
                new CollegeDepartment { Name = "قسم طب الحيوان", CollegeId = 2 },
                new CollegeDepartment { Name = "قسم تنمية الثروة الحيوانية", CollegeId = 2 },
                new CollegeDepartment { Name = "قسم البكتريولوجيا والفطريات والمناعة", CollegeId = 2 },
                new CollegeDepartment { Name = "قسم الكيمياء الحيوية", CollegeId = 2 },
                new CollegeDepartment { Name = "قسم الباثولوجيا الإكلينيكية", CollegeId = 2 },
                new CollegeDepartment { Name = "قسم أمراض ورعاية الأحياء المائية", CollegeId = 2 },
                new CollegeDepartment { Name = "قسم الرقابة الصحية على الأغذية", CollegeId = 2 },
                new CollegeDepartment { Name = "قسم الطب الشرعي والسموم", CollegeId = 2 },
                new CollegeDepartment { Name = "قسم الهستولوجيا", CollegeId = 2 },
                new CollegeDepartment { Name = "قسم التغذية والتغذية الإكلينيكية", CollegeId = 2 },
                new CollegeDepartment { Name = "قسم الطفيليات", CollegeId = 2 },
                new CollegeDepartment { Name = "قسم الباثولوجيا", CollegeId = 2 },
                new CollegeDepartment { Name = "قسم الفارماكولوجي", CollegeId = 2 },

                // كلية العلاج الطبيعي (3)
                new CollegeDepartment { Name = "قسم العلاج الطبيعي للأعصاب", CollegeId = 3 },
                new CollegeDepartment { Name = "قسم العلاج الطبيعي لجراحة العظام", CollegeId = 3 },
                new CollegeDepartment { Name = "قسم العلاج الطبيعي للأمراض الجلدية", CollegeId = 3 },
                new CollegeDepartment { Name = "قسم العلاج الطبيعي للأطفال", CollegeId = 3 },
                new CollegeDepartment { Name = "قسم العلاج الطبيعي للرياضة", CollegeId = 3 },

                // كلية التمريض (4)
                new CollegeDepartment { Name = "تمريض الأطفال", CollegeId = 4 },
                new CollegeDepartment { Name = "التمريض الباطني والجراحي", CollegeId = 4 },
                new CollegeDepartment { Name = "التمريض النفسي والصحة النفسية", CollegeId = 4 },
                new CollegeDepartment { Name = "إدارة التمريض", CollegeId = 4 },
                new CollegeDepartment { Name = "تمريض صحة المجتمع", CollegeId = 4 },
                new CollegeDepartment { Name = "تمريض وصحة المرأة والتوليد", CollegeId = 4 },
                new CollegeDepartment { Name = "إدارة الخدمات التمريضية", CollegeId = 4 },
                new CollegeDepartment { Name = "أساسيات التمريض", CollegeId = 4 },

                // كلية الهندسة بشبرا (5)
                new CollegeDepartment { Name = "قسم الهندسة الميكانيكية", CollegeId = 5 },
                new CollegeDepartment { Name = "قسم الهندسة الكهربائية", CollegeId = 5 },
                new CollegeDepartment { Name = "قسم هندسة المساحة", CollegeId = 5 },
                new CollegeDepartment { Name = "قسم الهندسة المعمارية", CollegeId = 5 },
                new CollegeDepartment { Name = "قسم الهندسة المدنية", CollegeId = 5 },
                new CollegeDepartment { Name = "قسم الرياضيات والفيزياء الهندسية", CollegeId = 5 },

                // كلية الهندسة ببنها (6)
                new CollegeDepartment { Name = "قسم الهندسة المدنية", CollegeId = 6 },
                new CollegeDepartment { Name = "قسم الهندسة الكهربائية", CollegeId = 6 },
                new CollegeDepartment { Name = "قسم الهندسة الميكانيكية", CollegeId = 6 },
                new CollegeDepartment { Name = "قسم الهندسة المعمارية", CollegeId = 6 },
                new CollegeDepartment { Name = "قسم العلوم الهندسية الأساسية", CollegeId = 6 },

                // كلية الحاسبات والذكاء الاصطناعي (7)
                new CollegeDepartment { Name = "قسم علوم الحاسب", CollegeId = 7 },
                new CollegeDepartment { Name = "قسم نظم المعلومات", CollegeId = 7 },
                new CollegeDepartment { Name = "قسم الحسابات العلمية", CollegeId = 7 },
                new CollegeDepartment { Name = "قسم الذكاء الاصطناعي", CollegeId = 7 },

                // كلية العلوم (8)
                new CollegeDepartment { Name = "قسم الرياضيات", CollegeId = 8 },
                new CollegeDepartment { Name = "قسم الفيزياء", CollegeId = 8 },
                new CollegeDepartment { Name = "قسم الكيمياء", CollegeId = 8 },
                new CollegeDepartment { Name = "قسم الجيولوجيا", CollegeId = 8 },
                new CollegeDepartment { Name = "قسم النبات", CollegeId = 8 },
                new CollegeDepartment { Name = "قسم علم الحيوان", CollegeId = 8 },
                new CollegeDepartment { Name = "قسم علم الحشرات", CollegeId = 8 },

                // كلية الزراعة (9)
                new CollegeDepartment { Name = "قسم المحاصيل", CollegeId = 9 },
                new CollegeDepartment { Name = "قسم وقاية النبات", CollegeId = 9 },
                new CollegeDepartment { Name = "قسم الإنتاج الحيواني", CollegeId = 9 },
                new CollegeDepartment { Name = "قسم البساتين", CollegeId = 9 },
                new CollegeDepartment { Name = "قسم الوراثة", CollegeId = 9 },
                new CollegeDepartment { Name = "قسم الأراضي", CollegeId = 9 },
                new CollegeDepartment { Name = "قسم الكيمياء الزراعية", CollegeId = 9 },
                new CollegeDepartment { Name = "قسم الصناعات الغذائية", CollegeId = 9 },
                new CollegeDepartment { Name = "قسم الألبان", CollegeId = 9 },
                new CollegeDepartment { Name = "قسم الاقتصاد الزراعي", CollegeId = 9 },
                new CollegeDepartment { Name = "قسم النبات الزراعي", CollegeId = 9 },
                new CollegeDepartment { Name = "قسم الهندسة الزراعية", CollegeId = 9 },
                new CollegeDepartment { Name = "قسم أمراض النبات", CollegeId = 9 },
                new CollegeDepartment { Name = "قسم الميكروبيولوجيا الزراعية", CollegeId = 9 },

                // كلية الفنون التطبيقية (10)
                new CollegeDepartment { Name = "برنامج علوم تصميم وإنتاج الأثاث", CollegeId = 10 },
                new CollegeDepartment { Name = "برنامج الغزل والنسيج والتريكو", CollegeId = 10 },
                new CollegeDepartment { Name = "برنامج طباعة المنسوجات والصباغة والتجهيز", CollegeId = 10 },
                new CollegeDepartment { Name = "برنامج تكنولوجيا الملابس والموضة", CollegeId = 10 },

                // كلية التجارة (11)
                new CollegeDepartment { Name = "قسم المحاسبة", CollegeId = 11 },
                new CollegeDepartment { Name = "قسم الاقتصاد", CollegeId = 11 },
                new CollegeDepartment { Name = "قسم إدارة الأعمال", CollegeId = 11 },
                new CollegeDepartment { Name = "قسم الإحصاء والرياضة والتأمين", CollegeId = 11 },

                // كلية التربية (12)
                new CollegeDepartment { Name = "قسم الصحة النفسية والتربية الخاصة", CollegeId = 12 },
                new CollegeDepartment { Name = "قسم علم النفس", CollegeId = 12 },
                new CollegeDepartment { Name = "قسم المناهج وطرق التدريس وتكنولوجيا التعليم", CollegeId = 12 },
                new CollegeDepartment { Name = "قسم الإدارة التعليمية والتربية المقارنة", CollegeId = 12 },
                new CollegeDepartment { Name = "قسم أصول التربية", CollegeId = 12 },

                // كلية التربية النوعية (13)
                new CollegeDepartment { Name = "قسم تكنولوجيا التعليم", CollegeId = 13 },
                new CollegeDepartment { Name = "قسم التربية الموسيقية", CollegeId = 13 },
                new CollegeDepartment { Name = "برنامج معلم التربية الفنية", CollegeId = 13 },
                new CollegeDepartment { Name = "قسم الاقتصاد المنزلي", CollegeId = 13 },
                new CollegeDepartment { Name = "قسم الطفولة المبكرة والتربية", CollegeId = 13 },
                new CollegeDepartment { Name = "قسم الإعلام التربوي", CollegeId = 13 },

                // كلية التربية الرياضية (14)
                new CollegeDepartment { Name = "قسم التدريب الرياضي", CollegeId = 14 },
                new CollegeDepartment { Name = "قسم الصحة والتغذية الرياضية", CollegeId = 14 },
                new CollegeDepartment { Name = "قسم الإدارة الرياضية", CollegeId = 14 },

                // كلية الحقوق (15)
                new CollegeDepartment { Name = "قسم القانون العام", CollegeId = 15 },
                new CollegeDepartment { Name = "قسم القانون الخاص", CollegeId = 15 },
                new CollegeDepartment { Name = "قسم الشريعة الإسلامية", CollegeId = 15 },

                // كلية الآداب (16)
                new CollegeDepartment { Name = "قسم اللغة العربية", CollegeId = 16 },
                new CollegeDepartment { Name = "قسم اللغة الإنجليزية", CollegeId = 16 },
                new CollegeDepartment { Name = "قسم التاريخ", CollegeId = 16 },
                new CollegeDepartment { Name = "قسم الفلسفة", CollegeId = 16 },
                new CollegeDepartment { Name = "قسم علم الاجتماع", CollegeId = 16 },
                new CollegeDepartment { Name = "قسم الجغرافيا", CollegeId = 16 }
            };

            if (!_context.CollegeDepartments.Any())
            {
                await _context.CollegeDepartments.AddRangeAsync(departments);
                await _context.SaveChangesAsync();
            }
        }
    }
}
