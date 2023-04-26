using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // BagOfCoal
    // Shovel
    // Coal
    public static readonly List<string> AcquiredItems = new List<string>();


    public static Player refer;

    List<Tilemap> Walls = new List<Tilemap>();

    void Awake()
    {
        refer = this;
    }
    
    public static bool CanMove = true;
    Vector3 dest;
    float destL = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        if (Input.GetKeyDown(KeyCode.D))
            GetComponent<SpriteRenderer>().flipX = true;
        else if (Input.GetKeyDown(KeyCode.A))
            GetComponent<SpriteRenderer>().flipX = false;
        bool a = false;
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("CamZoomArea"))
        {
            if (g.GetComponent<BoxCollider2D>().bounds.Contains(transform.position))
                a=true;
        }
        TransitionEffect.Zoomed = a;
        //Camera.main.orthographicSize = a ? 3f : 5.625f;
        
        Vector3 dir = Vector3.zero;
        
        if (Input.GetKey(KeyCode.D))
            dir.x = 1;
        if (Input.GetKey(KeyCode.A))
            dir.x = -1;
        if (Input.GetKey(KeyCode.W))
            dir.y = 1;
        if (Input.GetKey(KeyCode.S))
            dir.y = -1;
     
        if (CanMove)
            Move(dir);
        MoveUpdate();
    }
    void Move(Vector3 dir)
    {
        if (Train.refer.run && (transform.position + dir).y > 2.9f)
            return;
        Walls.Clear();
        // collision with walls
        foreach (Tilemap t in GameObject.FindObjectsOfType<Tilemap>())
        {
            if (t.gameObject.name.StartsWith("Wall"))
                Walls.Add(t);
        }
        if (Walls.Any(t => t != null && t.HasTile(t.WorldToCell(transform.position + dir))))
            return;

        if (destL != 0) return;
        dest = dir;
        destL = 1;
    }
    void MoveUpdate()
    {
        if (destL == 0) return;

        float ma = 6f * Time.deltaTime;

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