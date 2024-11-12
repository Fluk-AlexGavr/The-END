using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            player.transform.position = new Vector3(386, 20, 79);
        }
    }
}
