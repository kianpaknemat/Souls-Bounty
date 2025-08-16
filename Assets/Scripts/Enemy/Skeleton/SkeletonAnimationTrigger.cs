using UnityEngine;

public class SkeletonAnimationTrigger : MonoBehaviour
{
    private EnemySkeleton enemy => GetComponentInParent<EnemySkeleton>();
    private void AnimationsTrigger()
    {
        enemy.AnimationFinishTrigger();
    }
    private void attackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                PlayerStat _target = hit.GetComponent<PlayerStat>();
                enemy.Stats.doDamage(_target);
            }
        }
    }

}
