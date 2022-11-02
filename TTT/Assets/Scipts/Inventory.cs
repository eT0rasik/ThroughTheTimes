using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public DataBase data;

   // public List<ItemInventory> items = new List<ItemInventory>();
   
    public GameObject gameObjShow;

    public GameObject InventoryMainObject;
    public int maxCount;

    public Camera cam;
    public EventSystem es;

    public int currentId;
    public ItemInventory currentItem;

    public GameObject backGround;

    public GameObject defaultMenu;
    public List<GameObject> deactivate;

   // public RectTransform movingOnject;
    public Vector3 offset;

    public float timer;
    public bool ispuse;
    public bool guipuse;

    public void Start()
    {
        if (InventorySave.items.Count == 0)
        {
            AddGraphics();
        }
        else
        {
            AddGraphicsAfterSAve();
        }

        /*
        for (int i = 0; i < maxCount; i++) // test inventory
        {
            AddItem(i, data.items[Random.Range(0, data.items.Count)], Random.Range(1, 99));
           // SearchForSameItem(data.items[Random.Range(0, data.items.Count)], Random.Range(1, 99));
        }
        */

        UpdateInventory();
    } 
    public void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && ispuse == false)
        {
            ispuse = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ispuse == true)
        {
            ispuse = false;
        }
        if (ispuse == true)
        {
            timer = 0;
            guipuse = true;

        }
        else if (ispuse == false)
        {
            timer = 1f;
            guipuse = false;

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            for (int i = 0; i < deactivate.Count; ++i)
            {
                deactivate[i].SetActive(false);
            }
            defaultMenu.SetActive(true);
            backGround.SetActive(!backGround.activeSelf);
            if (backGround.activeSelf)
            {
                UpdateInventory();
            }
        }
    }

    private int SearchForFree()
    {
        int freeid;
        for (int i = 0; i < maxCount; i++)
        {
            if (InventorySave.items[i].id == 0)
            {
                freeid = i;
                return freeid;
            }
        }
        return -1;
    }

    public bool SearchForSameItem(Item item, int count)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (InventorySave.items[i].id == item.id)
            {
                InventorySave.items[i].count += count;
                count = 0;
                i = maxCount;
                return true;
            }
        }
        return false;
    }

    public bool CheckIfEnaughInInventory(int itemId, int count)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (InventorySave.items[i].id == itemId && InventorySave.items[i].count >= count)
            {
                MinusItem(count, i);
                return true;
            }
        }
        return false;
    }

    public void AddItem(Item item, int count)
    {
        int id = SearchForFree();
        if (SearchForSameItem(item, count))
        {
            UpdateInventory();
            return;
        }

        InventorySave.items[id].id = item.id;
        InventorySave.items[id].count = count;
        InventorySave.items[id].itemGameObj.transform.Find("Image").GetComponent<Image>().sprite = item.img;

        if (count > 0 && item.id != 0)
        {
            //items[id].itemGameObj.GetComponentInChildren<Text>().text = count.ToString();
            InventorySave.items[id].itemGameObj.transform.Find("Amount").GetComponent<Text>().text = count.ToString();
            InventorySave.items[id].itemGameObj.transform.Find("Name").GetComponent<Text>().text = item.name;
        }
        else
        {
            // items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
            InventorySave.items[id].itemGameObj.transform.Find("Amount").GetComponent<Text>().text = "";
            InventorySave.items[id].itemGameObj.transform.Find("Name").GetComponent<Text>().text = "";
        }
    }

    public void AddInventoryItem(int id, ItemInventory invItem)
    {
        //int id = SearchForFree();

        InventorySave.items[id].id = invItem.id;
        InventorySave.items[id].count = invItem.count;
        InventorySave.items[id].itemGameObj.transform.Find("Image").GetComponent<Image>().sprite = data.items[invItem.id].img;

        if (invItem.count > 0 && invItem.id != 0)
        {
            //items[id].itemGameObj.GetComponentInChildren<Text>().text = invItem.count.ToString();
            InventorySave.items[id].itemGameObj.transform.Find("Amount").GetComponent<Text>().text = invItem.count.ToString();
        
        }
        else
        {
            //items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
            InventorySave.items[id].itemGameObj.transform.Find("Amount").GetComponent<Text>().text = "";
            InventorySave.items[id].itemGameObj.transform.Find("Name").GetComponent<Text>().text = "";
        }
    }

    public void AddGraphics()
    {
        for (int i = 0; i < maxCount; i++)
        {
            GameObject newItem = Instantiate(gameObjShow, InventoryMainObject.transform) as GameObject;

            newItem.name = i.ToString();

            ItemInventory ii = new ItemInventory();
            ii.itemGameObj = newItem;

            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);

            Button tempButton = newItem.GetComponent<Button>();

            InventorySave.items.Add(ii);
        }
    }

    public void AddGraphicsAfterSAve()
    {
        for (int i = 0; i < maxCount; i++)
        {
            GameObject newItem = Instantiate(gameObjShow, InventoryMainObject.transform) as GameObject;

            newItem.name = i.ToString();

            ItemInventory ii = new ItemInventory();
            ii.itemGameObj = newItem;

            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);

            Button tempButton = newItem.GetComponent<Button>();

            InventorySave.items[i].itemGameObj = ii.itemGameObj;
        }
    }

    public void MinusItem(int amount, int buttinId)
    {
        InventorySave.items[buttinId].count -= amount;
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        for (int i = 0; i< maxCount; i++)
        {
            if (InventorySave.items[i].id != 0 && InventorySave.items[i].count > 0)
            {
                //items[i].itemGameObj.GetComponentInChildren<Text>().text = items[i].count.ToString();
                InventorySave.items[i].itemGameObj.transform.Find("Amount").GetComponent<Text>().text = InventorySave.items[i].count.ToString();
                InventorySave.items[i].itemGameObj.transform.Find("Image").GetComponent<Image>().sprite = data.items[InventorySave.items[i].id].img;
                InventorySave.items[i].itemGameObj.transform.Find("Name").GetComponent<Text>().text = data.items[InventorySave.items[i].id].name;
            }
            else
            {
                //items[i].itemGameObj.GetComponentInChildren<Text>().text = "";
                InventorySave.items[i].id = 0; 
                InventorySave.items[i].itemGameObj.transform.Find("Amount").GetComponent<Text>().text = "";
                InventorySave.items[i].itemGameObj.transform.Find("Name").GetComponent<Text>().text = "";
                InventorySave.items[i].itemGameObj.transform.Find("Image").GetComponent<Image>().sprite = data.items[0].img;
            }

        }
    }

    public ItemInventory CopyInventoryItem(ItemInventory old)
    {
        ItemInventory New = new ItemInventory();

        New.id = old.id;
        New.itemGameObj = old.itemGameObj;
        New.count = old.count;

        return New;
    }
}

[System.Serializable]

public class ItemInventory
{
    public int id;
    public GameObject itemGameObj;

    public int count;
}


