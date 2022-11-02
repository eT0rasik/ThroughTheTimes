using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torch : MonoBehaviour
{
    bool isUsed = false;
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

        tag = "FiredTorch";
        if (!isUsed)
        {
      
            //DataBase data = cam.GetComponent<DataBase>();
            //Item item = data.items[Random.Range(1, data.items.Count)];
            if (cam.GetComponent<Inventory>().CheckIfEnaughInInventory(4, 1))
            {
                messagePlate.transform.Find("Message").GetComponent<Text>().text = "Вы зажгли факел";
                transform.Find("PF_Flame").gameObject.SetActive(true);
                isUsed = true;
            }
            else
            {
                messagePlate.transform.Find("Message").GetComponent<Text>().text = "У вас нет кремния";
            }
            //cam.GetComponent<Inventory>().AddItem(item, 1); 
        }
        else
        {
            messagePlate.transform.Find("Message").GetComponent<Text>().text = "Горящий факел";
        }
    }
}
