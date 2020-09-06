using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalcsAvgGrade()
        {
            // Arrange Section
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            // Act-On or Actual Section
            var result = book.GetStatistics();

            // Assert Section
            Assert.Equal(85.6, result.Average, 1);      // Adding 3rd parameter of decimal place precision to avoid fail test on repeating float decimal
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}
