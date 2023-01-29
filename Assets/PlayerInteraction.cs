using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;
    public Teleporting teleport;

    private bool isTrigger = false;

    public void Start()
    {
        interactionUI = GameObject.Find("InteractionUI");
    }

    public void Update()
    {
        interactionUI.SetActive(isTrigger);

        if (isTrigger == true)
            if (Input.GetKeyDown(KeyCode.E))
            {
                teleport.Interact();
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            isTrigger = true;
            Debug.Log("Ãæµ¹");      
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Portal")
        {
            isTrigger = false;
        }
    }

    //void InteractionRay()
    //{
    //    Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));       
    //    RaycastHit hit;

    //    bool hitSomething = false;

    //    if (Physics.Raycast(ray, out hit, 2000f))
    //    {
            
    //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
    //        IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            
    //        if (interactable != null)
    //        {
    //            hitSomething = true;
    //            interactionText.text = interactable.GetDescription();

    //            if (Input.GetKeyDown(KeyCode.E))
    //                interactable.Interact();
    //        }
    //    }
    //    else
    //        Debug.Log("hit Nothing");

    //    interactionUI.SetActive(hitSomething);
    //}
}
