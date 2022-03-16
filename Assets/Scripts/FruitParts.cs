using UnityEngine;
using TMPro;

public class FruitParts : MonoBehaviour
{
    public bool divided = false;
    [SerializeField] GameObject _pr_cubes;
    public void DevideParts()
    {
        Destroy(transform.gameObject);
        GameObject cubes = Instantiate(_pr_cubes, transform.position, Quaternion.identity);
        cubes.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = transform.GetComponent<MeshRenderer>().materials[0].color;
        cubes.transform.GetChild(1).GetComponent<MeshRenderer>().materials[0].color = transform.GetComponent<MeshRenderer>().materials[0].color;
        cubes.transform.GetChild(2).GetComponent<MeshRenderer>().materials[0].color = transform.GetComponent<MeshRenderer>().materials[0].color;
        cubes.transform.GetChild(3).GetComponent<MeshRenderer>().materials[0].color = transform.GetComponent<MeshRenderer>().materials[0].color;
        cubes.transform.GetChild(4).GetComponent<MeshRenderer>().materials[0].color = transform.GetComponent<MeshRenderer>().materials[0].color;
        cubes.transform.GetChild(5).GetComponent<MeshRenderer>().materials[0].color = transform.GetComponent<MeshRenderer>().materials[0].color;

        cubes.transform.GetChild(0).tag = "Cubes";
        cubes.transform.GetChild(1).tag = "Cubes";
        cubes.transform.GetChild(2).tag = "Cubes";
        cubes.transform.GetChild(3).tag = "Cubes";
        cubes.transform.GetChild(4).tag = "Cubes";
        cubes.transform.GetChild(5).tag = "Cubes";
        var score = float.Parse(GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text);
        score += 10 * (1 + 0.5f * GameObject.Find("SwipeManager").GetComponent<SwipeManager>().PerfectSliceCount);
        GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = score.ToString();

        PlayerPrefs.SetFloat("Score", score);
    }

}