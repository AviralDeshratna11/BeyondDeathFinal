using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntry : MonoBehaviour
{
    [SerializeField] Sprite enemySprite;
    Sprite currentSprite;
    // Start is called before the first frame update
    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>().sprite;
             
    }

    // Update is called once per frame
    void Update()
    {
        currentSprite = enemySprite;
    }
}
