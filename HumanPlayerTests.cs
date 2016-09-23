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
            Assert.Equal(1, human.nextMove());
        }
    }
}
