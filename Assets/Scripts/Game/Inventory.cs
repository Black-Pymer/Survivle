using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class Inventory : MonoBehaviour
{
    #region variablesAndStart
    public byte[] slots=new byte[15];
    public byte objectInHand;//���� ���� �����
    public GameObject pistol;
    //������ - 0 
    //������� - 1
    //�������� - 2
    //������� - 3
    //����� -4
    //���� - 5
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
        //savePath = Application.persistentDataPath+"/Data.json";
        //if (File.Exists(savePath))
        //{
        //string fileData=File.ReadAllText(savePath);
        //InventoryInFile iif1=JsonUtility.FromJson<InventoryInFile>(fileData);
        //}
        //else
        //{
        //File.WriteAllText(savePath, "");
        //}
       
    }
    public void pickup()
    {
        byte id = gameObject.GetComponent<Player>().id;
        if (id == 3)
        {
            Debug.Log("Wow!");
            pistol.GetComponent<pistol>().bulletsout += 30;
            Destroy(gameObject.GetComponent<Player>().col);
        }
        else
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] == 0)
                {
                    slots[i] = id;
                    Player pl = gameObject.GetComponent<Player>();
                    Destroy(pl.col.gameObject);
                    pl.Unenable();
                    break;
                }
            }
        }
    }
    #endregion
}