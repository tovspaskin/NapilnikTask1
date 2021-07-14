using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapilnikTask1
{
    internal class Bot
    {
        private readonly Weapon _weapon;
        private ITarget _target;

        public Bot(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void OnSeePlayer(ITarget target)
        {
            _target = target;
            _weapon.Fire(_target);
        }
    }
}
