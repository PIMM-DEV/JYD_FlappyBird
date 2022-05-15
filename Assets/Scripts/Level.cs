using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static float gameTime;
    public static float gameLevel = 1f;
    public static bool cancel = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        gameTime++;
        if (gameTime > 240)
        {
            gameObject.transform.localPosition += new Vector3(0.0006944f, 0, 0);
            Debug.Log(gameLevel);
        }
        if (gameTime % 1800 == 240 && gameTime > 240)  
        {
            cancel = true;
            gameLevel += 0.25f;
        }
    }
}
