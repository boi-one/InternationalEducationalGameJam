using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInteraction : PromptAction
{
    public TMP_Text dialogue;
    public override void Interact()
    {
        dialogue.text = "Dialogue.";
    }
}
