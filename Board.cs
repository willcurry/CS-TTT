using System.IO;
using System;
using System.Text;

public class Board {

    public readonly string board;

    public Board(string board) {
        this.board = board;
    }

    public bool isAvailable(int position) {
        return board[position - 1] == '-';
    }

    public Board update(int position, char symbol) {
        StringBuilder newBoard = new StringBuilder(board);
        newBoard[position - 1] = symbol;
        return new Board(newBoard.ToString());
    }
}