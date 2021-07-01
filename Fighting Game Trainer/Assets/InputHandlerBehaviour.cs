using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputHandlerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Text inputDisplay;
    [SerializeField]
    Text[] previousInputs = new Text[18];

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
        // TODO set up strict 60fps structure

        switch (currentInputProp.currentDirection)
        {
            case InputDirection.NEUTRAL:
                inputDisplay.text = "5";
                break;
            case InputDirection.RIGHT:
                inputDisplay.text = "6";
                break;
            case InputDirection.DOWNRIGHT:
                inputDisplay.text = "3";
                break;
            case InputDirection.DOWN:
                inputDisplay.text = "2";
                break;
            case InputDirection.DOWNLEFT:
                inputDisplay.text = "1";
                break;
            case InputDirection.LEFT:
                inputDisplay.text = "4";
                break;
            case InputDirection.UPLEFT:
                inputDisplay.text = "7";
                break;
            case InputDirection.UP:
                inputDisplay.text = "8";
                break;
            case InputDirection.UPRIGHT:
                inputDisplay.text = "9";
                break;
        }

        if (previousInputs[0].text != inputDisplay.text)
        {
            for (int i = previousInputs.Length - 1; i > 0; i--)
            {
                previousInputs[i].text = previousInputs[i - 1].text;
            }
            previousInputs[0].text = inputDisplay.text;
        }

        // Set up a new input state
        currentInputProp = SetUpNewInputFrame();
    }

    private InputProperties SetUpNewInputFrame()
    {
        var newInputs = new InputProperties();

        newInputs.currentDirection = currentDirection;
        newInputs.pressingA = currentAState;
        newInputs.pressingB = currentBState;
        newInputs.pressingC = currentCState;
        newInputs.pressingD = currentDState;

        return newInputs;
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        InputDirection[] possibleDirections;

        var inputMovement = value.ReadValue<Vector2>();

        if (inputMovement.x > 0)
        {
            possibleDirections = rightDirections;
        }
        else if (inputMovement.x < 0)
        {
            possibleDirections = leftDirections;
        }
        else
        {
            possibleDirections = neutralDirections;
        }

        if (inputMovement.y > 0)
        {
            currentDirection = possibleDirections[0];
        }
        else if (inputMovement.y < 0)
        {
            currentDirection = possibleDirections[2];
        }
        else
        {
            currentDirection = possibleDirections[1];
        }

        currentInputProp.currentDirection = currentDirection;
    }
}
