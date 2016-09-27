using System;
using System.IO;
using Xunit;
using System.Text;

namespace Tests
{
    public class ComputerPlayerTests {
        [Fact]
        public void blocksOpponentOnRow3x3() {
            Board board = new Board("oo-------");
            Player computerPlayer = new ComputerPlayer('x');
            Player computerPlayer2 = new ComputerPlayer('o');
            Game game = new Game(board, computerPlayer, computerPlayer2, new ConsoleGame());
            game.playerMakeMove();
            Assert.Equal("oox------", game.getBoard().board);
        }

        [Fact]
        public void blocksOpponentOnColumn3x3() {
            Board board = new Board("o--o-----");
            Player computerPlayer = new ComputerPlayer('x');
            Player computerPlayer2 = new ComputerPlayer('o');
            Game game = new Game(board, computerPlayer, computerPlayer2, new ConsoleGame());
            game.playerMakeMove();
            Assert.Equal("o--o--x--", game.getBoard().board);
        }

        [Fact]
        public void blocksOpponentOnDigonal3x3() {
            Board board = new Board("o---o----");
            Player computerPlayer = new ComputerPlayer('x');
            Player computerPlayer2 = new ComputerPlayer('o');
            Game game = new Game(board, computerPlayer, computerPlayer2, new ConsoleGame());
            game.playerMakeMove();
            Assert.Equal("o---o---x", game.getBoard().board);
        }
        
        [Fact]
        public void goesForWinOnRow3x3() {
            Board board = new Board("xx-------");
            Player computerPlayer = new ComputerPlayer('x');
            Player computerPlayer2 = new ComputerPlayer('o');
            Game game = new Game(board, computerPlayer, computerPlayer2, new ConsoleGame());
            game.playerMakeMove();
            Assert.Equal("xxx------", game.board.board);
        }

        [Fact]
        public void goesForWinOnColumn3x3() {
            Board board = new Board("x--x-----");
            Player computerPlayer = new ComputerPlayer('x');
            Player computerPlayer2 = new ComputerPlayer('o');
            Game game = new Game(board, computerPlayer, computerPlayer2, new ConsoleGame());
            game.playerMakeMove();
            Assert.Equal("x--x--x--", game.board.board);
        }

        [Fact]
        public void goesForWinOnDiagonal3x3() {
            Board board = new Board("x---x----");
            Player computerPlayer = new ComputerPlayer('x');
            Player computerPlayer2 = new ComputerPlayer('o');
            Game game = new Game(board, computerPlayer, computerPlayer2, new ConsoleGame());
            game.playerMakeMove();
            Assert.Equal("x---x---x", game.getBoard().board);
        }
    }
}