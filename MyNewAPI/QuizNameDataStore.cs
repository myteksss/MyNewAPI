
using MyNewAPI.Models;
using Quiz.API.Models;

namespace MyNewAPI
{
    public class QuizNameDataStore
    {
        public List<QuizNameDto> QuizNames { get; set; }

        //public List<QuizQuestionsDto> quizQuestionsDtos { get; set; }

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
                    Level = 3,
                    QuestionAnswer = new List<QuizQuestionsDto>
                    {
                        new QuizQuestionsDto() { Id = 1, Question = "Pytanie 1", Answer = "odp 1" }
                    }
                },
                new QuizNameDto()
                {
                    Id=2,
                    Name = "Marvel quiz",
                    Description = "Quiz about Marvel heroes adventure",
                    Level = 3,
                    QuestionAnswer = new List<QuizQuestionsDto>
                    {
                        new QuizQuestionsDto() {Id=2, Question = "Pytanie 2", Answer = "odp 2"}
                    }
                },
                new QuizNameDto()
                {
                    Id = 3,
                    Name = "Stranger Things quiz",
                    Description = "Quiz about Stranger Things and others things :)",
                    Level = 3,
                    QuestionAnswer = new List<QuizQuestionsDto>
                    {
                        new QuizQuestionsDto(){Id = 3, Question = "Pytanie 3", Answer = "odp 3"}
                    }
                }
            };
        }
    }
}

