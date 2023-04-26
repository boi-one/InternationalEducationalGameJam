using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public GameObject wellgo, minego;
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
        UI = GameObject.Find("HUD").GetComponent<Canvas>().GetComponent<TMP_Text>();
        wellgo = GameObject.Find("Well");
        minego = GameObject.Find("Mine");
    }
    private void Update()
    {
        if((SceneManager.GetActiveScene().name !=  "Location1" || SceneManager.GetActiveScene().name != "InTransit" || SceneManager.GetActiveScene().name != "Location5") && UI != null)
        {
            UI.text = $"Coal: {coalCollected.amount} Brimstone: {brimstoneCollected.amount} Water: {waterCollected.amount}";
            foreach (Resource r in resources)
            {
                if (Vector3.Distance(r.go.transform.position, gameObject.transform.position) < 1f && Input.GetKeyDown(KeyCode.E))
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
                    }
                }
            }
        }
    }
}
public class Resource
{
    public int amount;
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

