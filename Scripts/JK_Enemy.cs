using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JK_Enemy : MonoBehaviour
{
    public static JK_Enemy instance;
    public int maxHP;
    public int hp;

    Camera cam;
    Rigidbody rg;
    CapsuleCollider cc;
    public Slider sliderHP;
    private void Awake()
    {
        instance = this;
    }
   
    
    void Start()
    {
        //rg.GetComponent<Rigidbody>();
        cam = Camera.main;
        CapsuleCollider cc = GetComponent<CapsuleCollider>();
        maxHP = 100;
        hp = maxHP;
        sliderHP.maxValue = maxHP;
        sliderHP.transform.position = transform.position;
       
    }
    private void Update()
    {
        // Ã¼·Â¹Ù
        sliderHP.transform.position = cam.WorldToScreenPoint(transform.position + new Vector3(0, 1.5f, 0));
    }
    public void GotDamaged()
    {
        sliderHP.value = hp;
        print(hp);
    }

}
