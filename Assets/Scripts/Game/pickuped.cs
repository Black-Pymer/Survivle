using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickuped : MonoBehaviour
{
    public int f = 0;
    public int g = 1;
    public string name;
    public GameObject obj;
    private void FixedUpdate()
    {
        if (f == 2)
        {
            PlayerPrefs.SetInt(name,2);
            f = 0;
        }
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt(name) == 0)
        {
            PlayerPrefs.SetInt(name,1);
        }
        else if (PlayerPrefs.GetInt(name) == 1)
        {
            Debug.Log("All normal");
        }
        else if(PlayerPrefs.GetInt(name) == 2)
        {
            Debug.Log("Если ты будешь работать, то будет кайфово");
            Destroy(obj);
        }
        Debug.Log(name+PlayerPrefs.GetInt(name).ToString());
    }
    
}
