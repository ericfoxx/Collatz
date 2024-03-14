using Collatz.Services;

namespace CollatzTest
{
    public class CollatzProcessorTest
    {
        [Theory]
        [InlineData(9,19,52)]
        [InlineData(1,0,1)]
        public void ComputesWithCorrectMetadata(int value, int steps, int max)
        {
            var list = CollatzProcessor.ComputeStatic(value);
            Assert.NotNull(list);
            Assert.Equal(steps, list.Steps);
            Assert.Equal(max, list.Max);
        }

        [Fact]
        public void AscendsTo2Correctly()
        {
            // Arrange
            var processor = new CollatzProcessor(2);

            // Act
            processor.AscendGraph();
            var graph = processor.CollatzGraph;
            var indexedVertices = graph.Vertices.Count;

            // Assert
            Assert.NotNull(graph);
            Assert.Equal(2, indexedVertices);
            Assert.Equal(2, graph.Vertices[1].UpEdgeEven);
            Assert.Equal(1, graph.Vertices[2].DownEdge);
        }

        [Fact]
        public void AscendsTo4Correctly()
        {
            // Arrange
            var maxN = 4;
            var processor = new CollatzProcessor(maxN);

            // Act
            processor.AscendGraph();
            var graph = processor.CollatzGraph;
            var indexedVertices = graph.Vertices.Count;

            // Assert
            Assert.NotNull(graph);
            Assert.Equal(4, indexedVertices);
            Assert.Equal(2, graph.Vertices[4].DownEdge);
            Assert.Equal(4, graph.Vertices[2].UpEdgeEven);
        }

        [Fact]
        public void AscendsTo16Correctly()
        {
            // Arrange
            var maxN = 16;
            var processor = new CollatzProcessor(maxN);

            // Act
            processor.AscendGraph();
            var graph = processor.CollatzGraph;
            var indexedVertices = graph.Vertices.Count;

            // Assert
            Assert.NotNull(graph);
            Assert.Equal(16, indexedVertices);
            Assert.Equal(8, graph.Vertices[16].DownEdge);
            Assert.Equal(5, graph.Vertices[16].UpEdgeOdd);
        }
    }
}