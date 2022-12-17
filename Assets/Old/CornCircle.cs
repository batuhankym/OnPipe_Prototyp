using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornCircle : MonoBehaviour
{
        // Prefab to instantiate
        public GameObject prefab;
        public Vector3 point;
        public Transform parentObj;
    
        // Radius of the circle
        public float radius = 5f;
    
        // Array or list to hold the instantiated objects
        private List<GameObject> objects = new List<GameObject>();
    
        void Start()
        {
            // Number of objects to instantiate
            int count = 30;
    
            // Angle between each object
            float angleStep = 360f / count;
    
            // Loop through and instantiate objects at evenly spaced points around the circle
            for (float angle = 0; angle < 360f; angle += angleStep)
            {
                // Calculate the x and y position of the point
                float x = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
                float y = radius * Mathf.Cos(angle * Mathf.Deg2Rad);

                var spawnDir = new Vector3(x, 0, y);
                
                var spawnPos = point + spawnDir * radius; 
                
                // Radius is just the distance away from the point
                // Create a new instance of the prefab at the point
                GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity) as GameObject;
                
                
                obj.transform.LookAt(point);
    
                // Add the object to the array or list
                objects.Add(obj);
            }
        }
    }


