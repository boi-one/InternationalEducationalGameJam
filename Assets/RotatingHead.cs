using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingHead : MonoBehaviour
{   
    void Start()
    {
        StartCoroutine(rotate());
        IEnumerator rotate()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                transform.Rotate(new Vector3(0, 0, 1), 1);
                yield return new WaitForSeconds(0.5f);
                transform.Rotate(new Vector3(0, 0, 1), 1);
                yield return new WaitForSeconds(0.5f);
                transform.Rotate(new Vector3(0, 0, 1), 1);
                yield return new WaitForSeconds(1f);
                transform.Rotate(new Vector3(0, 0, 1), -1);
                yield return new WaitForSeconds(0.5f);
                transform.Rotate(new Vector3(0, 0, 1), -1);
                yield return new WaitForSeconds(0.5f);
                transform.Rotate(new Vector3(0, 0, 1), -1);
                yield return new WaitForSeconds(1f);
            }
        }
    }

}
