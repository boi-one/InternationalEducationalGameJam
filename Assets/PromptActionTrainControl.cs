using System;
public class PromptActionTrainControl : PromptAction
{
    public override void Interact()
    {
        ((Train.refer.run = !Train.refer.run)?(Action)Train.refer.StartEngine:(Action)Train.refer.StopEngine)();
    }
}
