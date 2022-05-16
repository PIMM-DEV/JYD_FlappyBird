using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    float _distance = 7f;
    int _count = 2;
    int _index = 2;

    public GameObject[] backgrounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
            return;
        if(Level.Hellmode == 2)
        {
            gameObject.transform.localPosition += new Vector3(-0.01f * (Level.gameLevel + 0.5f), 0, 0);
        }
        else
        {
            gameObject.transform.localPosition += new Vector3(-0.01f * Level.gameLevel, 0, 0);
        }
        
        _count = 2 + (int) (-gameObject.transform.localPosition.x / 7f);

        if(_index != _count)
        {
            backgrounds[(_index-2) % 3].transform.localPosition = new Vector3(_distance * _count, 0, 0);
            _index = _count;
        }
    }
}
