using System;
using System.Collections.Generic;
using System.Linq;
using Papyrus.DataAccess.Concrete.EntityFramework;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete
{
    public class Seed
    {
        public static void SeedData(PapyrusContext context)
        {

            Category literature = new Category
            {
                Name = "Edebiyat",
                Description = "Edebiyat kategorisindeki kitaplar"
            };

            Category economy = new Category
            {
                Name = "Ekonomi",
                Description = "Ekonomi ile alakalı kitaplar"
            };

            Category psychology = new Category
            {
                Name = "Psikoloji",
                Description = "Ekonomi ile alakalı kitaplar"
            };

            if (!context.Categories.Any())
            {
                List<Category> categories = new List<Category>{
                                literature,
                                economy,
                                psychology
                            };

                context.AddRange(categories);
                context.SaveChanges();
            }

            Genre novel = new Genre
            {
                CategoryId = literature.Id,
                Name = "Roman",
                Description = "Roman türünde kitaplar"
            };

            Genre sciencefiction = new Genre
            {
                CategoryId = literature.Id,
                Name = "Bilim-Kurgu",
                Description = "Bilim-Kurgu türünde kitaplar"
            };

            Genre managment = new Genre
            {
                CategoryId = economy.Id,
                Name = "Yönetim",
                Description = "Yönetim türünde kitaplar"
            };

            Genre generalPsychology = new Genre
            {
                CategoryId = psychology.Id,
                Name = "Genel Psikoloji",
                Description = "Genel Psikoloji türünde kitaplar"
            };

            Genre childPsychology = new Genre
            {
                CategoryId = psychology.Id,
                Name = "Çocuk Psikoloji",
                Description = "Çocuk Psikoloji türünde kitaplar"
            };

            if (!context.Genres.Any())
            {
                List<Genre> genres = new List<Genre>
                {
                    novel,
                    sciencefiction,
                    managment,
                    generalPsychology,
                    childPsychology
                };

                context.AddRange(genres);
                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
                List<Book> books = new List<Book>{
                new Book
                {
                    GenreId= novel.Id,
                    Name = "Born Standing Up",
                    Summary = "To become a better writer, you have to write more. Writing reveals the story because you have to write to figure out what you’re writing about. Don’t judge your initial work too harshly because every writer has terrible first drafts."
                },
                new Book
                {
                    GenreId=novel.Id,
                    Name = "The Compound Effect",
                    Summary = "The compound effect is the strategy of reaping huge rewards from small, seemingly insignificant actions. You cannot improve something until you measure it. Always take 100 percent responsibility for everything that happens to you."
                },
                new Book
                {
                    GenreId=managment.Id,
                    Name = "The Art of Possibility",
                    Summary = "Everything in life is an invention. If you choose to look at your life in a new way, then suddenly your problems fade away. One of the best ways to do this is to focus on the possibilities surrounding you in any situation rather than slipping into the default mode of measuring and comparing your life to others."
                },
                new Book
                {
                    GenreId=generalPsychology.Id,
                    Name = "Free Will",
                    Summary = "We do not have the freedom and free will that we think we do. Yes, you can make conscious choices, but everything that makes up those conscious choices (your thoughts, your wants, your desires) is determined by prior causes outside your control. Just because you can do what you want does not mean you have free will because you are not choosing what you want in the first place."
                },
                new Book
                {
                    GenreId=sciencefiction.Id,
                    Name = "Guns, Germs, and Steel",
                    Summary = "Some environments provide more starting materials and more favorable conditions for utilizing inventions and building societies than other environments. This is particularly notable in the rise of European peoples, which occurred because of environmental differences and not because of biological differences in the people themselves. There are four primary reasons Europeans rose to power and conquered the natives of North and South America, and not the other way around: 1) the continental differences in the plants and animals available for domestication, which led to more food and larger populations in Europe and Asia, 2) the rate of diffusion of agriculture, technology and innovation due to the geographic orientation of Europe and Asia (east-west) compared to the Americas (north-south), 3) the ease of intercontinental diffusion between Europe, Asia, and Africa, and 4) the differences in continental size, which led to differences in total population size and technology diffusion."
                }
                };
                context.Books.AddRange(books);
                context.SaveChanges();
            }
        }

    }
}
