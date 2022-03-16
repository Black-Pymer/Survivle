using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Android;
public class Meny : MonoBehaviour
{
    private int iif;
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
        CreateAndLoad();
    }
    void CreateAndLoad()
    {
        PlayerPrefs.SetInt("Scene_num", 1);
        SceneManager.LoadScene(1);
    }
}
