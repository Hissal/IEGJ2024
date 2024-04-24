using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : CharacterBase
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && active)
        {
            CharacterSwapper.Instance.SwapCharacter(CharacterSwapper.Character.Teddy);
        }
    }

    public override void SwapTo()
    {
        // Swap to Child
        CharacterSwapper.Instance.SwapWorld(CharacterSwapper.Character.Child);
        base.SwapTo();
    }

    public override void SwapOff()
    {
        movementScript.rb.velocity = Vector3.zero;
        // Swap off Child
        base.SwapOff();
    }
}
