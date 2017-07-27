# TangoZenFoneARBugSample

![result](https://github.com/inuko/TangoZenFoneARBugSample/blob/media/capture.gif)

1. Launch the application.
2. In the first screen, select "Player" and start learning ADF.
  TangoApplication#Startup(null) It worked.
3. Press the Back key to return to the first screen.
4. select "Manager" and start learning ADF.
  TangoApplication#Startup(null) -> It worked.
5. Press the Save button to save the ADF. 
  AreaDescription#SaveCurrent() -> It worked.
6. In the first screen, select "Player" and start learning ADF. 
  TangoApplication#Startup(null) -> "Failed to connect Tango Service."
7. Terminate the application and start it.
8. In the first screen, select "Player" and start learning ADF. 
  Tango Core will be stopped.
