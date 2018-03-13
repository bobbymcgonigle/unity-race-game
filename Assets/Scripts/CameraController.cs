using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject Player;

	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - Player.transform.position;
		//offset is the distance between player and camera each frame
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		
		transform.position = Player.transform.position + offset;
		//offset is updated each frame by taking the players position and adding the previously calculated offset
		//this sets the cameras position so it is alwasy folling the player by a certain offset
	}
}
