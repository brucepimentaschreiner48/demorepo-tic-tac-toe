namespace SampleApp;

public class TicTacToe
{
    private readonly Board _board = new Board();

    public void Run()
    {
        _board.Render();
    }
}
