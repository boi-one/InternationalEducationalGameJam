using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;


interface Use
{
    void UseItem();
} 
public class Interact : MonoBehaviour
{
    public GameObject wellgo, minego, bucketgo, pickaxego;
    public Resource well, mine;
    public Equipment bucket, pickaxe;
    public Item coalCollected = new Item(10);
    public Item brimstoneCollected = new Item(50);
    public Item waterCollected = new Item(5);
    float collect;
    public float cooldown = 1f;
    Resource[] resources = new Resource[2];
    private void Awake()
    {
        well = new Resource(wellgo, 20);
        mine = new Resource(minego, 100);
        bucket = new Equipment(bucketgo);
        pickaxe = new Equipment(pickaxego);
        resources[0] = well;
        resources[1] = mine;
        bucket.UseItem();  
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
                        coalCollected.amount++;
                    else if (r == mine && Random.Range(0, 10) == 5)
                        brimstoneCollected.amount++;
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
public class Item
{
    public int amount;
    int potency;

    public Item(int _potency)
    {
        potency = _potency;
    }
}

public class Equipment : Use
{
    GameObject go;

    public void UseItem()
    {

    }

    public Equipment(GameObject _go)
    {
        go = _go;
    }
}

