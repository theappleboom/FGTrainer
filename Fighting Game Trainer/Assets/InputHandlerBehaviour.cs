using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputHandlerBehaviour : MonoBehaviour
{
    [SerializeField]
    private InputActions actions;
    [SerializeField]
    private Text inputDisplay;

    private InputDirection[] rightDirections = { InputDirection.UPRIGHT, InputDirection.RIGHT, InputDirection.DOWNRIGHT };
    private InputDirection[] neutralDirections = { InputDirection.UP, InputDirection.NEUTRAL, InputDirection.DOWN };
    private InputDirection[] leftDirections = { InputDirection.UPLEFT, InputDirection.LEFT, InputDirection.DOWNLEFT };

    private InputProperties currentInputProp;
    private InputDirection currentDirection;
    private bool currentAState;
    private bool currentBState;
    private bool currentCState;
    private bool currentDState;


    private void Update()
    {
        // clean out all current input states
        currentInputProp = new InputProperties();
        currentDirection = InputDirection.NEUTRAL;
        currentAState = false;
        currentBState = false;
        currentCState = false;
        currentDState = false;
    }

    private void FindDirection()
    {

    }
}
