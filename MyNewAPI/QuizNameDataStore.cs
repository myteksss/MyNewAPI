
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
                    QuizQuestion = new List<QuizQuestionsDto>
                    {
                        new QuizQuestionsDto() 
                        { 
                            Id = 1, 
                            QuizNameId = 1, 
                            Level = 2, 
                            Question = "Jakie ma w³osy HP",
                            quizOption = new List<QuizOptionDto>
                            {
                               new QuizOptionDto()
                               {
                                   Id = 1,
                                   QuizQuestionId = 1,
                                   Option = "Red",
                                   CorrectOption = 0
                               },
                               new QuizOptionDto()
                               {
                                   Id = 2,
                                   QuizQuestionId = 1,
                                   Option = "Blue",
                                   CorrectOption = 0
                               },
                               new QuizOptionDto()
                               {
                                   Id = 3,
                                   QuizQuestionId = 1,
                                   Option = "Blue",
                                   CorrectOption = 0
                               }, 
                               new QuizOptionDto()
                               {
                                   Id = 4,
                                   QuizQuestionId = 1,
                                   Option = "Black",
                                   CorrectOption = 1
                               }
                            }
                        },
                        new QuizQuestionsDto()
                        {
                            Id = 2,
                            QuizNameId = 1,
                            Level = 2,
                            Question = "Gdzie spa³ HP",
                            quizOption = new List<QuizOptionDto>
                            {
                               new QuizOptionDto()
                               {
                                   Id = 5,
                                   QuizQuestionId = 2,
                                   Option = "W aucie",
                                   CorrectOption = 0
                               },
                               new QuizOptionDto()
                               {
                                   Id = 6,
                                   QuizQuestionId = 2,
                                   Option = "W ja³cie",
                                   CorrectOption = 0
                               },
                               new QuizOptionDto()
                               {
                                   Id = 7,
                                   QuizQuestionId = 2,
                                   Option = "W hotelu",
                                   CorrectOption = 0
                               },
                               new QuizOptionDto()
                               {
                                   Id = 8,
                                   QuizQuestionId = 2,
                                   Option = "Pod schodami",
                                   CorrectOption = 1
                               }
                            }
                        }
                    }
                },
                new QuizNameDto()
                {
                    Id=2,
                    Name = "Marvel quiz",
                    Description = "Quiz about Marvel heroes adventure",
                    Level = 3,
                    QuizQuestion = new List<QuizQuestionsDto>
                    {
                        new QuizQuestionsDto()
                        {
                            Id = 1,
                            QuizNameId = 2,
                            Level = 2,
                            Question = "Jakie ma w³osy Hulk",
                            quizOption = new List<QuizOptionDto>
                            {
                               new QuizOptionDto()
                               {
                                   Id = 5,
                                   QuizQuestionId = 2,
                                   Option = "Yellow",
                                   CorrectOption = 0
                               },
                               new QuizOptionDto()
                               {
                                   Id = 6,
                                   QuizQuestionId = 2,
                                   Option = "Pink",
                                   CorrectOption = 0
                               },
                               new QuizOptionDto()
                               {
                                   Id = 7,
                                   QuizQuestionId = 2,
                                   Option = "Blue",
                                   CorrectOption = 0
                               },
                               new QuizOptionDto()
                               {
                                   Id = 8,
                                   QuizQuestionId = 2,
                                   Option = "Black",
                                   CorrectOption = 1
                               }
                            }
                        }
                    }
                },
                new QuizNameDto()
                {
                    Id = 3,
                    Name = "Stranger Things quiz",
                    Description = "Quiz about Stranger Things and others things :)",
                    Level = 3,
                    QuizQuestion = new List<QuizQuestionsDto>
                    {
                        new QuizQuestionsDto()
                        {
                            Id = 1,
                            QuizNameId = 3,
                            Level = 2,
                            Question = "Jakie ma w³osy Mike",
                            quizOption = new List<QuizOptionDto>
                            {
                               new QuizOptionDto()
                               {
                                   Id = 1,
                                   QuizQuestionId = 3,
                                   Option = "Blondie",
                                   CorrectOption = 0
                               },
                               new QuizOptionDto()
                               {
                                   Id = 2,
                                   QuizQuestionId = 3,
                                   Option = "Red",
                                   CorrectOption = 0
                               },
                               new QuizOptionDto()
                               {
                                   Id = 3,
                                   QuizQuestionId = 3,
                                   Option = "No hair",
                                   CorrectOption = 0
                               },
                               new QuizOptionDto()
                               {
                                   Id = 4,
                                   QuizQuestionId = 3,
                                   Option = "Black",
                                   CorrectOption = 1
                               }
                            }
                        }
                    }
                }
            };
        }
    }
}

