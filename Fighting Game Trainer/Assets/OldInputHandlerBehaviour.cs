using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldInputHandlerBehaviour : MonoBehaviour
{
    public enum InputDirection
    {
        NEUTRAL,
        RIGHT,
        DOWNRIGHT,
        DOWN,
        DOWNLEFT,
        LEFT,
        UPLEFT,
        UP,
        UPRIGHT
    }

    public struct InputProperties
    {
        public InputDirection currentDirection;
        public bool pressingA;
        public bool pressingB;
        public bool pressingC;
        public bool pressingD;
    }

    private InputDirection[] rightDirections = { InputDirection.UPRIGHT, InputDirection.RIGHT, InputDirection.DOWNRIGHT };
    private InputDirection[] neutralDirections = { InputDirection.UP, InputDirection.NEUTRAL, InputDirection.DOWN };
    private InputDirection[] leftDirections = { InputDirection.UPLEFT, InputDirection.LEFT, InputDirection.DOWNLEFT };

    private InputProperties inputProp;

    [SerializeField]
    private Text inputDisplay;

    // Update is called once per frame
    void Update()
    {
        // TODO set up strict 60fps structure
        inputProp = new InputProperties();
        inputProp.currentDirection = FindDirection();

        switch(inputProp.currentDirection)
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
    }

    private InputDirection FindDirection()
    {
        InputDirection[] possibleDirections;
        InputDirection direction;
        var hAxis = Input.GetAxis("Horizontal");
        var vAxis = Input.GetAxis("Vertical");

        if(hAxis > 0)
        {
            possibleDirections = rightDirections;
        } else if (hAxis < 0)
        {
            possibleDirections = leftDirections;
        } else
        {
            possibleDirections = neutralDirections;
        }

        if(vAxis > 0)
        {
            direction = possibleDirections[0];
        } else if (vAxis < 0)
        {
            direction = possibleDirections[2];
        } else
        {
            direction = possibleDirections[1];
        }

        return direction;
    }
}
