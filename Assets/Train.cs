using UnityEngine;

public class Train : MonoBehaviour
{
    Vector3 velocity;
    void Update()
    {
        //velocity += new Vector3(2, 0) * Time.deltaTime;
        //transform.position += velocity * Time.deltaTime;
        transform.position += new Vector3(2,0) * Time.deltaTime;
    }
}
