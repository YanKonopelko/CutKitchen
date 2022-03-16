using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiceCounter : MonoBehaviour
{
    public GameObject spices;
    public GameObject mixButton;
    public static int counter;
    int amount;

    float accelerometerUpdateInterval = 1.0f / 60.0f;
    // The greater the value of LowPassKernelWidthInSeconds, the slower the
    // filtered value will converge towards current input sample (and vice versa).
    float lowPassKernelWidthInSeconds = 1.0f;
    // This next parameter is initialized to 2.0 per Apple's recommendation,
    // or at least according to Brady! ;)
    float shakeDetectionThreshold = 2.0f;

    float lowPassFilterFactor;
    Vector3 lowPassValue;

    private void Start()
    {
        counter = 0;
        amount = spices.transform.childCount;

        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
    }

    private void Update()
    {
        Vector3 acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        Vector3 deltaAcceleration = acceleration - lowPassValue;

        if (counter >= amount)
        {
            mixButton.SetActive(true);
            if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
            {
                // Perform your "shaking actions" here. If necessary, add suitable
                // guards in the if check above to avoid redundant handling during
                // the same shake (e.g. a minimum refractory period).
                Debug.Log("Shake event detected at time " + Time.time);
                SceneManager.LoadScene(2);
            }
        }
    }
}
