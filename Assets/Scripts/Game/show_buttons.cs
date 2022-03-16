using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show_buttons : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject Inv_but_1;
    public GameObject Inv_but_2;
    Inventory inv;

    private int id;



    private void Start()
    {
        inv = GameObject.Find("Player").GetComponent<Inventory>();
    }


    public void ShowInventory()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetActive(!slots[i].gameObject.activeSelf);
            if (slots[i].gameObject.activeSelf)
            {
                id = inv.slots[i];
                switch (id)
                {
                    case 1:
                        slots[i].gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("heal_icon");
                        break;
                    case 2:
                        slots[i].gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("pistol_icon");
                        break;
                }
            }
        }
    }
}
