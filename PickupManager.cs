using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    //This script manages the pickups of an individual car.
    public List<Transform> attachPositions;
    private GameObject weaponClone;
    public int num_attachments = 0;
    private void OnTriggerEnter(Collider other) {
        bool done = false;
        if(other.tag == "weapon") {
            foreach (Transform attachPos in attachPositions) {
                if(!done && attachPos.childCount == 0) {   
                    weaponClone = Instantiate(other.gameObject, attachPos.position, attachPos.rotation, attachPos) as GameObject;
                    weaponClone.transform.SetParent(attachPos);
                    done = true; 
                    num_attachments++;
                }
            }
        }
    }
}
