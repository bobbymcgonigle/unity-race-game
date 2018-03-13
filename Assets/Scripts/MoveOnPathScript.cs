using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPathScript : MonoBehaviour {

    public PlayerPathFindingScript currentPath;
    public PlayerPathFindingScript innerPath;
    public PlayerPathFindingScript midPath;
    public PlayerPathFindingScript outerPath;
    public List<PlayerPathFindingScript> pathlist;
    public int pathID;
    public int CurrentWayPointID = 0;
    public float speed;
    private float reachDistance = 1.0f;     //dist btween ball and point in path, longer it is, the smoother
    public float rotationSpeed = 1.0f;           //with name, we're choosing path to follow
    public bool jump;

    Vector3 lastPosition;
    Vector3 currentPostion;
	
	void Start () {
        //path = GameObject.Find(pathName).GetComponent<PlayerPathFindingScript>();
        jump = false;
        lastPosition = transform.position;
        pathlist.Add(innerPath);
        pathlist.Add(midPath);
        pathlist.Add(outerPath);
        pathID = 1;
        currentPath = pathlist[pathID];
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (pathID > 0)
            {
                pathID--;
                currentPath = pathlist[pathID];
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (pathID < 2)
            {
                pathID++;
                currentPath = pathlist[pathID];
            }
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            //transform.position = new Vector3(transform.position.x, 10, transform.position.z);
            jump = true;
        }
        if(jump)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 10, transform.position.z), Time.deltaTime * (speed+10));
            if(transform.position.y >= 8)
            {
                jump = false;
            }
        }
        else
        {
            float distance = Vector3.Distance(currentPath.path_objs[CurrentWayPointID].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, currentPath.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);


            var rotation = Quaternion.LookRotation(currentPath.path_objs[CurrentWayPointID].position - transform.position);
            if (!rotation.Equals(Quaternion.Euler(0, 0, 0))) transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            if (distance <= reachDistance) CurrentWayPointID++;      //when current position is met, move on to next point
            if (CurrentWayPointID >= currentPath.path_objs.Count) CurrentWayPointID = 0;
        }
    }
}
