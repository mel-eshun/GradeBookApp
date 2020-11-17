using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
  public class Book
  {
    private List<double> grades;
    private string _name;
    private int _numGrades;


    public Book()
    {
      grades = new List<double>();
    }


    public string Name
    {
      get
      {
        return _name;
      }

      set
      {
        _name = value;
      }
    }


    public bool AddGrade(double grade)
    {
      bool result;

      if ((grade > 100) || (grade < 0))
      {
        result = false;
      }
      else
      {
        grades.Add(grade);
        result = true;
      }

      return result;
    }


    public char GetLetterGrade(double grade)
    {
      var stats = new Statistics();

      switch (grade)
      {
        case var averageGrade when averageGrade >= 90.0 && averageGrade <= 100:
          stats.LetterGrade = 'A';
          break;
        case var averageGrade when averageGrade >= 80.0:
          stats.LetterGrade = 'B';
          break;
        case var averageGrade when averageGrade >= 70.0:
          stats.LetterGrade = 'C';
          break;
        case var averageGrade when averageGrade >= 60.0 && averageGrade >= 0:
          stats.LetterGrade = 'D';
          break;
        default:
          stats.LetterGrade = 'F';
          break;
      }

      return stats.LetterGrade;
    }


    public Statistics ComputeStatistics()
    {
      var stats = new Statistics
      {
        LowestGrade = double.MaxValue,
        HighestGrade = double.MinValue,
        AverageGrade = 0.0
      };

      int index = 0;
      while (index < grades.Count)
      {
        stats.LowestGrade = Math.Min(grades[index], stats.LowestGrade);
        stats.HighestGrade = Math.Max(grades[index], stats.HighestGrade);
        stats.AverageGrade += grades[index];

        index += 1;
      }

      stats.AverageGrade /= grades.Count;

      stats.LetterGrade = GetLetterGrade(stats.AverageGrade);

      return stats;
    }


    public void ShowStatistics()
    {
      Console.WriteLine($"Book: {Name}");
      Console.WriteLine($"Lowest grade: {ComputeStatistics().LowestGrade:N2}");
      Console.WriteLine($"Highest grade: {ComputeStatistics().HighestGrade:N2}");
      Console.WriteLine($"Average grade: {ComputeStatistics().AverageGrade:N2}");
      Console.WriteLine($"Letter grade: {ComputeStatistics().LetterGrade}");
    }


    public bool CleanUserInput(List<string> rawInput)
    {
      bool result = false;

      foreach (var item in rawInput)
      {
        result = double.TryParse(item, out double grade);
        result = AddGrade(grade);
      }

      return result;
    }

    
    public bool RunProgramAgain()
    {
      bool result = true;

      Console.Write("Do you want to try again? [Y/N]: ");
      char answer = char.Parse(Console.ReadLine().Trim().ToLower());

      switch (answer)
      {
        case 'n':
          Console.WriteLine();
          Console.WriteLine("Program exiting...");
          result = false;
          break;
        case 'y':
          Console.WriteLine();
          result = true;
          break;
        default:
          Console.WriteLine();
          Console.WriteLine("Program exiting...");
          result = false;
          break;
      }
      Console.WriteLine();

      return result;
    }


    public bool CheckNumberGrades(int numGrades)
    {
      bool result = numGrades == grades.Count;

      return result;
    }


    public void Prompt()
    {
      bool result = true;
      do
      {
        Console.Write("Please enter number of grades to be calculated: ");
        var numGrades = int.Parse(Console.ReadLine().Trim());

        Console.Write("Pleas enter grades. Separate them with spaces: ");
        var rawInput = Console.ReadLine().Trim().Split(" ").ToList();

        result = CleanUserInput(rawInput);

        if (!result)
        {
          result = false;
          Console.WriteLine();
          Console.WriteLine("Sorry. Computation error.");
        } 
        else
        {
          if (CheckNumberGrades(numGrades))
          {
            Console.WriteLine();
            ComputeStatistics();
            ShowStatistics();
            Console.WriteLine();
          }
          else result = false;
        }

        result = RunProgramAgain();

      } while (result);
    }
  }
}
