using System;
using System.IO;
using Xunit;
using System.Text;

namespace Tests
{
    public class HumanPlayerTests {
        [Fact]
        public void playerHasNextMove() {
            Console.SetIn(new StringReader("1"));
            Player human = new HumanPlayer('x');
            Game game = new Game(new Board("---------"), human, human, new ConsoleGame());
            Assert.Equal(1, human.nextMove(game));
        }

        [Fact]
        public void asksForMoveWhileGivenMoveIsInvalid() {
            Console.SetIn(new StringReader("x\n10\n3"));
            Player human = new HumanPlayer('x');
            Game game = new Game(new Board("---------"), human, human, new ConsoleGame());
            Assert.Equal(3, human.nextMove(game));
        }
    }
}
