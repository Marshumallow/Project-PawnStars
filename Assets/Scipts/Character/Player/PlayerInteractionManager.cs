using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] public PlayerInputManager playerInputManager;

    [SerializeField] public Camera playerView;
    [SerializeField] public RaycastHit hitInfo;
    [SerializeField] public Interactable currentInteractable;
    [SerializeField] public TMP_Text interactText;

    [SerializeField] public float interactRange { get; private set; } = 2f;

    private void Awake()
    {
        
    }

    private void Update()
    {
        CheckGameObject();
    }

    public void SelectGameObject()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    public void EnableText(string text)
    {
        interactText.text = text + " (E)";
        interactText.gameObject.SetActive(true);
    }

    public void DisableText()
    {
        interactText.gameObject.SetActive(false);
    }

    private void CheckGameObject()
    {
        Ray ray = new Ray(playerView.transform.position, playerView.transform.forward);
        if (Physics.Raycast(ray, out hitInfo, interactRange))
        {
            if (hitInfo.collider.tag == "Item" || hitInfo.collider.tag == "Tool")
            {
                Interactable newInteractable = hitInfo.collider.GetComponent<Interactable>();

                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }
                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else
                {
                    DisableCurrentInteractable();
                }
            }
            else
            {
                DisableCurrentInteractable();
            }
        }
        else
        {
            DisableCurrentInteractable();
        }
    }

    private void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        EnableText(currentInteractable.message);
    }

    private void DisableCurrentInteractable()
    {
        DisableText();
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
