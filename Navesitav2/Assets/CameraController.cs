using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject CameraAnims;
    public Animator anims;
    public GameObject Menu;
    public GameObject AspectosUI;
    public GameObject PlayerUI;
    // Start is called before the first frame update
    void Start()
    {
        MenuMain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Aspectos()
    {
        anims.Play("AspectosTranslate");
        Menu.SetActive(false);
        AspectosUI.SetActive(true);
    }
    public void MenuMain()
    {
        anims.Play("MenuTranslate");
        Menu.SetActive(true);
        AspectosUI.SetActive(false);
    }
    public void Jugar()
    {
        anims.Play("PlayerTranslate");
        Menu.SetActive(false);
        
        AspectosUI.SetActive(false);
       
    }
}
