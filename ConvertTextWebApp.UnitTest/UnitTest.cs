using System;
using System.Text;
using System.Threading.Tasks;
using ConvertTextWebApp.Business.Hubs;
using ConvertTextWebApp.Business.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ConvertTextWebApp.UnitTest
{
    public class UnitTest
    {
        [Fact]
        public async Task Encode_Success()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<EncodingService>>();
            var mockClients = new Mock<IHubClients>();
            var mockContext = new Mock<IHubContext<EncodeHub>>();
            mockContext.Setup(x => x.Clients).Returns(mockClients.Object);

            var encodingService = new EncodingService(mockContext.Object, mockLogger.Object);

            // Act
            var result = await encodingService.Encode("Hello, World!");

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
            Assert.Equal("SGVsbG8sIFdvcmxkIQ==", result);
        }
    }
}