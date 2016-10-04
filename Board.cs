using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public class Board {
    public string board {get; private set;}
    public int dimension {get; private set;}
    public int size {get; private set;}
    private IList<int> moves;

    public Board(string board, IList<int> moves) {
        this.board = board;
        this.dimension = (int) Math.Sqrt(board.Length);
        this.size = dimension * dimension;
        this.moves = moves;
    }

    private bool isAvailable(int position) {
        return board[position - 1] == '-';
    }

    private bool withinRange(int position) {
        return (position < 10 && position > 0);
    }

    public bool isValid(int position) {
        return withinRange(position) && isAvailable(position);
    }

    public IEnumerable<int> availablePositions() {
        return Enumerable.Range(0, size).Where(position => board[position] == '-');
    }

    private string getRow(int index) {
        for (int i=0; i < size; i+=dimension) {
            string row = getRowCells(i, index);
            if (row != "-") return row;
        }
        return "-";
    }

    private string getRowCells(int rowStart, int index) {
        string row = "";
        bool shouldReturn = false;
        for (int j=rowStart; j < rowStart + dimension; j++) {
            row += board[j];
            if (j == index) shouldReturn = true;
        }
        return shouldReturn ? row : "-";
    }

    private string getColumn(int index) {
        for (int i=0; i < dimension; i++) {
            string column = getColumnCells(i, index);
            if (column != "-") return column;
        }
        return "-";
    }

    private string getColumnCells(int columnStart, int index) {
        string column = "";
        bool shouldReturn = false;
        for (int j=columnStart; j < columnStart + size; j+= dimension) {
            column += board[j];
            if (j == index) shouldReturn = true; 
        }
        return shouldReturn ? column : "-";
    }

    private string getRightDiagonal(int index) {
        string diagonal = "";
        bool shouldReturn = false;
        for (int i=0; i < size; i+= dimension + 1) {
            diagonal += board[i];
            if (index == i) shouldReturn = true;
        }
        return shouldReturn ? diagonal : "-";
    }
    
    private string getLeftDiagonal(int index) {
        string diagonal = "";
        bool shouldReturn = false;
        for (int i=dimension -1; i < size - 1; i += dimension - 1) {
            diagonal += board[i];
            if (index == i) shouldReturn = true;
        }
        return shouldReturn ? diagonal : "-";
    }

    private IList<string> getDiagonals(int index) {
        IList<string> diagonals = new List<string>();
        diagonals.Add(getRightDiagonal(index));
        diagonals.Add(getLeftDiagonal(index));
        return diagonals;
    }

    private IList<string> getWinningFormations() {
        int index = moves[moves.Count - 1];
        IList<string> formations = new List<string>();
        foreach (string formation in getDiagonals(index)) formations.Add(formation);
        formations.Add(getRow(index));
        formations.Add(getColumn(index));
        return formations;
    }

    private bool containsOnlySame(string formation) {
        foreach (char position in formation) {
            if (formation[0] != position) return false;
        }
        return true;
    }

    public Board update(int position, char symbol) {
        StringBuilder newBoard = new StringBuilder(board);
        newBoard[position] = symbol;
        moves.Add(position);
        return new Board(newBoard.ToString(), moves);
    }

    public bool hasDraw() {
        return !board.Contains("-");
    }

    public char getWinner() {
        return board[moves[moves.Count - 1]];
    }

    public bool hasFinished() {
        return (isWon() || hasDraw());
    }

    public bool isWon() {
        if (moves.Count < dimension) return false;
        foreach (string formation in getWinningFormations()) {
            if (!formation.Contains("-") && containsOnlySame(formation)) return true;
        }
        return false;
    }
}