using UnityEngine;
using UnityEngine.UI;

public class FuelLevel : MonoBehaviour
{
    public static void Activate() => refer.gameObject.SetActive(true);
    static FuelLevel refer;
    public static void SetAmount(float a) => refer.GetComponent<Slider>().value = a;

    void Awake()
    {
        refer = this;
        gameObject.SetActive(false);
    }
}
