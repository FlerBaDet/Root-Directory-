using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateImage : MonoBehaviour
{
    public GameObject image;
    Transform startPos;

    public void CreateImage(Sprite sprite)
    {
        GameObject newImage = Instantiate(image, transform);
        newImage.transform.SetParent(transform, true);
        newImage.transform.position = startPos.position;
        newImage.GetComponent<Image>().sprite = sprite;
        Translate();
    }

    public void Translate()
    {
        transform.position += new Vector3(0,7);
    }

    private void Start()
    {
        startPos = transform;
    }

}
