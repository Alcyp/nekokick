using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [Range(1,100)]
    public float speed = 10f;
    public SpawnObjects spawnObjects;
    public bool instance = false;
    public float loopDistance = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnObjects.activate && instance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
            if (transform.position.z < -109.6f)
            {
                Debug.Log("Ding!");
                Vector3 temp = transform.position;
                temp.z = 129.6f;
                transform.position = temp;
            }
        }
    }
}
