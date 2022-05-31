using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 5f;
    int wayPointIndex = 0;
    CircleCollider2D myCircleColider;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[wayPointIndex].transform.position;
        myCircleColider = GetComponent<CircleCollider2D>();
    }
    private void DestroyFireball()
    {
        if (myCircleColider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Destroy(gameObject);
        }
       
    }
    
    public void FireballPathing()
    {
        
        if (wayPointIndex <= waypoints.Count +1)
        {

            var targetPosition = waypoints[wayPointIndex + 1].transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed);

            if(transform.position == targetPosition)
            {
                wayPointIndex++;
            }

        }
       
    }


    // Update is called once per frame
    void Update()
    {
        FireballPathing();
        DestroyFireball();
    }
}
