using UnityEngine;

public class CoalBox : PromptAction
{
    public Sprite[] Sprites;

    public static SpriteRenderer Bubble;
    SpriteRenderer SR;
    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        Bubble = transform.Find("Bubble").GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        // Box is empty
        if (SR.sprite == Sprites[0])
        {
            if (!Player.AcquiredItems.Contains("BagOfCoal"))
            {
                Error.SendError("You need the bag of coal to fill this!");
                return;
            }
            SR.sprite = Sprites[1];
            Error.SendError("Filled box with coal, ready to use..");
        }
        // Not empty
        else
        {
            if (!Player.AcquiredItems.Contains("Shovel"))
            {
                Error.SendError("You need a shovel to take the coal with!");
                return;
            }
            if (Player.AcquiredItems.Contains("Coal"))
            {
                Error.SendError("You've already got coal in your shovel!");
                return;
            }
            Player.AcquiredItems.Add("Coal");
            Error.SendError("You take some coal with your shovel..");
        }
        
        Bubble.sprite = null;
    }
    public override void Approach()
    {
        Bubble.sprite = PromptSystem.BubbleClose;
    }
    public override void Leave()
    {
        if (!Player.AcquiredItems.Contains("BagOfCoal"))
            Bubble.sprite = PromptSystem.BubbleFar;
        else
            Bubble.sprite = null;
    }
}
