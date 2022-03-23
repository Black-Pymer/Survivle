using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class useitem : MonoBehaviour
{
    public GameObject pistol;
    private Image im;
    private Player Pl;
    private Inventory inv;
    void Awake()
    {
        Pl = GameObject.Find("Player").GetComponent<Player>();
        inv = GameObject.Find("Player").GetComponent<Inventory>();
    }
    public void Use(GameObject obj)
    {
        im = obj.GetComponent<Image>();
        if (im.sprite == Resources.Load<Sprite>("pistol_icon"))
        {
            pistol.SetActive(!pistol.activeSelf);
            Pl.objectInHand = 2;
        }
        else if (im.sprite = Resources.Load<Sprite>("health_icon"))
        {
            for(int i=1; i <= 15; i++)
            {
                if (obj.name == "slot" + i.ToString())
                {
                    inv.slots[i] = 0;
                    Pl.health += 75;
                    break;
                }
            }
        }
    }
}
