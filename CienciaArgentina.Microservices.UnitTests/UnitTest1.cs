using System;
using Xunit;

namespace CienciaArgentina.Microservices.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            const bool test1 = true;
            Assert.True(test1);
        }

        public void Test2()
        {
            const bool test1 = false;
            Assert.True(test1);
        }
    }
}
