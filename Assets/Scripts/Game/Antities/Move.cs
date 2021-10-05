
public static class Move
{
    public const int FirstLineID = -2;
    public const int LastLineID = 2;

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