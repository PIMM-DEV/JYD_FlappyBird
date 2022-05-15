using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdControl : MonoBehaviour
{
    public Text RestartUI;

    public static bool gameover = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Screen.SetResolution(480, 800, false);
        RestartUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 250));
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            Level.gameLevel = 1f;
            Level.gameTime = 0;
            Level.cancel = false;
            gameover = false;
            Application.LoadLevel("MainScene");
            RestartUI.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        gameover = true;
        RestartUI.gameObject.SetActive(true);
        Time.timeScale = 0;
        gameObject.GetComponent<Animator>().Play("Die");    
    }
}
