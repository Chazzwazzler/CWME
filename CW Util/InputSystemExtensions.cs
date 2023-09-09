#if ENABLE_INPUT_SYSTEM

using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CWUtils{
    public static class InputSystemExtensions
    {
        /// <summary>
        /// Checks if the button is being pressed at the present moment.
        /// </summary>
        public static bool IsPressed(this InputAction inputAction)
        {
            return inputAction.ReadValue<float>() > 0f;
        }

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