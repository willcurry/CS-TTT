using System;
public class Game {
    private Player playerActive;
    private Player playerInactive;
    public Board board {get; private set;}
    private readonly GameType gameType;

    public Game(Board board, Player playerActive, Player playerInactive, GameType gameType) {
        this.board = board;
        this.playerActive = playerActive;
        this.playerInactive = playerInactive;
        this.gameType = gameType;
    }

    public static void Main(string[] args) {
        Board board = new Board("---------");
        Game game = new Game(board, new HumanPlayer('x'), new HumanPlayer('o'), new ConsoleGame());
        game.start();
    }

    private void start() {
        askForGameMode();
        while (!board.isGameOver()) {
            gameType.displayBoard(board);
            playerMakeMove();
        }
        gameType.endGameMessage(board);
    }

    public void askForGameMode() {
        int pick = gameType.pickGameMode();
        if (pick == 2) {
            playerInactive = new ComputerPlayer('o');
        } else if(pick == 3) {
            playerActive = new ComputerPlayer('x');
            playerInactive = new ComputerPlayer('o');
        }
    }

    public int playerNextMove() {
        return playerActive.nextMove(this);
    }

    public void playerMakeMove() {
        board = board.update(playerNextMove(), playerActive.symbol());
        switchPlayers();
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