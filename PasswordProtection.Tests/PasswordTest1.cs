using PasswordProtection;
using Xunit;
using static PasswordProtection.Password;


namespace PasswordProtection.Tests
{
    public class PasswordTest1
    {
        [Theory]
        [InlineData("", "INELIGIBLE")]                 // empty
        [InlineData(" ", "INELIGIBLE")]                // space
        [InlineData("abcdef", "INELIGIBLE")]           // only lowercase, too short
        [InlineData("ABCDEF", "INELIGIBLE")]           // only uppercase, too short
        [InlineData("123456", "INELIGIBLE")]           // only digits, too short
        [InlineData("!@#$%", "INELIGIBLE")]            // only symbols, too short
        [InlineData("abcdefgh", "WEAK")]               // only lowercase, meets length
        [InlineData("ABCDEFGH", "WEAK")]               // only uppercase, meets length
        [InlineData("12345678", "WEAK")]               // only digits, meets length
        [InlineData("!!!!!!!!", "WEAK")]               // only symbols, meets length
        [InlineData("abc12345", "MEDIUM")]             // lowercase + digits
        [InlineData("ABC12345", "MEDIUM")]             // uppercase + digits
        [InlineData("abc!defg", "MEDIUM")]             // lowercase + symbol
        [InlineData("ABC!DEFG", "MEDIUM")]             // uppercase + symbol
        [InlineData("Abc12345", "MEDIUM")]             // upper + lower + digit
        [InlineData("A1!aaaaa", "STRONG")]             // upper + digit + symbol
        [InlineData("Ab!aaaaa", "MEDIUM")]             // upper + lower + symbol
        [InlineData("a1!aaaaa", "MEDIUM")]             // lower + digit + symbol
        [InlineData("Abc123!@5", "STRONG")]             // all criteria
        [InlineData("zZ9#xxxxx", "STRONG")]             // all criteria
        public void Evaluate_GivenPassword_ReturnsCorrectStrength(string password, string expected)
        {
            var result = Password.Evaluate(password);
            Assert.Equal(expected, result);
        }

        public class UuidGeneratorTests
        {

            /// <summary>
            /// Generates a version 4 UUID using random values.
            /// A version 4 UUID is defined by RFC 4122 and has the format xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx
            /// where '4' indicates version 4, and 'y' indicates one of 8, 9, A, or B.
            /// </summary>
            /// <returns>A string representation of the generated UUID (version 4).</returns>


            [Fact]
            public void GenerateV4_ReturnsValidUuid()
            {
                var uuid = UuidGenerator.GenerateV4();

                // Check not null or empty
                Assert.False(string.IsNullOrEmpty(uuid));

                // Check valid GUID format
                Assert.True(Guid.TryParse(uuid, out Guid parsed));

                // Check version 4 (the 13th hex digit should be '4')
                string hex = uuid.Replace("-", "");
                Assert.Equal('4', hex[12]);
            }


        }
}
