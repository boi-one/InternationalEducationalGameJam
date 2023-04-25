using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInteraction : PromptAction
{
    public TMP_Text dialogue;
    public GameObject mark;
    public override void Interact()
    {
        Debug.Log("bbb");
        dialogue.text = "Dialogue.Dialogue.Dialogue.Dialogue.Dialogue.Dialogue.Dialogue.Dialogue.Dialogue.Dialogue.Dialogue.Dialogue.Dialogue.Dialogue.";
        mark.SetActive(false);
    }
}
