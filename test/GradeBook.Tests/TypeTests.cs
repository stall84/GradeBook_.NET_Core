using System;
using Xunit;

namespace GradeBook.Tests
{
    // We're going to create a Delegate type here to demonstrate.
    // It's a type that assocites variables with methods
    // This delegate will take in a string and return a string
    // Delegates can be very powerful in that you can assign a variable (like 'log' below)
    // and then have that variable point to multiple methods. 
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {   // Fact attribute used by test-runner to find test methods  https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test 
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;

            log = ReturnMessage;  // shorthand way of:  log = new WriteLogDelegate(ReturnMessage);

            var result = log("Hello");

            Assert.Equal("Hello", result);
        }
        // create local private method to take in a string (same type as Delegate we're checking) and return string
        string ReturnMessage(string message)
        {
            return message;
        }

        [Fact]
        public void DoWhileCheck()
        {
            Book bookCheck = new Book("Georgie's Asshole");
            bookCheck.AddGrade(98.1);
            bookCheck.AddGrade(77.5);
            bookCheck.AddGrade(73.2);

            var result = bookCheck.GetStatistics();

            Assert.Equal(73.2, result.Low, 1);
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Michael";
            string upper = MakeUppercase(name);


            Assert.Equal("Michael", name);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void IntsPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // Arrange Section
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            // Act-On or Actual Section


            // Assert Section
            Assert.Equal("New Name", book1.Name);
        }
        private void SetName(Book book, string name)
        {
            book.Name = name;        // re-changed setter to public so that name can be changed outside after instantiation

            // book.Name = name;     // This line of code  becomes invalid when we set the setter property on Name to private
        }                           // Meaning the book object name can no longer be altered after the initial instantiation 

        [Fact]
        public void CSharpIsPassByValue()
        {
            // Arrange Section

            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            // Act-On or Actual Section


            // Assert Section
            Assert.Equal("Book 1", book1.Name);
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            Console.WriteLine($"Book Name: {book.Name}");
        }
        [Fact]
        public void CSharpCANPassByReference()
        {
            // Arrange Section

            var book1 = GetBook("Book 1");
            // You also have to use the ref keyword in the invocation of the method. 
            // safety measure to make sure you want to modify the original object
            GetBookSetNameByRef(ref book1, "New Name");
            // Act-On or Actual Section


            // Assert Section
            Assert.Equal("New Name", book1.Name);
        }
        private void GetBookSetNameByRef(ref Book book, string name)
        {   // By adding a 'ref' keyword in front of the parameter we can force C# to pass the 
            // reference instead of the value
            book = new Book(name);
            Console.WriteLine($"Book Name: {book.Name}");
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // Arrange Section
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            // Act-On or Actual Section


            // Assert Section
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);

        }
        private Book GetBook(string name)
        {
            return new Book(name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // Arrange Section
            var book1 = GetBook("Book 1");
            var book2 = book1;
            // Act-On or Actual Section


            // Assert Section
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }



    }
}
