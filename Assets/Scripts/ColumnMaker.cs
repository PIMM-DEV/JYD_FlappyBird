using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnMaker : MonoBehaviour
{
    public GameObject Column;
    public GameObject LColumn;
    public GameObject RColumn;
    public int score = -2;

    private float nowTime;
    private float makeTime = 2.5f;

    public Text ScoreUI;


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
            float randomC = Random.Range(3f, 0f);

            if(Level.gameLevel > 1.4 && randomC > 2f)
            {
                GameObject temp = Instantiate(RColumn);
                temp.transform.parent = gameObject.transform;
                float randomY = Random.Range(2f, -2f);

                temp.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 10f, randomY, 0);
                temp.transform.localScale = new Vector3(1, 1, 1);
            }
            else if(Level.gameLevel > 1.4 && randomC < 1f)
            {
                GameObject temp = Instantiate(LColumn);
                temp.transform.parent = gameObject.transform;
                float randomY = Random.Range(4f, 2f);

                temp.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 10f, randomY, 0);
                temp.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                GameObject temp = Instantiate(Column);
                temp.transform.parent = gameObject.transform;
                float randomY = Random.Range(4f, -2f);

                temp.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 10f, randomY, 0);
                temp.transform.localScale = new Vector3(1, 1, 1);
            }

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
