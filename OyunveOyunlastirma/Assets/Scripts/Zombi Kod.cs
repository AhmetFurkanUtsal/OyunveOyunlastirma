using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiKod : MonoBehaviour
{
    // Start is called before the first frame update

    public float zombiHp = 100;
    Animator zombiAnim;
    bool zombiOlu;
    void Start()
    {
        zombiAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zombiHp <= 0)
        
        {
            zombiOlu = true;
        }

        if (zombiOlu == true) 
        {
            zombiAnim.SetBool("oldu", true);
            StartCoroutine(YokOl());

        }
        else
        {

        }

    }
    IEnumerator YokOl()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    public void HasarAl()
    {
        zombiHp -= Random.Range(15, 25);
    }
}
