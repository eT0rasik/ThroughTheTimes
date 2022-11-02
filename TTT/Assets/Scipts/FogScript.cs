using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use(GameObject cam, GameObject messagePlate)
    {

        messagePlate.transform.Find("Message").GetComponent<Text>().text = "Туман настолько густой, что кажется, будто он образует стену. Что-то зловещее кроется в нём. Ты не решаешься войти в него.";

    }
}
