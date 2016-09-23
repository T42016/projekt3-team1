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
        public void MoveCursorDownShouldNotMoveOutsideBoard()
        {
            //Arrange via Setup
            //Act
            _underTest.();
            _underTest.MoveCursorDown();
            _underTest.MoveCursorDown();
            //Assert
            Assert.AreEqual(2, _underTest.PosY);
        }


    }
}