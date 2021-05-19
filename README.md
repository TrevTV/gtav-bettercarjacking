# Better Carjacking [![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/S6S244CYE)

A GTA V mod that allows peds to simply flee their vehicle when targeted.

# Building Instructions
1. Make sure you have .NET Framework 4.8 installed.
2. Open `BetterCarjacking.sln` in Visual Studio.
3. Go to Refrences in the Solution Explorer and set the location for ScriptHookVDotNet3
4. Go to the `Build` tab then `Build BetterCarjacking`

NOTE: Build Events are set to my copy of GTA V located at `F:\Games\steamapps\common\Grand Theft Auto V`, you will need to change it if installed elsewhere

# Installation and Dependencies
You need to have ScriptHookV and ScriptHookVDotNet 3 installed.  
Move BetterCarjacking.dll and BetterCarjacking.ini into your scripts folder

# Usage
Point a gun at a driver in a car. They have a 60% chance (by default) to drive backwards or forwards like normal or they could flee, giving you the car to take.

# Changelog
### 2.0.1
- Code redo, it's all much cleaner and will probably perform better
- Customizable leaving car chance (defaults to 60% chance)
- Peds will only exit if they can see the player (mostly, this isn't perfect)
- Peds wait a random amount of time before exiting (500 to 2500ms)

### 2.0.0
- Fixed a possible crash if player points gun in driver's seat.
- Peds no longer exit vehicle when player is already in vehicle
- Cars now decelerate instead of abruptly stopping
- You can now also point at a ped's car to trigger them

### 1.0.1
- Fixed a performance issue due to bad code.

### 1.0.0
- Initial release.
