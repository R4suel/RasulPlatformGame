using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class kontrol : MonoBehaviour
{

    AudioSource ses;


    Animator animator;

    public float harekethızı=0;
    public float yatay = 0;
    public static bool temasdurumu = true;
    private Rigidbody2D rb;
    public LayerMask groundMask;
    public int sayac = 1;
    public bool zıplamayetenegi = true;
    public static float zıplamakuvveti = 0.0f;

    public PhysicsMaterial2D bouncemat, normalMat;


    public Text oyunbittimetni;

    float anamenuyedonzaman = 0;



    Vector3 kamerailkpos;
    Vector3 kamerasonpos;
    GameObject kamera;
    void Start()
    {
        ses = GetComponent<AudioSource>();

        rb = gameObject.GetComponent<Rigidbody2D>();

        kamera = GameObject.FindGameObjectWithTag("MainCamera");
        kamerailkpos = kamera.transform.position - transform.position;

        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
      
        yatay = Input.GetAxis("Horizontal");
       

        if (zıplamakuvveti == 0.0f && temasdurumu)
        {
            rb.linearVelocity = new Vector2(yatay * harekethızı, rb.linearVelocity.y);
        }



        temasdurumu = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.9f), new Vector2(0.9f, 0.4f), 0f, groundMask);

        if (zıplamakuvveti > 0)
        {
            rb.sharedMaterial = bouncemat;
        }
        else
        {
            rb.sharedMaterial = normalMat;
        }




        if (Input.GetKey("space") && temasdurumu && zıplamayetenegi)//basılı tutarken
        {

            zıplamakuvveti += 15 * Time.deltaTime;
            animator.SetTrigger("kuvvet");

        //    sesler[1].Play();

        }
        if(!(temasdurumu &&zıplamayetenegi))
        {
            zıplamakuvveti = 0;
        }

        //if (Input.GetKeyDown("space") && temasdurumu && zıplamayetenegi)//basdığı an
        //{
        //    zıplamakuvveti = 0;
        //    zıplamayetenegi = true;
        //}



        //KUVVET SINIRINA GELİNCE OTOMATİK ZIPLAMA

        //if (zıplamakuvveti >= 10f && temasdurumu && transform.localScale.x == 1) // kuvvet belli bir sınır gecince oyomatik zıplama
        //{
        //    float tempx = yatay * harekethızı;
        //    float tempy = zıplamakuvveti*5;
        //    rb.velocity = new Vector2(10, tempy);
        //    //Invoke("ResetJump", 0.2f);
        //    zıplamayetenegi = true;
        //    animator.SetTrigger("jump");
           
        //    ses.Play();
        //}
        //if(zıplamakuvveti >= 10f && temasdurumu && transform.localScale.x == -1) // kuvvet belli bir sınır gecince oyomatik zıplama
        //{
        //    float tempx = yatay * harekethızı;
        //    float tempy = zıplamakuvveti * 5;
        //    rb.velocity = new Vector2(-10, tempy);
        //    //Invoke("ResetJump", 0.2f);
        //    zıplamayetenegi = true;
        //    animator.SetTrigger("jump");


        //    ses.Play();
        //}
       
        if(zıplamakuvveti >=10)
        {
            zıplamakuvveti = 10;
        }



        //if (Input.GetKeyUp("space"))//bırakırken
        //{
        //    float tempy = zıplamakuvveti * 5;
        //    rb.velocity = new Vector2(10, tempy);
        //    //if (temasdurumu)
        //    //{

        //    //    //rb.AddForce(new Vector2(30, 30), ForceMode2D.Impulse);

        //    //    //rb.AddForce((Vector2.up + Vector2.right) * zıplamakuvveti, (ForceMode2D)ForceMode.Impulse);

        //    //    // rb.AddForce((Vector2.up + Vector2.right) * zıplamakuvveti, ForceMode2D.Impulse);

        //    //    // rb.velocity = zıplamakuvveti * Vector2.one;


        //    //    //rb.AddForce((Vector2.up * Vector2.right) * zıplamakuvveti, (ForceMode2D)ForceMode.Impulse);
        //    //    //rb.AddForce(Vector2.right, ForceMode2D.Impulse);

        //    //    //Debug.DrawLine(transform.position, transform.position , Color.red);


        //    //    //rb.AddForce(Vector2.right * zıplamakuvveti, ForceMode2D.Impulse);
        //    //    //rb.AddForce(Vector2.up * zıplamakuvveti, ForceMode2D.Impulse);

        //    //    // rb.AddForce(Vector2.up*zıplamakuvveti + Vector2.right * zıplamakuvveti, ForceMode2D.Impulse);

        //    //    // rb.AddForce (zıplamakuvveti * Vector2.one,ForceMode2D.Impulse); 

        //    //    //rb.velocity = 30 * Vector2.right + 5* Vector2.up; 

        //    //    //rb.velocity += (Vector2.up * rb.velocity.x)*zıplamakuvveti;

        //    //    //rb.AddForce(transform.up * 800f);


        //    //    zıplamakuvveti = 0;

        //    //}
        //    zıplamayetenegi = true;
        //}





        if (Input.GetKeyUp("space") && transform.localScale.x == 1 && temasdurumu )
        {
            float tempy = zıplamakuvveti * 5;
            rb.linearVelocity = new Vector2(10, tempy);
            zıplamayetenegi = true;
            animator.SetTrigger("jump");

            ses.Play();
        }

        if (Input.GetKeyUp("space") && transform.localScale.x == -1 && temasdurumu)
        {

            float tempy = zıplamakuvveti * 5;
            rb.linearVelocity = new Vector2(-10, tempy);
            zıplamayetenegi = true;
            animator.SetTrigger("jump");

            ses.Play();
        }



    }

    private Vector3 Vector2(float v1, float v2, float z)
    {
        throw new NotImplementedException();
    }

    //void ResetJump()
    //{
    //    zıplamayetenegi = false;
    //    zıplamakuvveti = 0;
    //}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.9f), new Vector3(1.5f, 0.3f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.tag == "yanduvar")
        {
            rb.AddForce(transform.up * 800f);

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag == "bitis")
        {
            oyunbittimetni.text = "Tebrikler, başardın !";
            Time.timeScale = 0.5f;
        }
       

    }





    private void FixedUpdate()
    {
        animasyon();

        if (Time.timeScale == 0.5f)
        {
            anamenuyedonzaman += Time.deltaTime;
            if (anamenuyedonzaman > 1)
            {
                SceneManager.LoadScene("ana menu");
                Time.timeScale = 0;
            }
        }

    }

    void animasyon()
    {
        if(yatay == 0)//hareket etmiyorsa
        {
            //anim
            animator.SetBool("run", false);
        }


        else if(yatay > 0)//sağa 
        {
           //anim

            transform.localScale = new Vector2(1,1);
            animator.SetBool("run",true);
        }
        else if(yatay < 0)//sola
        {

            //anim

            transform.localScale = new Vector2(-1, 1);
            animator.SetBool("run", true);
        }

       

    }

    ////////////////////////////////////////////////////////////////////////
    ///
    void LateUpdate()
    {
        kamerakontrol();
    }
    void kamerakontrol()
    {
        kamerasonpos = kamerailkpos + transform.position;
        kamera.transform.position = Vector3.Lerp(kamera.transform.position, kamerasonpos, 1f);
    }
    ////////////////////////////////////////////////////////////////////////////////


}
