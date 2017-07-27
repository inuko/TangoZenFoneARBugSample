using System.Collections;
using System.Threading;
using Tango;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour, ITangoPose, ITangoLifecycle {

	private TangoApplication m_tangoApplication;

	private Thread m_saveThread;

	private AreaDescription m_currentAreaDescription;

	#region -- Unity --
	void Start () {
		m_tangoApplication = FindObjectOfType<TangoApplication>();

		if (m_tangoApplication != null) {
			m_tangoApplication.Register (this);
			if (AndroidHelper.IsTangoCorePresent ()) 
			{
				m_tangoApplication.RequestPermissions ();
			}
		} else {
			Debug.Log("No Tango Manager found in scene.");
		}
	}

	void Update () {
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKeyDown (KeyCode.Escape)) 
			{
				SceneManager.LoadScene ("Top");
				return;
			}
		}

		if (m_saveThread != null && m_saveThread.ThreadState != ThreadState.Running)
		{
			SceneManager.LoadScene ("Top");
			return;
		}
	}

	void Destroy()
	{
		if (m_tangoApplication)
		{
			m_tangoApplication.Unregister (this);
		}
	}
	#endregion -- Unity --

	#region -- ITangoLifecycle --
	/// <summary>
	/// Internal callback when a permissions event happens.
	/// </summary>
	/// <param name="permissionsGranted">If set to <c>true</c> permissions granted.</param>
	public void OnTangoPermissions(bool permissionsGranted)
	{
		if (permissionsGranted)
		{
			_StartGame ();
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

	/// <summary>
	/// This is called when successfully connected to the Tango service.
	/// </summary>
	public void OnTangoServiceConnected()
	{
	}

	/// <summary>
	/// This is called when disconnected from the Tango service.
	/// </summary>
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

	public void Save() {
		StartCoroutine (_DoSaveCurrentAreaDescription ());
	}

	private IEnumerator _DoSaveCurrentAreaDescription() 
	{
		if (m_saveThread != null) 
		{
			yield break;
		}
		if (m_tangoApplication.m_areaDescriptionLearningMode)
		{
			m_saveThread = new Thread(delegate()
				{
					// Start saving process in another thread.
					m_currentAreaDescription = AreaDescription.SaveCurrent();
					AreaDescription.Metadata metadata = m_currentAreaDescription.GetMetadata();
					metadata.m_name = "Demo";
					m_currentAreaDescription.SaveMetadata(metadata);
				});
			m_saveThread.Start();
		}
	}

	private void _StartGame() {
		m_tangoApplication.m_areaDescriptionLearningMode = true;
		m_tangoApplication.Startup(null);
	}
}