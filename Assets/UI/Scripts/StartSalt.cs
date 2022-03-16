using UnityEngine;

public class StartSalt : MonoBehaviour
{
    public void OnClickStartSalt()
    {
        SpiceCounter.counter++;
        GameObject.FindGameObjectWithTag("SaltAnim").GetComponent<ParticleSystem>().Play();
        PlayerPrefs.SetFloat("Score", PlayerPrefs.GetFloat("Score") + 25);
        Destroy(GameObject.FindGameObjectWithTag("Salt"));
    }
}
