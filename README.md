# PoEOnDeathReplay
Automatic Hotkey Trigger on Character Death


# How to Install

Download the latest release from here! https://github.com/SteffenBlake/PoEOnDeathReplay/releases/latest

It is compiled to run in standalone mode for Windows only. Since this software depends on Win32 libraries, at this time there is no plan for Linux support.

# How to use

Simply run `OnDeathReplay.WPF.exe` and it will start monitoring for character death. An icon will appear on your task tray for windows, simply right click on it and hit "Exit" to stop the program at any time.

You will need to setup whatever your choice of Automatic Replay program seperately.

AMD Users with AMD Adrenaline: https://www.amd.com/en/support/kb/faq/dh-023#:~:text=To%20enable%2C%20click%20Instant%20Replay,the%20Recording%20Profile%20being%20used.

Nvidia Users with GeForce Experience: https://beebom.com/how-setup-instant-replay-geforce-experience/ 

# How to configure

Simply modify the included `AppSettings.json` file to change what hotkey is triggered automatically on character death. **Note if you modify this file you will need to close and re-open the program to load the new settings!**

See below for what needs to be set for various config values:

`LogFilePath` - This is the path to your relevant Client.txt file which holds all live Path of Exile logs. Keep in mind backslashes need to be escaped.

* Standalone Default: `C:\\Program Files (x86)\\Grinding Gear Games\\Path of Exile\\logs\\Client.txt`

* Steam Default: `C:\Program Files (x86)\\Steam\\steamapps\\common\\Path of Exile\\logs\\Client.txt`

`KeyModifiers` - List of Modifiers to apply to the keystoke, namely Ctrl, Shift, and Alt. These have to be an exact match to the Virtual Key Codes from Microsoft, which you can find here: https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes

`Keys` - List of keys to press, these are the actual keys that will be pressed, and will be pressed in the order specified in the list.

See this example config here:

```
{
  "LogFilePath": "C:\\Program Files (x86)\\Grinding Gear Games\\Path of Exile\\logs\\Client.txt",

  // https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes

  // Key Modifiers like Shift, Control, Alt
  "KeyModifiers": [ "LCONTROL", "LSHIFT" ],

  // Actual (modified) Key to press
  "Keys": [ "VK_S" ]
}
```

This config is setup to monitor the Standalone Client log file, and it will send Ctrl+Shift+S when the character dies.

# Does this program violate the Path of Exile Terms of Services?

No, this program works even if path of exile isnt even open, it merely watches the log text file for the "You have been slain" line that gets logged when your character dies, then it triggers the global system keystroke (which isnt sent to Path of Exile, but instead to System, which is what stuff like AMD ReLive is watching for)

If you dont even have path of exile maximized and it is minimized and your character dies, and you are on a different window (like looking up trades on the trade site) it will still trigger and still work, as the keystroke has no interaction with the PoE client.
