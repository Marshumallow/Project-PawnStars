using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] public Outline outline;
    [SerializeField] public Camera playerView;

    [field:SerializeField] public string message;

    public UnityEvent OnInteraction;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    public void Interact()
    {
        OnInteraction.Invoke();
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

    }
}
