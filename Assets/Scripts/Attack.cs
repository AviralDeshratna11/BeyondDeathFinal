using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;

    [SerializeField] GameObject enemyBoss;
    BoxCollider2D attackBoxCollider;
    [SerializeField] ParticleSystem enemyDeathParticleEffects;
   
    private void Start()
    {
        
        attackBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (attackBoxCollider.IsTouchingLayers(LayerMask.GetMask("Enemy 1")))
            {
                Destroy(enemy1);
                
                Instantiate(enemyDeathParticleEffects, enemy1.transform.position, Quaternion.identity);
            }
            if (attackBoxCollider.IsTouchingLayers(LayerMask.GetMask("Enemy 2")))
            {
                Destroy(enemy2);
                Instantiate(enemyDeathParticleEffects, enemy2.transform.position, Quaternion.identity);
            }
            if (attackBoxCollider.IsTouchingLayers(LayerMask.GetMask("Enemy Boss")))
            {
               
                Destroy(enemyBoss);
                Instantiate(enemyDeathParticleEffects, enemyBoss.transform.position, Quaternion.identity);
            }
        }
       
        
    }
}
