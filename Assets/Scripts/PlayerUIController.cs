using System.Collections;
using Tango;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUIController : MonoBehaviour, ITangoLifecycle, ITangoPose
{
	private TangoApplication m_tangoApplication;

	#region -- Unity --
	void Start () 
	{
		m_tangoApplication = FindObjectOfType<TangoApplication>();

		if (m_tangoApplication != null) 
		{
			m_tangoApplication.Register (this);
			if (AndroidHelper.IsTangoCorePresent ()) 
			{
				m_tangoApplication.RequestPermissions ();
			}
		}
		else 
		{
			Debug.Log("No Tango Manager found in scene.");
		}
	}

	void Update() 
	{
		if (Application.platform == RuntimePlatform.Android) 
		{
			if (Input.GetKeyDown (KeyCode.Escape)) 
			{
				SceneManager.LoadScene ("Top");
				return;
			}
		}
	}

	void Destroy() 
	{
		if (m_tangoApplication != null)
		{
			m_tangoApplication.Unregister (this);
		}
	}
	#endregion -- Unity --

	#region -- ITangoLifecycle --
	public void OnTangoPermissions(bool permissionsGranted)
	{
		if (permissionsGranted)
		{
			m_tangoApplication.Startup (null);
		}
		else
		{
			AndroidHelper.ShowAndroidToastMessage("Motion Tracking and Area Learning Permissions Needed");

			// This is a fix for a lifecycle issue where calling
			// Application.Quit() here, and restarting the application
			// immediately results in a deadlocked app.
			AndroidHelper.AndroidQuit();
		}
	}

	public void OnTangoServiceConnected()
	{
	}

	public void OnTangoServiceDisconnected()
	{
	}
	#endregion -- ITangoLifecycle --

	#region -- ITangoPose --
	public void OnTangoPoseAvailable(Tango.TangoPoseData poseData)
	{
		if (poseData.framePair.baseFrame == 
			TangoEnums.TangoCoordinateFrameType.TANGO_COORDINATE_FRAME_AREA_DESCRIPTION &&
			poseData.framePair.targetFrame ==
			TangoEnums.TangoCoordinateFrameType.TANGO_COORDINATE_FRAME_START_OF_SERVICE &&
			poseData.status_code == TangoEnums.TangoPoseStatusType.TANGO_POSE_VALID)
		{
			
		}
	}
	#endregion -- ITangoPose --
}