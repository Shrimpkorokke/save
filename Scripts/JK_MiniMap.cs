using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_MiniMap : MonoBehaviour
{
    public Transform playerIcon;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Warrior")
        {
            playerIcon.transform.position = transform.position + new Vector3(0, 20, 0);
            
        }
        
        
    }
    

}
