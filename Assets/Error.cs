using System.Collections;
using TMPro;
using UnityEngine;

public class Error : MonoBehaviour
{
    static Error refer;
    void Awake() => refer = this;
    static Coroutine started = null;
    public static void SendError(string message)
    {
        TMP_Text tex = refer.GetComponent<TMP_Text>();
        tex.text = message;

        if (started != null)
        {
            refer.StopCoroutine(started);
            started = null;
        }
        
        started = refer.StartCoroutine(wait());
        IEnumerator wait()
        {
            tex.color = new Color(0f, 0f, 0f, 1f);
            yield return new WaitForSeconds(1f);
            tex.color = new Color(0f, 0f, 0f, 0.9f);
            yield return new WaitForSeconds(0.05f);
            tex.color = new Color(0f, 0f, 0f, 0.8f);
            yield return new WaitForSeconds(0.05f);
            tex.color = new Color(0f, 0f, 0f, 0.7f);
            yield return new WaitForSeconds(0.05f);
            tex.color = new Color(0f, 0f, 0f, 0.6f);
            yield return new WaitForSeconds(0.05f);
            tex.color = new Color(0f, 0f, 0f, 0.5f);
            yield return new WaitForSeconds(0.05f);
            tex.color = new Color(0f, 0f, 0f, 0.4f);
            yield return new WaitForSeconds(0.05f);
            tex.color = new Color(0f, 0f, 0f, 0.3f);
            yield return new WaitForSeconds(0.05f);
            tex.color = new Color(0f, 0f, 0f, 0.2f);
            yield return new WaitForSeconds(0.05f);
            tex.color = new Color(0f, 0f, 0f, 0.1f);
            yield return new WaitForSeconds(0.05f);
            tex.color = new Color(0f, 0f, 0f, 0f);
        }
    }
}
