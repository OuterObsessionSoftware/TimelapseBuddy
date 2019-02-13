# Timelapse-Buddy
Timelapse Buddy is a tool for creating time lapses of your desktop.

![Screenshot of Timelapse Buddy program](/screenshots/timelapse-buddy.jpg?raw=true "Timelapse Buddy")

## Windows setup
To use the app on Windows simply download the TimelapseBuddy.exe file from the [releases folder.](/releases) The program can be run from anywhere on your computer.

## Mac OS / Linux setup
To use the app on Mac OS or Linux you need [Mono project.](https://www.mono-project.com/) 

Start by downloading the TimelapseBuddy.exe file from the [releases folder.](/releases)

Next install [Mono project for your operating system.](https://www.mono-project.com/download/stable/#download-mac)

After installing Mono project simply [run the program with Mono project from the command line.](https://www.mono-project.com/docs/about-mono/supported-platforms/macos/)

## Operation

Start by setting a interval of how often you want a photo taken, I typically find one minute to work well.

Next seletct a folder where you want the program to output the screenshot, keep in mind that you will probably end up with a lot of screenshots so it's best to choose an empty folder.

Now that everything has been setup the "Start Timelapse" button should be clickable, press this button to start the time lapse.

At any point you can minimise the program to the notification area by clicking the "-" icon in the title bar. To maximise it again double click the stopwatch icon in the notification area.

## Editing the screenshots into a video

To edit the screenshots together into a video I personally like to use Adobe After Effects.

In After Effects create a new folder in the project viewer with an appropriate name. Drag all of the screenshots into this newly created folder.

Now you can drag the newly created folder onto the timeline. When doing so you should see this window:
![Screenshot of After Effects Composition Settings](/screenshots/adobe-after-effects-comp-settings.jpg?raw=true "After Effects Composition Settings")

Make sure the "Sequence Layers" checkbox is ticked. Alternatively you can do this under Animation>Keyframe Assistant>Sequence Layers...

The length of the time lapse is controlled by the duration of each image and the frame rate of the composition.

You can always use time stretch effect to fine tune the time lapse later.
--------------------------------------
If you're experiencing any problems then you can open a new issue under the [issue tab.](../../issues)

**Cheers,**

**Jameson**
