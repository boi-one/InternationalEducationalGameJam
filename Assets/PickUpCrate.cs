using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpCrate : PromptAction
{
    public GameObject player;
    public override void Interact()
    {
        if (!player.GetComponent<Interact>().pickup)
        {
            gameObject.transform.SetParent(player.transform, true);
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1);
            player.GetComponent<Interact>().pickup = true;
        }
        else
            player.GetComponent<Interact>().pickup = false;
    }
}
