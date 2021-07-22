using System;
using QuestTales.Core.Abilities;
using UnityEngine;

namespace QuestTales.Core.Abilities.OrcGrunt
{
    public class Bash : Ability
    {
        public override ControllerType controllerType => ControllerType.AI;

        public override IdType abilityIdType => IdType.Bash;

        public override RangeType abilityRange => RangeType.Melee;

        public override ColliderType abilityColliderType => ColliderType.Fan;

        public override AnimationType animationType => AnimationType.Swing;

        public override ColliderData colliderData => Resources.Load<ColliderData>("Data/Ability/Orc/BashCollider");

        public override AbilityStatsData abilityData => Resources.Load<AbilityStatsData>("Data/Ability/Orc/BashStatsData");

        public override void ProcessAbility()
        {
            Debug.Log("Attack!!!!");
        }
    }
}
