using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic; 

public class pathpointGenerator : MonoBehaviour
{
    
    public List<Transform> pathPoints = new List<Transform>();

    private void Start()
    {
        InvokeRepeating("CreatePoints", 5f, .5f); 
    }
    private void CreatePoints()
    {
        GameObject created = new GameObject(); 
        created.transform.position = transform.position;
        pathPoints.Add(created.transform);
    }


    
}
