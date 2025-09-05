namespace SampleApp;

public class Board
{
    private static readonly IDictionary<ushort, string> Visualization = new Dictionary<ushort, string>
    {
        [0] = " ",
        [1] = "X",
        [2] = "O"
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
}
