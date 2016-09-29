using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using System.Text;

namespace Tests
{
    public class ComputerPlayerTests {
        private IList<int> moves = new List<int>();

        [Fact]
        public void blocksOpponentOnRow3x3() {
            Board board = new Board("oo-------", moves);
            Player computerPlayer = new ComputerPlayer('x');
            Player computerPlayer2 = new ComputerPlayer('o');
            Game game = new Game(board, computerPlayer, computerPlayer2, new ConsoleGame());
            game.playerMakeMove();
            Assert.Equal("oox------", game.board.board);
        }

        [Fact]
        public void blocksOpponentOnColumn3x3() {
            Board board = new Board("o--o-----", moves);
            Player computerPlayer = new ComputerPlayer('x');
            Player computerPlayer2 = new ComputerPlayer('o');
            Game game = new Game(board, computerPlayer, computerPlayer2, new ConsoleGame());
            game.playerMakeMove();
            Assert.Equal("o--o--x--", game.board.board);
        }

        [Fact]
        public void blocksOpponentOnDigonal3x3() {
            Board board = new Board("o---o----", moves);
            Player computerPlayer = new ComputerPlayer('x');
            Player computerPlayer2 = new ComputerPlayer('o');
            Game game = new Game(board, computerPlayer, computerPlayer2, new ConsoleGame());
            game.playerMakeMove();
            Assert.Equal("o---o---x", game.board.board);
        }
        
        [Fact]
        public void goesForWinOnRow3x3() {
            Board board = new Board("xx-------", moves);
            Player computerPlayer = new ComputerPlayer('x');
            Player computerPlayer2 = new ComputerPlayer('o');
            Game game = new Game(board, computerPlayer, computerPlayer2, new ConsoleGame());
            game.playerMakeMove();
            Assert.Equal("xxx------", game.board.board);
        }

        [Fact]
        public void goesForWinOnColumn3x3() {
            Board board = new Board("x--x-----", moves);
            Player computerPlayer = new ComputerPlayer('x');
            Player computerPlayer2 = new ComputerPlayer('o');
            Game game = new Game(board, computerPlayer, computerPlayer2, new ConsoleGame());
            game.playerMakeMove();
            Assert.Equal("x--x--x--", game.board.board);
        }

        [Fact]
        public void goesForWinOnDiagonal3x3() {
            Board board = new Board("x---x----", moves);
            Player computerPlayer = new ComputerPlayer('x');
            Player computerPlayer2 = new ComputerPlayer('o');
            Game game = new Game(board, computerPlayer, computerPlayer2, new ConsoleGame());
            game.playerMakeMove();
            Assert.Equal("x---x---x", game.board.board);
        }
    }
}