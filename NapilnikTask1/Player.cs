using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapilnikTask1
{
    internal class Player : ITarget
    {
        private int _health;

        public Player(int health)
        {
            if (health <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _health = health;
        }

        public event Action OnDie;

        public bool IsAlive() => _health > 0;

        public void TakeDamage(int damage)
        {
            if (!IsAlive())
            {
                throw new NotImplementedException();
            }

            _health -= damage;
            if (_health <= 0)
            {
                _health = 0;
                OnDie?.Invoke();
            }

        }
    }
}
