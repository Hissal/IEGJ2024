using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddy : CharacterBase
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && active)
        {
            CharacterSwapper.Instance.SwapCharacter(CharacterSwapper.Character.Child);
        }
    }

    public override void SwapTo()
    {
        // Swap to Teddy
        base.SwapTo();
    }

    public override void SwapOff()
    {
        // Swap off Teddy
        base.SwapOff();
    }
}
