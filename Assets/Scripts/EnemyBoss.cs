using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] Fireball fireball;
    [SerializeField] Vector2 waypoint;
    Animator enemyBossAnimation;
    BoxCollider2D myBodyCollider;
    [SerializeField] ParticleSystem enemyDeathParticleEffects;




    // Start is called before the first frame update
    void Start()
    {
        enemyBossAnimation = GetComponent<Animator>();
        fireball = FindObjectOfType<Fireball>();

        SummoningFire();

    }

    public IEnumerator Animation()
    {


        enemyBossAnimation.SetBool("Enemy Boss Idle", true);
        yield return new WaitForSeconds(Random.Range(6f, 12f));
        enemyBossAnimation.SetBool("Enemy Boss Idle", false);
        enemyBossAnimation.SetTrigger("Enemy Boss");


        yield return new WaitForSeconds(2f);



        enemyBossAnimation.SetBool("Enemy Boss Idle", true);

        yield return new WaitForSeconds(10f);



    }
    public void SummoningFire()
    {
        Instantiate(fireball, waypoint, Quaternion.identity);
        StartCoroutine(WaitForReload());
    }
    public IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(3f);
        SummoningFire();
    }

    private void OnTriggerExit2D(Collider2D collision2D)
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            Destroy(gameObject);
        }
        
        
    }
    void Update()
    {
        StartCoroutine(Animation());
    }
}