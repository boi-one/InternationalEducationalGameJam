using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour
{
    public static Train refer;
    
    public float velocity;
    public bool run = false;
    void Start() => refer = this;
    void Update()
    {
        if (run)
            AccelerateDeccelerate(2);
        else
            AccelerateDeccelerate(-10);

        // Reached ends
        if (!InEndCooldown)
        {
            if (gameObject.transform.position.x > SwitchScenes.StartPointsEndpoints[(int)SwitchScenes.currentScene].Item2)
            {
                gameObject.GetComponent<SwitchScenes>().NextLocation();
                InEndCooldown = true;
            }
        }
    }

    bool InEndCooldown
    {
        get => _inEndCooldown;
        set
        {
            if (_inEndCooldown) return;

            _inEndCooldown = true;
            StartCoroutine(EndCooldown());
            IEnumerator EndCooldown()
            {
                yield return new WaitForSeconds(1f);
                _inEndCooldown = false;
            }
        }
    } bool _inEndCooldown = false;
    
    
    
    
    public void StartEngine()
    {
        run = true;
    }
    public void StopEngine()
    {
        run = false;
    }
    void AccelerateDeccelerate(float amount)
    {
        transform.position += new Vector3(velocity * Time.deltaTime, 0);        
        
        velocity += amount * Time.deltaTime;

        if (velocity < 0)
            velocity = 0;
        if (velocity > 15)
            velocity = 15;
    }
}
