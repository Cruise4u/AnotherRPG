using CustomPrimitiveColliders;
using System;
using UnityEngine;

public static class AbilityColliderConfigurator
{
    public static void SetCollider(GameObject weapon,Ability ability)
    {
        RemoveUnusedColliders(weapon);
        if (ability.abilityRange == RangeType.Melee)
        {
            switch (ability.abilityColliderType)
            {
                case ColliderType.Fan:
                    weapon.AddComponent<FanCollider2D>();
                    var fan = weapon.GetComponent<FanCollider2D>();
                    ConfigureCustomCollider(fan, ability.colliderData);
                    break;
            }
        }
    }

    public static void ConfigureNormalCollider(Collider2D collider, ColliderData colliderData)
    {
        if (collider.GetType() == typeof(CircleCollider2D))
        {
            var circleCollider = (CircleCollider2D)collider;
            circleCollider.radius = colliderData.radius;
            circleCollider.offset = colliderData.offset;
        }
        else if (collider.GetType() == typeof(BoxCollider2D))
        {
            var boxCollider = (BoxCollider2D)collider;
            boxCollider.size = colliderData.size;
            boxCollider.offset = colliderData.offset;
        }
    }

    public static void ConfigureCustomCollider(BaseCustomCollider collider, ColliderData colliderData)
    {
        if (collider.GetType() == typeof(FanCollider2D))
        {
            var fanCollider = (FanCollider2D)collider;
            fanCollider.angle = colliderData.angle;
            fanCollider.radius = colliderData.radius;
            fanCollider.vertices = colliderData.vertices;
            fanCollider.ReCreate(fanCollider.radius, fanCollider.angle, fanCollider.vertices);
        }
        else if (collider.GetType() == typeof(TriangleCollider2D))
        {
            var triangleCollider = (TriangleCollider2D)collider;
            triangleCollider.length = colliderData.length;
            triangleCollider.radius = colliderData.radius;
            triangleCollider.openAngle = colliderData.angle;
            triangleCollider.ReCreate(triangleCollider.radius, triangleCollider.length, triangleCollider.IsOpenAngleUsed, triangleCollider.openAngle);
        }
    }

    public static void RemoveUnusedColliders(GameObject weapon)
    {
        if (weapon.GetComponent<Collider2D>())
        {
            UnityEngine.Object.Destroy(weapon.GetComponent<Collider2D>());
        }
        else if (weapon.GetComponent<BaseCustomCollider>())
        {
            UnityEngine.Object.Destroy(weapon.GetComponent<Collider2D>());
        }
    }

    public static void DisableCollider(GameObject weapon)
    {
        if (weapon.GetComponent<Collider2D>())
        {
            weapon.GetComponent<Collider2D>().enabled = false;
        }
        else if (weapon.GetComponent<BaseCustomCollider>())
        {
            weapon.GetComponent<BaseCustomCollider>().enabled = false;
        }
    }

    public static void EnableCollider(GameObject weapon)
    {
        if (weapon.GetComponent<Collider2D>())
        {
            weapon.GetComponent<Collider2D>().enabled = true;
        }
        else if (weapon.GetComponent<BaseCustomCollider>())
        {
            weapon.GetComponent<BaseCustomCollider>().enabled = true;
        }
    }
}
