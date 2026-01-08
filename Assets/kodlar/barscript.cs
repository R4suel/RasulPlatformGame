using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class barscript : MonoBehaviour
{
     AudioSource ses;

    public Slider slider;
    public float deger;

    public GameObject obje1; //kuvve barının alt objelerini yok etmek için değişken tanımladık direk barı yok edince koda erişim kesilir tekrar aktif olmaz
    public GameObject obje2;

    private void Start()
    {
        ses = GetComponent<AudioSource>();
       
    }

    void Update()
    {

        deger = kontrol.zıplamakuvveti;

        obje1.SetActive(false);
        obje2.SetActive(false);
        slider.value = 0;
       

        if (Input.GetKey("space")&& kontrol.temasdurumu)
        {
            obje1.SetActive(true);
            obje2.SetActive(true);
            slider.value = deger;
           

        }



        if (Input.GetKeyDown("space") && kontrol.temasdurumu)
        {
            ses.Play();
            
            
        }
        if (Input.GetKeyUp("space"))    
        {
            ses.Stop();
           
        }
        if(deger >= 10)
        {
            ses.Stop();
        }





    }
}
