using UnityEngine;
public class Prompt : MonoBehaviour
{
    public GameObject PromptObject;
    public bool IsActive;
    public PromptAction PromptAction;
    
    public void Interact()
    {
        PromptAction.Interact();
    }
    void Awake()
    {
        PromptSystem.Prompts.Add(this);
        PromptObject = transform.Find("Canvas").Find("Prompt").gameObject;
        PromptAction = GetComponent<PromptAction>();
    }
}
public abstract class PromptAction : MonoBehaviour
{
    public abstract void Interact();
}