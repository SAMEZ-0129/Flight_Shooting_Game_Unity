using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_zone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if  (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy")) 
        {
            other.gameObject.SetActive(false); 
            if (other.gameObject.name.Contains("Bullet"))
            {
                Player_fire_bullet.bulletObjectPool.Add(other.gameObject);
            }
        }
    }
}
