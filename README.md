# Better Carjacking

A mod that makes it so that peds may just flee instead of driving away when targeted.<br> <br>

Please submit any issues in the issues tab.

# Building Instructions
Make sure you have .NET Framework 4.8 installed.<br>
Open "BetterCarjacking.sln" in Visual Studio. <br>
Go to Refrences in the Solution Explorer and set the location for ScriptHookVDotNet3<br>
Go to the Build tab then "Build Better Carjacking"<br> <br>

NOTE: If you have GTA V installed somewhere other than "steamapps\common\Grand Theft Auto V" you may see an error in the output window, ignore it as it is just attempting to copy it to your game folder.

# Installation and Dependencies:
You need to have ScriptHookV and ScriptHookVdotNet installed.<br>
Move the BetterCarjacking.dll into your scripts folder

# Usage
Point a gun at a driver in a car. They have a 50% chance to drive backwards or forwards like normal or they could flee, giving you the car to take.

# Changelog
### 2.0.0
<ul>
	<b>Fixes</b>
		<ul>
			<li>Fixed a possible crash if player points gun in driver's seat.</li>
                        <li>Peds no longer exit vehicle when player is already in vehicle</li>
		</ul>
	<b>Features</b>
		<ul>
			<li>Debug mode</li>
            <li>Cars now decelerate instead of abruptly stopping</li>
            <li>You can now also point at a ped's car to trigger them</li>
		</ul>
</ul>

### 1.0.1
<ul>
         <li>Fixed a major performance issue due to bad code.</li>
</ul>

### 1.0.0
<ul>
	<li>Initial release.</li>
</ul>