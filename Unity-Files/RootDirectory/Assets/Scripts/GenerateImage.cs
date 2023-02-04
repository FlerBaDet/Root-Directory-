using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateImage : MonoBehaviour
{
    public GameObject image;
    public Sprite testImage;
    Vector3 startPos;

    public void CreateImage(Sprite sprite)
    {
        GameObject newImage = Instantiate(image, transform);
        newImage.transform.parent = transform;
        newImage.GetComponent<Image>().sprite = sprite;
    }

    public void Translate()
    {
        transform.position += new Vector3(0,24);
    }

    private void Start()
    {
        startPos = transform.position;
        CreateImage(testImage);
        Translate();
    }

}
