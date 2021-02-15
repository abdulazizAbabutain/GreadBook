using System;
using Xunit;

namespace GradeBook.tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTest
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {


            //Given

            //When

            //Then
        }

        [Fact]
        public void CsharpIsPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        [Fact]
        public void CsharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            // GetBookSetName(book1, "New Name");

            //Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, String name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        }

        [Fact]
        public void ConSetNameFromREference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, String name)
        {
            book.Name = name;
        }


        [Fact]
        public void GetBookREturnsDifferentObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            // diffrent ways to test if the objact is same to another objact  
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(String name)
        {
            return new InMemoryBook(name);

        }
    }
}
