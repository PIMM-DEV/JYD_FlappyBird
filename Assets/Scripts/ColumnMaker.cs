using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnMaker : MonoBehaviour
{
    public GameObject Column;

    private float nowTime;
    private float makeTime = 2.5f;

    public Text ScoreUI;
    private int score = -2;


    // Start is called before the first frame update
    void Start()
    {
        nowTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Level.cancel == true)
        {
            nowTime = Time.time;
        }

        if(Time.time - nowTime > makeTime && Level.cancel == false)
        {
            nowTime = Time.time;
            GameObject temp = Instantiate(Column);
            temp.transform.parent = gameObject.transform;

            float randomY = Random.Range(4f, -2f);

            temp.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 10f, randomY, 0);
            temp.transform.localScale = new Vector3(1, 1, 1);

            score++;
            if (score < 0)
            {
                ScoreUI.text = "0";
            }
            else
            {
                ScoreUI.text = score.ToString();
            }
        }

        Level.cancel = false;
        makeTime = 2.5f / Level.gameLevel;
    }
}
