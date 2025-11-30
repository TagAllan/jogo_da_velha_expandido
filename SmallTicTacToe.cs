namespace JogoDaVelhaExpandido
{
    /// <summary>
    /// Representa um jogo da velha pequeno (3x3) dentro de um quadrante do jogo grande
    /// </summary>
    public class SmallTicTacToe
    {
        private char[,] board;
        private char winner;
        private bool isCompleted;

        public SmallTicTacToe()
        {
            board = new char[3, 3];
            winner = ' ';
            isCompleted = false;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        /// <summary>
        /// Tenta fazer uma jogada na posição especificada
        /// </summary>
        public bool MakeMove(int row, int col, char symbol)
        {
            if (isCompleted || row < 0 || row >= 3 || col < 0 || col >= 3)
            {
                return false;
            }

            if (board[row, col] != ' ')
            {
                return false;
            }

            board[row, col] = symbol;
            CheckWinner();
            return true;
        }

        /// <summary>
        /// Verifica se há um vencedor no jogo pequeno
        /// </summary>
        private void CheckWinner()
        {
            // Verifica linhas
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    winner = board[i, 0];
                    isCompleted = true;
                    return;
                }
            }

            // Verifica colunas
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] != ' ' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                {
                    winner = board[0, j];
                    isCompleted = true;
                    return;
                }
            }

            // Verifica diagonal principal
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                winner = board[0, 0];
                isCompleted = true;
                return;
            }

            // Verifica diagonal secundária
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                winner = board[0, 2];
                isCompleted = true;
                return;
            }

            // Verifica se o tabuleiro está cheio (empate)
            bool isFull = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        isFull = false;
                        break;
                    }
                }
                if (!isFull) break;
            }

            if (isFull)
            {
                isCompleted = true;
                winner = 'T'; // T de Tie (empate)
            }
        }

        public char GetCell(int row, int col)
        {
            if (row < 0 || row >= 3 || col < 0 || col >= 3)
                return ' ';
            return board[row, col];
        }

        public char GetWinner()
        {
            return winner;
        }

        public bool IsCompleted()
        {
            return isCompleted;
        }

        public bool IsFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                        return false;
                }
            }
            return true;
        }
    }
}




