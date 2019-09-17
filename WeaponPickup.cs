using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Renderer rend;
    public Collider col;
    private float timer = 0.0f;
    public bool active = true;
    public float respawnTime = 5.0f;
    public float amplitude = 0.01f;
    public float frequency = 1f;

    Vector3 current_pos = new Vector3();

    void Update () {
        if(!active) {
            if(transform.parent) {
                rend.enabled = true;
                col.enabled = true;
                active = true;
            }
            timer += Time.deltaTime;
            if(timer >= respawnTime) {
                rend.enabled = true;
                col.enabled = true;
                active = true;
                timer = 0.0f;
            }
        }
        if(!transform.parent && active) {
            transform.Rotate (0,35*Time.deltaTime,0);
            current_pos = transform.position;
            current_pos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
            transform.position = current_pos;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.parent.gameObject.tag == "car") {
            int max_a = other.transform.parent.gameObject.GetComponent<PickupManager>().attachPositions.Count;
            int curr_a = other.transform.parent.gameObject.GetComponent<PickupManager>().num_attachments;
            if (curr_a < max_a) {
                active = false;
                rend.enabled = false;
                col.enabled = false; 
            }
        }
    }
}
