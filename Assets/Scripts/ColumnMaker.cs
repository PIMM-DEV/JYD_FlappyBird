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
    private float makeTime = 2f;

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

            if(Level.gameLevel > 1.2 || Level.Hellmode == 2)
            {
                if(RandomC < 0.40 * (Level.gameLevel - 1))
                {
                    GameObject temp = Instantiate(FColumn);
                    temp.transform.parent = gameObject.transform;

                    float randomY = Random.Range(7f, 3.5f);
                    temp.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 10f, randomY, 0);
                    temp.transform.localScale = new Vector3(1, 1, 1);
                    if(Level.gameLevel > 1.7 || Level.Hellmode == 2)
                    {
                        if(RandomR < 0.40 * (Level.gameLevel - 1))
                        {
                        temp.transform.rotation = Quaternion.Euler(0,0,15 * Level.Hellmode);
                        }
                        if(RandomR > 1 - 0.40 * (Level.gameLevel - 1))
                        {
                        temp.transform.rotation = Quaternion.Euler(0,0,-15 * Level.Hellmode);
                        }
                    }
                    
                }
                else if(RandomC > 1 - 0.40 * (Level.gameLevel - 1))
                {
                    GameObject temp = Instantiate(RColumn);
                    temp.transform.parent = gameObject.transform;

                    float randomY = Random.Range(-1.5f, -5f);
                    temp.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 10f, randomY, 0);
                    temp.transform.localScale = new Vector3(1, 1, 1);
                    if(Level.gameLevel > 1.7 || Level.Hellmode == 2)
                    {
                        if(RandomR < 0.40 * (Level.gameLevel - 1))
                        {
                        temp.transform.rotation = Quaternion.Euler(0,0,15 * Level.Hellmode);
                        }
                        if(RandomR > 1 - 0.40 * (Level.gameLevel - 1) * 4)
                        {
                        temp.transform.rotation = Quaternion.Euler(0,0,-15 * Level.Hellmode);
                        }
                    }
                }
                else
                {
                    GameObject temp = Instantiate(Column);
                    temp.transform.parent = gameObject.transform;

                    float randomY = Random.Range(3.75f, -1.75f);
                    temp.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 10f, randomY, 0);
                    temp.transform.localScale = new Vector3(1, 1, 1);
                    if(Level.gameLevel > 1.4 || Level.Hellmode == 2)
                    {
                        if(RandomR < 0.40 * (Level.gameLevel - 1))
                        {
                        temp.transform.rotation = Quaternion.Euler(0,0,15 * Level.Hellmode);
                        }
                        if(RandomR > 1 - 0.40 * (Level.gameLevel - 1))
                        {
                        temp.transform.rotation = Quaternion.Euler(0,0,-15 * Level.Hellmode);
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
        makeTime = 2f;
    }
}
