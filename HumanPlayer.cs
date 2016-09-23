using System;
public class HumanPlayer : Player {
    
    private readonly char symbol;

    public HumanPlayer(char symbol) {
        this.symbol = symbol;
    }

    int Player.nextMove(Game game) {
        int move = getMove();
        while (!game.isValid(move)) {
            move = getMove();
        }
        return move;
    }

    char Player.symbol() {
        return symbol;
    }

    private int getMove() {
        string userInput = Console.ReadLine();
        int position;
        int.TryParse(userInput, out position);
        return position;
    }
}