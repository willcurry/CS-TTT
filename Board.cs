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

    private IEnumerable<string> getRows() {
        return from index in Enumerable.Range(0, dimension)
                                   select board.Substring(index * dimension, dimension);
    }

    private IList<string> getColumns() {
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

    private string getRightDiagonal() {
        string diagonal = "";
        for (int i=0; i < size; i+= dimension + 1) {
            diagonal += board[i];
        }
        return diagonal;
    }
    
    private string getLeftDiagonal() {
        string diagonal = "";
        for (int i=dimension -1; i < size - 1; i += dimension - 1) {
            diagonal += board[i];
        }
        return diagonal;
    }

    private IList<string> getDiagonals() {
        IList<string> diagonals = new List<string>();
        diagonals.Add(getRightDiagonal());
        diagonals.Add(getLeftDiagonal());
        return diagonals;
    }

    private IList<string> getWinningFormations() {
        IList<string> formations = new List<string>();
        foreach (string formation in getDiagonals()) formations.Add(formation);
        foreach (string formation in getRows()) formations.Add(formation);
        foreach (string formation in getColumns()) formations.Add(formation);
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
        foreach (string formation in getWinningFormations()) {
            if (!formation.Contains("-") && containsOnlySame(formation)) return true;
        }
        return false;
    }
}