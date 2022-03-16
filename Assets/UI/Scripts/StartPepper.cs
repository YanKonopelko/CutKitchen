using UnityEngine;

public class StartPepper : MonoBehaviour
{
    public void OnClickStartPepper()
    {
        SpiceCounter.counter++;
        GameObject.FindGameObjectWithTag("PepperAnim").GetComponent<ParticleSystem>().Play();
        PlayerPrefs.SetFloat("Score", PlayerPrefs.GetFloat("Score") + 25);
        Destroy(GameObject.FindGameObjectWithTag("Pepper"));
    }
}
