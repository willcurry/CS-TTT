using System.IO;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class Board {
    public readonly string board;
    public readonly int dimension;
    public readonly int size;

    public Board(string board) {
        this.board = board;
        this.dimension = (int) Math.Sqrt(board.Length);
        this.size = dimension * dimension;
    }

    public bool isAvailable(int position) {
        return board[position - 1] == '-';
    }

    public IList<int> availablePositions() {
        IList<int> positions = new List<int>();
        for (int i=0; i < size; i++) {
            if (board[i] == '-') {
                positions.Add(i + 1);
            }
        }
        return positions;
    }

    public IList<string> getRows() {
        IList<string> rows = new List<string>();
        for (int i=0; i < size; i+=dimension) {
            string row = "";
            for (int j=i; j < i + dimension; j++) {
                row += board[j];
            }
            rows.Add(row);
        }
        return rows;
    }

    public IList<string> getColumns() {
        IList<string> columns = new List<string>();
        for (int i=0; i < dimension; i++) {
            string column = "";
            for (int j=i; j < i + size; j+= dimension) {
                column += board[j];
            }
            columns.Add(column);
        }
        return columns;
    }

    public string getRightDiagonal() {
        string diagonal = "";
        for (int i=0; i < size; i+= dimension + 1) {
            diagonal += board[i];
        }
        return diagonal;
    }
    
    public string getLeftDiagonal() {
        string diagonal = "";
        for (int i=dimension -1; i < size - 1; i += dimension - 1) {
            diagonal += board[i];
        }
        return diagonal;
    }

    public IList<string> getDiagonals() {
        IList<string> diagonals = new List<string>();
        diagonals.Add(getRightDiagonal());
        diagonals.Add(getLeftDiagonal());
        return diagonals;
    }

    public IList<string> getWinningFormations() {
        IList<string> formations = new List<string>();
        foreach (string formation in getDiagonals()) formations.Add(formation);
        foreach (string formation in getRows()) formations.Add(formation);
        foreach (string formation in getColumns()) formations.Add(formation);
        return formations;
    }

    public char findWinner() {
        foreach (string formation in getWinningFormations()) {
            if (containsOnlySame('x', formation)) {
                return 'x';
            } else if (containsOnlySame('o', formation)) {
                return 'o';
            }
        }
        return 'd';
    }

    public bool hasWinner() {
        return (findWinner() != 'd');
    }

    private bool containsOnlySame(char player, string formation) {
        foreach (char position in formation) {
            if (position != player) return false;
        }
        return true;
    }

    public bool hasDraw() {
        return (!board.Contains("-"));
    }

    public bool isGameOver() {
        return (hasWinner() || hasDraw());
    }

    public Board update(int position, char symbol) {
        StringBuilder newBoard = new StringBuilder(board);
        newBoard[position - 1] = symbol;
        return new Board(newBoard.ToString());
    }
}