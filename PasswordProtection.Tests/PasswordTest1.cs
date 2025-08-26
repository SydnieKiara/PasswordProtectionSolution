using PasswordProtection;
using Xunit;


namespace PasswordProtection.Tests
{
    public class PasswordTest1
    {
        [Theory]
        [InlineData("", "INELIGIBLE")]             // empty
        [InlineData(" ", "INELIGIBLE")]            // space
        [InlineData("abcdef", "WEAK")]             // only lowercase
        [InlineData("ABCDEF", "WEAK")]             // only uppercase
        [InlineData("123456", "WEAK")]             // only digits
        [InlineData("!@#$%", "WEAK")]              // only symbols
        [InlineData("abc123", "MEDIUM")]           // lowercase + digits
        [InlineData("ABC123", "MEDIUM")]           // uppercase + digits
        [InlineData("abc!", "MEDIUM")]             // lowercase + symbol
        [InlineData("ABC!", "MEDIUM")]             // uppercase + symbol
        [InlineData("Ab1", "MEDIUM")]              // upper + lower + digit
        [InlineData("A1!", "MEDIUM")]              // upper + digit + symbol
        [InlineData("Ab!", "MEDIUM")]              // upper + lower + symbol
        [InlineData("a1!", "MEDIUM")]              // lower + digit + symbol
        [InlineData("Ab1!", "STRONG")]             // all criteria
        [InlineData("zZ9#", "STRONG")]             // all criteria
        public void Evaluate_GivenPassword_ReturnsCorrectStrength(string password, string expected)
        {
            var result = Password.Evaluate(password);
            Assert.Equal(expected, result);
        }
    }
}