public class Game {
    private Player playerActive;
    private Player playerInactive;
    private Board board;
    public Game(Board board, Player playerActive, Player playerInactive) {
        this.board = board;
        this.playerActive = playerActive;
        this.playerInactive = playerInactive;
    }
    public int playerNextMove() {
        return playerActive.nextMove();
    }
    public void playerMakeMove() {
        board = board.update(playerActive.nextMove(), playerActive.symbol());
        switchPlayers();
    }
    public Board getBoard() {
        return board;
    }
    public void switchPlayers() {
        var tempPlayer = playerInactive;
        playerInactive = playerActive;
        playerActive = tempPlayer;
    }
}