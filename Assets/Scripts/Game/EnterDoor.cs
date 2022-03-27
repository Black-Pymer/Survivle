using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class EnterDoor : MonoBehaviour
{
    public byte status;
    public byte scene_num = 0;
    public GameObject pistol;
    private Player lp;
    private byte a;
    Inventory inv;
    private void Start()
    {
        inv=GameObject.Find("Player").GetComponent<Inventory>();
        lp = GameObject.Find("Player").GetComponent<Player>();
    }
    // Start is called before the first frame update
    public void buttonPressed()
    {
        Debug.Log("ButtonPressed");
        if (lp.status >= status)
        {
            //Time.timeScale = 0;
            //string a = File.ReadAllText(inv.savePath);
            //iif = JsonUtility.FromJson<InventoryInFile>(a); потом почини это дерьмо я не вкурсе как ;)
            //SceneManager.LoadScene(iif.scene);
            for(byte i = 0; i<inv.slots.Length;i++)
            {
                a = i;
                i++;
                PlayerPrefs.SetInt("slot" + i.ToString(), inv.slots[a]);
                i--;
            }
            PlayerPrefs.SetInt("ObjectInHand", inv.objectInHand);
            PlayerPrefs.SetInt("bulletsin", (int)pistol.GetComponent<pistol>().bulletsin);
            PlayerPrefs.SetInt("bulletsout", (int)pistol.GetComponent<pistol>().bulletsout);
            PlayerPrefs.SetInt("health", (int)lp.health);
            PlayerPrefs.SetInt("status",(int)lp.status);
            if (scene_num == 0)
            {
                PlayerPrefs.SetInt("Scene_num", SceneManager.GetActiveScene().buildIndex + 1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
            else
            {
                PlayerPrefs.SetInt("Scene_num", scene_num);
                SceneManager.LoadScene(scene_num);
            }
            
            
        }
    }
}
