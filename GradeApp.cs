using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
  public class GradeApp
  {
    private List<double> grades;
    private string _name;


    public GradeApp()
    {
      grades = new List<double>();
    }


    public bool AddGrade(double grade)
    {
      bool result = false;

      if ((grade > 100) || (grade < 0))
      {
        Console.WriteLine();
        throw new ArgumentException($"Invalid {nameof(grade)}: {grade}");
      }
      else
      {
        grades.Add(grade);
        result = true;
      }

      return result;
    }


    public List<double> GetGrades
    {
      get
      {
        return grades;
      }
    }


    public bool CleanUserGradeInput(List<string> rawInput, int _numGrades)
    {
      bool result = false;

      if (rawInput.Count == _numGrades)
      {

        foreach (var item in rawInput)
        {
          try
          {
            result = double.TryParse(item, out double grade);

            if (result)
            {
              result = AddGrade(grade);
            }
            else
            {
              Console.WriteLine("Invalid input.");
              result = false;
              break;
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      } else
      {
        Console.WriteLine();
        Console.WriteLine("Number of grades does not match with number our courses.");
        Console.WriteLine();
        result = false;
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
          Clear();
          break;
        default:
          Console.WriteLine();
          Console.WriteLine("Invalid input");
          Console.WriteLine();
          Console.WriteLine("Program exiting...");
          result = false;
          break;
      }
      Console.WriteLine();

      return result;
    }


    private void Clear() => grades.Clear();


    /*
     * Program entry. 
     * Receives, cleans and compute statistics on user input
     */
    public void Prompt()
    {
      bool result = true;

      do
      {
        Console.Write("Please enter number of grades to be calculated: ");
        var numGrades = int.Parse(Console.ReadLine().Trim());

        Console.Write("Pleas enter grades. Separate them with spaces: ");
        var rawInput = Console.ReadLine().Trim().Split(" ").ToList();

        result = CleanUserGradeInput(rawInput, numGrades);

        if (result)
        {
          if (!result)
          {
            result = false;
            Console.WriteLine();
            Console.WriteLine("Sorry. Computation error.");
          }
          else
          {
            Console.WriteLine();
            if (grades.Count == numGrades)
            {
              var stats = new Statistics();
              stats.ComputeStatistics(grades);
              stats.ShowStatistics();
            }
            else result = false;
            Console.WriteLine();
          }
        }
        else
        {
          result = false;
        }

        result = RunProgramAgain();

      } while (result);
    }
  }
}
