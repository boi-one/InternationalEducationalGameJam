using UnityEngine;
public class Prompt : MonoBehaviour
{
    public bool CanBeInteractedWith;
    PromptAction PromptAction;

    public void Interact()
    {
        if (CanBeInteractedWith)
            PromptAction.Interact();   
    }
    public void Approach() => PromptAction.Approach();
    public void Leave() => PromptAction.Leave();
    void Awake()
    {
        PromptSystem.Prompts.Add(this);
        PromptAction = GetComponent<PromptAction>();
        PromptAction.PromptRefer = this;
    }
    void OnDestroy() => PromptSystem.Prompts.Remove(this);
}
public abstract class PromptAction : MonoBehaviour
{
    [HideInInspector] public Prompt PromptRefer;
    public abstract void Interact();
    public abstract void Approach();
    public abstract void Leave();
}