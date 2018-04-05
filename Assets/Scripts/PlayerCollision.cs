using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public Text countText;
    public GameOver GameOverMenu;
    public int lives;

    void Start()
    {
        lives = 3;
        SetCountText();
    }

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Wall")
		{
			Destroy(col.gameObject); //If collision with a wall occurs destroy the wall object
            lives = lives - 1;	//remove a life
			SetCountText(); // display new lives
		}

	}

    void SetCountText()
    {
        countText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            
			GameOverMenu.TriggerGameOver(); //gamecontroller is refernced here and will show the game over screen 
        }
    }
}