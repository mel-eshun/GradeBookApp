using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main()
    {

      var book = new Book
      {
        Name = "The Archer"
      };

      book.AddGrade(72.25);
      book.AddGrade(90.8);
      book.AddGrade(50.57);
      book.AddGrade(59.0);

      book.ShowStatistics();
    }
  }
}
