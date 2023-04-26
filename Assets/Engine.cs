using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : PromptAction
{
    SpriteRenderer Bubble;
    public static Engine refer;
    void Awake()
    {
        refer = this;
        Bubble = transform.Find("Bubble").GetComponent<SpriteRenderer>();
        EngineSR = transform.parent.Find("EngineSprite").GetComponent<SpriteRenderer>();
    }

    public Sprite[] EngineSprites;
    public SpriteRenderer EngineSR;

    public static bool EngineState
    {
        get => _engineState;
        set
        {
            _engineState = value;
        }
    }static bool _engineState = false;
    static float fuelLeft = 0f;
    
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
        CoalBox.Bubble.sprite = PromptSystem.BubbleFar;

        Error.SendError("Adding coal into the oven... starting the engine...");
        EngineState = true;
        Bubble.sprite = null;

        FuelLevel.Activate();
        FuelLevel.SetAmount(1f);
        fuelLeft = 1f;

        StartCoroutine(FuelDrain());
        IEnumerator FuelDrain()
        {
            while (fuelLeft > 0f)
            {
                fuelLeft -= 0.002f;
                FuelLevel.SetAmount(fuelLeft);
                yield return new WaitForSeconds(0.1f);
            }
        }
        
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

            if (fuelLeft < 0)
                goto BREAK;

            goto REPEAT;
            
            BREAK:
            EngineSR.sprite = EngineSprites[0];
            fuelLeft = 0;
            FuelLevel.SetAmount(0);
            EngineState = false;
            Error.SendError("Engine out of fuel!");
            Train.refer.StopEngine();
        }
    }
    public override void Approach() => Bubble.sprite = PromptSystem.BubbleClose;

    public override void Leave()
    {
        if (EngineState)
            Bubble.sprite = null;
        else
            Bubble.sprite = PromptSystem.BubbleFar;
    }
}
