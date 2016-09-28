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
            Assert.Equal(board.update(0, 'x').board, "x--------");
        }

        [Fact]
        public void boardKnowsIfPositionIsAvailable() {
            Board board = new Board("-x-------");
            Assert.Equal(board.isAvailable(2), false);
        }

        [Fact]
        public void boardKnowsAllPositionsAvailable() {
            Board board = new Board("-xo-----x");
            int[] expectedArray = {0, 3, 4, 5, 6, 7};
            List<int> expected = expectedArray.ToList();
            Assert.Equal(expected, board.availablePositions());
        }

        [Fact]
        public void boardKnowsAllRows() {
            Board board = new Board("xx--oo---");
            string[] expectedArray = {"xx-", "-oo", "---"};
            List<string> expected = expectedArray.ToList();
            Assert.Equal(expected, board.rows());
        }

        [Fact]
        public void boardKnowsAllColumns() {
            Board board = new Board("xx--oo---");
            string[] expectedArray = {"x--", "xo-", "-o-"};
            List<string> expected = expectedArray.ToList();
            Assert.Equal(board.getColumns(), expected);
        }

        [Fact]
        public void boardKnowsAllDiagonals() {
            Board board = new Board("x-o-oox-x");
            string[] expectedArray = {"xox", "oox"};
            List <string> expected = expectedArray.ToList();
            Assert.Equal(expected, board.getDiagonals());
        }

        [Fact]
        public void canFindWinnerOnRow() {
            Board board = new Board("xxx------");
            Assert.True(board.isWon());
        }

        [Fact]
        public void canFindWinnerOnColumn() {
            Board board = new Board("x--x--x--");
            Assert.True(board.isWon());
        }

        [Fact]
        public void canFindWinnerOnDiagonal() {
            Board board = new Board("x---x---x");
            Assert.True(board.isWon());
        }

        [Fact]
        public void knowsThereIsADraw() {
            Board board = new Board("oxxxoxoox");
            Assert.True(board.hasDraw());
        }

        [Fact]
        public void knowsWhenGameIsOver() {
            Board board = new Board("xxx------");
            Assert.True(board.hasFinished());
        }

        [Fact]
        public void knowsTheWinner() {
            Board board = new Board("xxx------");
            Assert.Equal('x', board.getWinner());
        }

        [Fact] 
        public void canValidatePositions() {
            Board board = new Board("xx-------");
            Assert.False(board.isValid(1));
            Assert.False(board.isValid(0));
            Assert.False(board.isValid(10));
        }
    }
}