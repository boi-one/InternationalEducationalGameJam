using System;
using UnityEngine;


public class Prompt : MonoBehaviour
{
    public GameObject PromptObject;
    void Awake()
    {
        PromptSystem.Huds.Add(this);
        PromptObject = transform.Find("Canvas").Find("Prompt").gameObject;
    }
}
