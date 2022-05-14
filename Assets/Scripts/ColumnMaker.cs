using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnMaker : MonoBehaviour
{
    public GameObject Column;

    private float nowTime;
    private float makeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        nowTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - nowTime > makeTime)
        {
            nowTime = Time.time;
            GameObject temp = Instantiate(Column);
            temp.transform.parent = gameObject.transform;

            float randomY = Random.Range(4f, -2f);

            temp.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 5f, randomY, 0);
            temp.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
