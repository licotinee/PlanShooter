using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBossControl : MonoBehaviour
{
    public GameObject bossBullet;
    public Transform poninFire1;
    public Transform poninFire2;
    public Transform parentBulletClone;
    public GameObject enemyExplosionAnim;
    public Transform PosEnemyBoss;
    public int bloodBoss = 300;
    //public GameObject boss;

    private static EnemyBossControl instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    public static EnemyBossControl Instance
    {
        get { return instance; }
    }
    void Start()
    {
        //StartCoroutine(BossShooting());
        InvokeRepeating("SpawnBullet", 1f, 1.5f);

        //BossMove();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void BossMove()
    {
        transform.DOMove(PosEnemyBoss.transform.position, 4f);
    }

    private void SpawnBullet()
    {
        var bulltetClone1 = Instantiate(bossBullet, poninFire1.transform.position, Quaternion.identity);
        var bulltetClone2 = Instantiate(bossBullet, poninFire2.transform.position, Quaternion.identity);
        bulltetClone1.transform.SetParent(parentBulletClone);
        bulltetClone2.transform.SetParent(parentBulletClone);
    }
    //public void BossActive()
    //{

    //    StartCoroutine(BossShooting());

    //}

    //void BossShoot()
    //{
    //    Instantiate(bossBullet, transform.position, Quaternion.identity);
    //}
    //IEnumerator BossShooting()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    BossShoot();
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController.Instance.isShooting = false;
            Destroy(collision.transform.gameObject);
            GameObject explosion = Instantiate(enemyExplosionAnim, collision.transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            PlayerController.Instance.UILoseActice();
        }
        if (collision.gameObject.tag == "Bullet")
        {
            bloodBoss -= 1;
            Destroy(collision.transform.gameObject);

        }

        if(bloodBoss == 0)
        {
            PlayerController.Instance.score += 10;
            Destroy(gameObject);
            GameObject explosion = Instantiate(enemyExplosionAnim, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            PlayerController.Instance.UpdateScore();
            PlayerController.Instance.DelayUIWin();
        }

    }



}
