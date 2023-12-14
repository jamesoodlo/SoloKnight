using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public PowerSlash powerSlash;

    public void SlashProjectile()
    {
        powerSlash.Shoot();
    }
}
