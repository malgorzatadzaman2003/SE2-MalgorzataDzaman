using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xunit;

namespace SE2_1
{
    public class CalcTests
    {
        private readonly Calculator _calculator;

        public CalcTests()
        {
            _calculator = new Calculator();
        }
        [Fact]
        public void Process_EmptyString_ReturnsZero()
        {
            var result = _calculator.Process("");
            Assert.Equal(0, result);
        }
        [Fact]
        public void Process_SingleNumber_ReturnsTheValue()
        {
            var result = _calculator.Process("5");
            Assert.Equal(5, result);
        }

        [Fact]
        public void Process_TwoNumbersCommaDelimited_ReturnsSum()
        {
            var result = _calculator.Process("1,2");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Process_TwoNumbersNewlineDelimited_ReturnsSum()
        {
            var result = _calculator.Process("1\n2");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Process_ThreeNumbersDelimited_ReturnsSum()
        {
            var result = _calculator.Process("1,2\n3");
            Assert.Equal(6, result);
        }

        [Fact]
        public void Process_NegativeNumbers_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentException>(() => _calculator.Process("-1,2"));
            Assert.Equal("Negative numbers not allowed: -1", exception.Message);
        }

        [Fact]
        public void Process_NumberGreaterThan2000_IsIgnored()
        {
            var result = _calculator.Process("100,2001,50");
            Assert.Equal(150, result); // 2001 should be ignored
        }

        [Fact]
        public void Process_SingleCharacterDelimiter_ReturnsSum()
        {
            var result = _calculator.Process("//#\n2#5");
            Assert.Equal(7, result);
        }

        [Fact]
        public void Process_MultiCharacterDelimiter_ReturnsSum()
        {
            var result = _calculator.Process("//[###]\n2###5");
            Assert.Equal(7, result);
        }

        [Fact]
        public void Process_ManyDelimiters_ReturnsSum()
        {
            var result = _calculator.Process("//[###][abc]\n2###5abc3");
            Assert.Equal(10, result);
        }

        [Fact]
        public void Process_IgnoreNumbersGreaterThan2000WithDelimiters()
        {
            var result = _calculator.Process("//[###]\n2###2001###5");
            Assert.Equal(7, result); // 2001 should be ignored
        }


    }
}
