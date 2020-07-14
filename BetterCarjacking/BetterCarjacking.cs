using GTA;
using GTA.Native;
using System;

public class BetterCarjacking : Script
{
    private Random rand = new Random();

    public BetterCarjacking()
    {
        Tick += OnTick;
    }

    void OnTick(object sender, EventArgs e)
    {
        // Aim check to have better performance
        if (Game.Player.IsAiming)
            PedCheck();
    }

    void PedCheck()
    {
        // Get all peds within a radius and run code for each
        foreach (Ped ped in World.GetNearbyPeds(Game.Player.Character, 25f))
        {
            // Chance of if car attempts escape or flees
            if (rand.Next(0, 100) <= 100)
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
        }
    }
}