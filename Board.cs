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

    public void Render()
    {
        for (int row = 0; row < 3; row++)
        {
            if (row != 0)
            {
                Console.WriteLine("--|---|--");
            }
            Console.WriteLine(String.Join(" | ", _state.Skip(0).Take(3).Select(n => Visualization[n])));
        }
    }
}
