using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptActionDepositCoal : PromptAction
{
    public GameObject player;
    public TMP_Text ui;
    public int fuelAmount, waterAmount;
    public override void Interact()
    {
        Item c, b, w;
        c = player.GetComponent<Interact>().coalCollected;
        b = player.GetComponent<Interact>().brimstoneCollected;
        w = player.GetComponent<Interact>().waterCollected;
        fuelAmount += (c.amount*c.potency)+(b.amount*b.potency);
        c.amount -= c.amount;
        b.amount -= b.amount;
        waterAmount += (w.amount*w.potency);
        w.amount -= w.amount;
        ui.text = $"coal and brimmy: {fuelAmount} \nwater: {waterAmount}\n\n1 water = 5 units\n1 coal = 10 units\n1 brimstone = 50 units";
    }
}
