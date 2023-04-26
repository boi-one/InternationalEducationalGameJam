using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptActionResourceInteract : PromptAction
{
    SpriteRenderer Bubble;
    public TMP_Text dialogue;

    void Awake() => Bubble = transform.Find("Bubble").GetComponent<SpriteRenderer>();
    public override void Interact()
    {
        dialogue.text = "Repeatedly press E to get resources";
    }
    public override void Approach() => Bubble.sprite = PromptSystem.BubbleClose;
    public override void Leave() => Bubble.sprite = null;
}
