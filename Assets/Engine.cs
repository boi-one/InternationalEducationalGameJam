using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : PromptAction
{
    SpriteRenderer Bubble;

    void Awake()
    {
        Bubble = transform.Find("Bubble").GetComponent<SpriteRenderer>();
        EngineSR = transform.parent.Find("EngineSprite").GetComponent<SpriteRenderer>();
    }

    public Sprite[] EngineSprites;
    public SpriteRenderer EngineSR;
    public static bool EngineState = false;
    public static float FuelLevel = 0f;
    
    public override void Interact()
    {
        if (EngineState)
        {
            Error.SendError("The engine is already running!");
            return;
        }
        if (Player.AcquiredItems.Contains("Coal") == false)
        {
            Error.SendError("We've got no coal on our hands!");
            return;
        }
        Player.AcquiredItems.Remove("Coal");

        Error.SendError("Adding coal into the oven... starting the engine...");
        EngineState = true;
        Bubble.sprite = null;

        FuelLevel += 10f;
        
        
        //IEnumerator
        
        StartCoroutine(EngineAnimation());
        IEnumerator EngineAnimation()
        {
            EngineSR.sprite = EngineSprites[1];
            yield return new WaitForSeconds(1.5f);
            EngineSR.sprite = EngineSprites[2];
            yield return new WaitForSeconds(0.5f);

            
            
            REPEAT:
            
            EngineSR.sprite = EngineSprites[3];
            yield return new WaitForSeconds(0.1f);
            EngineSR.sprite = EngineSprites[4];
            yield return new WaitForSeconds(0.1f);
            EngineSR.sprite = EngineSprites[5];
            yield return new WaitForSeconds(0.1f);

            goto REPEAT;
        }
    }
    public override void Approach() => Bubble.sprite = PromptSystem.BubbleClose;
    public override void Leave() => Bubble.sprite = PromptSystem.BubbleFar;
}
