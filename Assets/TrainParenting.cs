using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TrainParenting : MonoBehaviour
{
    public List<GameObject> TakeWithTrain = new List<GameObject>();

    public Tilemap t;
    void Awake() => t = transform.Find("Map").Find("TrainFloor").GetComponent<Tilemap>();
    
    void Update()
    {
        List<Transform> OurChildren = GetChildrenRecursive(transform);
        foreach (GameObject go in TakeWithTrain)
        {
            if (OurChildren.Contains(go.transform))
            {
                if (!t.HasTile(t.WorldToCell(go.transform.position)))
                {
                    go.transform.SetParent(null);
                }
            }
            else
            {
                if (t.HasTile(t.WorldToCell(go.transform.position)))
                {
                    go.transform.SetParent(transform);
                    go.transform.position = new Vector3(Mathf.Floor(go.transform.position.x) + 0.5f, Mathf.Floor(go.transform.position.y) + 0.5f);
                }
            }
        }
    }

    List<Transform> GetChildrenRecursive(Transform t)
    {
        List<Transform> results = new List<Transform>();
        foreach (Transform tt in t)
        {
            results.Add(tt);
            results.AddRange(GetChildrenRecursive(tt));
        }
        return results;
    }
}
