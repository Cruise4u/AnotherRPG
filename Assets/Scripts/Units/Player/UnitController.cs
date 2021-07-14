using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public Rigidbody2D rb;

    public SpriteRenderer weaponSprite;
    public Camera playerCamera;
    public BaseStatsData baseStatsData;
    public GameObject playerAimGO;
    public GameObject playerWeapon;

    public bool isAttacking;
    public UnitCombat unitCombat;
    public float range;

    public float aimAngle;

    private BaseStats baseStats;
    private UnitMovement unitMovement;
    private AbilityAim unitAim;

    public void KeyboardInputCallback()
    {
        if (Input.anyKey)
        {
            unitMovement.MoveToDirection();
        }
    }

    public void MouseInputCallback()
    {
        unitCombat.ReduceCooldown(0.85f);
        if (Input.GetMouseButtonDown(0))
        {
            if(unitCombat.attackCooldown < 0.1f)
            {

            }
        }
    }

    public void AimInputCallback()
    {
        unitAim.SetWeaponAimAtMouse(playerCamera, weaponSprite);
    }

    public void Start()
    {
        baseStats = new BaseStats(baseStatsData);
        unitMovement = new UnitMovement(transform,rb,baseStats.speed);
        unitAim = new AbilityAim(transform, playerAimGO,playerWeapon);
        unitCombat = new UnitCombat();
    }

    // Update is called once per frame

    public void Update()
    {
        KeyboardInputCallback();
        MouseInputCallback();
        AimInputCallback();

    }

}
