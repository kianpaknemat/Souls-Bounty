using UnityEngine;

public class ParalexBackground : MonoBehaviour
{
    private GameObject cam;
    [SerializeField] private float paralexEffect;
    private float xPosion;
    private float lengh;
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        lengh = GetComponent<SpriteRenderer>().bounds.size.x;
        xPosion = transform.localPosition.x;

    }


    void Update()
    {
        float distanceMoved = cam.transform.position.x * (1 - paralexEffect);

        if (distanceMoved > xPosion + lengh)
        {
            xPosion = xPosion +lengh;
        }
        else if (distanceMoved < xPosion - lengh)
        {
            xPosion = xPosion - lengh;
        }

    }
}
