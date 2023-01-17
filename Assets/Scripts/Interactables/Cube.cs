using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Interactable
{

    private Rigidbody selfRigidbody;

    public Material Red;
    public Material Green;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        selfRigidbody= GetComponent<Rigidbody>();  

        rend = GetComponent<Renderer>();
        rend.sharedMaterial = Red;
    }

    /*private void FixedUpdate()
    {
        if (canJump)
        {
            canJump= false;
            selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
        }
    }*/

    // Update is called once per frame
    void Update()
    {

    }

    //This function is where we will design our interaction using code.
    protected override void Interact()
    {
        //ChangeTexture();
        // Chamar a void "ChangeTexture"
    }

  //fazer uma void com nome de "ChangeTexture" com a função de mudar a textura do objeto
    public void ChangeTextureGreen()
    {
        rend.sharedMaterial = Green;
    }

    public void ChangeTextureRed()
    {
        rend.sharedMaterial = Red;
    }

}
