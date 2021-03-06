using System;
using System.IO;
using Xunit;
using System.Collections.Generic;

namespace Tests
{
    public class GameTests
    {
        private IList<int> moves;

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
            Board board = new Board("---------", moves);
            Game game = new Game(board, playerX(), playerO(), new ConsoleGame());
            game.playerMakeMove();
            Assert.Equal(game.board.board, "x--------");
        }

        [Fact]
        public void playerInactiveBecomesActiveAfterTurn() {
            Console.SetIn(new StringReader("1\n2"));
            Board board = new Board("---------", moves);
            Game game = new Game(board, playerX(), playerO(), new ConsoleGame());
            game.playerMakeMove();
            game.playerMakeMove();
            Assert.Equal("xo-------", game.board.board);
        }
    }
}