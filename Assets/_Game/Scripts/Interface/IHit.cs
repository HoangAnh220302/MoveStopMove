using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IHit
{
    void OnHit(UnityAction hitAction);
}
