using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject wellgo;
    public GameObject minego;
    public Resource well, mine;
    public int coalCollected;
    public int brimstoneCollected;
    public int waterCollected;
    float collect;
    public float cooldown = 1f;
    Resource[] resources = new Resource[2];
    private void Awake()
    {
        well = new Resource(wellgo, 20);
        mine = new Resource(minego , 100);
        resources[0] = well;
        resources[1] = mine;
    }
    private void Update()
    {
        foreach (Resource r in resources)
        {
            if (Vector3.Distance(r.go.transform.position, gameObject.transform.position) < 2f && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log($"coal {coalCollected} brimstone {brimstoneCollected} water {waterCollected} resources {r.amount}");
                if (Time.time > collect && !r.exhausted)
                {
                    r.amount--;
                    if (r == mine && Random.Range(0, 10) != 5)
                        coalCollected++;
                    else if (r == mine && Random.Range(0, 10) == 5)
                        brimstoneCollected++;
                    else if (r == well)
                        waterCollected++;
                    if (r.amount == 0)
                        r.exhausted = true;
                    collect = Time.time + cooldown;
                }
            }
        }
    }
}
public class Resource
{
    public int amount;
    public bool exhausted;
    public GameObject go;
    public Resource(GameObject _go, int _amount)
    {
        go = _go;
        amount = _amount;
    }
}

