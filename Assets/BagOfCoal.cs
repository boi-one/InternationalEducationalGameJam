using UnityEngine;

public class BagOfCoal : PromptAction
{
    SpriteRenderer Bubble;
    void Awake() => Bubble = transform.Find("Bubble").GetComponent<SpriteRenderer>();

    public Sprite EmptyBag;
    
    
    public override void Interact()
    {
        // Create trash
        GameObject trash = new GameObject("trash");
        trash.transform.position = transform.position;
        SpriteRenderer SR = trash.AddComponent<SpriteRenderer>();
        SR.sortingLayerName = "Player";
        SR.sprite = EmptyBag;
        
        // Success
        Player.AcquiredItems.Add("BagOfCoal");
        Error.SendError("Bag 'o COAL acquired!");

        // Put exclamation mark on coal box
        CoalBox.Bubble.sprite = PromptSystem.BubbleFar;
        
        Destroy(gameObject);
    }
    public override void Approach() => Bubble.sprite = PromptSystem.BubbleClose;
    public override void Leave() => Bubble.sprite = null;
}
