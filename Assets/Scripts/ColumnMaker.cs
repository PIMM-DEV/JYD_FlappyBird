using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnMaker : MonoBehaviour // 특) 코드 개더러움
{
    public GameObject Column;
    public GameObject RColumn;
    public GameObject FColumn;
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
            float RandomC = Random.Range(1f, 0f);
            float RandomR = Random.Range(1f, 0f);

            if(Level.gameLevel > 1.2)
            {
                if(RandomC < 0.40 * (Level.gameLevel - 1))
                {
                    GameObject temp = Instantiate(FColumn);
                    temp.transform.parent = gameObject.transform;

                    float randomY = Random.Range(4f, 1f);
                    temp.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 10f, randomY, 0);
                    temp.transform.localScale = new Vector3(1, 1, 1);
                    if(Level.gameLevel > 1.7)
                    {
                        if(RandomR < 0.40 * (Level.gameLevel - 1))
                        {
                        temp.transform.rotation = Quaternion.Euler(0,0,15);
                        }
                        if(RandomR > 1 - 0.40 * (Level.gameLevel - 1))
                        {
                        temp.transform.rotation = Quaternion.Euler(0,0,-15);
                        }
                    }
                    
                }
                else if(RandomC > 1 - 0.40 * (Level.gameLevel - 1))
                {
                    GameObject temp = Instantiate(RColumn);
                    temp.transform.parent = gameObject.transform;

                    float randomY = Random.Range(1f, -2f);
                    temp.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 10f, randomY, 0);
                    temp.transform.localScale = new Vector3(1, 1, 1);
                    if(Level.gameLevel > 1.7)
                    {
                        if(RandomR < 0.40 * (Level.gameLevel - 1))
                        {
                        temp.transform.rotation = Quaternion.Euler(0,0,15);
                        }
                        if(RandomR > 1 - 0.40 * (Level.gameLevel - 1) * 4)
                        {
                        temp.transform.rotation = Quaternion.Euler(0,0,-15);
                        }
                    }
                }
                else
                {
                    GameObject temp = Instantiate(Column);
                    temp.transform.parent = gameObject.transform;

                    float randomY = Random.Range(4f, -2f);
                    temp.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 10f, randomY, 0);
                    temp.transform.localScale = new Vector3(1, 1, 1);
                    if(Level.gameLevel > 1.4)
                    {
                        if(RandomR < 0.40 * (Level.gameLevel - 1))
                        {
                        temp.transform.rotation = Quaternion.Euler(0,0,15);
                        }
                        if(RandomR > 1 - 0.40 * (Level.gameLevel - 1))
                        {
                        temp.transform.rotation = Quaternion.Euler(0,0,-15);
                        }
                    }
                }
            }
            else
            {
                GameObject temp = Instantiate(Column);
                temp.transform.parent = gameObject.transform;

                float randomY = Random.Range(4f, -2f);
                temp.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 10f, randomY, 0);
                temp.transform.localScale = new Vector3(1, 1, 1);
                if(Level.gameLevel > 1.4)
                {
                    if(RandomR < 0.40 * (Level.gameLevel - 1))
                    {
                    temp.transform.rotation = Quaternion.Euler(0,0,30);
                    }
                    if(RandomR > 1 - 0.40 * (Level.gameLevel - 1))
                    {
                    temp.transform.rotation = Quaternion.Euler(0,0,-30);
                    }
                }
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
