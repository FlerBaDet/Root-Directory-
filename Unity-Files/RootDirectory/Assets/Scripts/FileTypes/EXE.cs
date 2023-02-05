using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Sod-OS/FILETYPE/EXE")]
public class EXE : File
{
    //public EventManager EM;
    //public int currentEvent = 0;

    private void Awake()
    {
        deleted = false;
    }

    public override void Open(OSController controller, EventManager EM)
    {
        
        controller.LogStringWithReturn(EM.currEVENT.author + " " + EM.currEVENT.date);
        controller.LogStringWithReturn(EM.currEVENT.message);
        controller.LogStringWithReturn("", EM.currEVENT.lineBreaks + 2);
        //controller.LogStringWithReturn("============================");
        //controller.DisplayDirectory();
    }

    public override void Open(OSController controller)
    {
        throw new System.NotImplementedException();
    }

    public override void Delete(OSController controller)
    {
        throw new System.NotImplementedException();
    }

}