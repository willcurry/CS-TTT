using System;
public class HumanPlayer : Player {
    private readonly char symbol;
    public HumanPlayer(char symbol) {
        this.symbol = symbol;
    }
    int Player.nextMove() {
        string userInput = Console.ReadLine();
        int position;
        int.TryParse(userInput, out position);
        return position;
    }

    char Player.symbol() {
        return symbol;
    }
}