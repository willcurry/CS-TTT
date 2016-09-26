using System;
public class ConsoleGame : GameType {
    private readonly Board board;

    public ConsoleGame(Board board) {
        this.board = board;
    }

    public void displayBoard() {
        Console.WriteLine(board.board.Substring(0,3));
        Console.WriteLine(board.board.Substring(3, 3));
        Console.WriteLine(board.board.Substring(6, 3));
        Console.WriteLine("───────────────────────────────────");
    }
    
    public void displayGamemodes() {
        Console.WriteLine("What game mode would you like play?");
        Console.WriteLine("1) Player vs Player");
        Console.WriteLine("2) Player vs Computer");
        Console.WriteLine("3) Computer vs Computer");
        Console.WriteLine("───────────────────────────────────");
    }

    public int pickGameMode() {
        displayGamemodes();
        int pick;
        int.TryParse(Console.ReadLine(), out pick);
        return pick;
    }
}