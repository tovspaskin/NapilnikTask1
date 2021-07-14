using System;

namespace NapilnikTask1
{
    public enum Reason
    {
        Ok,
        NoBullets,
        TargetIsDead,
    }

    internal class Weapon
    {
        private readonly int _damage;
        private readonly int _bulletsForShoot;
        private readonly int _maxBullets;
        private int _bullets;
        private ITarget _target;

        public Weapon(int damage, int maxBullets, int bulletsForShoot)
        {
            if (damage <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _damage = damage;
            if (maxBullets < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            _bullets = maxBullets;
            _maxBullets = maxBullets;
            if (bulletsForShoot < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            _bulletsForShoot = bulletsForShoot;
        }

        private bool HaveAmmoForShoot => _bullets >= _bulletsForShoot;

        public void Fire(ITarget target)
        {
            _target = target;
            if (CanFire() == Reason.Ok)
            {
                target.TakeDamage(_damage);
                ReduceShot();
            }
            else if (CanFire() == Reason.NoBullets)
            {
                Recharge();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void ReduceShot()
        {
            _bullets = _bulletsForShoot;
        }

        private void Recharge()
        {
            _bullets = _maxBullets;
        }

        private Reason CanFire()
        {
            if (!_target.IsAlive())
            {
                return Reason.TargetIsDead;
            }

            if (!HaveAmmoForShoot)
            {
                return Reason.NoBullets;
            }

            return Reason.Ok;
        }
    }
}
