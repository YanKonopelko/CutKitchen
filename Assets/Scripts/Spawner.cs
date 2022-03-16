using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject[] ingredients;
    int counter = 1;

    void Start()
    {
        string[] list = (string[])Recipe.recipes[PlayerPrefs.GetString("CurrentRecipe")];
        Repeat(list);
    }

    IEnumerator Spawn(int i, string[] list)
    {
        Vector3 pos = spawnPos.position;
        Instantiate(ingredients[i], pos, ingredients[i].transform.rotation);
        yield return new WaitForSeconds(5);
        counter += 1;
        Repeat(list);
    }

    void Repeat(string[] list)
    {
        if (counter < list.Length)
        {
            if (list[counter] == "Огурец")
                StartCoroutine(Spawn(0, list));
            if (list[counter] == "Помидор")
                StartCoroutine(Spawn(1, list));
            if (list[counter] == "Колбаса")
                StartCoroutine(Spawn(2, list));
            if (list[counter] == "Картошка")
                StartCoroutine(Spawn(3, list));
            if (list[counter] == "Авокадо")
                StartCoroutine(Spawn(4, list));
        }
    }
}
