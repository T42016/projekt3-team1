using System;
using System.Security.Cryptography.X509Certificates;
using MemoryLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeperLogic;

namespace userTest
{
    [TestClass]
    public class Constructor_Test
    {
        private MemoryGame _underTest;
        [TestInitialize]
        public void Setup()
        {
            _underTest = new MemoryGame(4, 4);
        }
        [TestMethod]
        public void ConstrutorShouldSetGamestateToPlayingAtStart()
        {
            //Arrange & Act
            var game = new MemoryGame(4, 4);

            //Assert
            Assert.AreEqual(game.State, GameState.Playing);
        }

        [TestMethod]
        public void ConstructorShouldCountNroFMoes()
        {
            //Arange
            MemoryGame game = new MemoryGame(5, 5);

            //Act
            game.ClickCoordinate(0, 0);
            game.ClickCoordinate(1, 0);

            //Assert
            Assert.AreEqual(game.Draws, 1);
        }


    }
}