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
        while (!board.hasFinished()) {
            gameType.displayBoard(board);
            playerMakeMove();
        }
        gameType.endGame(board);
    }

    private void askForGameMode() {
        int pick = gameType.pickGameMode();
        if (pick == 2) {
            playerInactive = new ComputerPlayer('o');
        } else if(pick == 3) {
            playerActive = new ComputerPlayer('x');
            playerInactive = new ComputerPlayer('o');
        } else if (pick == 4) {
            playerActive = new ComputerPlayer('x');
        }
    }

    private int playerNextMove() {
        return playerActive.nextMove(board);
    }

    public void playerMakeMove() {
        board = board.update(playerNextMove(), playerActive.symbol());
        switchPlayers();
    }

    private void switchPlayers() {
        Player tempPlayer = playerInactive;
        playerInactive = playerActive;
        playerActive = tempPlayer;
    }
}