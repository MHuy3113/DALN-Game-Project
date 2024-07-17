using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPos : MonoBehaviour
{
    public GameObject player;
    public GameObject pos;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            player.transform.position = pos.transform.position;
        }
    
    }
    
}
