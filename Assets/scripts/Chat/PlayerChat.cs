using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChat : MonoBehaviour
{
    [SerializeField]
    private Text text;

    [SerializeField]
    private Image image;

    [SerializeField]
    private RectTransform imageTransform;

    private AspectRatioFitter aspectRatioFitter;

    private void Awake() {
        aspectRatioFitter = image.GetComponent<AspectRatioFitter>();
    }

    public void Init(String text)
    {
        image.gameObject.SetActive(false);
        this.text.text = text;
        this.text.gameObject.SetActive(true);
    }

    public void Init(Texture2D texture)
    {
        text.gameObject.SetActive(false);

        // Convert Texture2D to Sprite
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        image.sprite = sprite;

        Vector2 size = imageTransform.sizeDelta;
        imageTransform.sizeDelta = new Vector2(Mathf.Min(size.x, texture.width), size.y);

        if (aspectRatioFitter)
        {
            aspectRatioFitter.aspectRatio = (float)texture.width / texture.height;
        }
        image.gameObject.SetActive(true);
    }
}
