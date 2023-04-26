using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TransitionEffect : MonoBehaviour
{
    public static bool Zoomed
    {
        get => _Zoomed;
        set
        {
            if (_Zoomed == value) return;
            _Zoomed = value;

            if (value)
            {
                refer.StartCoroutine(BRUH());
                IEnumerator BRUH()
                {
                    Camera.main.orthographicSize /= 1.1f;
                    yield return new WaitForSeconds(0.05f);
                    Camera.main.orthographicSize /= 1.1f;
                    yield return new WaitForSeconds(0.05f);
                    Camera.main.orthographicSize /= 1.1f;
                    yield return new WaitForSeconds(0.05f);
                    Camera.main.orthographicSize /= 1.1f;
                    yield return new WaitForSeconds(0.05f);
                    Camera.main.orthographicSize /= 1.1f;
                }
            }
            else
            {
                refer.StartCoroutine(BRUH());
                IEnumerator BRUH()
                {
                    Camera.main.orthographicSize *= 1.1f;
                    yield return new WaitForSeconds(0.05f);
                    Camera.main.orthographicSize *= 1.1f;
                    yield return new WaitForSeconds(0.05f);
                    Camera.main.orthographicSize *= 1.1f;
                    yield return new WaitForSeconds(0.05f);
                    Camera.main.orthographicSize *= 1.1f;
                    yield return new WaitForSeconds(0.05f);
                    Camera.main.orthographicSize *= 1.1f;
                }
            }
        }
    }
    //3f : 5.625f

    public static bool _Zoomed = false;
    
    
    static TransitionEffect refer;
    static Image i;

    void Awake()
    {
        refer = this;
        i = refer.transform.Find("Canvas").Find("Panel").GetComponent<Image>();
    }


    public static void Activate()
    {
        refer.StartCoroutine(wait());
        IEnumerator wait()
        {
            i.color = new Color(0, 0, 0, 0.1f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.2f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.3f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.4f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.6f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.7f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.8f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.9f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 1f);
        
            yield return new WaitForSeconds(0.5f);
            
            i.color = new Color(0, 0, 0, 0.9f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.8f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.7f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.6f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.4f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.3f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.2f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0.1f);
            yield return new WaitForSeconds(0.05f);
            i.color = new Color(0, 0, 0, 0f);
        }
    }
}
