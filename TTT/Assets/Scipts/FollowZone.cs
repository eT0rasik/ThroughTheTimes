using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowZone : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    FollowPlayer followPlayer;
    [SerializeField] bool canLost;
    // Start is called before the first frame update
    void Start()
    {
        followPlayer = GetComponentInParent<FollowPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
            followPlayer.SetFollowState(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && canLost)
        {
            followPlayer.SetFollowState(false);
        }
    }
}
