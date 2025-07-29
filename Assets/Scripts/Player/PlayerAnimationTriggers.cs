using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();
    public void AnimationTrigge()
    {
        player.AnimationTrigger();
    }
}
