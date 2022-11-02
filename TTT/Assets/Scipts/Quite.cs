using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ToMenu()
    {
        Destroy(FindObjectOfType<DontDestroy>());
        InventorySave.items = new List<ItemInventory>();
        SceneManager.LoadScene("Main_Menu");
    }
}
