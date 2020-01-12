using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHandler : MonoBehaviour
{

    private Image[] images;
    private Canvas gmCanvas;
    private Canvas playerCanvas;

    void Start()
    {
        gmCanvas = GameObject.Find("Game Manager").GetComponentInChildren<Canvas>();
        playerCanvas = GameObject.Find("Player").GetComponentInChildren<Canvas>();

        images = gmCanvas.GetComponentsInChildren<Image>();

        foreach (Image image in images)
        {
            Image playerImage = Instantiate(image, image.transform.position, image.transform.rotation);
            playerImage.transform.SetParent(playerCanvas.transform);
            playerImage.transform.localScale = image.transform.localScale;
        }
    }
}
