using UnityEngine;

public class PlayerStat : CharecterStats
{
    private Player player;
    protected override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
    }
    public override void takeDamage(int _damage)
    {
        base.takeDamage(_damage);
        player.DamageEffect();
    }
}
