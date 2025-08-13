using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();
    public void AnimationTrigge()
    {
        player.AnimationTrigger();
    }

    private void attackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                hit.GetComponent<Enemy>().Damage();
            }
        }
    }

    private void ThorowSword()
    {
        SkillManagar.instance.Sword.CreateSword();
    }
}

