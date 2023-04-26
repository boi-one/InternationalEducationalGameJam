using UnityEngine;

public class BagOfCoal : PromptAction
{
    SpriteRenderer Bubble;
    void Awake() => Bubble = transform.Find("Bubble").GetComponent<SpriteRenderer>();

    public Sprite EmptyBag;
    
    
    public override void Interact()
    {
        Error.SendError("Bag 'o COAL acquired!");
        GameObject trash = new GameObject("trash");
        trash.transform.position = transform.position;
        SpriteRenderer SR = trash.AddComponent<SpriteRenderer>();
        SR.sortingLayerName = "Player";
        SR.sprite = EmptyBag;
        
        Player.AcquiredItems.Add("BagOfCoal");
        
        Destroy(gameObject);
    }
    public override void Approach() => Bubble.sprite = PromptSystem.BubbleClose;
    public override void Leave() => Bubble.sprite = PromptSystem.BubbleFar;
}
