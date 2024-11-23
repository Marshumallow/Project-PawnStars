using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] public PlayerInteractionManager playerInteractionManager;
    [SerializeField] public Outline outline;
    [SerializeField] public GameObject HoldPos;

    [SerializeField] public Vector3 resetPos;
    [SerializeField] public Vector3 curretPosition;

    [SerializeField] public bool isHeld;

    [field:SerializeField] public string message;

    public UnityEvent OnInteraction;
    public UnityEvent OnReset;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
        resetPos = this.gameObject.transform.position;
    }

    private void Update()
    {
        if (isHeld == true)
        {
            this.gameObject.transform.position = HoldPos.transform.position;
        }
        else
        {
            this.gameObject.transform.position = resetPos;
        }
    }

    public void Interact()
    {
        OnInteraction.Invoke();
    }

    public void ResetInteract()
    {
        OnReset.Invoke();
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }

    public void HoldTool()
    {
        isHeld = true;
    }

    public void ResetTool()
    {
        isHeld = false;
    }
}
