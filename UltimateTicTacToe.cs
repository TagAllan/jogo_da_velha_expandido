namespace JogoDaVelhaExpandido
{
    public class UltimateTicTacToe
    {
        private SmallTicTacToe[,] smallBoards;
        private char[,] bigBoard; // Representa o estado do jogo grande
        private int currentBoardRow;
        private int currentBoardCol;
        private bool canChooseAnyBoard;

        public UltimateTicTacToe()
        {
            smallBoards = new SmallTicTacToe[3, 3];
            bigBoard = new char[3, 3];
            
            // Inicializa os 9 jogos pequenos
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    smallBoards[i, j] = new SmallTicTacToe();
                    bigBoard[i, j] = ' ';
                }
            }

            currentBoardRow = -1;
            currentBoardCol = -1;
            canChooseAnyBoard = true; // No início, pode escolher qualquer quadrante
        }

        /// <summary>
        /// Faz uma jogada no jogo
        /// </summary>
        public bool MakeMove(int bigRow, int bigCol, int smallRow, int smallCol, char symbol)
        {
            // Verifica se pode jogar neste quadrante
            if (!canChooseAnyBoard)
            {
                if (bigRow != currentBoardRow || bigCol != currentBoardCol)
                {
                    return false;
                }
            }

            // Verifica se o quadrante grande já está completo
            if (smallBoards[bigRow, bigCol].IsCompleted())
            {
                return false;
            }

            // Faz a jogada no jogo pequeno
            if (!smallBoards[bigRow, bigCol].MakeMove(smallRow, smallCol, symbol))
            {
                return false;
            }

            // Verifica se o jogo pequeno foi vencido
            char smallWinner = smallBoards[bigRow, bigCol].GetWinner();
            if (smallWinner != ' ' && smallWinner != 'T')
            {
                bigBoard[bigRow, bigCol] = smallWinner;
            }

            // Determina o próximo quadrante baseado na posição jogada
            currentBoardRow = smallRow;
            currentBoardCol = smallCol;

            // Verifica se o próximo quadrante está completo
            if (smallBoards[currentBoardRow, currentBoardCol].IsCompleted())
            {
                canChooseAnyBoard = true;
            }
            else
            {
                canChooseAnyBoard = false;
            }

            return true;
        }

        /// <summary>
        /// Permite escolher livremente o quadrante (quando o direcionado está completo)
        /// </summary>
        public void SetNextBoard(int bigRow, int bigCol)
        {
            if (canChooseAnyBoard)
            {
                currentBoardRow = bigRow;
                currentBoardCol = bigCol;
                canChooseAnyBoard = false;
            }
        }

        public int GetCurrentBoardRow()
        {
            return currentBoardRow;
        }

        public int GetCurrentBoardCol()
        {
            return currentBoardCol;
        }

        public bool CanChooseAnyBoard()
        {
            return canChooseAnyBoard;
        }

        public SmallTicTacToe GetSmallBoard(int row, int col)
        {
            return smallBoards[row, col];
        }

        public char GetBigBoardCell(int row, int col)
        {
            return bigBoard[row, col];
        }

        /// <summary>
        /// Verifica se há um vencedor no jogo grande
        /// </summary>
        public char CheckBigWinner()
        {
            // Verifica linhas
            for (int i = 0; i < 3; i++)
            {
                if (bigBoard[i, 0] != ' ' && bigBoard[i, 0] == bigBoard[i, 1] && bigBoard[i, 1] == bigBoard[i, 2])
                {
                    return bigBoard[i, 0];
                }
            }

            // Verifica colunas
            for (int j = 0; j < 3; j++)
            {
                if (bigBoard[0, j] != ' ' && bigBoard[0, j] == bigBoard[1, j] && bigBoard[1, j] == bigBoard[2, j])
                {
                    return bigBoard[0, j];
                }
            }

            // Verifica diagonal principal
            if (bigBoard[0, 0] != ' ' && bigBoard[0, 0] == bigBoard[1, 1] && bigBoard[1, 1] == bigBoard[2, 2])
            {
                return bigBoard[0, 0];
            }

            // Verifica diagonal secundária
            if (bigBoard[0, 2] != ' ' && bigBoard[0, 2] == bigBoard[1, 1] && bigBoard[1, 1] == bigBoard[2, 0])
            {
                return bigBoard[0, 2];
            }

            return ' '; // Sem vencedor ainda
        }

        /// <summary>
        /// Verifica se o jogo terminou (vencedor ou empate)
        /// </summary>
        public bool IsGameOver()
        {
            char winner = CheckBigWinner();
            if (winner != ' ')
            {
                return true;
            }

            // Verifica se todos os quadrantes estão completos
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!smallBoards[i, j].IsCompleted())
                    {
                        return false;
                    }
                }
            }

            return true; // Empate - todos os quadrantes completos mas sem vencedor
        }
    }
}




