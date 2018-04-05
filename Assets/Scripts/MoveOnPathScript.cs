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
    public bool goDown;
    public bool crouch;
	private int movementID;
    private int yPos = 0;
	
	
	private Animator anim;
	private Collider head;
	
	void Start() {
        //path = GameObject.Find(pathName).GetComponent<PlayerPathFindingScript>();
        jump = false;
        goDown = false;
        pathlist.Add(innerPath);
        pathlist.Add(midPath);
        pathlist.Add(outerPath);
        pathID = 1;
        currentPath = pathlist[pathID];
		anim = GetComponent<Animator>();
		head = GetComponent<SphereCollider>();
    }
	
	void Update () {
		


		if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal")< 0)
        {
            if (pathID > 0)
            {
                pathID--;
                currentPath = pathlist[pathID];
            }
        }
		if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") >0)
        {
            if (pathID < 2)
            {
                pathID++;
                currentPath = pathlist[pathID];

            }

        }

		if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical")> 0 && !jump && !goDown)
        {
            jump = true;
            movementID = CurrentWayPointID+1;
            if (movementID >= currentPath.path_objs.Count) movementID = 0;
			
        }
		if(Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical")< 0&& !crouch)
		{
			crouch=true;
			head.enabled = false;
		}
		else if(Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical")< 0&& crouch)
		{
			crouch = false;
			head.enabled = true;
		}
		
        if (jump)
        {
            if (!goDown)
            {
                Vector3 vec = currentPath.path_objs[movementID].position;
                vec.Set(vec.x, 10, vec.z);
                //float newY = vec.x * vec.x + 2 * vec.x + 5;               //attempt at parabola jump using quatratic equation
                //vec.Set(vec.x, newY, vec.z);
                //transform.position = Vector3.MoveTowards(transform.position, vec, Time.deltaTime * (speed + 10));
                transform.position = Vector3.MoveTowards(transform.position, vec, Time.deltaTime * (speed + 15));

                if (transform.position.y >= 8)
                {
                    //transform.position.Set(transform.position.x, 1, transform.position.z);
                    goDown = true;
                    CurrentWayPointID++;
                    if (CurrentWayPointID >= currentPath.path_objs.Count) CurrentWayPointID = 0;
                }
            }
            else
            {
                Vector3 downPos = new Vector3(transform.position.x, yPos, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, downPos, Time.deltaTime * (speed + 15));
                if (transform.position.y == yPos)
                {
                    goDown = false;
                    jump = false;
					
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPath.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);
            var rotation = Quaternion.LookRotation(currentPath.path_objs[CurrentWayPointID].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            if (CurrentWayPointID >= currentPath.path_objs.Count) CurrentWayPointID = 0;
            float distance = Vector3.Distance(currentPath.path_objs[CurrentWayPointID].position, transform.position);
            if (distance <= reachDistance) CurrentWayPointID++;      //when current position is met, move on to next point
            if (CurrentWayPointID >= currentPath.path_objs.Count) CurrentWayPointID = 0;
        }
		anim.SetBool("jump",jump);
		anim.SetBool("crouch",crouch);
    }
}
