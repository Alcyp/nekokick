using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public float spawnRate = 2f;
    public float spawnTimer = 0f;
    public float spawnRateSpeed = 0.001f;
    public GameObject baseTree;
    public bool verticalRot;
    public bool normalRot;
    public bool activate = false;

    private void Start()
    {
        for (int i = 10; i < 100; i++)
        {
            spawnTimer -= 0.1f;
            if (spawnTimer < 0)
            {
                spawnTimer = spawnRate;
                spawnObject(1f * i);
            }
            if (spawnRate > 0) { spawnRate -= spawnRateSpeed * 0.1f; }
        }
    }

    void Update()
    {
        if (activate)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0)
            {
                spawnTimer = spawnRate;
                spawnObject(100f);
            }
            if (spawnRate > 0) { spawnRate -= spawnRateSpeed * Time.deltaTime; }
        }
    }

    void spawnObject(float distance)
    {
        GameObject newObject = Instantiate(baseTree);
        float angle = Random.Range(-1.4f, 1.4f);
        float x = 2f * Mathf.Sin(angle);
        float y = 2f - 2f * Mathf.Cos(angle);
        newObject.transform.position = new Vector3(x, y, distance);
        if (normalRot)
        {
            Vector3 temp = newObject.transform.eulerAngles;
            temp.z += angle * 57.3f;
            newObject.transform.eulerAngles = temp;
        }
        if (verticalRot)
        {
            Vector3 temp = newObject.transform.eulerAngles;
            temp.y = Random.Range(0f, 360f);
            newObject.transform.eulerAngles = temp;
        }

        newObject.GetComponent<MoveObject>().instance = true;
    }

    void Activate()
    {
        activate = true;
    }
}
