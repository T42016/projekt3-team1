using System;
using MemoryLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeperLogic;

namespace userTest
{
    [TestClass]
    public class Constructor_Test
    {
        [TestMethod]
        public void ConstrutorShouldSetGamestateToPlayingAtStart()
        {
            //Arrange & Act
            var game = new MemoryGame(4, 4);

            //Assert
            Assert.AreEqual(game.State, GameState.Playing);
        }
    }
}
