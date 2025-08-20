using UnityEngine;
using System.Collections;

public class AirshipScriptingExample : MonoBehaviour 
{

	void Update () 
	{
		// Set propellor RPM
		AirshipController.RPM=Mathf.PingPong(Time.time*50.0f, 300.0f);

		// Set Rudder Angle
		AirshipController.RudderAngle=Mathf.PingPong(Time.time*25.0f, 70.0f)-35.0f;

		// Set Elevator Angle
		AirshipController.ElevatorAngle=Mathf.PingPong(Time.time*15.0f, 70.0f)-35.0f;
	}

	public Hessburg.AirshipController AirshipController;
}
