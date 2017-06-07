# Utility Tool
An extendable tool to create programs with custom layouts which do tasks which you specify.

# Current Tasks
- ProcessExecuteTask
    - Executes a specified process when the specified `control` is invoked
- TimerTask
    - Starts a timer task which executes a specified task after the specified interval
- BalloonTipTask
    - Shows a balloon tip in the system tray

# Current Controls
- Button
    - Activates task on click
- None
    - Tasks with no GUI use this

# Example Layout
The follow layout produces:

![](http://puu.sh/nHv0N/f05ec72289.png)

Placed in the same directory as the executable, called `layout.json`
```
{
    "Text": "Utilities",
    "Components": [
        {
            "Control": "Button",
            "Text": "Todo List",
            "Task": "ProcessExecuteTask",
            "Args": ["D:\Dropbox\todo.txt", true],
            "Width": 250,
            "Height": 30,
            "X": 20,
            "Y": 10
        },
        {
            "Control": "Button",
            "Text": "Volume Mixer",
            "Task": "ProcessExecuteTask",
            "Args": ["C:\Windows\system32\sndvol.exe", true],
            "Width": 250,
            "Height": 30,
            "X": 20,
            "Y": 45
        },
        {
            "Control": "None",
            "Task": "TimerTask",
            "Args": [10800000, "BalloonTipTask", 10000, "Break", "Three hours have passed", "Info"]
        }
    ]
}
```
