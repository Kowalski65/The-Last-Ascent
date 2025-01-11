using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform target; 
    public Vector2 parallaxEffect; 

    private Vector3 lastTargetPosition;

    void Start()
    {
        if (target != null)
        {
            lastTargetPosition = target.position;
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 deltaMovement = target.position - lastTargetPosition;
            transform.position += new Vector3(deltaMovement.x * parallaxEffect.x, deltaMovement.y * parallaxEffect.y, 0);
            lastTargetPosition = target.position;
        }
    }
}
