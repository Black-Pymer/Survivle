using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Android;
public class Meny : MonoBehaviour
{
    private int iif;
    private int scene = 3;
    private byte i;
    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("Scene_num"));
        //Permission.RequestUserPermission(Permission.InternalStorageWrite);
        Permission.RequestUserPermission(Permission.ExternalStorageWrite);
    }
    // Start is called before the first frame update
    string path;
    public void Continue()
    {
        Debug.Log("Con");
        path=Application.dataPath+"/Data.json";
        if (PlayerPrefs.GetInt("Scene_num") != 0)
        {
            iif = PlayerPrefs.GetInt("Scene_num");
            //string a = File.ReadAllText(path);
            //InventoryInFile iif = new InventoryInFile();
            //iif = JsonUtility.FromJson<InventoryInFile>(a);
            SceneManager.LoadScene(iif);
        }
        else
        {
            CreateAndLoad();
        }
    }
    public void NewGame()
    {
        PlayerPrefs.SetInt("Scene_num",0);
        for(i = 0;i<=15; i++)
        {
            PlayerPrefs.SetInt("slot" + i.ToString(), 0);
        }
        PlayerPrefs.SetInt("status",0);
        for (int b = 3; b<60;b++)
        {
            for (int i = 1; i < 15; i += 1)
            {
                PlayerPrefs.SetInt("level" + scene.ToString()+ "." + i.ToString(), 0);
                Debug.Log("level" + scene.ToString()+"." + i.ToString());
                if (i >= 15)
                {
                    break;
                }
            }
            scene++;
        }
        
        
        CreateAndLoad();
    }
    void CreateAndLoad()
    {
        PlayerPrefs.SetInt("Scene_num", 1);
        SceneManager.LoadScene(1);
    }
}
