using System.IO;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class Board {

    public readonly string board;
    public readonly int size;

    public Board(string board) {
        this.board = board;
        this.size = (int) Math.Sqrt(board.Length);
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

    public List<string> getAllRows() {
        List<string> rows = new List<string>();
        for (int i=0; i < board.Length; i+=size) {
            string row = "";
            for (int j=i; j < i + size; j++) {
                row += board[j];
            }
            rows.Add(row);
        }
        return rows;
    }

    public List<string> getAllColumns() {
        List<string> columns = new List<string>();
        for (int i=0; i < size; i++) {
            string column = "";
            for (int j=i; j < i + board.Length; j+= size) {
                column += board[j];
            }
            columns.Add(column);
        }
        return columns;
    }

    public Board update(int position, char symbol) {
        StringBuilder newBoard = new StringBuilder(board);
        newBoard[position - 1] = symbol;
        return new Board(newBoard.ToString());
    }
}