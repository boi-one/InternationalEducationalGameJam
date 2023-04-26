using UnityEngine;
public class TrainControl : PromptAction
{
    SpriteRenderer Bubble;
    void Awake() => Bubble = transform.Find("Bubble").GetComponent<SpriteRenderer>();


    public override void Interact()
    {
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
        
        Bubble.sprite = null;
    }
    public override void Approach() => Bubble.sprite = PromptSystem.BubbleClose;
    public override void Leave() => Bubble.sprite = PromptSystem.BubbleFar;
}
