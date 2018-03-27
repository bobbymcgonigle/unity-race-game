using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public Text countText;
    
    private int count;

    void Start()
    {
        count = 3;
        SetCountText();
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            SetCountText();
        }
    }
    */
	//for testinf purposes at the moment othe wall is destroyed when collided with and a life is taken away, The wall will not be dostoryed in the final build, This is just a test
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Wall")
		{
			Destroy(col.gameObject); //If collision with a wall occurs destroy the wall object
			count = count - 1;	//remove a life
			SetCountText(); // display new lives
		}
	}

    void SetCountText()
    {
        countText.text = "Lives: " + count.ToString();
        if (count <= 0)
        {
            countText.text = "Game Over!";
        }
    }
}