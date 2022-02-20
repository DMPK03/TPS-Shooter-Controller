
namespace Dmpk_TPS
{
    public class Health
    {
        private int max;
        private IDamagable creator;
        
        public int Min { get; private set; } 

        public int Current { get; private set; }

        public Health(int max, int min, IDamagable creator)
        {
            this.max = max;
            this.Min = min;
            this.Current = max;
            this.creator = creator;
        }

        public void TakeDamage(int damage)
        {
            Current -= damage;
            if(Current < Min)
            {
                Current = Min;
                if(creator != null) creator.Die();
            } 
        }

        public void HealDamage(int damage)
        {
            Current += damage;
            if(Current > max) Current = max;
        }

    }
}

