using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState {
    void StateUpdate(PlayerStateManager stateManager);
    IPlayerState CheckTransition(PlayerStateManager stateManager);
    void AnimatorUpdate(PlayerStateManager stateManager);
    void StateEntered(PlayerStateManager stateManager);
}
