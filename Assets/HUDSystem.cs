using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDSystem : MonoBehaviour
{
    public static List<HUD> Huds = new List<HUD>();

    public static Camera MainCam;
    static Player Player;

    void Awake()
    {
        MainCam = Camera.main;
        Player = GameObject.FindObjectOfType<Player>();
    }
    void Update()
    {
        foreach (HUD h in Huds)
        {
            h.HUDObject.SetActive(false);
            if (Vector3.Distance(Player.transform.position, h.transform.position) <= 1.5f)
            {
                h.HUDObject.SetActive(true);
            }
        }
    }
}
