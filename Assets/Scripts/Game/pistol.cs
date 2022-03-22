using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistol : MonoBehaviour
{
    public int bulletsin;
    public int bulletsout;
    public GameObject Camera;

    private bool canShoot = true;
    private bool isReloading;
    // Start is called before the first frame update
    void OnLevelWasLoaded()
    {
        bulletsin = PlayerPrefs.GetInt("bulletsin");
        bulletsout = PlayerPrefs.GetInt("bulletsout");
    }
    public void Shoot()
    {
        if (bulletsin == 0&&!isReloading)
        {
            Reload();
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }

        if (canShoot)
        {
            Ray shot = new Ray(Camera.transform.position, Camera.transform.forward);
            Debug.DrawRay(Camera.transform.position, Camera.transform.forward * 5f, Color.green);
            RaycastHit hit1;
            Debug.Log("hello");
            if (Physics.Raycast(shot, out hit1) && hit1.collider.gameObject.tag == "Enemy")
            {
                hit1.collider.gameObject.GetComponent<Zombi>().health -= 20;
            }
            bulletsin -= 1;
            Camera.transform.parent.gameObject.GetComponent<AudioSource>().Play();
        }
        
    }
    public void Reload()
    {
        isReloading = true;
        Camera.transform.parent.gameObject.GetComponent<Player>().txtUnderCamera.text = "Reloading weapon...";//Тронешь - ёбну

        if (bulletsout >= 6)
        {
            Invoke("Rel", 1.5f);
        }
        else
        {
            Debug.Log("Нету патронов");
        }
    }
    void Rel()
    {
        bulletsin += 6;
        bulletsout -= 6;
        isReloading = false;
    }
}
