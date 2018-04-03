using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPathScript : MonoBehaviour
{

    public Color rayColor = Color.white;                        //colour of path
    public List<Transform> path_objs = new List<Transform>();   //paths
    Transform[] array;

    void Start()
    {
    }

    private void OnDrawGizmos() //allows you to draw the path in the editor, this wont be visible when playing
    {
        Gizmos.color = rayColor;
        array = GetComponentsInChildren<Transform>();
        path_objs.Clear();

        foreach (Transform path_obj in array)
        {
            if (path_obj != this.transform) path_objs.Add(path_obj); //add new objects
        }
        for (int i = 0; i < path_objs.Count; i++)
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
}
