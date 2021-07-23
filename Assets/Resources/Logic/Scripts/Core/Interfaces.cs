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

public interface IMovable
{
    void Move(Vector3 position);
}

public interface IMover
{
    void MoveObject(IMovable movable);
}

public interface ICastable
{

}

public interface ICaster
{

}

public interface IPushable
{
    void Push(Vector3 direction);
}

public interface IPusher
{
    Vector3 pushDirection { get; set; }
    void PushEnemy(IPushable pushable);
}

public interface IDefeatable
{
    void Defeat();
}
