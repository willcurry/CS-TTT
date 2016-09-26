using System;
public class Game {
    private Player playerActive;
    private Player playerInactive;
    private Board board;

    public Game(Board board, Player playerActive, Player playerInactive) {
        this.board = board;
        this.playerActive = playerActive;
        this.playerInactive = playerInactive;
    }

    public static void Main(string[] args) {
        Board board = new Board("---------");
        Game game = new Game(board, new HumanPlayer('x'), new HumanPlayer('o'));
        game.start();
    }

    private void start() {
        pickGameMode();
        while (!board.isGameOver()) {
            displayBoard();
            playerMakeMove();
        }
    }

    public void displayGamemodes() {
        Console.WriteLine("What game mode would you like play?");
        Console.WriteLine("1) Player vs Player");
        Console.WriteLine("2) Player vs Computer");
        Console.WriteLine("3) Computer vs Computer");
        Console.WriteLine("───────────────────────────────────");
    }

    public void pickGameMode() {
        displayGamemodes();
        int pick;
        int.TryParse(Console.ReadLine(), out pick);
        if (pick == 2) {
            playerInactive = new ComputerPlayer('o');
        } else if(pick == 3) {
            playerActive = new ComputerPlayer('x');
            playerInactive = new ComputerPlayer('o');
        }
    }

    private void displayBoard() {
        Console.WriteLine(board.board.Substring(0,3));
        Console.WriteLine(board.board.Substring(3, 3));
        Console.WriteLine(board.board.Substring(6, 3));
        Console.WriteLine("───────────────────────────────────");
    }

    public int playerNextMove() {
        return playerActive.nextMove(this);
    }

    public void playerMakeMove() {
        board = board.update(playerNextMove(), playerActive.symbol());
        switchPlayers();
    }

    public Board getBoard() {
        return board;
    }
    
    public void switchPlayers() {
        Player tempPlayer = playerInactive;
        playerInactive = playerActive;
        playerActive = tempPlayer;
    }
    
    private bool withinRange(int position) {
        return (position < 10 && position > 0);
    }

    private bool isAvailable(int position) {
        return board.isAvailable(position);
    }

    public bool isValid(int position) {
        return withinRange(position) && isAvailable(position);
    }
}