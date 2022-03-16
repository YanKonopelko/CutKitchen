using UnityEngine;

public class StartOil : MonoBehaviour
{
    public void OnClickStartOil()
    {
        SpiceCounter.counter++;
        GameObject.FindGameObjectWithTag("OilAnim").GetComponent<ParticleSystem>().Play();
        PlayerPrefs.SetFloat("Score", PlayerPrefs.GetFloat("Score") + 25);
        Destroy(GameObject.FindGameObjectWithTag("Oil"));
    }
}
