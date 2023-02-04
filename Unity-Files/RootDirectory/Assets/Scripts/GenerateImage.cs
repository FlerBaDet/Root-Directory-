using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateImage : MonoBehaviour
{
    public GameObject image;
    public OSController controller;
    GameObject newImage;
    Vector3 startPos;

    public void CreateImage(Sprite sprite)
    {
        //Translate(controller.osNav.imageTransRate * 7);
        controller.LogStringWithReturn("", 7f, true);
        DeployImage(sprite);
    }

    private void DeployImage(Sprite sprite)
    {
        newImage = Instantiate(image, transform);
        newImage.transform.position = startPos;
        newImage.transform.SetParent(transform, false);
        newImage.GetComponent<Image>().sprite = sprite;
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
