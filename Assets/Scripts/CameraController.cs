using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject Player;

    public PlayerPathFindingScript currentPath;

    public float height;
    private Quaternion rotation;
    public float speed = 10;
    private Vector3 playerPrevPos;
    public int CurrentWayPointID = 0;
    private float reachDistance = 1.0f;
    public float playerDist;

    // Use this for initialization
    void Start () 
	{
        playerPrevPos = Player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
        float distance = Vector3.Distance(currentPath.path_objs[CurrentWayPointID].position, transform.position);
        playerDist = Vector3.Distance(Player.transform.position, transform.position);
        if(playerDist > 15) { speed = 20; }
        else if(playerDist < 10) { speed = 1; }
        else { speed = 10; }
        transform.position = Vector3.MoveTowards(transform.position, currentPath.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);

        transform.LookAt(Player.transform.position);
        
        if (distance <= reachDistance) CurrentWayPointID++;      //when current position is met, move on to next point
        if (CurrentWayPointID >= currentPath.path_objs.Count) CurrentWayPointID = 0;
    }
}
