using UnityEngine;

public class SwordSkill : Skill
{
    [Header("Sword Info")]
    [SerializeField] private GameObject SwordPrifab;
    [SerializeField] private Vector2 SwordDirection;
    [SerializeField] protected float SwordGravity;


    public void CreateSword()
    {
        GameObject newSword = Instantiate(SwordPrifab,player.transform.position,transform.rotation);
        SwordSkillControler newSwordScipt = newSword.GetComponent<SwordSkillControler>();
        newSwordScipt.setUpSword(SwordDirection,SwordGravity);
    }
}
