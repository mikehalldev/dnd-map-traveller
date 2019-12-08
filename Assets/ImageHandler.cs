using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHandler : MonoBehaviour
{

    private Dictionary<Image, Image> images;
    private Canvas gmCanvas;
    private Canvas playerCanvas;

    void Start()
    {
        images = new Dictionary<Image, Image>();
        gmCanvas = GameObject.Find("Game Manager").GetComponentInChildren<Canvas>();
        playerCanvas = GameObject.Find("Player").GetComponentInChildren<Canvas>();

        MakeImageDictionary();
    }

    void MakeImageDictionary()
    {
        Image[] gmImages = gmCanvas.GetComponentsInChildren<Image>();
        foreach (Image image in gmImages)
        {
            Image playerImage = MakePlayerImage(image);
            images.Add(image, playerImage);
        }
    }

    Image MakePlayerImage(Image image)
    {
        Image playerImage = Instantiate(image, image.transform.position, image.transform.rotation);
        playerImage.transform.SetParent(playerCanvas.transform);
        playerImage.transform.localScale = image.transform.localScale;

        Color color = playerImage.color;
        color.a = 0f;
        playerImage.color = color;
        return playerImage;
    }
}
