using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMove : MonoBehaviour
{

    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Cubes"))
        {
            var newpos = collision.transform.position;
            newpos.x += Time.deltaTime;
            collision.transform.position = newpos;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            var newpos = other.transform.parent.position;
            newpos.x += 1.2f * Time.deltaTime;
            other.transform.parent.position = newpos;
        }
    }
}
