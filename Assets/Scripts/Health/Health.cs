
namespace Dmpk_TPS
{
    public class Health
    {
        private int max;
        
        public int Min { get; private set; } 

        public int Current { get; private set; }

        public Health(int max)
        {
            this.max = max;
            this.Min = 0;
            this.Current = max;
        }
        
        public Health(int max, int min)
        {
            this.max = max;
            this.Min = min;
            this.Current = max;
        }

        public void TakeDamage(int damage)
        {
            Current -= damage;
            if(Current < Min) Current = Min;
        }

        public void HealDamage(int damage)
        {
            Current += damage;
            if(Current > max) Current = max;
        }

    }
}

