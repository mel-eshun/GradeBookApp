using System;
using System.Collections.Generic;

namespace GradeBook
{
  public class Statistics
  {
    public double LowestGrade;
    public double HighestGrade;
    public double AverageGrade;
    public char LetterGrade;

    public Statistics()
    {
      LowestGrade = double.MaxValue;
      HighestGrade = double.MinValue;
      AverageGrade = 0.0;
    }

    public void ComputeStatistics(List<double> grades)
    {
      int index = 0;
      while (index < grades.Count)
      {
        LowestGrade = Math.Min(grades[index], LowestGrade);
        HighestGrade = Math.Max(grades[index], HighestGrade);
        AverageGrade += grades[index];

        index += 1;
      }

      AverageGrade /= grades.Count;

      LetterGrade = GetLetterGrade(AverageGrade);
    }

    private char GetLetterGrade(double grade)
    {
      switch (grade)
      {
        case var averageGrade when averageGrade >= 90.0 && averageGrade <= 100:
          LetterGrade = 'A';
          break;
        case var averageGrade when averageGrade >= 80.0:
          LetterGrade = 'B';
          break;
        case var averageGrade when averageGrade >= 70.0:
          LetterGrade = 'C';
          break;
        case var averageGrade when averageGrade >= 60.0 && averageGrade >= 0:
          LetterGrade = 'D';
          break;
        default:
          LetterGrade = 'F';
          break;
      }

      return LetterGrade;
    }

    public void ShowStatistics()
    {
      Console.WriteLine($"Lowest grade: {LowestGrade:N2}");
      Console.WriteLine($"Highest grade: {HighestGrade:N2}");
      Console.WriteLine($"Average grade: {AverageGrade:N2}");
      Console.WriteLine($"Letter grade: {LetterGrade}");
    }
  }
}
