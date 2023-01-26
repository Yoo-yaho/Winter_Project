using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;

    public void Start()
    {
        Instantiate(player);
        player.transform.position = transform.position;
    }
}
