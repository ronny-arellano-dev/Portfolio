using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace The_Architect.Modules.Factorio
{
    public class _Storage
    {
        public string name;
        public string description;
        public string recipe;
        public string totalRaw;
        public int storageSize;
        public int health;
        public int stackSize;
        public string dimensions;
        public string fuelValue;
        public int vehicleAccel;
        public string internalName;
        public string prototypeType;
        public string requiredTech;
        public string producedBy;
        public string usedAsFuelBy;
        public string consumedBy;
    }

    public class _TransportBeltSys
    {
        public string name;
        public string description;
        public string recipe;
        public string totalRaw;
        public int health;
        public int stackSize;
        public string dimensions;
        public string beltSpeed;
        public string internalName;
        public string prototypeType;
        public string requiredTech;
        public string producedBy;
        public string consumedBy;
    }
}