using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrassHopperEnd : PromptAction
{
    SpriteRenderer Bubble;
    GameObject Speech;
    TMP_Text Text;
    void Awake()
    {
        Bubble = transform.Find("Bubble").GetComponent<SpriteRenderer>();
        Speech = transform.Find("HUD").Find("Speech").gameObject;
        Text = Speech.transform.Find("Text").GetComponent<TMP_Text>();
    }

    bool Shutup = false;
    
    public override void Interact()
    {
        if (Shutup) return;
        Bubble.sprite = null;
        Talk();
    }
    public override void Approach()
    {
        if (Shutup) return;
        Bubble.sprite = PromptSystem.BubbleClose;
    }
    public override void Leave()
    {
        if (Shutup) return;
        Bubble.sprite = PromptSystem.BubbleFar;
    }


    List<string> Dialogue = new List<string>
    {
        "Heya.. pardner.",
        "We got to the end.",
        "...",
        "Okay..",
        "Ill shut up now."
    };
    void Talk()
    {
        if (Speech.activeInHierarchy) return;
        
        Speech.SetActive(true);
        Player.CanMove = false;

        StartCoroutine(loop());
        IEnumerator loop()
        {
            while (Dialogue.Count > 0)
            {
                string selected = Dialogue[0];
                Dialogue.RemoveAt(0);
                
                while (selected.Length > 0)
                {
                    Text.text += selected[0];
                    selected = selected.Remove(0, 1);
                    yield return new WaitForSeconds(0.05f);
                }
                
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
                Text.text = "";
            }
            
            Speech.SetActive(false);
            Player.CanMove = true;
            Shutup = true;
            Bubble.sprite = null;
        }
    }
}