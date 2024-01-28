using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class wall : MonoBehaviour
{
    public GameObject wallStickerPrefab;
    [FormerlySerializedAs("wallScale")] public Vector3 wallPosition;
    public GameObject bulletSticker;
    public RawImage currentBulletImage;

    void Start()
    {
        wallPosition = transform.localPosition;
        currentBulletImage = bulletSticker.GetComponent<RawImage>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(gameObject.transform.position);
        Vector3 bulletPos = other.transform.position;
        currentBulletImage = bulletSticker.GetComponent<RawImage>();
        
        createSticker(bulletPos, transform.localPosition, currentBulletImage);
        
    }

    private void createSticker(Vector3 stickerPosition, Vector3 wallPosition, RawImage rawImage)
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
        // Create the new material
        Texture2D textureFromRawImage = null;
        textureFromRawImage = rawImage.texture as Texture2D;
        Material newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.mainTexture = textureFromRawImage;
        
        //Create the sticker
        var sticker = Instantiate(wallStickerPrefab, stickerPosition, Quaternion.Euler(stickerRotationX, stickerRotationY, stickerRotationZ));
        Renderer stickerRender = sticker.GetComponent<Renderer>();
        stickerRender.material.SetTexture("_BaseMap" ,textureFromRawImage);
    }
}