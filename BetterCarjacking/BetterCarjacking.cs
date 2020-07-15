using GTA;
using GTA.Native;
using System;
using System.Windows.Forms;

namespace BetterCarjacking
{
    public class BetterCarjacking : Script
    {
        private Random rand = new Random();

        public BetterCarjacking()
        {
            Tick += OnTick;
        }

        void OnTick(object sender, EventArgs e)
        {
            GTA.UI.Notification.Show(Game.Player.IsAiming.ToString(), false);
            PedCheck();
        }

        void PedCheck()
        {
            GTA.UI.Notification.Show("Checking Ped", false);
            foreach (Ped ped in World.GetNearbyPeds(Game.Player.Character, 100f))
            {
                GTA.UI.Notification.Show("Found Ped", false);
                if (!CanJackPed(ped))
                    return;

                if (!(rand.Next(0, 100) <= 100))
                    return;

                GTA.UI.Notification.Show("Jacking Ped", false);
                ped.BlockPermanentEvents = true;

                Decelerate(ped.CurrentVehicle);

                Function.Call(Hash.TASK_LEAVE_VEHICLE, ped, ped.CurrentVehicle, 256);

                while (ped.IsSittingInVehicle())
                    Wait(100);

                Function.Call(Hash.TASK_REACT_AND_FLEE_PED, ped, Game.Player.Character);
            }
        }

        void Decelerate(Vehicle veh)
        {
            while (veh.WheelSpeed * 3.16 > 3)
            {
                veh.Speed -= 3.16f;
            }
        }

        bool CanJackPed(Ped ped)
        {
            var pedInVehicle = ped.IsSittingInVehicle();

            if (!pedInVehicle)
                return false;

            var targeting = Game.Player.IsTargeting(ped) || Game.Player.IsTargeting(ped.CurrentVehicle);
            var pedInPolice = ped.IsInPoliceVehicle;
            var driverIsPlayer = ped.CurrentVehicle.GetPedOnSeat(VehicleSeat.Driver) == Game.Player.Character;
            var playerInVehicle = Game.Player.Character.IsSittingInVehicle();

            if (!targeting)
                return false;
            if (driverIsPlayer)
                return false;
            if (pedInPolice)
                return false;
            if (playerInVehicle)
                return false;
            GTA.UI.Notification.Show("Can Jack Ped", false);
            return true;
        }
    }
}