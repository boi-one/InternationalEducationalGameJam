using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public Scenes currentScene = Scenes.location1;
    private void Update()
    {   
        if (Input.GetKey(KeyCode.A) && SceneManager.GetActiveScene().name != "InTransit")//go to transit scene if not in transit scene
        {
            SceneManager.LoadScene(0);
            switch (currentScene)
            {
                case Scenes.location1:
                    currentScene = Scenes.location2;
                    break;
                case Scenes.location2:
                    currentScene = Scenes.location3;
                    break;
                case Scenes.location3:
                    currentScene = Scenes.location4;
                    break;
                case Scenes.location4:
                    currentScene = Scenes.location5;
                    break;
            }
            Debug.Log(" next scene is " + currentScene);
        }
        if (Input.GetKeyDown(KeyCode.D))//go to next scene
        {
            Debug.Log("currentscene " + (int)currentScene);
            int cs = (int)currentScene;
            SceneManager.LoadScene(cs);
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