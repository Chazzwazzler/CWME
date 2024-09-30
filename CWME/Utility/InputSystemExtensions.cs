#if ENABLE_INPUT_SYSTEM

using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CWUtils{
    public static class InputSystemExtensions
    {
        /// <summary>
        /// Add a new custom binding to InputActions for the new input system.
        /// </summary>
        public static InputAction AddCustomBinding(InputActions inputActions, int actionMap, string name, InputActionType inputType, string keycodePath){
            inputActions.Disable();
            InputAction action = inputActions.asset.actionMaps[actionMap].AddAction(name, inputType);
            action.AddBinding(keycodePath);
            InputController.inputActions.Enable();
            return action;
        }
    }
}

#endif