using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public Scenes currentScene = Scenes.location1;
    public float border = 15f;

    public void NextLocation()
    {
        if (SceneManager.GetActiveScene().name != "InTransit")//go to transit scene if not in transit scene
        {
            SceneManager.LoadScene(0);
            Vector3 startpos = GameObject.Find("StartPoint").transform.position;
            switch (currentScene)
            {
                case Scenes.location1:
                    currentScene = Scenes.location2;
                    gameObject.transform.position = startpos;
                    break;
                case Scenes.location2:
                    currentScene = Scenes.location3;
                    gameObject.transform.position = startpos;
                    break;
                case Scenes.location3:
                    currentScene = Scenes.location4;
                    gameObject.transform.position = startpos;
                    break;
                case Scenes.location4:
                    currentScene = Scenes.location5;
                    gameObject.transform.position = startpos;
                    break;
            }
        }
        else if (SceneManager.GetActiveScene().name == "InTransit")//go to next scene
        {
            SceneManager.LoadScene((int)currentScene);
            Vector3 startpos = GameObject.Find("StartPoint").transform.position;
            gameObject.transform.position = startpos;
            gameObject.GetComponent<Train>().StopEngine();
        }
    }
    public enum Scenes
    {
        TransitScene,
        location1,
        location2,
        location3,
        location4,
        location5
    }
}