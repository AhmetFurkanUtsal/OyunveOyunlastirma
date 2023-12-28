using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class AteşEt : MonoBehaviour
{
    // Start is called before the first frame update

    Camera kamera;
    public LayerMask zombiKatman;
    void Start()
    {
        kamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            AtesEtme();
        }
       
    }
    void AtesEtme()
    {
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,Mathf.Infinity,zombiKatman))
        {
            hit.collider.gameObject.GetComponent<ZombiKod>().HasarAl();
        }
    }
}
