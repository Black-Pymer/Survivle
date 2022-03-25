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
        else if (im.sprite = Resources.Load<Sprite>("heal_icon"))
        {
            for(int i=1; i <= 15; i++)
            {
                if (obj.name == "slot" + i.ToString())
                {
                    i--;
                    inv.slots[i] = 0;
                    im.sprite = Resources.Load<Sprite>("air_icon");
                    Pl.health += 75;
                    if (Pl.health > 100)
                    {
                        Pl.health = 100; 
                    }
                    break;
                }
            }
        }
    }
}
