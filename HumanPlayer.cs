using System;
public class HumanPlayer : Player {
    private readonly char symbol;
    public HumanPlayer(char symbol) {
        this.symbol = symbol;
    }
    int Player.nextMove() {
        return getMove();
    }

    char Player.symbol() {
        return symbol;
    }

    private int getMove() {
        string userInput = Console.ReadLine();
        int position;
        int.TryParse(userInput, out position);
        if (isValid(position)) {
            return position;
        }
        return getMove();
    }

    private bool isValid(int position) {
        return (position < 10 && position > 0);
    }
}