using System.Xml.Serialization;
using UnityEngine;

public class Skill : MonoBehaviour
{

    [SerializeField] protected float collDown;
    protected float coolDownTimer;

    protected Player player;


    protected virtual void Start()
    {
        player = PlayerManager.instance.player;
    }

    protected virtual void Update()
    {
        coolDownTimer -= Time.deltaTime;
    }

    public virtual bool canUseSkill()
    {
        if(coolDownTimer < 0)
        {
            useSkill();
            coolDownTimer = collDown;
            return true;
        }
        return false;
    }




    public virtual void useSkill()
    {
        // you can add some skill
    }

}
