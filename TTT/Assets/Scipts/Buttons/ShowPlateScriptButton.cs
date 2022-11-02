using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlateScriptButton : MonoBehaviour
{
    [SerializeField] GameObject show;
    [SerializeField] List<GameObject> deactivate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInventory()
    {       
        for (int i = 0; i < deactivate.Count; ++i)
        {
            deactivate[i].SetActive(false);
        }
        show.SetActive(true);
    }
}
