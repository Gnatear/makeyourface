using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public float initialSpeed;
    public Transform wallLeft;
    public Transform wallRight;
    public Transform wallFront;
    public Transform wallBack;

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
        newPosition.z = Mathf.Clamp(newPosition.z, wallFront.position.z, wallBack.position.z);

        transform.position = newPosition;
    }

    public void ResetTarget()
    {
        transform.position = new Vector3(Random.Range(wallLeft.position.x, wallRight.position.x), transform.position.y, Random.Range(wallFront.position.z, wallBack.position.z));
    }
}
