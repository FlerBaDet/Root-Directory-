using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Sod-OS/FILETYPE/JPOG")]
public class JPOG : File
{
    public Sprite image;
    
    GenerateImage imageDisplay;

    private void Awake()
    {
        deleted = false;
    }
    public override void Open(OSController controller)
    {
        imageDisplay = controller.imageDisplay;
        imageDisplay.CreateImage(image);

    }

    public override void Open(OSController controller, EventManager eventManager)
    {
        throw new System.NotImplementedException();
    }

    public override void Delete(OSController controller)
    {
        
    }

}
