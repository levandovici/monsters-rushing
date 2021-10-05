
public static class Bump
{
    public interface IBumpable
    {
        float BumpDamage { get; }



        void Bump(float damage);
    }
}