using System;

public class ComputerPlayer : Player {
    private readonly char mark;

    public ComputerPlayer(char mark) {
        this.mark = mark;
    }

    public int nextMove(Board board) {
        System.Threading.Thread.Sleep(1000);
        return minimax(8, Int32.MinValue, Int32.MaxValue, board, mark).move;
    }


    public char symbol() {
        return mark;
    }

    private ScoredMove minimax(int depth, int alpha, int beta, Board board, char player) {
        ScoredMove bestMove = resetBestScore(player);
        if (board.hasFinished() || depth == 0) {
            return new ScoredMove(score(board, depth), bestMove.score, this);
        }
        foreach (int position in board.availablePositions()) {
            Board newBoard = board.update(position, player);
            ScoredMove score = minimax(depth - 1, alpha, beta, newBoard, player == 'x' ? 'o' : 'x');
            bestMove = updateScore(player, bestMove, position, score);
            if (player == mark) {
                alpha = Math.Max(alpha, bestMove.score);
            } else {
                beta = Math.Min(beta, bestMove.score);
            }
            if (alpha >= beta) break;
        }
        return bestMove;
    }

    private ScoredMove updateScore(char player, ScoredMove currentBestMove, int position, ScoredMove score) {
        if (score.isBetter(currentBestMove, player)) {
            currentBestMove = new ScoredMove(score.score, position, this);
        }
        return currentBestMove;
    }

    private int score(Board board, int moves) {
        if (board.isWon() && board.getWinner() == mark) {
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
        public int move {get; private set;}
        private readonly ComputerPlayer computerPlayer;
        public int score {get; private set;}

        public ScoredMove(int score, int move, ComputerPlayer computerPlayer) {
            this.move = move;
            this.computerPlayer = computerPlayer;
            this.score = score;
        }

        public bool isBetter(ScoredMove scoredMove, char player) {
            return (player == computerPlayer.mark && score > scoredMove.score) || (player != computerPlayer.mark && score < scoredMove.score);
        }
    }
}