using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapilnikTask1
{
    internal class Bot
    {
        private Weapon _weapon;
        private ITarget _target;

        public Bot(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            _target = player;
            _weapon.Fire(_target);
        }
    }
}
