namespace NapilnikTask1
{
    internal class Weapon
    {
        private int _damage;
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            _damage = damage;
            _bullets = bullets;
        }

        public void Fire(ITarget target)
        {
            if (_bullets > 0 && !target.IsDead())
            {
                target.TakeDamage(_damage);
                _bullets--;
            }
        }
    }
}
