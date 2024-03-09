using Collatz.Services;

namespace CollatzTest
{
    public class CollatzProcessorTest
    {
        [Theory]
        [InlineData(9,19,52)]
        [InlineData(1,0,1)]
        public void ComputesWithCorrectMetadata(long value, long steps, long max)
        {
            var list = CollatzProcessor.ComputeStatic(value);
            Assert.NotNull(list);
            Assert.Equal(steps, list.Count-1);
            Assert.Equal(max, list.Max());
        }
    }
}