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
