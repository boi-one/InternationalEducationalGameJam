using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrassHopper : PromptAction
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
        "What'you doing around here? You lost, or what.",
        "Me? I'm just a crooked \"grasshopper\". I've been waiting for someone to come by for ages... curse this wasteland. ",
        "Where are we? What a stupid question. This is the middle of nowhere... locations don't exist. There are only directions. \"Keep going north\", as they told me.",
        "\"Go north, and you'll find salvation\", they told me.",
        "I'm afraid there's no salvation for me. God left me unfinished. My hind leg broke a while ago.. it got.. it just got snapped in half.. the body is so fragile...",
        "..That's life. Oh! Excuse my muttering. So;",
        "I found this abandoned locomotive.. but I don't have hands, so I can't use it. But you finally arrived. I studied every part of this train..." +
        "if I help you repair it, will you please take me with you? To the north, is the promised land. Salvation. Evenif just alleged.",
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