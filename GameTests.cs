using System;
using System.IO;
using Xunit;
using System.Text;

namespace Tests
{
    public class GameTests
    {
        private Player playerX() {
            Player playerX = new HumanPlayer('x');
            return playerX;
        }
        private Player playerO() {
            Player playerO = new HumanPlayer('o');
            return playerO;
        } 

        [Fact]
        public void gameKnowsPlayersNextMove() {
            Console.SetIn(new StringReader("1"));
            Board board = new Board("---------");
            Game game = new Game(board, playerX(), playerO(), new ConsoleGame());
            Assert.Equal(1, game.playerNextMove());
        }

        [Fact]
        public void playerInactiveBecomesActiveAfterTurn() {
            Console.SetIn(new StringReader("1\n2"));
            Board board = new Board("---------");
            Game game = new Game(board, playerX(), playerO(), new ConsoleGame());
            game.playerMakeMove();
            game.playerMakeMove();
            Assert.Equal("xo-------", game.board.board);
        }

        [Fact]
        public void canFindWinnerOnRow() {
            Board board = new Board("xxx------");
            Game game = new Game(board, playerX(), playerO(), new ConsoleGame());
            Assert.True(board.isWon());
        }

        [Fact]
        public void canFindWinnerOnColumn() {
            Board board = new Board("x--x--x--");
            Game game = new Game(board, playerX(), playerO(), new ConsoleGame());
            Assert.True(board.isWon());
        }

        [Fact]
        public void canFindWinnerOnDiagonal() {
            Board board = new Board("x---x---x");
            Game game = new Game(board, playerX(), playerO(), new ConsoleGame());
            Assert.True(board.isWon());
        }

        [Fact]
        public void knowsThereIsADraw() {
            Board board = new Board("oxxxoxoox");
            Game game = new Game(board, playerX(), playerO(), new ConsoleGame());
            Assert.True(board.hasDraw());
        }

        [Fact]
        public void knowsWhenGameIsOver() {
            Board board = new Board("xxx------");
            Game game = new Game(board, playerX(), playerO(), new ConsoleGame());
            Assert.True(board.hasFinished());
        }

        [Fact]
        public void knowsTheWinner() {
            Board board = new Board("xxx------");
            Game game = new Game(board, playerX(), playerO(), new ConsoleGame());
            Assert.Equal('x', board.getWinner());
        }
    }
}