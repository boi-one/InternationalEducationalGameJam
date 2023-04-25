using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    Vector3 velocity;
    bool run = false;
    public float border = 50f;
    private void Start()
    {
        border = gameObject.GetComponent<SwitchScenes>().border;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ((run = !run)?(Action)StartEngine:(Action)StopEngine)();
        if (run)
            AccelerateDeccelerate(2);
        else if(!run && velocity.x >= 2)
        {
            AccelerateDeccelerate(-4);
        }
        if (gameObject.transform.position.x > border)
            gameObject.GetComponent<SwitchScenes>().NextLocation();

    }
    public void StartEngine()
    {
        run = true;
    }
    public void StopEngine()
    {
        run = false;
    }
    void AccelerateDeccelerate(float speed)
    {
        Debug.Log(speed);
        velocity += new Vector3(speed, 0) * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}
