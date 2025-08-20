using UnityEngine;
using System.Collections;

namespace Hessburg
{

	public class AirshipController : MonoBehaviour 
	{

		void Start () 
		{
			if(Exhaust != null)
			{
				if(Exhaust.Length==4)
				{
					if(Exhaust[0] != null && Exhaust[1] != null && Exhaust[2] != null && Exhaust[3] != null)
					{
						ExhaustSet=true;
					}
					else
					{
						Debug.Log("Please attach all four Exhaust particle systems in the inspector");
					}		
				}
				else
				{
					Debug.Log("Please attach all four Exhaust particle systems in the inspector");
				}	
			}
			else
			{
				Debug.Log("Please attach all four Exhaust particle systems in the inspector");
			}	

			if(Propellor_Front_L != null && Propellor_Front_R != null && Propellor_Rear_L != null && Propellor_Rear_R != null)
			{
				PropellorsSet=true;
			}
			else
			{
				Debug.Log("Please attach all 4 propellor transforms to the AirshipController script in the inspector");
			}	

			if(Elevator != null)
			{
				if(Elevator.Length==4)
				{
					if(Elevator[0] != null && Elevator[1] != null && Elevator[2] != null && Elevator[3] != null)
					{
						ElevatorsSet=true;
					}
					else
					{
						Debug.Log("Please attach all 4 elevator pivot transforms to the AirshipController script in the inspector");
					}	
				}
				else
				{
					Debug.Log("Please attach all 4 elevator pivot transforms to the AirshipController script in the inspector");
				}	
			}
			else
			{
				Debug.Log("Please attach all 4 elevator pivot transforms to the AirshipController script in the inspector");
			}	

			if(Rudder != null)
			{
				if(Rudder.Length==8)
				{
					if(Rudder[0] != null && Rudder[1] != null && Rudder[2] != null && Rudder[3] != null && Rudder[4] != null && Rudder[5] != null && Rudder[6] != null && Rudder[7] != null)
					{
						RuddersSet=true;
					}
					else
					{
						Debug.Log("Please attach all 8 rudder transforms to the AirshipController script in the inspector");
					}	
				}
				else
				{
					Debug.Log("Please attach all 8 rudder transforms to the AirshipController script in the inspector");
				}	
			}
			else
			{
				Debug.Log("Please attach all 8 rudder transforms to the AirshipController script in the inspector");
			}	

		}
		
		void Update () 
		{
			if(PropellorsSet)
			{
				// RPM clamped to maximum visually acceptable rotation speed – for higher speeds you will need a different visual representation of the turning propellors. (like a blurred alpha texture)
				Propellor_Front_L.Rotate(new Vector3(0.0f, 0.0f, Time.deltaTime *Mathf.Clamp(RPM, -220.0f, 220.0f)*6.0f));
				Propellor_Front_R.Rotate(new Vector3(0.0f, 0.0f, Time.deltaTime *-Mathf.Clamp(RPM, -220.0f, 220.0f)*6.0f));
				Propellor_Rear_L.Rotate(new Vector3(0.0f, 0.0f, Time.deltaTime *Mathf.Clamp(RPM, -220.0f, 220.0f)*6.0f));
				Propellor_Rear_R.Rotate(new Vector3(0.0f, 0.0f, Time.deltaTime *-Mathf.Clamp(RPM, -220.0f, 220.0f)*6.0f));
			}	

			if(RuddersSet)
			{
				RudderAngle=Mathf.Clamp(RudderAngle, -35.0f, 35.0f);
				for(i = 0; i<8; i++)
				{
					if(RudderAngle>=0.0) 
					{
						Rudder[i].localEulerAngles = new Vector3(0.0f, RudderAngle, 0.0f);
					}
					else
					{
						Rudder[i].localEulerAngles = new Vector3(0.0f, 360.0f+RudderAngle, 0.0f);
					}	
				}	
			}	

			if(ElevatorsSet)
			{
				ElevatorAngle=Mathf.Clamp(ElevatorAngle, -15.0f, 35.0f);
				for(i = 0; i<4; i++)
				{
					if(ElevatorAngle>=0.0) 
					{
						Elevator[i].localEulerAngles = new Vector3(ElevatorAngle, 0.0f, 0.0f);
					}
					else
					{
						Elevator[i].localEulerAngles = new Vector3(360.0f+ElevatorAngle, 0.0f, 0.0f);
					}	
				}	
			}	

			if(ExhaustSet)
			{	
				for(i = 0; i<4; i++)
				{
					Exhaust[i].material.SetColor("_TintColor", new Color(0.1f, 0.1f, 0.2f, Mathf.Clamp01(Mathf.Abs(RPM)*0.01f)));
				}	
			}	
		}

		public float RPM;
		public float RudderAngle;
		public float ElevatorAngle;
		public Transform Propellor_Front_L;
		public Transform Propellor_Front_R;
		public Transform Propellor_Rear_L;
		public Transform Propellor_Rear_R;
		public Transform[] Elevator;
		public Transform[] Rudder;
		public ParticleSystemRenderer[] Exhaust;
		private bool PropellorsSet;
		private bool RuddersSet;
		private bool ElevatorsSet;
		private bool ExhaustSet;
		private int i;
	}
}