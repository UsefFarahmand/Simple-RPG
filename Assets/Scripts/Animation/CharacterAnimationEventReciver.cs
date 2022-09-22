using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEventReciver : AnimationEventReciver
{
    CharacterCombat combat;

    private void Start()
    {
        combat = transform.root.GetComponentInChildren<CharacterCombat>();
    }

    public void AttackHit()
    {
        combat.AttackHit_AnimationEvent();
    }
}