using UnityEngine;

public class RecipeInfoBackBtn : MonoBehaviour
{
    public GameObject recipes;
    public GameObject recipeInfo;

    void Update()
    {
        // Make sure user is on Android platform
        if (Application.platform == RuntimePlatform.Android)
        {
            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                recipeInfo.SetActive(false);
                recipes.SetActive(true);
                foreach (Transform child in recipeInfo.transform.GetChild(0).GetChild(0))
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }

    public void OnClick()
    {
        recipeInfo.SetActive(false);
        recipes.SetActive(true);
        foreach (Transform child in recipeInfo.transform.GetChild(0).GetChild(0))
        {
            Destroy(child.gameObject);
        }
    }
}
