using System;
using System.IO;
using Xunit;
using System.Text;

namespace Tests
{
    public class HumanPlayerTests {
        [Fact]
        public void playerHasNextMoveAndIsDecreased() {
            Console.SetIn(new StringReader("1"));
            Player human = new HumanPlayer('x');
            Board board = new Board("---------");
            Game game = new Game(board, human, human, new ConsoleGame());
            Assert.Equal(0, human.nextMove(board));
        }

        [Fact]
        public void asksForMoveWhileGivenMoveIsInvalid() {
            Console.SetIn(new StringReader("x\n10\n3"));
            Player human = new HumanPlayer('x');
            Board board = new Board("---------");
            Game game = new Game(board, human, human, new ConsoleGame());
            Assert.Equal(2, human.nextMove(board));
        }
    }
}
