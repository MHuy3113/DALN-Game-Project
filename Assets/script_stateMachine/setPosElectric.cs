using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPosElectric : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);
    }
}
