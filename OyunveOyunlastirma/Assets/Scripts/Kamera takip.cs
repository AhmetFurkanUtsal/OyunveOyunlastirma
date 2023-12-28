using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kameratakip : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform hedef;
    public Vector3 hedefMesafe;
    [SerializeField]
    private float fareHassasiyeti;
    float fareX, fareY;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, hedef.position + hedefMesafe, Time.deltaTime*10 );
        fareX += Input.GetAxis("Mouse X")*fareHassasiyeti;
        fareY += Input.GetAxis("Mouse Y")*fareHassasiyeti;
        if(fareY <= 0)
        {
            fareY = 0;
        }

       if(fareY >= 20)
        {
            fareY = 20;
        }
        this.transform.eulerAngles= new Vector3(fareY,fareX,0);
        hedef.transform.eulerAngles = new Vector3(0, fareX, 0);
    }
}
