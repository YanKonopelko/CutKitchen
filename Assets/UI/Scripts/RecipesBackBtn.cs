using UnityEngine;

public class RecipesBackBtn : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject recipes;

    void Update()
    {
        // Make sure user is on Android platform
        if (Application.platform == RuntimePlatform.Android)
        {
            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                mainMenu.SetActive(true);
                recipes.SetActive(false);
            }
        }
    }

    public void OnClick()
    {
        mainMenu.SetActive(true);
        recipes.SetActive(false);
    }
}
