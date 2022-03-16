using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        transform.Translate(speed, 0, 0);
    }
}
