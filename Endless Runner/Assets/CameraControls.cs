﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float maxTilt = 90f;
    public float inputStrength = 1000f;
    public float maxMomentum = 100f;

    public float momentum = 0f;
    public float currentAngle = 0f;
    public float decay = 5f;
    public float gravity = 11.5f;
    public float g;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        g = gravity * currentAngle;
        if (Mathf.Abs(g) < 10f) { g = 0; }
        momentum += (Input.GetAxis("Horizontal") * inputStrength - g - decay * momentum) * Time.deltaTime;

        momentum = Mathf.Clamp(momentum, -maxMomentum, maxMomentum);

        currentAngle += momentum * Time.deltaTime;

        currentAngle = Mathf.Clamp(currentAngle, -maxTilt, maxTilt);

        transform.eulerAngles = new Vector3(0, 0, currentAngle);
    }
}
