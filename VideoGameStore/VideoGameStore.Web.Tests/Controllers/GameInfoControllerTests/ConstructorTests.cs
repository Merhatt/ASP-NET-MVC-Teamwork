using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Services.Contracts;

namespace VideoGameStore.Web.Tests.Controllers.GameInfoControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void NullGameServices_ShouldThrow()
        {
            var gameServiceMock = new Mock<IGameServices>();

        }
    }
}
