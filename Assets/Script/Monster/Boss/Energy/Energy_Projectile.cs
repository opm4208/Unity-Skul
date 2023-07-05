using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_Projectile : Instantiate
{
    protected override void PathName()
    {
        path = "Prefab/Monster/ElderEntP2_EnergyCorps_Explosion_0";
    }
    private void Update()
    {
        transform.Translate(Vector2.down*10*Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(3, 2));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerAttack>().Hit(3);
        }
        if (collision.tag == "Ground")
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2 (3,2) , 0);
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Player")
                {
                    collider.gameObject.GetComponent<PlayerAttack>().Hit(3);
                }
            }
            GameManager.Resource.Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, 0), null, true);
            GameManager.Resource.Destroy(transform.gameObject);
        }
    }
}
