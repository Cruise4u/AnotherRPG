﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestTales.Core.Abilities;


namespace QuestTales.Core.Abilities.Paladin
{
    public class HolyStrike : Ability,IDamager
    {
        public override ControllerType controllerType => ControllerType.Player;
        public override IdType abilityIdType => IdType.HolyStrike;
        public override RangeType abilityRange => RangeType.Melee;
        public override ColliderType abilityColliderType => ColliderType.Fan;
        public override AnimationType animationType => AnimationType.Circular;
        public override ColliderData colliderData => Resources.Load<ColliderData>("Data/Ability/Paladin/HolyStrikeCollider");
        public override AbilityStatsData abilityData => Resources.Load<AbilityStatsData>("Data/Ability/Paladin/HolyStrikeStatsData");

        public IEnumerator CoroutineHolyStrike(GameObject weapon, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            AbilityColliderConfigurator.DisableCollider(weapon);
        }

        public void DealDamage(IDamagable damagable)
        {
            if(damagable != null)
            {
                damagable.TakeDamage(abilityData.power);
            }
            else
            {
                Debug.Log("It's freaking nullllabllle!");
            }
        }

        public override void ProcessAbility(List<GameObject> targets)
        {
            if(targets != null && targets.Count > 0)
            {
                foreach (GameObject target in targets)
                {
                    DealDamage(target.transform.parent.GetComponent<CombatController>());
                }
            }
        }
    }

}
