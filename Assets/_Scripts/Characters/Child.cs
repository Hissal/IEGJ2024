using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : CharacterBase
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && active)
        {
            CharacterSwapper.Instance.SwapCharacter(CharacterSwapper.Character.Teddy);
        }
    }

    public override void SwapTo()
    {
        // Swap to Child
        base.SwapTo();
    }

    public override void SwapOff()
    {
        // Swap off Child
        base.SwapOff();
    }
}
