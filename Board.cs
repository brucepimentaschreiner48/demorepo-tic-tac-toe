namespace SampleApp;

public class Board
{
    private static readonly IDictionary<ushort, string> Visualization = new Dictionary<ushort, string>
    {
        [0] = " ",
        [1] = "X",
        [2] = "O"
    };

    private static readonly IList<ushort[]> WinningStates = new List<ushort[]>
    {
        new ushort[] {0, 1, 2},
        new ushort[] {3, 4, 5},
        new ushort[] {6, 7, 8},
        new ushort[] {0, 3, 6},
        new ushort[] {1, 4, 7},
        new ushort[] {2, 5, 8},
        new ushort[] {0, 4, 8},
        new ushort[] {2, 4, 6},
    };
    private readonly ushort[] _state = new ushort[9];
    private ushort _currentPlayer = 1;

    public ushort? ApplyMove(Move move)
    {
        if (move.Player != _currentPlayer)
        {
            Console.WriteLine($"Invalid move for player {Visualization[move.Player]}. It is currently player {Visualization[_currentPlayer]} turn.");
            return _currentPlayer;
        }

        if (move.Index > 8)
        {
            Console.WriteLine($"Position index has to be between 0 and 8");
            return _currentPlayer;
        }

        if (_state[move.Index] != 0)
        {
            Console.WriteLine($"Position with index {move.Index} is already occupied by {Visualization[_state[move.Index]]}");
            return _currentPlayer;
        }

        _state[move.Index] = _currentPlayer;
        if (CheckGameEndCondition())
        {
            return null;
        }
        _currentPlayer = (ushort)(_currentPlayer == 1 ? 2 : 1);
        return _currentPlayer;
    }

    public void Render()
    {
        for (int row = 0; row < 3; row++)
        {
            if (row != 0)
            {
                Console.WriteLine("--|---|--");
            }
            Console.WriteLine(String.Join(" | ", _state.Skip(3 * row).Take(3).Select(n => Visualization[n])));
        }
    }

    private bool CheckGameEndCondition()
    {
        foreach (var pattern in WinningStates)
        {
            var result = pattern.Select(index => _state[index]).Aggregate(1, (acc, player) => acc * player);
            if (result == 1)
            {
                Console.WriteLine($"Player 1 ({Visualization[1]}) wins!");
                return true;
            }

            if (result == 8)
            {
                Console.WriteLine($"Player 2 ({Visualization[2]}) wins!");
                return true;
            }
        }

        if (_state.All(s => s != 0))
        {
            Console.WriteLine($"Game ends with a TIE!");
            return true;
        }

        return false;
    }
}
