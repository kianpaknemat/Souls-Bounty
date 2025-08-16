using UnityEngine;

public class EnemyStat : CharecterStats
{
    private Enemy enemy;
    protected override void Start()
    {
        base.Start();
        enemy = GetComponent<Enemy>();
    }
    public override void takeDamage(int _damage)
    {
        base.takeDamage(_damage);
        enemy.DamageEffect();
    }
}
