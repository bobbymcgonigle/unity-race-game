using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathFindingScript : MonoBehaviour {

    public Color rayColor = Color.white;                        //colour of path
    public List<Transform> path_objs = new List<Transform>();   //paths
    private bool[] placed;                                      
    Transform[] array;
    public GameObject objToMove;
    public GameObject objToJump;
    public GameObject objToDuck;
    public int objToMoveHeight = 3; //these values are flexible for different objects of different heights
    public int objToJumpHeight = 1;
    public int objToDuckHeight = 4;
    public int noOfObjs;

    void Start()
    {
        if(noOfObjs > path_objs.Count-2) noOfObjs = path_objs.Count-2;  //path objs is limit
        Spawn();
    }
    private void OnDrawGizmos() //allows you to draw the path in the editor, this wont be visible when playing
    {
        Gizmos.color = rayColor;
        array = GetComponentsInChildren<Transform>();
        path_objs.Clear();

        foreach(Transform path_obj in array)
        {
            if(path_obj != this.transform) path_objs.Add(path_obj); //add new objects
        }
        for(int i = 0; i <path_objs.Count; i++)
        {
            Vector3 positon = path_objs[i].position;
            if (i > 0)
            {
                Vector3 previous = path_objs[i - 1].position;
                Gizmos.DrawLine(previous, positon);       //draw out lines between points
                Gizmos.DrawWireSphere(positon, 0.3f);     //draw out point in path
            }
        }
    }
    
    private void Spawn()    //places a set amount of objects on the field, over path points
    {
        placed = new bool[path_objs.Count];

        for (int i = 0; i < noOfObjs; i++)  //for every object to place down
        {
            bool done = false;
            int pathPoint = 0;
            while (!done)                           //check if path obj already has collision obj
            {
                pathPoint = Random.Range(2, path_objs.Count);   //points above 2 to prevent player instantly taking damage
                if(placed[pathPoint] == false)
                {
                    done = true;
                    placed[pathPoint] = true;
                }
            }
            var rotation = Quaternion.LookRotation(path_objs[pathPoint+1].position - path_objs[pathPoint].position); //sets rotation of object

            //here we choose one of three object types and place them in the game
            int val = Random.Range(0, 3);
            if (val == 0)
            {
                Vector3 realpos = new Vector3(path_objs[pathPoint].position.x, objToMoveHeight, path_objs[pathPoint].position.z);//set new vector for object
                Instantiate(objToMove, realpos, rotation);  //place object
            }
            else if(val == 1)
            {
                Vector3 realpos = new Vector3(path_objs[pathPoint].position.x, objToJumpHeight, path_objs[pathPoint].position.z);
                Instantiate(objToJump, realpos, rotation);
            }
            else
            {
                Vector3 realpos = new Vector3(path_objs[pathPoint].position.x, objToDuckHeight, path_objs[pathPoint].position.z);
                Instantiate(objToDuck, realpos, rotation);
            }
        }
    }
}
