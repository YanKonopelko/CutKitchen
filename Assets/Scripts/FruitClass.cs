using UnityEngine;
using TMPro;
using System;
using System.Collections;
public class FruitClass : MonoBehaviour
{
    public bool divided = false;
    [SerializeField] GameObject Congratulations;
    [SerializeField] float divideLength = 0.2f;
    public void DevideFruit(Vector3 startpos, Vector3 exitpos)
    {
        Vector3 newpos;
        if (!divided)
        {
            transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
            transform.GetChild(1).GetChild(2).gameObject.SetActive(true);

            var obj = transform.GetChild(1).GetChild(0).GetComponent<FixedJoint>();
            Destroy(obj);
            newpos = transform.GetChild(0).position;
            newpos.x -= divideLength;
            transform.GetChild(0).position = newpos;
            newpos = transform.GetChild(1).position;
            newpos.x += divideLength;
            transform.GetChild(1).position = newpos;
            divided = true;
            transform.GetChild(0).GetComponent<FruitHalfs>().divided = false;
            transform.GetChild(1).GetComponent<FruitHalfs>().divided = false;

            bool perfect = false;

            if (Math.Abs(startpos.z - (startpos.z - exitpos.z) / 2 - transform.parent.GetChild(1).position.z) +
                Math.Abs(startpos.x - (startpos.x - exitpos.x) / 2 - transform.parent.GetChild(1).position.x) < 0.6f)
                perfect = true;
            Debug.Log(transform.parent.GetChild(1).position);
            var pos = new Vector3(startpos.x - (startpos.x - exitpos.x) / 2, 2, startpos.z - (startpos.z - exitpos.z) / 2);
            Debug.Log(pos);

            if (perfect)
            {
                if (GameObject.Find("SwipeManager").GetComponent<SwipeManager>().PerfectSliceCount < 8)
                    GameObject.Find("SwipeManager").GetComponent<SwipeManager>().PerfectSliceCount += 1;

                var congr = Instantiate(Congratulations, GameObject.Find("GameplayCanvas").transform);
                congr.GetComponent<RectTransform>().anchoredPosition = new Vector2(420, 900);
                var anim = congr.transform.GetComponent<Animation>();
                anim.Play("CongratulationsAnim");
                GameObject.Find("SwipeManager").GetComponent<SwipeManager>().Refresh();
            }
            else
            {
                //GameObject.Find("SwipeManager").GetComponent<SwipeManager>().PerfectSliceCount = 0;
                GameObject.Find("SwipeManager").GetComponent<SwipeManager>().Refresh();
            }

            var score = float.Parse(GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text);
            score += 10 * (1 + 0.5f * GameObject.Find("SwipeManager").GetComponent<SwipeManager>().PerfectSliceCount);
            GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = score.ToString();
            Destroy(transform.parent.GetChild(1).gameObject);

            PlayerPrefs.SetFloat("Score", score);

            if (transform.parent.GetChild(2).gameObject != null)
            {
                StartCoroutine(SeedFall());
            }
        }
    }

    IEnumerator SeedFall()
    {
        yield return new WaitForSeconds(0.5f);
        transform.parent.GetChild(2).GetComponent<BoxCollider>().enabled = true;
    }
}