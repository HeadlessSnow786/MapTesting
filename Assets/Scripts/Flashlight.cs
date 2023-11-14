using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject luminant;
    private bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        luminant.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            luminant.gameObject.SetActive(isOn);
        }
    }
}
