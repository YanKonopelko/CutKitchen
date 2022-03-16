using UnityEngine;
using System;
using TMPro;
public class SwipeDetection : MonoBehaviour
{
    Vector3 startpos;
    Vector3 exitpos;
    Ray ray;
    RaycastHit raycstHit;
    public void Tuch()
    {
#if UNITY_EDITOR
        ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycstHit, float.MaxValue))
            startpos = raycstHit.point;
#endif

#if PLATFORM_ANDROID
        if (Input.touchCount > 0)
        {
            ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out raycstHit, float.MaxValue))
                startpos = raycstHit.point;
        }
#endif
    }
    public void unTouch()
    {
#if UNITY_EDITOR
        ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycstHit, float.MaxValue))
            exitpos = raycstHit.point;
#endif
#if PLATFORM_ANDROID
        if (Input.touchCount > 0)
        {
            ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out raycstHit, float.MaxValue))
                exitpos = raycstHit.point;
        }
#endif
        if (startpos.z < exitpos.z)
        {
            var a = exitpos;
            exitpos = startpos;
            startpos = a;

        }

        if (Math.Abs((startpos.z - exitpos.z)) > 0.4f && Math.Abs((startpos.x - exitpos.x)) < 0.5f)
        {
            if (transform.GetComponent<FruitParts>() != null && transform.parent.GetComponent<FruitHalfs>() != null && transform.parent.GetComponent<FruitHalfs>().divided == true && transform.parent.parent.GetComponent<FruitClass>().divided == true && transform.GetComponent<FruitParts>().divided == false)
            {
                transform.GetComponent<FruitParts>().DevideParts();
            }
            if (transform.GetComponent<FruitHalfs>() != null && transform.parent.GetComponent<FruitClass>() != null && transform.parent.GetComponent<FruitClass>().divided == true && transform.GetComponent<FruitHalfs>().divided == false)
            {
                transform.GetComponent<FruitHalfs>().DevideHafls(startpos, exitpos);
            }
            if (transform.GetComponent<FruitClass>() != null && transform.GetComponent<FruitClass>().divided == false)
            {
                transform.GetComponent<FruitClass>().DevideFruit(startpos, exitpos);
            }
            if (transform.name == "Seed")
            {
                transform.GetComponent<AvocadoSeed>().hp -= 1;
                if (transform.GetComponent<AvocadoSeed>().hp == 0)
                {
                    var score = float.Parse(GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text);
                    score += 100;
                    GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = score.ToString();
                    PlayerPrefs.SetFloat("Score", score);
                    Destroy(transform.gameObject);
                }
            }
        }
    }
}