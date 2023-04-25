using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpCrate : PromptAction
{
    public GameObject player;
    public override void Interact()
    {
        bool pickup = player.GetComponent<Interact>().pickup;
        if (!pickup)
        {
            gameObject.transform.SetParent(player.transform, true);
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+1);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log(pickup);  
            if (pickup)
                gameObject.transform.parent = null;
        }
    }
}
