using UnityEngine;

public class AvocadoSeed : MonoBehaviour
{
    public int hp = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            transform.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}