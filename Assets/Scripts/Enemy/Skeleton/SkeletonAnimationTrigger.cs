using UnityEngine;

public class SkeletonAnimationTrigger : MonoBehaviour
{
    private EnemySkeleton enemy => GetComponentInParent<EnemySkeleton>();
    private void AnimationsTrigger()
    {
        enemy.AnimationFinishTrigger();
    }
}
