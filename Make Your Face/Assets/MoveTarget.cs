using System.Collections;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public float speed;
    public Transform wall_left;
    public Transform wall_right;
    public Transform wall_front;
    public Transform wall_back;

    void Update()
    {
        MoveRandomly();
    }

    void MoveRandomly()
    {
    
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        
        Vector3 newPosition = transform.position + randomDirection * speed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, wall_left.position.x, wall_right.position.x);
        newPosition.z = Mathf.Clamp(newPosition.z, wall_front.position.z, wall_back.position.z);


        // Set the new position
        transform.position = newPosition;
    }
}
