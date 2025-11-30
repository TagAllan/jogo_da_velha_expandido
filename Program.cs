using System;

namespace JogoDaVelhaExpandido
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("║     JOGO DA VELHA EXPANDIDO - ULTIMATE TIC TAC TOE    ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Pergunta qual símbolo o jogador inicial vai usar
            char player1Symbol = ' ';
            while (player1Symbol != 'X' && player1Symbol != 'O')
            {
                Console.Write("Jogador 1, escolha seu símbolo (X ou O): ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.Length > 0)
                {
                    player1Symbol = char.ToUpper(input[0]);
                }
            }

            char player2Symbol = player1Symbol == 'X' ? 'O' : 'X';
            Console.WriteLine($"Jogador 1: {player1Symbol}");
            Console.WriteLine($"Jogador 2: {player2Symbol}");
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para começar...");
            Console.ReadKey();
            Console.Clear();

            UltimateTicTacToe game = new UltimateTicTacToe();
            char currentPlayer = player1Symbol;
            bool gameOver = false;

            while (!gameOver)
            {
                DisplayBoard(game);
                Console.WriteLine();

                int bigRow, bigCol, smallRow, smallCol;

                // Se pode escolher qualquer quadrante
                if (game.CanChooseAnyBoard())
                {
                    Console.WriteLine($"Vez do Jogador {currentPlayer}");
                    Console.WriteLine("O quadrante direcionado está completo. Escolha livremente qual quadrante jogar!");
                    Console.WriteLine("Digite a posição no formato: quadrante_linha quadrante_coluna linha coluna");
                    Console.WriteLine("Exemplo: 0 0 1 1 (joga no quadrante superior esquerdo, posição central)");
                    Console.Write("Sua jogada: ");

                    string? input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Entrada inválida! Tente novamente.");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length != 4)
                    {
                        Console.WriteLine("Formato inválido! Use: linha_quadrante coluna_quadrante linha coluna");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    if (!int.TryParse(parts[0], out bigRow) || !int.TryParse(parts[1], out bigCol) ||
                        !int.TryParse(parts[2], out smallRow) || !int.TryParse(parts[3], out smallCol))
                    {
                        Console.WriteLine("Valores inválidos! Use números de 0 a 2.");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    // Valida os índices
                    if (bigRow < 0 || bigRow > 2 || bigCol < 0 || bigCol > 2 ||
                        smallRow < 0 || smallRow > 2 || smallCol < 0 || smallCol > 2)
                    {
                        Console.WriteLine("Valores devem estar entre 0 e 2!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    game.SetNextBoard(bigRow, bigCol);
                }
                else
                {
                    Console.WriteLine($"Vez do Jogador {currentPlayer}");
                    Console.WriteLine($"Você DEVE jogar no quadrante ({game.GetCurrentBoardRow()}, {game.GetCurrentBoardCol()})");
                    Console.WriteLine("Digite a posição dentro do quadrante no formato: linha coluna");
                    Console.WriteLine("Exemplo: 1 1 (joga na posição central do quadrante)");
                    Console.Write("Sua jogada: ");

                    bigRow = game.GetCurrentBoardRow();
                    bigCol = game.GetCurrentBoardCol();

                    string? input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Entrada inválida! Tente novamente.");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length != 2)
                    {
                        Console.WriteLine("Formato inválido! Use: linha coluna");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    if (!int.TryParse(parts[0], out smallRow) || !int.TryParse(parts[1], out smallCol))
                    {
                        Console.WriteLine("Valores inválidos! Use números de 0 a 2.");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    // Valida os índices
                    if (smallRow < 0 || smallRow > 2 || smallCol < 0 || smallCol > 2)
                    {
                        Console.WriteLine("Valores devem estar entre 0 e 2!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                }

                // Tenta fazer a jogada
                if (!game.MakeMove(bigRow, bigCol, smallRow, smallCol, currentPlayer))
                {
                    Console.WriteLine("Jogada inválida! Esta posição já está ocupada ou o quadrante está completo.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                // Verifica se o jogo terminou
                char winner = game.CheckBigWinner();
                if (winner != ' ')
                {
                    Console.Clear();
                    DisplayBoard(game);
                    Console.WriteLine();
                    Console.WriteLine($"╔═══════════════════════════════════════════════════════╗");
                    Console.WriteLine($"║           PARABÉNS! Jogador {winner} VENCEU!            ║");
                    Console.WriteLine($"╚═══════════════════════════════════════════════════════╝");
                    gameOver = true;
                }
                else if (game.IsGameOver())
                {
                    Console.Clear();
                    DisplayBoard(game);
                    Console.WriteLine();
                    Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                    EMPATE!                            ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
                    gameOver = true;
                }
                else
                {
                    // Alterna o jogador
                    currentPlayer = currentPlayer == player1Symbol ? player2Symbol : player1Symbol;
                    Console.Clear();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static void DisplayBoard(UltimateTicTacToe game)
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("                    TABULEIRO GRANDE                        ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            // Desenha o tabuleiro grande com os 9 jogos pequenos
            for (int bigRow = 0; bigRow < 3; bigRow++)
            {
                // Para cada linha de quadrantes grandes
                for (int smallRow = 0; smallRow < 3; smallRow++)
                {
                    // Para cada quadrante grande na linha
                    for (int bigCol = 0; bigCol < 3; bigCol++)
                    {
                        Console.Write("│ ");
                        SmallTicTacToe smallBoard = game.GetSmallBoard(bigRow, bigCol);
                        char bigWinner = game.GetBigBoardCell(bigRow, bigCol);

                        // Se o quadrante grande foi vencido, mostra o vencedor
                        if (bigWinner != ' ')
                        {
                            for (int smallCol = 0; smallCol < 3; smallCol++)
                            {
                                if (smallCol == 1 && smallRow == 1)
                                {
                                    Console.Write($"{bigWinner}");
                                }
                                else
                                {
                                    Console.Write(" ");
                                }
                                if (smallCol < 2) Console.Write(" ");
                            }
                        }
                        else
                        {
                            // Mostra o estado do jogo pequeno
                            for (int smallCol = 0; smallCol < 3; smallCol++)
                            {
                                char cell = smallBoard.GetCell(smallRow, smallCol);
                                if (cell == ' ')
                                {
                                    Console.Write("·");
                                }
                                else
                                {
                                    Console.Write(cell);
                                }
                                if (smallCol < 2) Console.Write(" ");
                            }
                        }
                        Console.Write(" │");
                        if (bigCol < 2) Console.Write(" ");
                    }
                    Console.WriteLine();
                }

                // Linha separadora entre quadrantes grandes
                if (bigRow < 2)
                {
                    for (int bigCol = 0; bigCol < 3; bigCol++)
                    {
                        Console.Write("├───────┤");
                        if (bigCol < 2) Console.Write("─");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("Legenda:");
            Console.WriteLine("  · = Posição vazia");
            Console.WriteLine("  X = Jogada do jogador X");
            Console.WriteLine("  O = Jogada do jogador O");
            Console.WriteLine("  Quadrante com X ou O grande = Quadrante vencido");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
        }
    }
}
