using System;
using UnityEditor;
using UnityEngine;

public interface IDamagable
{
    void TakeDamage(int damage);
}

public interface IDamager
{
    void DealDamage(IDamagable damagable);
}

public interface IStunner
{
    void Stun(IStunnable stunnable);
}

public interface IStunnable
{
    void GetStunned();
}

public interface IMovable
{
    void Move(Vector3 position);
}

public interface IMover
{
    void MoveObject(IMovable movable);
}

public interface IPushable
{
    Vector3 pushDirection { get; set; }
    void Push(Vector3 pushDirection);
}

public interface IPusher
{
    void PushEnemy(IPushable pushable);
}

public interface IDefeatable
{
    void Defeat();
}
