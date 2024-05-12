using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : GameUnit
{
    public const float TIME_WEAPON_RELOAD = 0.5f;

    [SerializeField] GameObject child;
    [SerializeField] BulletType bulletType;

    public bool isCanAttack => child.activeSelf;
}
