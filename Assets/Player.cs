using UnityEngine;
public class Player : MonoBehaviour
{
    Vector3? dest;
    void Update()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
            dir.x = -1;
        if (Input.GetKey(KeyCode.A))
            Move(new Vector3(-1,0));
        if (Input.GetKey(KeyCode.W))
            Move(new Vector3(0,1));
        if (Input.GetKey(KeyCode.S))
            Move(new Vector3(0,-1));
        
        Move(dir);
        MoveUpdate();
    }
    void Move(Vector3 dir)
    {
        if (dest != null) return;
        dest = transform.position + dir;
    }
    void MoveUpdate()
    {
        if (dest == null) return;

        if (Vector3.Distance(transform.position, (Vector3)dest) <= 5f * Time.deltaTime)
        {
            transform.position = (Vector3)dest;
            dest = null;
        }
        else
            transform.position += ((Vector3)dest - transform.position).normalized * 5f * Time.deltaTime;
    }
}