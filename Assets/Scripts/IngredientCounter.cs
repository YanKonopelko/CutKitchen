using UnityEngine;

public class IngredientCounter : MonoBehaviour
{
    GameObject mixCan;
    //GameObject gameCan;
    GameObject conveyor;

    private void Start()
    {
        mixCan = GameObject.FindWithTag("MixingCanvas");
        //gameCan = GameObject.FindWithTag("GameplayCanvas");
        conveyor = GameObject.FindWithTag("Conveyor");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            CounterInt.counter++;
        }
        if (CounterInt.counter == PlayerPrefs.GetInt("IngredientCounter"))
        {
            CounterInt.counter = 0;
            mixCan.GetComponent<Canvas>().enabled = true;
            //gameCan.SetActive(false);
            conveyor.SetActive(false);
        }
    }
}
