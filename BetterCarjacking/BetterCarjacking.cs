using System;

using GTA;
using GTA.Native;

namespace BetterCarjacking
{
    public class BetterCarjacking : Script
    {
        private Random rand = new Random();
        private int leaveCarChance;

        public BetterCarjacking()
        {
            ScriptSettings scriptSettings = ScriptSettings.Load("scripts\\BetterCarjacking.ini");
            leaveCarChance = scriptSettings.GetValue("Main", "LeaveCarChance", 60);

            Tick += OnTick;
        }

        private void OnTick(object sender, EventArgs e)
        {
            try
            {
                foreach (Ped ped in World.GetNearbyPeds(Game.Player.Character, 15f))
                {
                    if (IsPlayerTargeting(ped) && CanPedSeePlayer(ped) && ShouldPedLeaveCar())
                    {
                        ped.BlockPermanentEvents = true;

                        while (ped.CurrentVehicle.WheelSpeed * 3.16 > 3)
                            ped.CurrentVehicle.Speed -= 0.316f;

                        Wait(GetRandomWaitBeforeExit());

                        Function.Call(Hash.TASK_LEAVE_VEHICLE, ped, ped.CurrentVehicle, 256);
                        while (ped.IsSittingInVehicle()) Wait(100);
                        Function.Call(Hash.TASK_REACT_AND_FLEE_PED, ped, Game.Player.Character);
                    }
                }
            }
            catch { }
        }

        private int GetRandomWaitBeforeExit() => rand.Next(500, 2500);

        private bool ShouldPedLeaveCar() => rand.Next(100) < leaveCarChance;
        private bool IsPlayerTargeting(Entity entity) => Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING_AT_ENTITY, Game.Player, entity);
        private bool CanPedSeePlayer(Ped ped) => Function.Call<bool>(Hash.IS_PED_FACING_PED, ped, Game.Player.Character, 90f);
    }
}