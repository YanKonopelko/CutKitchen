using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ScoreScene : MonoBehaviour
{
    [SerializeField] private int a;
    [SerializeField] private int b;
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private TextMeshProUGUI Congratulations;
    [SerializeField] private TextMeshProUGUI Salad;

    public void Load()
    {
        SceneManager.LoadScene(0);
    }
    private void Start()
    {
        string[] list = (string[])Recipe.recipes[PlayerPrefs.GetString("CurrentRecipe")];
        int[] scoreList = (int[])Recipe.recipes[PlayerPrefs.GetString("CurrentRecipe") + "Score"];
        Score.text = "Очки: " + PlayerPrefs.GetFloat("Score").ToString();
        Salad.text = "Ты приготовил: " + "\n" + list[0];
        if (PlayerPrefs.GetFloat("Score") < scoreList[0])
            Congratulations.text = "Съедобно";
        if (PlayerPrefs.GetFloat("Score") >= scoreList[0] && PlayerPrefs.GetFloat("Score") < scoreList[1])
            Congratulations.text = "Вкусно";
        if (PlayerPrefs.GetFloat("Score") >= scoreList[1])
            Congratulations.text = "Божественно";

    }
}