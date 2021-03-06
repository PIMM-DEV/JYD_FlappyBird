using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdControl : MonoBehaviour
{
    public Text RestartUI;
    public Text WinUI;

    public static bool gameover = false;
    private float birdcolor = 255f;
    SpriteRenderer bird;
    

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Screen.SetResolution(480, 800, false);
        RestartUI.gameObject.SetActive(false);
        WinUI.gameObject.SetActive(false);
        bird = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) 
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
            WinUI.gameObject.SetActive(false);
            Level.Hellmode = 1;
        }
        if(Level.gameLevel == 0f)
        {
            gameObject.transform.localPosition += new Vector3(0.1f, 0, 0);
            WinUI.gameObject.SetActive(true);
            if (Level.Hellmode == 1)
            {
                WinUI.text = "You Win!\nThanks For Playing!\nPress 'H' Key to\ntry HELLMODE...";
            }
            if (Level.Hellmode == 2)
            {
                WinUI.text = "You Win 'HELLMODE'!\nThanks for Playing!";
            }
        }
        if (Level.Hellmode == 2 && birdcolor > 100)
        {
            birdcolor -= 0.5f;
            bird.material.color = new Color(255/255f, birdcolor/255f, birdcolor/255f);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (Level.gameLevel != 0f)
        {
            gameover = true;
            RestartUI.gameObject.SetActive(true);
            Time.timeScale = 0;
            gameObject.GetComponent<Animator>().Play("Die");
        }    
    }

}
