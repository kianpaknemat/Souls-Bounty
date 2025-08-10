using UnityEngine;

public class CloneSkill : Skill
{
    [SerializeField] private GameObject clonePrefab;

    public void createClone(Transform clonePosition)
    {
        if (clonePrefab == null)
        {
            Debug.LogError("[CloneSkill] clonePrefab is null! Assign it in the inspector.", this);
            return;
        }

        GameObject newClone = Instantiate(clonePrefab);
        newClone.GetComponent<CloneSkillController>().setUpClone(clonePosition);
        
    }
}
