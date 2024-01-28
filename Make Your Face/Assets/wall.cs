using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public GameObject wallStickerPrefab;
    public Vector3 wallScale;


    void Start()
    {
        wallScale = transform.localScale;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(gameObject.transform.position);
        Vector3 bulletPos = other.transform.position;
        Debug.Log("hit pos: " + bulletPos);
        if (wallScale.z == 1)
        {
            Vector3 stickerRotation = new Vector3(90, 0, 0);
            createSticker(bulletPos, transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void createSticker(Vector3 stickerPosition, float x, float y, float z)
    {
        float stickerRotationX = 0;
        float stickerRotationY = 0;
        float stickerRotationZ = 0;
        
        if (z == 1)
        {
            stickerRotationX = 90;
        }
        
        var sticker = Instantiate(wallStickerPrefab, stickerPosition, Quaternion.Euler(stickerRotationX, stickerRotationY, stickerRotationZ));
    }
}