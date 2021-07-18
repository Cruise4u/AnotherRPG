using System;
using UnityEngine;
using QuestTales.Core.Abilities;
using System.Collections;

namespace QuestTales.Core.Abilities.Paladin
{
    public class HolyStrike : Ability
    {
        public override IdType abilityName => IdType.HolyStrike;

        public override RangeType abilityRange => RangeType.Melee;

        public override ColliderType abilityColliderType => ColliderType.Fan;

        public override ColliderData colliderData => Resources.Load<ColliderData>("Data/Ability/Paladin/HolyStrikeCollider");

        public override AnimationType animationType => AnimationType.Swing;

        public override void ProcessAbility()
        {
            Debug.Log("Do Holy Strike Cool Stuff!!");
        }

        public IEnumerator CoroutineHolyStrike(GameObject weapon, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            AbilityColliderConfigurator.DisableCollider(weapon);
        }
    }


}
