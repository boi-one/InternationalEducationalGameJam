using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInteraction : PromptAction
{
    public override void Interact()
    {
        gameObject.GetComponent<Canvas>().GetComponent<Prompt>().GetComponent<TMP_Text>().text = "Dialogue.";
    }
}
