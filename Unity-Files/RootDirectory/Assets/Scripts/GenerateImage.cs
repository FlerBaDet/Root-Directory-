using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateImage : MonoBehaviour
{
    public GameObject image;
    public OSController controller;
    Vector3 startPos;

    public void CreateImage(Sprite sprite)
    {
        GameObject newImage = Instantiate(image, transform);
        newImage.transform.position = startPos;
        newImage.transform.SetParent(transform, false);
        newImage.GetComponent<Image>().sprite = sprite;
        MakeSpace();
    }

    public void MakeSpace()
    {
        for (int i = 0; i < controller.osNav.imageMoveRate; i++)
        {
            controller.LogStringWithReturn("", controller.osNav.imageTransRate/controller.osNav.imageMoveRate);
        }
    }

    public void Translate(int y)
    {
        transform.position += new Vector3(0, y);
    }

    private void Awake()
    {
        startPos = transform.position;
    }

}
