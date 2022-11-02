using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        newPos = player.transform.position;
        newPos.y += 13;
        newPos.z -= 6;
        transform.position = newPos;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
