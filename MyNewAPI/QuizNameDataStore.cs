
using MyNewAPI.Models;

namespace MyNewAPI
{
    public class QuizNameDataStore
    {
        public List<QuizNameDto> QuizNames { get; set; }

        public static QuizNameDataStore Current { get; } = new QuizNameDataStore();

        public QuizNameDataStore()
        {
            QuizNames = new List<QuizNameDto>()
            {
                new QuizNameDto()
                {
                    Id = 1,
                    Name = "Harry Potter quiz",
                    Description = "Quiz about live and adventure Harry Potter",
                    Level = 3
                },
                new QuizNameDto()
                {
                    Id=2,
                    Name = "Marvel quiz",
                    Description = "Quiz about Marvel heroes adventure",
                    Level = 3
                },
                new QuizNameDto()
                {
                    Id = 3,
                    Name = "Stranger Things quiz",
                    Description = "Quiz about Stranger Things and others things :)",
                    Level = 3
                }
            };
        }
    }
}

