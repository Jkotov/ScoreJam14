using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adfa : MonoBehaviour
{
    public float time { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("TimeText"))
        {
            GameObject.Find("TimeText").GetComponent<winTime>().SetTime(time);
            Destroy(this.gameObject);
        }
    }
}
