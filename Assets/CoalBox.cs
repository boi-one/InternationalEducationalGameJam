using UnityEngine;

public class CoalBox : PromptAction
{
    public Sprite[] Sprites;
    public static bool CoalBagAcquired = false;
    
    
    public static SpriteRenderer Bubble;
    void Awake() => Bubble = transform.Find("Bubble").GetComponent<SpriteRenderer>();
    
    
    public override void Interact()
    { 
        if (!CoalBagAcquired)
            Error.SendError("You need the bag of coal to fill this");
        
        Bubble.sprite = null;
    }
    public override void Approach()
    {
        Bubble.sprite = PromptSystem.BubbleClose;
    }
    public override void Leave()
    {
        if (CoalBagAcquired)
            Bubble.sprite = PromptSystem.BubbleFar;
        else
            Bubble.sprite = null;
    }
}
