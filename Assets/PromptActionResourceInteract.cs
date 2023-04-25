using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptActionResourceInteract : PromptAction
{
    public TMP_Text dialogue;
    public override void Interact()
    {
        dialogue.text = "Repeatedly press E to get resources";
    }
}
