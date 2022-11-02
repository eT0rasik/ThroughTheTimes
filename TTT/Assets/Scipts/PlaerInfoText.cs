using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaerInfoText : MonoBehaviour
{
    public GameObject Hp;
    public GameObject Hunger;
    public GameObject Mind;
    Text HpText;
    Text HungerText;
    Text MindText;
    GameObject player;
    PlaerInfo playerinfo;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerinfo = player.GetComponent<PlaerInfo>();
        HpText = Hp.GetComponent<Text>();
        HungerText = Hunger.GetComponent<Text>();
        MindText = Mind.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HpText.text = "Здоровье: " + playerinfo.GetHp().ToString() + "/100";
            HungerText.text =  "Голод: " + playerinfo.GetHunger().ToString();
            MindText.text = "Разум: " + playerinfo.GetMind().ToString() + "/100";
        }
    }
}
