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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            SetCountText();
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