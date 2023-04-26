using UnityEngine;
public class TrainControl : PromptAction
{
    public static TrainControl refer;
    public static SpriteRenderer SR;
    public static SpriteRenderer Bubble;
    public Sprite[] Sprites;
    void Awake()
    {
        Bubble = transform.Find("Bubble").GetComponent<SpriteRenderer>();
        SR = GetComponent<SpriteRenderer>();
        refer = this;
    }

    public override void Interact()
    {
        if (Player.refer.transform.position.y > transform.position.y)
            Player.refer.transform.position = transform.position + new Vector3(-1, 0);
        
        if (Engine.EngineState == false)
        {
            Error.SendError("The engine isn't running!");
            return;
        }
        
        bool a = Train.refer.run;
        if (!a)
        {
            Error.SendError("Starting the train...");
            Train.refer.StartEngine();
        }
        else
        {
            Error.SendError("Stopping the train...");
            Train.refer.StopEngine();
        }
    }
    public override void Approach() => Bubble.sprite = PromptSystem.BubbleClose;

    public override void Leave()
    {
        Bubble.sprite = null;   
    }
}