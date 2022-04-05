using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class Inventory : MonoBehaviour
{
    #region variablesAndStart
    public byte[] slots=new byte[15];
    [HideInInspector]public byte objectInHand;//ебну если удали
    public GameObject pistol;
    //воздух - 0 
    //аптечка - 1
    //пистолет - 2
    //патроны - 3
    //палки -4
    //жига - 5
    //карточка - 6
    //
    //
    //
    //
    //
    //Короче теперь тут есть новые Player Prefs
    //level3.1
    #endregion
    #region PickUpAndLoadInventory
    // Start is called before the first frame update
    private void Awake()
    {
        for(byte i = 0; i < slots.Length; i++) {
            byte ij = i;
            ij++;
            slots[i] = (byte)PlayerPrefs.GetInt("slot" + ij.ToString());
        }
    }
    public void pickup()
    {
        byte id = gameObject.GetComponent<Player>().id;
        Player pl = gameObject.GetComponent<Player>();
        if (id == 3) //Патроны
        {
            Debug.Log("Wow!");
            pistol.GetComponent<pistol>().bulletsout += 30;
            pl.col.gameObject.GetComponent<pickuped>().f = 2; 
            Invoke("del", 0.1f);
        }
        else if (id == 6)//Карта
        {
            pl.status = pl.col.gameObject.GetComponent<Card>().stat;
            pl.col.gameObject.GetComponent<pickuped>().f = 2; 
            Invoke("del", 0.1f);
        }
        else//Всё остальное
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] == 0)
                {
                    slots[i] = id;
                    pl.Unenable();
                    pl.col.gameObject.GetComponent<pickuped>().f = 2; 
                    Invoke("del", 0.1f);
                    break;
                }
            }
        }
        
        
    }
    void del()//Удаление объеста с минимальной задержкой
    {
        Player pl = gameObject.GetComponent<Player>();
        Destroy(pl.col.gameObject);
    }
    #endregion
}