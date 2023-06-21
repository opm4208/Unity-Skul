using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingWoodBall : EnemyBall
{
    private StandingMonsterData data;
    private Coroutine ballResource;
    private void Awake()
    {
        data = GameManager.Resource.Load<StandingMonsterData>("Data/StandingWood");
    }

    void Start()
    {
        damage = data.StandingMonsters[0].damage;
        ballResource = StartCoroutine(BallResource());
    }
    IEnumerator BallResource()
    {
        yield return new WaitForSeconds(5);
        GameManager.Resource.Destroy(transform.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layerMask.IsContain(collision.gameObject.layer))
        {
            StopCoroutine(ballResource);
            collision.gameObject.GetComponent<PlayerAttack>().Hit(damage);
            GameManager.Resource.Destroy(transform.gameObject);
        }
    }
}
