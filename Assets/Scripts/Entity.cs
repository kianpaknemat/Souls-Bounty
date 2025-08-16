using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour

{
    #region check wall, ground
    [Header("KnockBack info")]
    [SerializeField] protected Vector2 knockBackDirection;
    protected bool isKnocked;


    [Header("check wall & ground")]
    public Transform attackCheck;
    public float attackCheckRadius;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    public Transform wallCheck;
    public float wallCheckRadius = 0.2f;
    public LayerMask walldLayer;
    public bool IsWall()
    {
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        return Physics2D.Raycast(wallCheck.position, direction, wallCheckRadius, walldLayer);
    }
    #endregion



    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public EntityFX FX { get; private set; }
    public CharecterStats Stats { get; private set;}

    #endregion


    #region time
    [Header("Time")]
    public float Timer;
    public float coolDown = 5f;

    #endregion
    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        RB = GetComponent<Rigidbody2D>();
        FX = GetComponent<EntityFX>();
        Stats = GetComponent<CharecterStats>();
    }
    protected virtual void Update()
    {

    }

    public virtual void DamageEffect()
    {
        FX.StartCoroutine("FlashFX");
        StartCoroutine("hitKnockBack");
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }

    public void SetVelocity(float x, float y)
    {
        if (isKnocked)
        {
            return;
        }
        if (RB != null)
            RB.linearVelocity = new Vector2(x, y);

        if (x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
    public void SetZeroVelocity()
    {
        if (isKnocked)
            { return; }

        if (RB != null)
            RB.linearVelocity = Vector2.zero;
    }


    public float GetDirection()
    {
        return Mathf.Sign(transform.localScale.x);
    }

    protected virtual IEnumerator hitKnockBack()
    {
        isKnocked = true;
        float dir = GetDirection();

        RB.linearVelocity = new Vector2(knockBackDirection.x * -dir, knockBackDirection.y);

        yield return new WaitForSeconds(0.07f); 

        isKnocked = false;
    }

}
