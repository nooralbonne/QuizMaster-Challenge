using System;
using System.Collections.Generic;

namespace QuizMaster_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartQuiz();
        }

        static void StartQuiz()
        {
            var questionsAndAnswers = new List<dynamic>
            {
                new { Question = "Is the capital of France Paris?", Answer = true },
                new { Question = "Is 2 + 2 equal to 5?", Answer = false },
                new { Question = "Is the sky blue on a clear day?", Answer = true }
            };

            int score = 0;
            int totalQuestions = questionsAndAnswers.Count;

            try
            {
                for (int i = 0; i < totalQuestions; i++)
                {
                    Console.WriteLine(questionsAndAnswers[i].Question);
                    bool userAnswer;
                    bool validAnswer = bool.TryParse(Console.ReadLine(), out userAnswer);

                    if (!validAnswer)
                    {
                        Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
                        i--; // Ask the same question again
                        continue;
                    }

                    if (userAnswer == questionsAndAnswers[i].Answer)
                    {
                        Console.WriteLine("Correct!");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect. The correct answer is {questionsAndAnswers[i].Answer}.");
                    }
                }

                Console.WriteLine($"Your final score is {score} / {totalQuestions}.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"A formatting error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Quiz completed.");
            }
        }
    }
}
