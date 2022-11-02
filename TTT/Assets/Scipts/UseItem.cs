using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    GameObject cam;
    PlaerInfo playerInfo;
    public void UsingItemFromInventory()
    {
        cam = transform.parent.parent.parent.parent.parent.gameObject;
        playerInfo = cam.GetComponent<CamFollow>().GetPlayer().GetComponent<PlaerInfo>();
        int buttonId = int.Parse(gameObject.name);
        int itemId = InventorySave.items[buttonId].id;
        Debug.Log("Тут храниться предмет с Id " + itemId);
        switch(itemId)
        {
            case 0: return;
            case 1:
                if (!playerInfo.torchOnOff)
                {
                    playerInfo.FireTorch();
                    
                }
                else
                {

                }
                break;
            case 2: playerInfo.SetBleeding(false); break;
            case 3: playerInfo.TakeAFood(30); break;
            case 4: return; //Нельзя использовать просто так
            case 5: break; //Лечит инфекции
            case 6: playerInfo.Heal(10); break; //
            case 7: playerInfo.Heal(10); break;
            case 8: break;
            default: return;
        }
        cam.GetComponent<Inventory>().MinusItem(1, buttonId);
    }
}
