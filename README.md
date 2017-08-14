# TangoZenFoneARBugSample

Tango Core version is "1.55:2017.07.25-release-m21-release-0-g659c03f5:240017564:stable"

ZenFone AR
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


PHAB2 Pro
![result](https://github.com/inuko/TangoZenFoneARBugSample/blob/phab2pro/capture.gif)
1. Launch the application.
2. In the first screen, select "Player" and start learning ADF.
<BR> TangoApplication#Startup(null) It worked.
3. Press the Back key to return to the first screen.
4. select "Manager" and start learning ADF.
<BR> TangoApplication#Startup(null) -> It worked.
5. Press the Save button to save the ADF. 
<BR> AreaDescription#SaveCurrent() -> It worked.
6. In the first screen, select "Player" and start learning ADF. 
<BR> TangoApplication#Startup(null) -> It worked.
