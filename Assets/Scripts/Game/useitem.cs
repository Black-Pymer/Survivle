using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class useitem : MonoBehaviour
{
    public GameObject pistol;
    private Image im;
    private Player Pl;
    void Awake()
    {
        Pl = GameObject.Find("Player").GetComponent<Player>();
    }
    public void Use(GameObject obj)
    {
        im = obj.GetComponent<Image>();
        if (im.sprite == Resources.Load<Sprite>("pistol_icon"))
        {
            pistol.SetActive(!pistol.activeSelf);
            Pl.objectInHand = 2;
        }
    }
}
