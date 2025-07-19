using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your grade percentage: ");
        int grade = Convert.ToInt32(Console.ReadLine());

        string letter = "";
        string sign = "";

        // Determine the letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign
        if (letter != "F")
        {
            int lastDigit = grade % 10;
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }

            // Handle exceptional cases
            if (letter == "A" && sign == "+")
            {
                sign = "";
            }
        }
        else
        {
            sign = "";
        }

        // Determine if the user passed the course
        string passedMessage = grade >= 70 ? "Congratulations, you passed the course!" : "Don't worry, you'll do better next time!";

        // Print the results
        if (!string.IsNullOrEmpty(sign))
        {
            Console.WriteLine($"Your grade is {letter}{sign}.");
        }
        else
        {
            Console.WriteLine($"Your grade is {letter}.");
        }
        Console.WriteLine(passedMessage);
    }
}