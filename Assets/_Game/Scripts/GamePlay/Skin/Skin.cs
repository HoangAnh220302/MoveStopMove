using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : GameUnit
{
    [SerializeField] Transform head;
    [SerializeField] Transform rightHand;
    [SerializeField] Transform leftHand;
    [SerializeField] Renderer pant;

    [SerializeField] bool isCanChange = false;
    [SerializeField] Animator animator;

    private Weapon currentWeapon;
    private Accessory currentAccessory;
    private Hat currentHat;

    public Animator Animator => animator;
    public Weapon Weapon => currentWeapon;

    public void ChangeWeapon(WeaponType weaponType)
    {
        currentWeapon = SimplePool.Spawn<Weapon>((PoolType)weaponType, rightHand);
    }
    public void OnDespawn()
    {

    }
}
