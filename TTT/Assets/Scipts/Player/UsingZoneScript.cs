using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UsingZoneScript : MonoBehaviour
{
    private GameObject thing;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject messagePlate;
    [SerializeField] AudioSource boxSound;
    bool messageClosed = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!messageClosed && Input.GetKeyDown(KeyCode.Space))
        {
            messagePlate.transform.Find("Message").GetComponent<Text>().text = "";
            messagePlate.SetActive(!messagePlate.activeSelf);
            messageClosed = true;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && thing != null && messageClosed)
        {
            messagePlate.SetActive(!messagePlate.activeSelf);
            messageClosed = false;
            switch (thing.tag)
            {
                case "Box": boxSound.Play(); thing.GetComponent<Box>().Use(cam, messagePlate); break;
                case "UsedBox": thing.GetComponent<Box>().Use(cam, messagePlate); break;
                case "Torch": thing.GetComponent<Torch>().Use(cam, messagePlate); break;
                case "FiredTorch": thing.GetComponent<Torch>().Use(cam, messagePlate); break;
                case "Fog": thing.GetComponent<FogScript>().Use(cam, messagePlate); break;
                default: break;
            }
            return;
        }
    }

    void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Box":
                {
                    Debug.Log("Can use the box");
                    thing = other.gameObject;
                    break;
                }
            case "UsedBox":
                {
                    Debug.Log("Can use used box");
                    thing = other.gameObject;
                    break;
                }
            case "Torch":
                {
                    thing = other.gameObject;
                    break;
                }
            case "FiredTorch":
                {
                    thing = other.gameObject;
                    break;
                }
            case "Fog":
                {
                    thing = other.gameObject;
                    break;
                }
            default: break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(thing))
        {
            thing = null;
            Debug.Log("No more gameobject");
        }
    }
}
