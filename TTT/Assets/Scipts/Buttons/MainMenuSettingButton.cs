using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSettingButton : MonoBehaviour
{
    [SerializeField] GameObject plate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void On_Off()
    {
        plate.SetActive(!plate.activeSelf);
    }
}
