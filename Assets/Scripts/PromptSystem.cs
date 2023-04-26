using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PromptSystem : MonoBehaviour
{
    public static readonly List<Prompt> Prompts = new List<Prompt>();
    public static Sprite BubbleFar;
    public static Sprite BubbleClose;
    public Sprite[] _BubbleSprites;
    
    static Player Player;

    void Awake()
    {
        Player = GameObject.FindObjectOfType<Player>();
        BubbleFar = _BubbleSprites[0];
        BubbleClose = _BubbleSprites[1];
    }
    
    Prompt CurrentlyViewedPrompt
    {
        get => _currentlyViewedPrompt;
        set
        {
            if (_currentlyViewedPrompt == value)
                return;
            
            // removing
            if (_currentlyViewedPrompt != null)
                _currentlyViewedPrompt.Leave();
            if (value != null)
                value.Approach();
            
            _currentlyViewedPrompt = value;
        }
    } Prompt _currentlyViewedPrompt = null;
    
    void Update()
    {
        Vector3 pos = Player.transform.position;

        Prompt selected = null;
        foreach (var p in Prompts.Where(p => (pos - p.transform.position).magnitude < 1.5f))
            selected = p;
        foreach (var p in Prompts.Where(p => new[] { new Vector3(-1, 0), new Vector3(1, 0), new Vector3(0, 1), new Vector3(0, -1), }.Any(c => pos + c == p.transform.position)))
            selected = p;

        CurrentlyViewedPrompt = selected;

        // interact
        if (Input.GetKeyDown(KeyCode.E) && CurrentlyViewedPrompt != null)
            CurrentlyViewedPrompt.Interact();
    }
}
