using UnityEngine;

public class Shovel : PromptAction
{
    SpriteRenderer Bubble;
    void Awake() => Bubble = transform.Find("Bubble").GetComponent<SpriteRenderer>();
     
    
    
    
    public override void Interact()
    {
        Error.SendError("Shovel acquired!");
        Destroy(gameObject);
    }
    public override void Approach() => Bubble.sprite = PromptSystem.BubbleClose;
    public override void Leave() => Bubble.sprite = PromptSystem.BubbleFar;
    
}
