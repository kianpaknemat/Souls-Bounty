using System;
using Unity.Mathematics;
using UnityEngine;

public class CloneSkillController : MonoBehaviour
{
    private SpriteRenderer sr;
    private float Clonetimer;
    [SerializeField] private float colorlosingSpeed;
    private Animator anime;


    [SerializeField] private Transform attackCheck;
    [SerializeField] private float attackCheckRAdius = 0.8f;


    private Transform closestEnemy;

    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
    }
    private void Update()
    {
        Clonetimer -= Time.deltaTime;

        facecClosestTargget();

        if (Clonetimer < 0)
        {
            sr.color = new Color(1, 1, 1, sr.color.a - (Time.deltaTime * colorlosingSpeed));

            if (sr.color.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void setUpClone(Transform newTransform, float cloneDurition, bool canAttack)
    {

        if (canAttack)
        {
            anime.SetInteger("AttackNumber", UnityEngine.Random.Range(1, 4));

        }
        transform.position = newTransform.position;
        Clonetimer = cloneDurition;

    }
    public void AnimationTrigge()
    {
        Clonetimer = -1f;
    }

    private void attackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, attackCheckRAdius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                hit.GetComponent<Enemy>().DamageEffect();
            }
        }
    }

    private void facecClosestTargget()
    {
        Collider2D[] colider = Physics2D.OverlapCircleAll(transform.position, 25);
        float closestInstance = Mathf.Infinity;

        closestEnemy = null; 

        foreach (var hit in colider)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, hit.transform.position);
                if (distanceToEnemy < closestInstance)
                {
                    closestInstance = distanceToEnemy;
                    closestEnemy = hit.transform;
                }
            }
        }

        if (closestEnemy != null)
        {
            bool faceRight = closestEnemy.position.x > transform.position.x;

            if (faceRight && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (!faceRight && transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }




}
