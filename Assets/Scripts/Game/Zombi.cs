using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Zombi : MonoBehaviour
{
    #region variables_and_Start
    public float radius;
    public float speed;
    public float s;
    public int hard = 1;
    public bool isready = true;
    public byte health = 100;
    public TextMeshPro healthText;

    private GameObject player;
    [SerializeField]private bool playerInArea = false;
    private Rigidbody rb;
    private Player pl;
    private Rigidbody rbpl;
    private Animator an;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pl = player.GetComponent<Player>();
        rbpl = player.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        an = GetComponent<Animator>();
    }
    #endregion
    #region Updetes
    void Update()
    {
        if (playerInArea)
        {
            Debug.Log(3);
            healthText.text=health.ToString();
            transform.LookAt(player.transform.position);
            an.SetBool("inPlayer", true);
            Ray checkPlayer = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(checkPlayer,out hit))
            {
                Debug.Log(4);
                if (hit.distance < 3&&hit.collider.gameObject.name=="Player"&&isready==true)
                {
                    Debug.Log(5);
                    Invoke("damage",1f);
                    isready = false;
                    
                }
            }
        }
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position,radius);
        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            if (overlappedColliders[i].gameObject.name == "Player")
            {
                playerInArea = true;
                an.SetBool("inPlayer",true);
                break;
            }
            else
            {
                playerInArea = false;
                an.SetBool("inPlayer",false);
            }
        }
        if (health <= 0)
        {
            an.SetBool("isLiving", false);
            Invoke("Death", 2f);
        }

    }
    private void FixedUpdate()
    {
        if (playerInArea)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed*Time.timeScale);
            
        }
    }
    #endregion
    #region otherVoids
    void damage()
    {
        pl.health -= 5*hard;
        isready = true;
    }
    void Death()
    {
        Destroy(gameObject);
    }
    #endregion
}
