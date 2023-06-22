using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyMoveManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> listEnemy;
    [SerializeField] public List<Transform> listPosRhombus;
    [SerializeField] public List<Transform> listPosTriangle;
    [SerializeField] public List<Transform> listPosRectangle;
    [SerializeField] public GameObject EnemyBoss;
    [SerializeField] public Transform PosEnemyBossSpawn;

    public GameObject playerShooting;

    
    void Start()
    {
        Invoke("EnemyMove1", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        //if(listEnemy.Count == 0)
        //{
        //    Instantiate(EnemyBoss, PosEnemyBossSpawn.transform.position, Quaternion.identity);
        //}
    }

    private void EnemyMove1()
    {
        for (int i = 0; i < listEnemy.Count; i++)
        {
            listEnemy[i].transform.DOMove(new Vector2(listPosRhombus[i].position.x, listPosRhombus[i].position.y), 3f);
        }
        Invoke("EnemyMove2", 5f);
        
    }

    private void EnemyMove2()
    {
        for (int i = 0; i < listEnemy.Count; i++)
        {
            listEnemy[i].transform.DOMove(new Vector2(listPosTriangle[i].position.x, listPosTriangle[i].position.y), 3f);
        }

        Invoke("EnemyMove3", 5f);
    }

    private void EnemyMove3()
    {
        for (int i = 0; i < listEnemy.Count; i++)
        {
            listEnemy[i].transform.DOMove(new Vector2(listPosRectangle[i].position.x, listPosRectangle[i].position.y), 3f);
        }
        Invoke("IsEnemySimulated", 3f);
        
        
    }

    private void IsEnemySimulated()
    {
        for (int i = 0; i < listEnemy.Count; i++)
        {
            listEnemy[i].GetComponent<Rigidbody2D>().simulated = true;
        }
        //IsShooting();
    }

    //private void IsShooting()
    //{
    //    playerShooting.GetComponent<Shooting>().Bullet();
    //}
    



}
