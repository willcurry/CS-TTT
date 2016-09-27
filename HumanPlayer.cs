using System;
public class HumanPlayer : Player {

    private readonly char mark;

    public HumanPlayer(char mark) {
        this.mark = mark;
    }

    public int nextMove(Board board) {
        int move = getMove();
        while (!board.isValid(move)) {
            move = getMove();
        }
        return move - 1;
    }

    public char symbol() {
        return mark;
    }

    private int getMove() {
        string userInput = Console.ReadLine();
        int position;
        int.TryParse(userInput, out position);
        return position;
    }
}