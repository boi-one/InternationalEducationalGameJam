using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public static Train refer;
    
    Vector3 velocity;
    public bool run = false;
    public float border = 50f;
    private void Start()
    {
        refer = this;
        border = gameObject.GetComponent<SwitchScenes>().border;
    }
    void Update()
    {
        if (run)
            AccelerateDeccelerate(2);
        else if(!run && velocity.x >= 2)
        {
            AccelerateDeccelerate(-4);
        }
        if (gameObject.transform.position.x > GameObject.Find("EndPoint").transform.position.x)
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
    void AccelerateDeccelerate(float amount)
    {
        transform.position += velocity * Time.deltaTime;
        
        if (amount > 0 && velocity.x > 15) return;
        
        velocity += new Vector3(amount, 0) * Time.deltaTime;
    }
}
