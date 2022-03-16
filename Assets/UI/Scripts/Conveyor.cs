using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed;
    public float scrollXPos;
    public float scrollYPos;

    void Update()
    {
        float updatedXPos = Time.time * scrollXPos * speed; 
        float updatedYPos = Time.time * scrollYPos * speed;
        this.gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(updatedXPos, updatedYPos);
    }
}
