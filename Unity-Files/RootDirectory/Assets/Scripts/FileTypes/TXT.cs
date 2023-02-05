using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sod-OS/FILETYPE/TXT")]
public class TXT : File
{
    [TextArea]
    public string txtFileContents;
    public int lineBreaks;
    public override void Open(OSController controller)
    {
        controller.LogStringWithReturn(txtFileContents);
        controller.LogStringWithReturn("", lineBreaks);
    }

    public override void Open(OSController controller, EventManager eventManager)
    {
        throw new System.NotImplementedException();
    }

    public override void Delete(OSController controller)
    {
        throw new System.NotImplementedException();
    }

}
