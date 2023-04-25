using System.Collections.Generic;
using UnityEngine;

public class PromptSystem : MonoBehaviour
{
    public static readonly List<Prompt> Prompts = new List<Prompt>();

    static Player Player;

    void Awake()
    {
        Player = GameObject.FindObjectOfType<Player>();
    }
    void Update()
    {
        // show or unshow prompts as you get near objects
        foreach (Prompt h in Prompts)
        {
            bool a = Vector3.Distance(Player.transform.position, h.transform.position) <= 1.5f;
            h.PromptObject.SetActive(a);
            h.IsActive = a;
        }
        
        // interact
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Prompt pr in Prompts)
            {
                if (pr.IsActive)
                    pr.Interact();
            }
        }
    }
}
