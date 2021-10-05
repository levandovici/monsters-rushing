
public static class Health
{
    public interface IDamageTakeable : IKillable
    {
         void TakeDamage(float hp);
    }

    public interface IKillable
    {
        void Kill();
    }

    public interface IHealable
    {
        void Heal(float hp);
    }
}