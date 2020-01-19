using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageHandler : MonoBehaviour {

    private Image[] images;
    private Canvas gmCanvas;
    private Canvas playerCanvas;

    private EventTrigger.Entry clickEntry;

    Dictionary<Image, Image> imagePairs;

    void Start() {
        gmCanvas = GameObject.Find("Game Manager").GetComponentInChildren<Canvas>();
        playerCanvas = GameObject.Find("Player").GetComponentInChildren<Canvas>();

        images = gmCanvas.GetComponentsInChildren<Image>();

        clickEntry = new EventTrigger.Entry();
        clickEntry.eventID = EventTriggerType.PointerClick;
        clickEntry.callback.AddListener((eventData) => { OnClick((PointerEventData) eventData); });

        imagePairs = new Dictionary<Image, Image>();
        foreach (Image image in images) {
            EventTrigger trigger = image.gameObject.AddComponent<EventTrigger>();
            trigger.triggers.Add(clickEntry);

            Image playerImage = Instantiate(
                image,
                image.transform.position + playerCanvas.transform.position,
                image.transform.rotation,
                playerCanvas.transform
            );
            playerImage.transform.localScale = image.transform.localScale;

            imagePairs.Add(image, playerImage);
        }
    }

    private void OnClick(PointerEventData eventData) {
        Image image = eventData.pointerPress.GetComponent<Image>();
        ChangeTransparency(imagePairs[image]);
    }

    private void ChangeTransparency(Image image) {
        Color color = image.color;
        if (color.a == 1) {
            color.a = 0;
        } else {
            color.a = 1;
        }
        image.color = color;
    }
}
