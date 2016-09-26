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
            Assert.Equal(board.availablePositions(), expected);
        }

        [Fact]
        public void boardKnowsAllRows() {
            Board board = new Board("xx--oo---");
            string[] expectedArray = {"xx-", "-oo", "---"};
            List<string> expected = expectedArray.ToList();
            Assert.Equal(board.getRows(), expected);
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
        public void boardCanFindWinnerOnRow() {
            Board board = new Board("xxx------");
            Assert.Equal('x', board.findWinner());
        }

        [Fact]
        public void boardCanFindWinnerOnColumn() {
            Board board = new Board("x--x--x--");
            Assert.Equal('x', board.findWinner());
        }

        [Fact]
        public void boardCanFindWinnerOnDiagonal() {
            Board board = new Board("x---x---x");
            Assert.Equal('x', board.findWinner());
        }

        [Fact]
        public void boardKnowsThereIsADraw() {
            Board board = new Board("oxxxoxoox");
            Assert.True(board.hasDraw());
        }

        [Fact]
        public void boardKnowsWhenGameIsOver() {
            Board board = new Board("xxx------");
            Assert.True(board.hasWinner());
        }
    }
}