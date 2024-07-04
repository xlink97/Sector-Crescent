using Content.Server.DeviceLinking.Components;

namespace Content.Server.NPC.HTN.Preconditions
{
    /// <summary>
    /// Returns true if the entity has a SignalControl component in On state
    /// </summary>
    public sealed partial class SignalControlPrecondition : HTNPrecondition
    {
        [Dependency] private readonly IEntityManager _entManager = default!;

        public override bool IsMet(NPCBlackboard blackboard)
        {
            if (blackboard.TryGetValue<EntityUid>(NPCBlackboard.Owner, out var owner, _entManager))
            {
                if (_entManager.TryGetComponent<SignalControlComponent>(owner, out var control))
                {
                    return control.IsOn;
                }
            }

            return false;
        }
    }
}
