using UnityEngine;

public class CloneSkillController : MonoBehaviour
{
    public void setUpClone(Transform newTransform)
    {
        transform.position = newTransform.position;

    }

}
