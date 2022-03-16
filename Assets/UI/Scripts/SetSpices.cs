using UnityEngine;

public class SetSpices : MonoBehaviour
{
    public GameObject SpicesPanel;
    public GameObject Salt;
    public GameObject Pepper;
    public GameObject Oil;

    void Start()
    {
        string[] list = (string[])Recipe.recipes[PlayerPrefs.GetString("CurrentRecipe") + "Spices"];
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i] == "����")
                Instantiate(Salt, SpicesPanel.transform);
            if (list[i] == "�����")
                Instantiate(Pepper, SpicesPanel.transform);
            if (list[i] == "�����")
                Instantiate(Oil, SpicesPanel.transform);
        }
    }
}
