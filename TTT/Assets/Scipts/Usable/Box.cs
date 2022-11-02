using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
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
        tag = "UsedBox";
        int amount = 1;
        if (!isUsed)
        {
            DataBase data = cam.GetComponent<DataBase>();
            Item item = data.items[Random.Range(1, data.items.Count)];
            if (item.id == 4)
            {
                amount = 6;
            }
            messagePlate.transform.Find("Message").GetComponent<Text>().text = "Вы нашли " + item.name.ToLower(); ;
            cam.GetComponent<Inventory>().AddItem(item, amount);
            isUsed = true;
        }
        else
        {
            messagePlate.transform.Find("Message").GetComponent<Text>().text = "Коробка пуста";
        }
    }
}
