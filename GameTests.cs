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
    }
}