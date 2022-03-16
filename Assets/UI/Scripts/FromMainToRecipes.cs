using UnityEngine;

public class FromMainToRecipes : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject recipes;

    public void ToRecipes()
    {
        mainMenu.SetActive(false);
        recipes.SetActive(true);
    }
}
