using System;
using Xunit;

namespace GradeBook.Test
{

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {

        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count += 1;
            return message;
        }
        string ReturnMessage(string message)
        {
            count += 1;
            return message;
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            //Arange
            var x = GetInt();
            
            //Act
            SetInt(ref x);

            //Assert
            Assert.Equal(x, 42);
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
        public void CSharpCanPassByRef()
        {
            //Arange
            var book1 = GetBook("Book 1");

            //Act
            GetBookSetName(out book1, "New Name");

            //Assert
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(out Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            //Arange
            var book1 = GetBook("Book 1");

            //Act
            GetBookSetName(book1, "New Name");

            //Assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //Arange
            var book1 = GetBook("Book 1");

            //Act
            SetName(book1, "New Name");

            //Assert
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void StringBehavesLikeValueTypes()
        {
            //Arange
            string name = "String";

            //Act
            var upper =  MakeUpperCase(name);

            
            //Assert
            Assert.Equal("String", name);
            Assert.Equal("STRING", upper);
        }

        private string MakeUpperCase(string parameter)
        {
           return parameter.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //Arange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //Act
           
            //Assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TwoVariblesCanReferenceSameObject()
        {
            //Arange
            var book1 = GetBook("Book 1");
            
            //Act
            var book2 = book1;

            //Assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }


        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
