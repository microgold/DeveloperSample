using System;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Equal(24, Algorithms.GetFactorial(4));
        }

        [Fact]
        public void FactorialOfZero()
        {
            Assert.Equal(1, Algorithms.GetFactorial(0));
        }

        [Fact]
        public void FactorialOfOne()
        {
            Assert.Equal(1, Algorithms.GetFactorial(1));
        }

        [Fact]
        public void FactorialOfNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() => Algorithms.GetFactorial(-1));
        }



        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
        }

        [Fact]
        public void FormatTwoSeparators()
        {
            Assert.Equal("a and b", Algorithms.FormatSeparators("a", "b"));
        }

        [Fact]
        public void FormatSingleSeparator()
        {
            Assert.Equal("a", Algorithms.FormatSeparators("a"));
        }

        [Fact]
        public void FormatNoSeparators()
        {
            Assert.Equal(string.Empty, Algorithms.FormatSeparators());
        }

        [Fact]
        public void FormatMultipleSeparators()
        {
            Assert.Equal("a, b, c, d and e", Algorithms.FormatSeparators("a", "b", "c", "d", "e"));
        }

        [Fact]
        public void FormatNullSeparators()
        {
            Assert.Equal(string.Empty, Algorithms.FormatSeparators(null));
        }


    }
}