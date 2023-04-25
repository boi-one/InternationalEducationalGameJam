using UnityEngine;
public class Player : MonoBehaviour
{
    Vector3 dest;
    float destL = 0;
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
        if (destL != 0) return;
        dest = dir;
        destL = 1;
    }
    void MoveUpdate()
    {
        if (destL == 0) return;

        float ma = 15f * Time.deltaTime;

        if (destL <= ma)
        {
            Centralize();
            destL = 0;
        }
        else
        {
            transform.position += dest.normalized * ma;
            destL -= ma;
        }
    }

    void Centralize()
    {
        if (transform.parent == null)
            transform.position = new Vector3(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f);
        else
            
            transform.position = transform.parent.position + new Vector3(Mathf.Floor(transform.localPosition.x) + 0.5f, Mathf.Floor(transform.localPosition.y) + 0.5f);
    }
}