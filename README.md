# TangoZenFoneARBugSample

Tango Core version is "1.55:2017.06.23-release-m20-release-0-g571120a1:240016802:stable"

![result](https://github.com/inuko/TangoZenFoneARBugSample/blob/media/capture.gif)

1. Launch the application.
2. In the first screen, select "Player" and start learning ADF.
<BR> TangoApplication#Startup(null) It worked.
3. Press the Back key to return to the first screen.
4. select "Manager" and start learning ADF.
<BR> TangoApplication#Startup(null) -> It worked.
5. Press the Save button to save the ADF. 
<BR> AreaDescription#SaveCurrent() -> It worked.
6. In the first screen, select "Player" and start learning ADF. 
<BR> TangoApplication#Startup(null) -> "Failed to connect Tango Service."
7. Terminate the application and start it.
8. In the first screen, select "Player" and start learning ADF. 
<BR> Tango Core will be stopped.
