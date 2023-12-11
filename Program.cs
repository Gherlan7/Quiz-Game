using System.ComponentModel;
using System.IO;
namespace Quiz_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("questions.txt");

            List<string> questions = new List<string>();
            List<string> answers = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                if (i%4 == 0)
                    questions.Add(text[i]);
                else 
                    answers.Add(text[i]);
            }

            int questionsIndex = 0;
            int answersIndex = 0;
            int score = 0;

            while (questionsIndex< questions.Count) 
            {
                Console.WriteLine(questions[questionsIndex]);
                questionsIndex++;

                int correctAnswerIndex = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (answers[answersIndex].StartsWith(">"))
                    {
                        correctAnswerIndex = i + 1;
                    }

                    Console.WriteLine(i + 1 + "." + answers[answersIndex].Replace(">", ""));

                    answersIndex++;
                    
                    
                }

                try
                {
                    int answer = int.Parse(Console.ReadLine());

                    if (answer == correctAnswerIndex && answer <= 3)
                    {
                        Console.WriteLine("Correct !");
                        score++;
                    }
                    else if (answer > 3)
                    {
                        Console.WriteLine("Please enter values between 0 and 3 !");
                    }
                    else
                        Console.WriteLine("Incorrect !");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter ONLY numbers !");
                   
                }
               
            }

            Console.WriteLine("End of the game ! Your score was:" + score);
            if (score > questions.Count/2)
            {
                Console.WriteLine("Thats a good score !!!");
            }
            else
            {
                Console.WriteLine("You need to study more !");
            }
        }
    }
}