using UnityEngine;

public class SwordSkillControler : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private Player player;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
    }

    public void setUpSword(Vector2 _dir, float _gravity)
    {
        rb.linearVelocity = _dir;
        rb.gravityScale = _gravity;

    }
}
