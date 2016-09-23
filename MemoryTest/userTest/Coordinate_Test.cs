using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoryLogic;

namespace userTest
{
    [TestClass]
    public class Coordinate_Test
    {
        private MemoryGame _underTest;

        [TestInitialize]
        public void Setup()
        {
            _underTest = new MemoryGame(4, 4);
        }

        [TestMethod]
        public void BoardGameShouldSetCorrectSize()
        {
            //Arrange & Act
            var game = new MemoryGame(4, 4);

            //Assert
            Assert.AreEqual(game.SizeX, 4);
            Assert.AreEqual(game.SizeY, 4);

        }

        [TestMethod]
        public void BoardGameShouldGetX()
        {
            //Arrange & Act
            var game = new MemoryGame(4, 4);

            //Assert
            Assert.AreEqual(game.SizeX, 4);
        }

        [TestMethod]
        public void BoardGameShouldGetY()
        {
            //Arrange & Act
            var game = new MemoryGame(4, 4);

            //Assert
            Assert.AreEqual(game.SizeY, 4);
        }

        [TestMethod]
        public void BoardGameShouldGetCorrectPositionX()
        {
            var coord = _underTest.GetCoordinate(2, 0);
            //Assert 
            Assert.AreEqual(coord.X, 2);
        }

        [TestMethod]
        public void BoardGameShouldGetCorrectPositionY()
        {
            //Arrange via setup
            //Act
            var coord = _underTest.GetCoordinate(0, 3);
            //Assert 
            Assert.AreEqual(coord.Y, 3);
        }

        [TestMethod]
        public void GetCoordinateShouldReturnValidCoord()
        {
            //Arrange via setup
            //Act
            var coord = _underTest.GetCoordinate(0, 0);
            //Assert 
            Assert.IsInstanceOfType(coord, typeof(PositionInfo));
        }

        [TestMethod]
        public void GetCoordinateShouldReturnPositionInfoWithCorrectXForValidCoordinate()
        {
            //Arrange via setup
            //Act
            var coord = _underTest.GetCoordinate(1, 0);
            //Assert 
            Assert.AreEqual(coord.X, 1);

        }
    }
}
