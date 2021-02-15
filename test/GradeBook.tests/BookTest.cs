using System;
using Xunit;

namespace GradeBook.tests
{
    public class BookTest
    {
        [Fact]
        public void BookCalculatesStatistics()
        {
            // arrange 
            var book = new InMemoryBook();
            book.addGrade(90.0);
            book.addGrade(13.4);

            book.addGrade(84.9);

            // act 
            var result = book.GetStatistics();


            // assert 
            Assert.Equal(62.8, result.Average, 1);
            Assert.Equal(90.0, result.High, 1);
            Assert.Equal(13.4, result.Low, 1);



        }
    }
}
