using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathFindingScript : MonoBehaviour {

    public Color rayColor = Color.white;                        //colour of path
    public List<Transform> path_objs = new List<Transform>();   //paths
    Transform[] array;

    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        array = GetComponentsInChildren<Transform>();
        path_objs.Clear();

        foreach(Transform path_obj in array)
        {
            if(path_obj != this.transform) path_objs.Add(path_obj);
        }
        for(int i = 0; i <path_objs.Count; i++)
        {
            Vector3 positon = path_objs[i].position;
            if (i > 0)
            {
                Vector3 previous = path_objs[i - 1].position;
                Gizmos.DrawLine(previous, positon);
                Gizmos.DrawWireSphere(positon, 0.3f);     //draw out point in path
            }
        }
    }
}
