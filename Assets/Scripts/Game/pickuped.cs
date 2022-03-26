using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickuped : MonoBehaviour
{
    public int g = 1;
    public string name;
    public GameObject obj;
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
            Destroy(obj);
            Debug.Log("Привет ты лох, если будешь багаюзить данную механику");
        }
        Debug.Log(name+PlayerPrefs.GetInt(name).ToString());
    }
    public void OnDestroy()
    {
        PlayerPrefs.SetInt(name,g);
    }
}
