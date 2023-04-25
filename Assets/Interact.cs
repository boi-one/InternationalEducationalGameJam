using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Interact : MonoBehaviour
{
    public GameObject wellgo, minego, train, childgo;
    public Resource well, mine;
    public Item coalCollected = new Item(10);
    public Item brimstoneCollected = new Item(50);
    public Item waterCollected = new Item(5);
    float collect;
    float cooldown;
    Resource[] resources = new Resource[2];
    public TMP_Text UI;
    public bool pickup = false;
    private void Awake()
    {
        well = new Resource(wellgo, 20, 1f);
        mine = new Resource(minego, 100, 3f);
        resources[0] = well;
        resources[1] = mine;
    }
    private void Update()
    {
        UI.text = $"Coal: {coalCollected.amount} Brimstone: {brimstoneCollected.amount} Water: {waterCollected.amount}";
        foreach (Resource r in resources)
        {
            if (r != null)
            {
                if (Vector3.Distance(r.go.transform.position, gameObject.transform.position) < 1.5f && Input.GetKeyDown(KeyCode.E))
                {
                    if (Time.time > collect && !r.exhausted)
                    {
                        cooldown = r.cooldown;
                        r.amount--;
                        if (r == mine && Random.Range(0, 10) != 5)
                        coalCollected.amount++;
                        else if (r == mine && Random.Range(0, 10) == 5)
                        brimstoneCollected.amount++;
                        else if (r == well)
                            waterCollected.amount++;
                        collect = Time.time + cooldown;
                        if (r.amount == 0)
                            r.exhausted = true;
                    }
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.E) && pickup)
        {
            Transform child = gameObject.transform.GetChild(0);
            /*if(train.GetComponent<TrainParenting>().t != null) //is null?
            {
                Tilemap t = train.GetComponent<TrainParenting>().t;
                if (t.HasTile(t.WorldToCell(childgo.transform.position)))
                    train.GetComponent<TrainParenting>().TakeWithTrain.Add(childgo);
            }*/
            child.transform.SetParent(null, true);
        }
    }
}
public class Resource
{
    public int amount;
    public int value;
    public float cooldown;
    public bool exhausted;
    public GameObject go;
    public Resource(GameObject _go, int _amount, float _cooldown)
    {
        go = _go;
        amount = _amount;
        cooldown = _cooldown;
    }
}
public class Item
{
    public GameObject go;
    public int amount;
    public int potency;

    public Item(int _potency)
    {
        potency = _potency;
    }
}

