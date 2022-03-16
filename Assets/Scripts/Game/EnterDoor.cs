using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
public class EnterDoor : MonoBehaviour
{
    public byte status;
    public GameObject pistol;
    public TextMeshPro txt_under_Camera;
    private Player lp;
    private byte a;
    private byte scene_num;
    Inventory inv;
    private void Start()
    {
        inv=GameObject.Find("Player").GetComponent<Inventory>();
        lp = GameObject.Find("Player").GetComponent<Player>();
        scene_num = (byte)SceneManager.GetActiveScene().buildIndex;
    }
    // Start is called before the first frame update
    public void buttonPressed()
    {
        Debug.Log("ButtonPressed");
        if (PlayerPrefs.GetInt("status") >= status)
        {
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
            if (scene_num == 0)
            {
                PlayerPrefs.SetInt("Scene_num", SceneManager.GetActiveScene().buildIndex + 1);
                PlayerPrefs.SetInt("ObjectInHand", inv.objectInHand);
                PlayerPrefs.SetInt("bulletsin", pistol.GetComponent<pistol>().bulletsin);
                PlayerPrefs.SetInt("bulletsout", pistol.GetComponent<pistol>().bulletsout);
                PlayerPrefs.SetInt("health", (int)lp.health);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                PlayerPrefs.SetInt("Scene_num", scene_num);
                PlayerPrefs.SetInt("ObjectInHand", inv.objectInHand);
                PlayerPrefs.SetInt("bulletsin", pistol.GetComponent<pistol>().bulletsin);
                PlayerPrefs.SetInt("bulletsout", pistol.GetComponent<pistol>().bulletsout);
                PlayerPrefs.SetInt("health", (int)lp.health);
                SceneManager.LoadScene(scene_num);
            }
            
        }
        else
        {
            txt_under_Camera.text = "Нужен уровень доступа "+status.ToString();
        }
    }
}
