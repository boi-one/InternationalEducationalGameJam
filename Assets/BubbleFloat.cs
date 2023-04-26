using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFloat : MonoBehaviour
{
    bool a = true;
    float accel = 0;
    void Update()
    {
        if (a)
            accel += 0.3f * Time.deltaTime;
        else
            accel -= 0.3f * Time.deltaTime;
        
        if (accel > 0.3f)
            a = false;
        else if (accel < -0.3f)
            a = true;

        transform.position += new Vector3(0, accel) * Time.deltaTime;
    }
}
