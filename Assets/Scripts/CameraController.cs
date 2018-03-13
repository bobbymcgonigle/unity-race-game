using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject Player;

    public float height;
    private float distance;
	private Vector3 offset;
    private Quaternion rotation;
    private float rotationSpeed = 0.5f;
    private Vector3 playerPrevPos, playerMoveDir;

    // Use this for initialization
    void Start () 
	{
		offset = transform.position - Player.transform.position;
        distance = offset.magnitude;
        playerPrevPos = Player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
        playerMoveDir = Player.transform.position - playerPrevPos;
        playerMoveDir.Normalize();
        transform.position = Player.transform.position - playerMoveDir * distance;
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
        transform.LookAt(Player.transform.position);
        playerPrevPos = Player.transform.position;
        //transform.rotation = new Quaternion(transform.rotation.z, 45, transform.rotation.y, 0);
        //transform.LookAt(player.transform.position);

    }
}
