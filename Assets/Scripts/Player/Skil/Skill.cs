using UnityEngine;

public class Skill : MonoBehaviour
{

    [SerializeField] protected float collDown;
    protected float coolDownTimer;

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
        //hello you can add some skill
    }

}
