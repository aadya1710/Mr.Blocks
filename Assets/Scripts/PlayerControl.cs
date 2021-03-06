using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float speed;
    public GameObject GameWonPanel;
    private bool isgamedone = false;
    public GameObject GameLostPanel;
    void Start()
    {
        //print("Start");
    }
    void Update()
    {
        if (isgamedone == true)
        {
            return;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            rigidbody2d.velocity = new Vector2(speed , 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigidbody2d.velocity = new Vector2(-speed, 0f);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rigidbody2d.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rigidbody2d.velocity = new Vector2(0f, -speed );
        }
        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Door")
        {
            Debug.Log("Level Completed!!!");
            GameWonPanel.SetActive(true);
            isgamedone = true;
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }
        else if (collision.tag == "Enemy")
        {
            Debug.Log("Level Completed!!!");
            GameLostPanel.SetActive(true);
            isgamedone = true;
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
