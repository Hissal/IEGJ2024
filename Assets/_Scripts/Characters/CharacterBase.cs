using System.Collections;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public bool active { get; protected set; }
    [SerializeField] protected ChildMovement movementScript;

    private IEnumerator SetActiveDelayed()
    {
        yield return null;
        active = true;
        movementScript.active = true;
    }

    public virtual void SwapTo() { StartCoroutine(SetActiveDelayed()); }
    public virtual void SwapOff() { active = false; movementScript.active = false; }
}
