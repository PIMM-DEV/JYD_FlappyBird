using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(480, 800, false);
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
            Application.LoadLevel("MainScene");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("GameOver");
        Time.timeScale = 0;
    }
}
