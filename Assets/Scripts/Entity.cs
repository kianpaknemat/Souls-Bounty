using UnityEngine;

public class Entity : MonoBehaviour

{
    #region check wall, ground
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
    }
    protected virtual void Update()
    {

    }

    public virtual void Damage()
    {
        FX.StartCoroutine("FlashFX");
        Debug.Log(gameObject.name + " Was Damage.");
    }
    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }

}
