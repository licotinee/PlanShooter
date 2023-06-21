using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    //public float spawnInterval = 0.5f;
    public Transform parentBulletClone;
    
    void Start()
    {
        Bullet();

    }

   public void Bullet()
    {
        InvokeRepeating("SpawnBullet", 1f, 0.1f);
    }

    private void SpawnBullet()
    {
        var bulltetClone = Instantiate(bullet, transform.position, Quaternion.identity);
        bulltetClone.transform.SetParent(parentBulletClone);
    }
}
