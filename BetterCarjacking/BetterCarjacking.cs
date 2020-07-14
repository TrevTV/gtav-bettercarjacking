using GTA;
using GTA.Native;
using System;

public class BetterCarjacking : Script
{
    private Random rand = new Random();
    public bool isDebug = false; // edit if you are debugging

    public BetterCarjacking()
    {
        Tick += OnTick;
    }

    private void OnTick(object sender, EventArgs e)
    {
        // Get all peds within a radius and run code for each
        foreach (Ped ped in World.GetNearbyPeds(Game.Player.Character, 50))
        {
            // Chance of if car attempts escape or flees
            // To change chance edit the function IsDebug
            if (rand.Next(0, 100) <= IsDebug())
            {
                // Check if player is targeting ped or vehicle and is not a cop and in a vehicle
                if ((Game.Player.IsTargeting(ped) || Game.Player.TargetedEntity == ped.CurrentVehicle) && ped.IsSittingInVehicle() && !ped.IsInPoliceVehicle && !(ped.CurrentVehicle.GetPedOnSeat(VehicleSeat.Driver) == Game.Player.Character) && !Game.Player.Character.IsSittingInVehicle())
                {
                    ped.BlockPermanentEvents = true;
                    Game.Player.IsTargeting(ped.CurrentVehicle);
                    // Decelerate
                    while ((ped.CurrentVehicle.WheelSpeed * 3.16) > 3)
                    {
                        ped.CurrentVehicle.Speed = ped.CurrentVehicle.Speed - (1f * 3.16f);
                    }
                    Script.Wait(1000);
                    Function.Call(Hash.TASK_LEAVE_VEHICLE, ped, ped.CurrentVehicle, 256);
                    while (ped.IsSittingInVehicle())
                    {
                        Script.Wait(100);
                    }
                    Function.Call(Hash.TASK_REACT_AND_FLEE_PED, ped, Game.Player.Character);
                }
            }
            else
            {
                return;
            }
        }

        if (isDebug)
        {
            if (Game.Player.WantedLevel > 0) { Game.Player.WantedLevel = 0; } // If debugging player is never wanted
        }
    }

    private int IsDebug()
    {
        if (isDebug)
        {
            return 100; // If debug 100% chance of flee
        }
        else
        {
            return 50; // If not debug 50% chance of flee
        }
    }
}