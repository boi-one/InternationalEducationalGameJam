using System.Collections.Generic;
using UnityEngine;

public class PromptSystem : MonoBehaviour
{
    public static readonly List<Prompt> Prompts = new List<Prompt>();

    static Player Player;
    void Awake() => Player = GameObject.FindObjectOfType<Player>();
    
    void Update()
    {
        // show or unshow prompts as you get near objects
        foreach (Prompt h in Prompts)
        {
            bool a = false;
            foreach (Vector3 dir in new[] { new Vector3(-1, 0), new Vector3(1, 0), new Vector3(0, 1), new Vector3(0, -1), })
            {
                if (Player.transform.position + dir == h.transform.position)
                    a = true;
            }
            
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
