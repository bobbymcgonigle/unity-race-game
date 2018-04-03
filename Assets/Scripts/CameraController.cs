using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject Player;

    public CameraPathScript currentPath;
    
    public float speed = 10;                //movement speed
    public int CurrentWayPointID = 0;       //current destiation
    private float reachDistance = 1.0f;
    public float playerDist;                //distance between camera and player
    
    void Start () 
	{}
	
	void LateUpdate () 
	{
        float distance = Vector3.Distance(currentPath.path_objs[CurrentWayPointID].position, transform.position);   //distance between camera and desitation
        playerDist = Vector3.Distance(Player.transform.position, transform.position);   //distance between camera and player

        //if player is too close or far, camera speeds up or slows accordingly until within correct range
        if (playerDist > 15) { speed = 20; }
        else if(playerDist < 10) { speed = 1; }
        else { speed = 10; }
        
        transform.position = Vector3.MoveTowards(transform.position, currentPath.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);    //move towards next destination

        transform.LookAt(Player.transform.position);    //pointed at player
        
        if (distance <= reachDistance) CurrentWayPointID++;      //when current position is met, move on to next point
        if (CurrentWayPointID >= currentPath.path_objs.Count) CurrentWayPointID = 0;
    }
}
