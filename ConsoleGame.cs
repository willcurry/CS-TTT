using System;
public class ConsoleGame : GameType {
    public void displayBoard(Board board) {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        int count = 1;
        foreach (string row in board.getRows()) {
            Console.WriteLine(row);
            rowSeperator(count++);
        }
        displayLine();
    }
    
    public void displayGamemodes() {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("What game mode would you like play?");
        Console.WriteLine("1) Player vs Player");
        Console.WriteLine("2) Player vs Computer");
        Console.WriteLine("3) Computer vs Computer");
        Console.WriteLine("4) Computer vs Player");
        displayLine();
    }

    private void rowSeperator(int number) {
        Console.WriteLine("────" + number);
    }

    private void displayLine() {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("───────────────────────────────────");
        Console.ResetColor(); 
    }

    public void endGame(Board board) {
        displayBoard(board);
        if (board.isWon()) Console.WriteLine(board.getWinner() + " has won the game!");
        else Console.WriteLine("The game is a draw!");
    }

    public int pickGameMode() {
        displayGamemodes();
        int pick;
        int.TryParse(Console.ReadLine(), out pick);
        return pick;
    }
}