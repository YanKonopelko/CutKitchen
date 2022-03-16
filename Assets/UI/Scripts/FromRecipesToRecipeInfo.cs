using UnityEngine;
using TMPro;

public class FromRecipesToRecipeInfo : MonoBehaviour
{
    public GameObject RecipeMenu;
    public GameObject RecipeInfo;
    public GameObject recipeTextPrefab;
    public void ToRecipeInfo()
    {
        PlayerPrefs.SetString("CurrentRecipe", name);
        string[] list = (string[])Recipe.recipes[name];
        PlayerPrefs.SetInt("IngredientCounter",list.Length - 1);

        RecipeMenu.SetActive(false);
        RecipeInfo.SetActive(true);
        RecipeInfo.transform.GetChild(2)
            .GetComponent<TextMeshProUGUI>().SetText(list[0]);
        for (int i = 1; i < list.Length; i++)
        {
            GameObject go = Instantiate(recipeTextPrefab, RecipeInfo.transform.GetChild(0).GetChild(0));
            go.GetComponent<TextMeshProUGUI>().SetText(list[i]);
        }
    }
}
