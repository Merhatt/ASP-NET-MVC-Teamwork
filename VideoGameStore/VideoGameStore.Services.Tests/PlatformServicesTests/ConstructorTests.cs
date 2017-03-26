﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Services.Tests.PlatformServicesTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void NullRepository_ShouldThrow()
        {
            //Arrange & Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => new PlatformServices(null));

            Assert.AreEqual("repository cannot be null", msg.Message);
        }
    }
}
