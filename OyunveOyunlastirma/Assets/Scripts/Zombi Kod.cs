using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiKod : MonoBehaviour
{
    // Start is called before the first frame update

    public float zombiHp = 100;
    Animator zombiAnim;
    bool zombiOlu;
    public float KocvalamaMesafesi;
    public float saldirmaMesafesi;
    float mesafe;
    NavMeshAgent zombiNavMesh;


    GameObject hedefOyuncu;
    void Start()
    {
        zombiAnim = this.GetComponent<Animator>();
        hedefOyuncu = GameObject.Find("Player");
        zombiNavMesh = this.GetComponent<NavMeshAgent>();

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
             mesafe = Vector3.Distance(this.transform.position, hedefOyuncu.transform.position);
            if(mesafe < KocvalamaMesafesi)
            {

                zombiNavMesh.isStopped = false;
                zombiNavMesh.SetDestination(hedefOyuncu.transform.position);
                // yürüme animasyonu
                zombiAnim.SetBool("yuruyor", true);
                
                this.transform.LookAt(hedefOyuncu.transform.position);
            }
            else
            {
                zombiNavMesh.isStopped = true;
                //durma animasyonu
                zombiAnim.SetBool("yuruyor", false);
                zombiAnim.SetBool("saldiriyor", false);
            }
            if(mesafe < saldirmaMesafesi)
            {
                this.transform.LookAt(hedefOyuncu.transform.position);
                zombiNavMesh.isStopped = true;
                // vurma animasyonu
                zombiAnim.SetBool("yuruyor", false);
                zombiAnim.SetBool("saldiriyor", true);
            }
          

        }

    }

    public void HasarVer()
    {
        hedefOyuncu.GetComponent<PlayerMovement>().HasarAl();
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
