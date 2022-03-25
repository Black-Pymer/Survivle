using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    #region variables_and_Start
    private Rigidbody rb;
    [SerializeField]private pistol pist;
    private bool canShoot;

    public byte id =0;
    public byte status = (byte)PlayerPrefs.GetInt("status");
    public GameObject Camera;
    public int health = 100;
    public TextMeshPro hpt;//текст про hp
    public TextMeshPro txtUnderCamera;
    public GameObject[] buttons;
    public float speed;
    public Joystick variableJoystick;
    [HideInInspector]public GameObject col;//collider
    [HideInInspector]public byte objectInHand;
    private void OnLevelWasLoaded(int level)
    {
        health = PlayerPrefs.GetInt("health");
    }
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        Debug.Log(PlayerPrefs.GetInt("slot0"));
        Debug.Log(PlayerPrefs.GetInt("slot1"));
        Debug.Log(PlayerPrefs.GetInt("slot2"));
        Debug.Log(PlayerPrefs.GetInt("slot3"));
        Debug.Log(PlayerPrefs.GetInt("slot4"));
        Debug.Log(PlayerPrefs.GetInt("slot5"));
        Debug.Log(PlayerPrefs.GetInt("slot6"));

    }
    #endregion
    #region Moving
    void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        transform.Translate(direction * speed * Time.fixedDeltaTime*Time.timeScale);
        //начало работы с текстом hp
        hpt.text = health.ToString();
        if (health <= 0 )
        {
            SceneManager.LoadScene("Die");
        }
    }
    #endregion
    #region pickUpItems
    void Update()
    {
        Ray forwardRay = new Ray(Camera.transform.position,Camera.transform.forward);
        Debug.DrawRay(Camera.transform.position, Camera.transform.forward * 5f, Color.red);
        RaycastHit hit;
        
        if (Physics.Raycast(forwardRay, out hit))
        {

            if (hit.distance < 5f)
            {
                if (hit.collider.gameObject.layer == 6)
                {
                    col = hit.collider.gameObject;
                    id=hit.collider.gameObject.GetComponent<NameReader>().id;
                    NameReader nr = hit.collider.gameObject.GetComponent<NameReader>();
                    txtUnderCamera.text = col.GetComponent<NameReader>()._name;
                    for (byte i = 0; i < buttons.Length; i++)
                    {
                        if (nr.type == i)
                        {
                            buttons[i].gameObject.SetActive(true);
                            break;
                        }
                    }
                }
            }
            else
            {
                Unenable();
            }
        }
        else
        {
            Unenable();
        }
        #endregion
        #region UsingItems
        if (objectInHand == 2)
        {
            buttons[2].SetActive(true);
        }
        else
        {
            buttons[2].SetActive(false);
        }
    }
    public void Unenable()
    {
        txtUnderCamera.text = "";
        for (byte i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }
    
    #endregion
}
