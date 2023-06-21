using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float bloods = 5f;
    public GameObject enemyExplosionAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.transform.gameObject);
            bloods -= 1;
            
        }
        if (bloods == 0f)
        {
            Destroy(gameObject);
            PlayerController.Instance.score += 1;
            GameObject explosion = Instantiate(enemyExplosionAnim, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            PlayerController.Instance.UpdateScore();

    
        }
        if (collision.gameObject.tag == "Player")
        {
            PlayerController.Instance.isShooting = false;
            Destroy(collision.transform.gameObject);
            GameObject explosion = Instantiate(enemyExplosionAnim, collision.transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            PlayerController.Instance.UILoseActice();
        }

    }

  


    }
