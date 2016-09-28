public interface GameType {
    void displayBoard(Board board);
    void displayGamemodes();
    int pickGameMode();
    void endGame(Board board);
}