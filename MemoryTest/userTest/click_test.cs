using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoryLogic;

namespace userTest
{
    [TestClass]
    public class click_test
    {
        [TestMethod]
        public void ClickCoordinateShouldOpenCoordinate()
        {
            //Arange
            MemoryGame game = new MemoryGame(5, 5);

            //Act
            game.ClickCoordinate(0, 0);

            //Assert
            Assert.AreEqual(true, game.GetCoordinate(0, 0).IsOpen);
        }

        [TestMethod]
        public void ClickCoordinateShouldFindMatch()
        {
            //Arange
            MemoryGame game = new MemoryGame(1, 2);

            //Act
            game.ClickCoordinate(0, 0);
            game.ClickCoordinate(0, 1);

            //Assert
            Assert.AreEqual(true, game.GetCoordinate(0, 0).IsFound);
        }
    }
}
