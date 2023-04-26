using System;
public class TrainControl : PromptAction
{
    public override void Interact()
    {
        ((Train.refer.run = !Train.refer.run)?(Action)Train.refer.StartEngine:(Action)Train.refer.StopEngine)();
    }

    public override void Approach()
    {
    }

    public override void Leave()
    {
    }
}
