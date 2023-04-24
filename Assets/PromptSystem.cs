using System.Collections.Generic;
using UnityEngine;

public class PromptSystem : MonoBehaviour
{
    public static List<Prompt> Huds = new List<Prompt>();

    static Player Player;

    void Awake()
    {
        Player = GameObject.FindObjectOfType<Player>();
    }
    void Update()
    {
        foreach (Prompt h in Huds)
        {
            h.PromptObject.SetActive(false);
            if (Vector3.Distance(Player.transform.position, h.transform.position) <= 1.5f)
            {
                h.PromptObject.SetActive(true);
            }
        }
    }
}
