using UnityEngine;

public class SwordSkill : Skill
{
    [Header("Sword Info")]
    [SerializeField] private GameObject SwordPrifab;
    [SerializeField] private Vector2 SwordDirection;
    [SerializeField] protected float SwordGravity;

}
