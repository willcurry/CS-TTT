using System.IO;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class Board {

    public readonly string board;

    public Board(string board) {
        this.board = board;
    }

    public bool isAvailable(int position) {
        return board[position - 1] == '-';
    }

    public List<int> availablePositions() {
        List<int> positions = new List<int>();
        for (int i=0; i < board.Length; i++) {
            if (board[i] == '-') {
                positions.Add(i + 1);
            }
        }
        return positions;
    }

    public Board update(int position, char symbol) {
        StringBuilder newBoard = new StringBuilder(board);
        newBoard[position - 1] = symbol;
        return new Board(newBoard.ToString());
    }
}