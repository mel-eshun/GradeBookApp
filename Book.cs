using System;
using System.Collections.Generic;

namespace GradeBook
{
  public class Book
  {
    private List<double> grades;
    private string _name;


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
      var stats = new Statistics();
      stats.LowestGrade = double.MaxValue;
      stats.HighestGrade = double.MinValue;
      stats.AverageGrade = 0.0;

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
  }
}
