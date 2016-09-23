using System;
using System.IO;
using Xunit;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class BoardTests
    {
        [Fact]
        public void ThreeByThreeBoardIsCreated() {
            Board board = new Board("---------");
            Assert.Equal(board.board, "---------");
        }

        [Fact]
        public void boardIsUpdatedWithMove() {
            Board board = new Board("---------");
            Assert.Equal(board.update(1, 'x').board, "x--------");
        }

        [Fact]
        public void boardKnowsIfPositionIsAvailable() {
            Board board = new Board("-x-------");
            Assert.Equal(board.isAvailable(2), false);
        }

        [Fact]
        public void boardKnowsAllPositionsAvailable() {
            Board board = new Board("-xo-----x");
            int[] expectedArray = {1, 4, 5, 6, 7, 8};
            List<int> expected = expectedArray.ToList();
            Console.WriteLine(board.availablePositions() + " ! " + expected);
            Assert.Equal(board.availablePositions(), expected);
        }
    }
}