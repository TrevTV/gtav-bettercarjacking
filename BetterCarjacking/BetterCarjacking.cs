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
            if (!CanJackPed(ped))
                return;

            if (!(rand.Next(0, 100) <= 100))
                return;

            ped.BlockPermanentEvents = true;

            Decelerate(ped.CurrentVehicle);

            // Script.Wait(1000);
            Function.Call(Hash.TASK_LEAVE_VEHICLE, ped, ped.CurrentVehicle, 256);
            while (ped.IsSittingInVehicle())
            {
                Script.Wait(100);
            }
            Function.Call(Hash.TASK_REACT_AND_FLEE_PED, ped, Game.Player.Character);
        }
    }

    void Decelerate(Vehicle veh)
    {
        while ((veh.WheelSpeed * 3.16) > 3)
        {
            veh.Speed -= 3.16f;
        }
    }

    bool CanJackPed(Ped ped)
    {
        var pedInVehicle = ped.IsSittingInVehicle();
        var targeting = Game.Player.IsTargeting(ped) || Game.Player.IsTargeting(ped.CurrentVehicle);
        var pedInPolice = ped.IsInPoliceVehicle;
        var driverIsPlayer = ped.CurrentVehicle.GetPedOnSeat(VehicleSeat.Driver) == Game.Player.Character;
        var playerInVehicle = Game.Player.Character.IsSittingInVehicle();

        if (!pedInVehicle)
            return false;
        if (!targeting)
            return false;
        if (pedInPolice)
            return false;
        if (driverIsPlayer)
            return false;
        if (playerInVehicle)
            return false;

        return true;
    }
}