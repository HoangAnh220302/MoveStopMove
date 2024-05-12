using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;

public class Character : AbCharacter, IHit
{
    public const float THROW_DELAY_TIME = 0.4f;
    public const float ATTACK_RANGE = 5.0f;
    public const float MAX_SIZE = 4.0f;
    public const float MIN_SIZE = 1.0f;
    public Skin currentSkin;
    public bool IsCanAttack => currentSkin.Weapon.isCanAttack;
    public int Score => score;
    public float Size => size;
    public bool IsDead { get; protected set; }

    private string animationName;
    private List<Character> targetList = new List<Character>();
    private Character target;
    private Vector3 targetPoint;
    private int score;


    protected float size = 1f;

    public override void OnInit()
    {
        IsDead = false;
        score = 0;

        WearClothes();
        ClearTarget();
    }
    public void WearClothes()
    {

    }
    public void TakeOffClothes()
    {
        currentSkin?.OnDespawn();
    }
    public void AnimationChange(string animationName)
    {
        if(this.animationName != animationName)
        {
            currentSkin.Animator.ResetTrigger(this.animationName);
            this.animationName = animationName;
            currentSkin.Animator.SetTrigger(this.animationName);
        }
    }
    public Character GetTargetInRange()
    {
        Character target = null;
        float distance = float.PositiveInfinity;

        for (int i = 0; i < targetList.Count; i++)
        {
            if (targetList[i] != null && targetList[i] != this && !targetList[i].IsDead && Vector3.Distance(TF.position, targetList[i].TF.position) <= ATTACK_RANGE * size + targetList[i].size)
            {
                float dis = Vector3.Distance(TF.position, targetList[i].TF.position);

                if (dis < distance)
                {
                    distance = dis;
                    target = targetList[i];
                }
            }
        }

        return target;
    }
    public override void OnAttack()
    {
        target = GetTargetInRange();

        if(IsCanAttack && target != null && !target.IsDead)
        {
            targetPoint = target.TF.position;
            TF.LookAt(targetPoint + (TF.position.y - targetPoint.y) * Vector3.up);
            AnimationChange(Constant.ANIM_ATTACK);
        }
    }
    public override void OnDeath()
    {
        AnimationChange(Constant.ANIM_DIE);
        //LevelManager.Ins.CharacterDeath(this);
    }
    public override void OnDespawn()
    {

    }
    public override void OnMoveStop()
    {
        
    }
    public void OnHit(UnityAction hitAction)
    {
        if(!IsDead)
        {
            IsDead = true;
            hitAction?.Invoke();
            OnDeath();
        }
    }
    public void ChangeWeapon(WeaponType weaponType)
    {

    }
    public void ChangeSkin(SkinType skinType)
    {

    }
    public void ChangeHat(HatType hatType)
    {

    }
    public void ChangeAccessory(AccessoryType accessoryType)
    {

    }
    public void ChangePant(PantType pantType)
    {

    }

    public void ClearTarget()
    {
        targetList.Clear();
    }
}
