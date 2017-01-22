/**
 * SerialCommUnity (Serial Communication for Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;

/**
 * Controls the Arcade button color
 */
public class ButtonColor : MonoBehaviour
{
    public SerialController serialController;

    // Initialization
    public void Start()
    {
        // Might need to hard code in the PORT
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    // Slow strobes button
    public void modeAttract() 
    {
	serialController.SendSerialMessage("A");
    }

    // Button on solid
    public void modeOn()
    {
	serialController.SendSerialMessage("1");
    }

    // Button light off
    public void modeOff()
    {
	serialController.SendSerialMessage("0");
    }

    // Button quick fades out and flahshes briefly
    public void modeDie()
    {
	serialController.SendSerialMessage("X");
    }

    // Button flashes fast several times
    public void modeWin()
    {
	serialController.SendSerialMessage("W");
    }

    // Executed each frame
    // We are not expecting to recieve any messages but serial connection established
    public void Update()
    {
        //---------------------------------------------------------------------
        // Receive data
        //---------------------------------------------------------------------

        string message = serialController.ReadSerialMessage();

        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            Debug.Log("Message arrived: " + message);
    }
}

