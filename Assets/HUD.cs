using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject HUDObject;
    void Awake()
    {
        HUDSystem.Huds.Add(this);
        HUDObject = transform.Find("Canvas").Find("HUD").gameObject;
    }
}
