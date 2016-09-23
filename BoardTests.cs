﻿using System;
using System.IO;
using Xunit;
using System.Text;

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
    }
}