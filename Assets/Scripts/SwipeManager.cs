using UnityEngine;
using TMPro;
public class SwipeManager : MonoBehaviour
{
    public int PerfectSliceCount = 0;
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        text.text = "X1";
    }
    public void Refresh()
    {
        float k = 1 + PerfectSliceCount * 0.5f;
        text.text = "X" + k;
    }
}