using UnityEngine;
using TMPro;
using System;

public class FruitHalfs : MonoBehaviour
{
    [SerializeField] public int Number;
    public bool divided = false;
    public int dividecount = 0;
    [SerializeField] GameObject Congratulations;
    public void DevideHafls(Vector3 startpos, Vector3 exitpos)
    {
        Vector3 newpos;
        bool perfect = false;
        if (!divided)
        {
            if (Number == 1)
            {
                var obj = transform.GetChild(0).GetComponent<FixedJoint>();
                Destroy(obj);
                newpos = transform.GetChild(1).position;
                newpos.x -= 0.1f;
                transform.GetChild(1).position = newpos;
            }
            else
            {

                var obj = transform.GetChild(1).GetComponent<FixedJoint>();
                Destroy(obj);
                newpos = transform.GetChild(1).position;
                newpos.x += 0.1f;
                transform.GetChild(1).position = newpos;

            }
            divided = true;



            if (Math.Abs(startpos.z - (startpos.z - exitpos.z) / 2 - transform.position.z) +
                Math.Abs(startpos.x - (startpos.x - exitpos.x) / 2 - transform.GetChild(2).position.x) < 0.6f)
                perfect = true;
            if (perfect)
            {
                if (GameObject.Find("SwipeManager").GetComponent<SwipeManager>().PerfectSliceCount < 8)
                    GameObject.Find("SwipeManager").GetComponent<SwipeManager>().PerfectSliceCount += 1;
                GameObject.Find("SwipeManager").GetComponent<SwipeManager>().Refresh();

                var congr = Instantiate(Congratulations, GameObject.Find("GameplayCanvas").transform);
                congr.GetComponent<RectTransform>().anchoredPosition = new Vector2(420, 900);
                var anim = congr.transform.GetComponent<Animation>();
                anim.Play("CongratulationsAnim");
            }
            else
            {
                //GameObject.Find("SwipeManager").GetComponent<SwipeManager>().PerfectSliceCount = 0;
                GameObject.Find("SwipeManager").GetComponent<SwipeManager>().Refresh();
            }
            var score = float.Parse(GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text);
            score += 10 * (1 + 0.5f * GameObject.Find("SwipeManager").GetComponent<SwipeManager>().PerfectSliceCount);
            GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = score.ToString();
            Destroy(transform.GetChild(2).gameObject);

            PlayerPrefs.SetFloat("Score", score);
        }
    }

}