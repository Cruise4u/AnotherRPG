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
    public float arcAngle;
    public float range;

    public float aimAngle;

    private BaseStats baseStats;
    private UnitMovement unitMovement;
    private UnitAim unitAim;

    public void MoveToDirection(UnitCombat unitCombat)
    {
        if (unitCombat.isHit != true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                unitMovement.Move(new Vector3(0, 1, 0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                unitMovement.Move(new Vector3(0, -1, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                unitMovement.Move(new Vector3(1, 0, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
                unitMovement.Move(new Vector3(-1, 0, 0));
            }
        }
    }

    public void ReadKeyboardInput()
    {
        if (Input.anyKey)
        {
            MoveToDirection(unitCombat);
        }
    }

    public void ReadMouseInput()
    {
        unitCombat.ReduceCooldown(0.85f);
        if (Input.GetMouseButtonDown(0))
        {
            if(unitCombat.attackCooldown < 0.1f)
            {
                //unitCombat.MeleeSwingTweening(arcAngle,playerWeaponGO,unitAim,this);
                //unitCombat.StabAnimation(transform,playerWeapon, range);
                StartCoroutine(unitCombat.SwingTweenAnimationCoroutine(transform, playerWeapon,unitAim.GetAngleFromRotation()));
                //StartCoroutine(unitCombat.StabTweenAnimationCoroutine(transform, playerWeapon, range));
            }
        }
    }

    public void Start()
    {
        baseStats = new BaseStats(baseStatsData);
        unitMovement = new UnitMovement(transform,rb,baseStats.speed);
        unitAim = new UnitAim(transform, playerAimGO,playerWeapon);
        unitCombat = new UnitCombat();
    }

    // Update is called once per frame
    public void Update()
    {
        ReadKeyboardInput();
        ReadMouseInput();
        unitAim.AimWeaponAtMouseIndicator(playerCamera, weaponSprite);
    }

}
