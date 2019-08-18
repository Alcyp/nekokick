using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [Range(1,100)]
    public float speed = 10f;
    public SpawnObjects spawnObjects;
    public bool instance = false;

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
            if (transform.position.z < -5f)
            {
                Destroy(gameObject);
            }
        }
    }
}
