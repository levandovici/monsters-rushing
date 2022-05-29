
public static class Move
{
    public const int FirstLineID = -1;
    public const int LastLineID = 1;

    public const float CellSize = 5f;



    public interface IBounce
    {
        void Rebound();
        
        void DoNotRebound();
    }



    public enum ELineInfo
    {
        stay, toLeft, toRight
    }
}