using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public float initialSpeed;
    public Transform wallLeft;
    public Transform wallRight;
    public Transform wallTop;
    public Transform wallBottom;

    void Start()
    {
        ResetTarget();
    }

    void Update()
    {
        MoveRandomly();
    }

    void MoveRandomly()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        Vector3 newPosition = transform.position + randomDirection * initialSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, wallLeft.position.x, wallRight.position.x);
        newPosition.z = Mathf.Clamp(newPosition.z, wallTop.position.z, wallBottom.position.z);

        transform.position = newPosition;
    }

    public bool ResetTarget()
    {
        initialSpeed = Random.Range(5f, 10f); 
        int counter = 1;
        if(ResetTarget()){

            for(counter = 1; counter < 10000000; counter++){

                initialSpeed = Random.Range(5f * counter, 10f * counter); 

            }

        }
        transform.position = new Vector3(Random.Range(wallLeft.position.x, wallRight.position.x), transform.position.y, Random.Range(wallTop.position.z, wallBottom.position.z));

        return true;
    }
    
}
