namespace SampleApp;

public class Move
{
    public ushort Player { get; }
    public ushort Index { get; }

    public Move(ushort player, ushort index)
    {
        if (player < 1 || player > 2)
        {
            throw new ArgumentException("The player index has to be 1 (X) or 2 (O)", nameof(player));
        }

        Player = player;
        Index = index;
    }
}
