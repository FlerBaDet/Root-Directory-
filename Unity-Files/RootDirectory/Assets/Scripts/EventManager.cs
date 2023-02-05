using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public EVENT[] EVENTs;
    public EVENT currEVENT;
    public int currentEventNumber = 0;

    private void Start()
    {
        currEVENT = EVENTs[currentEventNumber];
    }

    public void init()
    {
        if (currentEventNumber < EVENTs.Length)
        {
            currEVENT = EVENTs[currentEventNumber];
        }
    }

    public void EventCheck(OSController controller, string comm, File fileAffected)
    {
        if (currentEventNumber < EVENTs.Length)
        {
            currEVENT = EVENTs[currentEventNumber];
            Debug.Log(comm == currEVENT.command);
            Debug.Log(comm);
            Debug.Log(currEVENT.command);
            
            if (comm.ToLower() == currEVENT.command.ToLower() && controller.osNav.currentDirectory == currEVENT.location && fileAffected.keyword == currEVENT.file.keyword && currEVENT.eventNumber == currentEventNumber)
            {
                currEVENT.completed = true;
                currentEventNumber++;
                init();
            }
        }
        else
        {
            Debug.Log("Out of Events");
        }
    }

}
