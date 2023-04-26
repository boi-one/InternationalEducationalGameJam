using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public static readonly List<(float, float)> StartPointsEndpoints = new List<(float, float)>()
    {
        (0,130), // first
        (-300,280), // in transit
        (-33.5f, 17.5f), // second
        (-33.5f, 17.5f), // third
        (-33.5f, 17.5f), // fourth
        (-33.5f, 17.5f), // final destination
    };
    public static Scenes currentScene = Scenes.location1;
    public static Scenes lastLocationScene = Scenes.location1;
    
    public void NextLocation()
    {
        Debug.Log("Going to next location");
        
        // From current location to transit
        if (SceneManager.GetActiveScene().name != "InTransit")
        {
            currentScene = Scenes.TransitScene;
            
            StartCoroutine(SceneLoad());
            IEnumerator SceneLoad()
            {
                TransitionEffect.Activate();
                yield return new WaitForSeconds(0.5f);
                SceneManager.LoadScene(1);
                
                // Move to start pos
                gameObject.transform.position = new Vector3(StartPointsEndpoints[0].Item1, transform.position.y);
            }
        }
        // From transit to next location
        else if (SceneManager.GetActiveScene().name == "InTransit") 
        {
            // Set next
            currentScene = lastLocationScene switch
            {
                Scenes.location1 => Scenes.location2,
                Scenes.location2 => Scenes.location3,
                Scenes.location3 => Scenes.location4,
                Scenes.location4 => Scenes.location5,
                _ => currentScene
            };
            lastLocationScene = currentScene;
            
            StartCoroutine(SceneLoad());
            IEnumerator SceneLoad()
            {
                TransitionEffect.Activate();
                yield return new WaitForSeconds(0.5f);
                SceneManager.LoadScene((int)currentScene);
                GameObject coalBox = GameObject.Find("CoalBox");
                coalBox.GetComponent<CoalBox>().SR.sprite = coalBox.GetComponent<CoalBox>().Sprites[0];
                FuelLevel.SetAmount(0);

                // Move to start pos
                gameObject.transform.position = new Vector3(StartPointsEndpoints[(int)currentScene].Item1, transform.position.y);
                
                // Decellerate
                gameObject.GetComponent<Train>().velocity = 15;
                gameObject.GetComponent<Train>().StopEngine();
            }
        }
    }
    public enum Scenes
    {
        location1,
        TransitScene,
        location2,
        location3,
        location4,
        location5
    }
}