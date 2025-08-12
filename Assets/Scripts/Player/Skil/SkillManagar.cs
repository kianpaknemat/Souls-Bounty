using UnityEngine;

public class SkillManagar : MonoBehaviour
{
    public static SkillManagar instance;
    public DashSkill dash { get; private set; }
    public CloneSkill Clone { get; private set; }

    private void Awake()
    {
        {

            if (instance != null)
            {

                Destroy(instance.gameObject);
            }


            else
            {
                instance = this;
            }



        }
    }

    private void Start()
    {
        dash = GetComponent<DashSkill>();
        Clone = GetComponent<CloneSkill>();
    }
}
