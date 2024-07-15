using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBoss : MonoBehaviour
{
    public float energy = 0;
    public int hp = 100;
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        energy += 10;
    }
}
