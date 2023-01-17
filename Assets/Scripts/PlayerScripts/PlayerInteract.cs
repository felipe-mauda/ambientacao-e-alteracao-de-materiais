using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;

    public bool InventoryOpen = false;
    public GameObject inventoryMenuUI;

    private PlayerLook mouse;
    private PlayerMotor playerMotor;

    void Start()
    {
        mouse= GetComponent<PlayerLook>();
        cam = GetComponent<PlayerLook>().cam;
        playerUI= GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
        playerMotor = GetComponent<PlayerMotor>(); 
    }

    void Update()
    {

        playerUI.UpdateText(string.Empty);
        //create a ray at the center of the camera, shootin outwards
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; //variable to store our collision information.
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.gameObject.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.onFoot.Interact.triggered)
                {
                    if(InventoryOpen)
                    {
                        CloseMenu();
                        
                    }
                    else
                    {
                        OpenMenu();
                        
                    }
                    //interactable.BaseInteract();
                }
            }
        }

    }

    public void CloseMenu()
    {
        inventoryMenuUI.SetActive(false);
        InventoryOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        mouse.xSensitivity= 30f;
        mouse.ySensitivity= 30f;
        playerMotor.speed = 5f;
    }

    public void OpenMenu()
    {
        inventoryMenuUI.SetActive(true);
        InventoryOpen = true;
        Cursor.lockState = CursorLockMode.None;
        mouse.xSensitivity = 0f;
        mouse.ySensitivity = 0f;
        playerMotor.speed= 0f;

    }
}
