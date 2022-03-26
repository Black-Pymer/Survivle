using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class Inventory : MonoBehaviour
{
    #region variablesAndStart
    public byte[] slots=new byte[15];
    [HideInInspector]public byte objectInHand;//���� ���� �����
    public GameObject pistol;
    //������ - 0 
    //������� - 1
    //�������� - 2
    //������� - 3
    //����� -4
    //���� - 5
    //
    //������ ������ ��� ���� ����� Player Prefs
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
        if (id == 3)
        {
            Debug.Log("Wow!");
            pistol.GetComponent<pistol>().bulletsout += 30;
        }
        else
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] == 0)
                {
                    slots[i] = id;
                    pl.Unenable();
                    break;
                }
            }
        }
        Destroy(pl.col.gameObject);
    }
    #endregion
}