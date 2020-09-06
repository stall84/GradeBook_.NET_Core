using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
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
            book.Name = name;
        }

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
