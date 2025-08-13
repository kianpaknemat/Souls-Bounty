using UnityEngine;

public class CloneSkill : Skill
{
    [Header("Clone Info")]
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float cloneDurition;

    [Space]

    [SerializeField] private bool canAttack;

    public void createClone(Transform clonePosition)
    {
        if (clonePrefab == null)
        {
            Debug.LogError("[CloneSkill] clonePrefab is null! Assign it in the inspector.", this);
            return;
        }

        GameObject newClone = Instantiate(clonePrefab);
        newClone.GetComponent<CloneSkillController>().setUpClone(clonePosition, cloneDurition, canAttack);

    }
}