using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptActionPickUpCrate : PromptAction
{
    SpriteRenderer Bubble;
    public GameObject player;
    public GameObject Prompt;

    void Awake() => Bubble = transform.Find("Bubble").GetComponent<SpriteRenderer>();
    public override void Interact()
    {
        player = GameObject.Find("Player");
        //Prompt.SetActive(false); haal de prompt weg
        if (!player.GetComponent<Interact>().pickup)
        {
            gameObject.transform.SetParent(player.transform, true);
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1);
            player.GetComponent<Interact>().pickup = true;
        }
        else
            player.GetComponent<Interact>().pickup = false;
    }
    public override void Approach() => Bubble.sprite = PromptSystem.BubbleClose;
    public override void Leave() => Bubble.sprite = null;
}
