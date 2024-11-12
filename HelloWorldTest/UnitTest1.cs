


using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {


        //Harjoitus - Piirtelyä
        [Fact]
        [Trait("TestGroup", "ArtPrinting")]
        public void ArtPrinting()
        {


            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get the console output
            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Prepare expected multiplication table output
   
            // Assert that the correct prompt is shown
            Assert.False(string.IsNullOrEmpty(result[0]), "The first line should not be null or empty.");


            // Checks if line contains exactly three spaces followed by a single asterisk and then any amount of trailing spaces.
            Assert.True(Regex.IsMatch(result[0], @"^ {3}\*\s*$"));
            Assert.True(Regex.IsMatch(result[2], @"^ {3}\*\s*$"));

            // Checks if line contains exactly two spaces followed by three asterisks and any amount of trailing spaces.
            Assert.True(Regex.IsMatch(result[3], @"^ {2}\*{3}\s*$"));

            // Checks if line contains exactly one space followed by five asterisks and any amount of trailing spaces.
            Assert.True(Regex.IsMatch(result[4], @"^ {1}\*{5}\s*$"));

            // Checks if line starts with exactly seven asterisks and any amount of trailing spaces.
            Assert.True(Regex.IsMatch(result[5], @"^\*{7}\s*$"));

        }


        private bool CompareLines(string[] actualLines, string[] expectedLines)
        {
            if (actualLines.Length != expectedLines.Length)
            {
                return false;
            }

            for (int i = 0; i < actualLines.Length; i++)
            {
                if (actualLines[i] != expectedLines[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}


    

