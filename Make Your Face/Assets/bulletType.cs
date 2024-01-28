
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletType : MonoBehaviour
{
    public RawImage currentImage;
    public List<Texture2D> imageList = new List<Texture2D>();
    private int currentImageIndex = 0;
    public GameObject wallStickerPrefab;

    public Material stickerMaterial;
    // Start is called before the first frame update
    void Start()
    {
        currentImage = GetComponent<RawImage>();
        currentImage.texture = imageList[currentImageIndex];
        stickerMaterial = wallStickerPrefab.GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            
            Debug.Log("switch picture!!");
            int listLength = imageList.Count;
            int n = Random.Range(0, (listLength - 1));
            // if (currentImageIndex == (listLength - 1))
            // {
            //     currentImageIndex = 0;
            // }
            // else
            // {
            //     currentImageIndex += 1;
            // }

            currentImage.texture = imageList[n];
        }
    }
}