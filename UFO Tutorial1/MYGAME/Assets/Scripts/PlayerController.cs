using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
    public Text loseText;

    private Rigidbody2D rb2d;
    private int count;
    private int lives;
   
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = "";
        setCountText();
        setLivesText();
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText();
        }
        
        if (other.gameObject.CompareTag("EnemyPickups"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            setLivesText();
            setCountText();
        }

        if (count == 12) //note that this number should be equal to the number of yellow pickups on the first playfield
        {
            transform.position = new Vector2(0f, 50.0f); 
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 20)
        {
            winText.text = "You Win! Game created by CECILIA LOPEZ";
            Destroy(this);
        }
        if (lives == 0)
        {
            winText.text = "YOU LOSE";
            Destroy(this);
        }


    }


    void setLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
       
    }
 
}
