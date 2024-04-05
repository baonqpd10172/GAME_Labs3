using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSliderController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    private void Start()
    {
        slider.value = 10f;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Trap");
            slider.value--;
        }
    }
}
