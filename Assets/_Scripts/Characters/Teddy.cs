using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddy : CharacterBase
{
    [SerializeField] private float distanceToChildForSwapping = 1;

    [SerializeField] private Transform childTransform;
    [SerializeField] private SpriteRenderer spriteRend;
    [SerializeField] private Collider teddyCollider;

    private void Start()
    {
        spriteRend.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && active && Vector3.Distance(transform.position, childTransform.position) < distanceToChildForSwapping)
        {
            CharacterSwapper.Instance.SwapCharacter(CharacterSwapper.Character.Child);
        }

        if (!active)
        {
            transform.position = childTransform.position;
        }
    }

    public override void SwapTo()
    {
        movementScript.rb.velocity = Vector3.zero;
        transform.position = childTransform.position;
        spriteRend.enabled = true;
        teddyCollider.enabled = true;

        // Swap to Teddy
        CharacterSwapper.Instance.SwapWorld(CharacterSwapper.Character.Teddy);
        base.SwapTo();
    }

    public override void SwapOff()
    {
        spriteRend.enabled = false;
        teddyCollider.enabled = false;
        // Swap off Teddy
        base.SwapOff();
    }
}
