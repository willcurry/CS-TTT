using System;

public class ComputerPlayer : Player {
    private readonly char mark;

    public ComputerPlayer(char mark) {
        this.mark = mark;
    }

    public int nextMove(Game game) {
        return minimax(8, Int32.MinValue, Int32.MaxValue, game.getBoard(), mark).getMove();
    }

    public char symbol() {
        return mark;
    }

    private ScoredMove minimax(int depth, int alpha, int beta, Board board, char player) {
        ScoredMove bestMove = resetBestScore(player);
        if (board.isGameOver() || depth == 0) {
            return new ScoredMove(score(board, depth), bestMove.getScore(), this);
        }
        foreach (int position in board.availablePositions()) {
            Board newBoard = board.update(position, player);
            ScoredMove score = minimax(depth - 1, alpha, beta, newBoard, player == 'x' ? 'o' : 'x');
            bestMove = updateScore(player, bestMove, position, score);
            if (player == mark) {
                alpha = Math.Max(alpha, bestMove.getScore());
            } else {
                beta = Math.Min(beta, bestMove.getScore());
            }
            if (alpha >= beta) break;
        }
        return bestMove;
    }

    private ScoredMove updateScore(char player, ScoredMove currentBestMove, int position, ScoredMove score) {
        if (score.isBetter(currentBestMove, player)) {
            currentBestMove = new ScoredMove(score.getScore(), position, this);
        }
        return currentBestMove;
    }

    public int score(Board board, int moves) {
        if (board.findWinner() == mark) {
            return moves;
        }
        if (board.hasDraw()){
            return 0;
        }
        return -moves;
    }

    private ScoredMove resetBestScore(char player) {
        int bestMove = -1;
        if (player == mark) {
            return new ScoredMove(-1000, bestMove, this);
        } else {
            return new ScoredMove(1000, bestMove, this);
        }
    }


    private class ScoredMove {
        private readonly int score;
        private readonly int move;
        private readonly ComputerPlayer computerPlayer;

        public ScoredMove(int score, int move, ComputerPlayer computerPlayer) {
            this.score = score;
            this.move = move;
            this.computerPlayer = computerPlayer;
        }

        public int getScore() {
            return score;
        }

        public int getMove() {
            return move;
        }

        public bool isBetter(ScoredMove scoredMove, char player) {
            return (player == computerPlayer.mark && score > scoredMove.score) || (player != computerPlayer.mark && score < scoredMove.score);
        }
    }
}