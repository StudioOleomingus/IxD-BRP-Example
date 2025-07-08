using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string objectName = "";
    public bool isInventoryItem = false;
    public string itemNeededToInteract = "";
    private Outline outlineComp;

    public virtual void Start()
    {
        outlineComp = GetComponent<Outline>();
    }

    public virtual void Hovering(Vector3 rayHitPoint)
    {
        if (outlineComp != null)
            outlineComp.enabled = true;
    }

    public virtual void ResetHovering(Vector3 rayHitPoint)
    {
        if (outlineComp != null)
            outlineComp.enabled = false;
    }
}
