# Jogo da Velha Expandido - Ultimate Tic Tac Toe

Um jogo de Ultimate Tic Tac Toe implementado em C# (.NET 8.0) que pode ser executado no terminal/console.

## Sobre o Jogo

O **Ultimate Tic Tac Toe** (também conhecido como Jogo da Velha Expandido) é uma variação estratégica do tradicional jogo da velha. O jogo consiste em 9 tabuleiros menores (3x3) que formam um tabuleiro maior (3x3).

### Regras do Jogo

1. **Objetivo**: Vencer 3 tabuleiros pequenos em linha (horizontal, vertical ou diagonal) no tabuleiro grande.

2. **Como Jogar**:
   - Cada jogada é feita em um dos 9 tabuleiros pequenos (quadrantes)
   - A posição que você joga dentro de um quadrante pequeno **determina** qual quadrante o próximo jogador DEVE jogar
   - Por exemplo: se você joga na posição central (1,1) de um quadrante, o próximo jogador deve jogar no quadrante central do tabuleiro grande

3. **Liberdade de Escolha**:
   - Se o quadrante direcionado estiver completo (vencido ou empatado), você pode escolher qualquer quadrante para jogar

4. **Vitória**:
   - Vença um quadrante pequeno completando uma linha de 3 (X ou O)
   - Vença o jogo grande completando 3 quadrantes em linha

## Como Executar

### Pré-requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior instalado

### Passos para Executar

1. Clone este repositório:
```bash
git clone https://github.com/seu-usuario/jogo-da-velha-expandido.git
cd jogo-da-velha-expandido
```

2. Restaure as dependências e compile:
```bash
dotnet restore
dotnet build
```

3. Execute o jogo:
```bash
dotnet run
```

Ou execute diretamente o executável compilado:
```bash
dotnet run --project JogoDaVelhaExpandido.csproj
```

## Como Jogar

1. Ao iniciar o jogo, escolha o símbolo do Jogador 1 (X ou O)
2. O Jogador 2 receberá automaticamente o símbolo oposto
3. Siga as instruções na tela para fazer suas jogadas:
   - **Formato normal**: `linha coluna` (exemplo: `1 1` para a posição central)
   - **Formato livre**: `quadrante_linha quadrante_coluna linha coluna` (quando pode escolher qualquer quadrante)

### Exemplo de Jogada

```
Vez do Jogador X
Você DEVE jogar no quadrante (1, 1)
Digite a posição dentro do quadrante no formato: linha coluna
Exemplo: 1 1 (joga na posição central do quadrante)
Sua jogada: 0 1
```

## Estrutura do Projeto

```
JogoDaVelhaExpandido/
│
├── Program.cs              # Interface de usuário e loop principal do jogo
├── UltimateTicTacToe.cs    # Lógica do jogo grande (tabuleiro 3x3 de tabuleiros)
├── SmallTicTacToe.cs       # Lógica de cada tabuleiro pequeno (3x3)
├── JogoDaVelhaExpandido.csproj
└── README.md
```

## Tecnologias Utilizadas

- **C#** - Linguagem de programação
- **.NET 8.0** - Framework
- **Console Application** - Interface de terminal

## Características

-  Interface visual no console com caracteres especiais (UTF-8)
-  Validação completa de jogadas
-  Detecção automática de vencedores (tabuleiros pequenos e grande)
-  Detecção de empates
-  Sistema de direcionamento de quadrantes
-  Liberdade de escolha quando o quadrante direcionado está completo

## Exemplo de Tabuleiro

```
═══════════════════════════════════════════════════════════════
                    TABULEIRO GRANDE                        
═══════════════════════════════════════════════════════════════

│ · · · │ │ · · · │ │ · · · │
│ · X · │ │ · · · │ │ · · · │
│ · · · │ │ · · · │ │ · · · │
├───────┤─├───────┤─├───────┤
│ · · · │ │ · O · │ │ · · · │
│ · · · │ │ · · · │ │ · · · │
│ · · · │ │ · · · │ │ · · · │
├───────┤─├───────┤─├───────┤
│ · · · │ │ · · · │ │ · · · │
│ · · · │ │ · · · │ │ · · · │
│ · · · │ │ · · · │ │ · · · │
```

## Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para:

1. Fazer um fork do projeto
2. Criar uma branch para sua feature (`git checkout -b feature/NovaFeature`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova feature'`)
4. Push para a branch (`git push origin feature/NovaFeature`)
5. Abrir um Pull Request

## Autor

Allan

##  Melhorias Futuras

- [ ] Adicionar modo contra IA (inteligência artificial)
- [ ] Melhorar a interface visual
- [ ] Adicionar cores ao terminal
- [ ] Sistema de pontuação e histórico
- [ ] Modo online/multiplayer
- [ ] Animações de vitória

 Se você gostou do projeto, deixe uma estrela!

# jogo_da_velha_expandido
Ultimate Tic Tac Toe em C# - Projeto de aprendizado em programação orientada a objetos, manipulação de arrays e lógica de jogos no .NET 8.0
