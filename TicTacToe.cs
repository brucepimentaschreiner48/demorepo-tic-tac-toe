namespace SampleApp;

public class TicTacToe
{
    private readonly Board _board = new Board();
    private ushort? _nextPlayer = 1;

    public void Run()
    {
        Console.WriteLine("Let's play a game. X goes before O. Enter 'q' to quit.");

        Console.WriteLine();
        _board.Render();
        Console.WriteLine();

        do
        {
            var move = ReadMove();
            if (move == null)
            {
                Console.WriteLine("Quit.");
                return;
            }

            Console.WriteLine($"=> Move {move.Player} : {move.Index}");
            _nextPlayer = _board.ApplyMove(move);
            _board.Render();
            Console.WriteLine();

            if (_nextPlayer == null)
            {
                return;
            }
        } while (true);
    }

    private Move? ReadMove()
    {
        do
        {
            Console.WriteLine($"Move of player {_nextPlayer}. Enter a number 0-8 or 'q' to quit");
            var line = Console.ReadLine()?.Trim();

            if (line == "q")
            {
                return null;
            }

            if (ushort.TryParse(line, out var index))
            {
                return new Move(_nextPlayer!.Value, index);
            }
        } while (true);
    }
}
