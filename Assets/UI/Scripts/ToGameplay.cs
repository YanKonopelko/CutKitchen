using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGameplay : MonoBehaviour
{
    public void GoToGameplay()
    {
        SceneManager.LoadScene(1);
    }
}
