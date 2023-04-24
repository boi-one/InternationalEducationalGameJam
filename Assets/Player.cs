using UnityEngine;
public class Player : MonoBehaviour
{
    Vector3? dest;
    void Update()
    {
        Vector3 dir = Vector3.zero;
        
        if (Input.GetKey(KeyCode.D))
            dir.x = 1;
        if (Input.GetKey(KeyCode.A))
            dir.x = -1;
        if (Input.GetKey(KeyCode.W))
            dir.y = 1;
        if (Input.GetKey(KeyCode.S))
            dir.y = -1;
        
        Move(dir);
        MoveUpdate();
    }
    void Move(Vector3 dir)
    {
        if (dest != null) return;
        dest = dir;
    }
    void MoveUpdate()
    {
        if (dest == null) return;

        float ma = 15f * Time.deltaTime;

        if (((Vector3)dest).magnitude <= ma)
        {
            transform.position += (Vector3)dest;
            dest = null;
        }
        else
        {
            transform.position += ((Vector3)dest).normalized * ma;
            dest /= 1 + ma;
        }
    }
}