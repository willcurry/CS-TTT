using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class BoardTests
    {
        private IList<int> moves = new List<int>();
        [Fact]
        public void ThreeByThreeBoardIsCreated() {
            Board board = new Board("---------", moves);
            Assert.Equal(board.board, "---------");
        }

        [Fact]
        public void boardIsUpdatedWithMove() {
            Board board = new Board("x--------", moves);
            Assert.Equal(board.update(0, 'x').board, "x--------");
        }

        [Fact]
        public void boardKnowsIfPositionIsAvailable() {
            Board board = new Board("-x-------", moves);
            Assert.Equal(board.isValid(2), false);
        }

        [Fact]
        public void boardKnowsAllPositionsAvailable() {
            Board board = new Board("-xx-----o", moves);
            int[] expectedArray = {0, 3, 4, 5, 6, 7};
            List<int> expected = expectedArray.ToList();
            Assert.Equal(expected, board.availablePositions());
        }

        [Fact]
        public void canFindWinnerOnRow() {
            Board board = new Board("xxx------", moves);
            moves.Add(0);
            moves.Add(1);
            moves.Add(2);
            Assert.True(board.isWon());
        }

        [Fact]
        public void canFindWinnerOnColumn() {
            Board board = new Board("x--x--x--", moves);
            moves.Add(0);
            moves.Add(3);
            moves.Add(6);
            Assert.True(board.isWon());
        }

        [Fact]
        public void canFindWinnerOnDiagonal() {
            Board board = new Board("x---x---x", moves);
            moves.Add(0);
            moves.Add(4);
            moves.Add(8);
            Assert.True(board.isWon());
        }

        [Fact]
        public void knowsThereIsADraw() {
            Board board = new Board("xoooxxxoo", moves);
            Assert.True(board.hasDraw());
        }

        [Fact]
        public void knowsWhenGameIsOver() {
            Board board = new Board("xxx------", moves);
            moves.Add(0);
            moves.Add(1);
            moves.Add(2);
            Assert.True(board.hasFinished());
        }

        [Fact]
        public void knowsTheWinner() {
            moves.Add(5);
            Board board = new Board("---xxx---", moves);
            Assert.Equal('x', board.getWinner());
        }

        [Fact] 
        public void canValidatePositions() {
            Board board = new Board("x--------", moves);
            Assert.False(board.isValid(1));
            Assert.False(board.isValid(0));
            Assert.False(board.isValid(10));
        }
    }
}