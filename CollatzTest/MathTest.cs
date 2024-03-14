using Collatz.Services;

namespace CollatzTest
{
    public class MathTest
    {
        [Fact]
        public void CollatzOddParsesProperly()
        {
            int i = 20;
            var hasOddEdge = ((i - 1) % 3) == 0;
            Assert.False(hasOddEdge);
        }

        [Fact]
        public void Collatz2ParsesProperly()
        {
            int i = 2;
            var hasOddEdge = ((i - 1) % 3) == 0;
            Assert.False(hasOddEdge);
        }
    }
}