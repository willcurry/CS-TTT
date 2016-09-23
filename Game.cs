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
    
    public bool isValid(int position) {
        return (position < 10 && position > 0);
    }
}