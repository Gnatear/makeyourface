using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class wall : MonoBehaviour
{
    public GameObject wallStickerPrefab;
    [FormerlySerializedAs("wallScale")] public Vector3 wallPosition;


    void Start()
    {
        wallPosition = transform.localPosition;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(gameObject.transform.position);
        Vector3 bulletPos = other.transform.position;
        createSticker(bulletPos, transform.localPosition);
        
    }

    private void createSticker(Vector3 stickerPosition, Vector3 wallPosition)
    {
        float stickerRotationX = 0;
        float stickerRotationY = 0;
        float stickerRotationZ = 0;
        
        if (wallPosition.y == 0)
        {
            stickerRotationX = 0;
        }
        else
        {
            stickerRotationX = 90;
            if (this.wallPosition.x > 0)
            {
                stickerRotationY = -90;
            }
            if (this.wallPosition.x < 0)
            {
                stickerRotationY = 90;
            }
            if (this.wallPosition.z < 0)
            {
                stickerRotationY = 0;
            }
            if (this.wallPosition.z > 0)
            {
                stickerRotationY = 180;
            }
        }
        var sticker = Instantiate(wallStickerPrefab, stickerPosition, Quaternion.Euler(stickerRotationX, stickerRotationY, stickerRotationZ));
    }
}