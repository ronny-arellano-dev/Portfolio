using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace The_Architect.Modules.Factorio
{
    [Group("factorio")]
    public class Factorio : ModuleBase<SocketCommandContext>
    {
        [Command]
        public async Task FactorioHelp()
        {
            EmbedBuilder factorioHelp = new EmbedBuilder();

            factorioHelp.WithTitle("Factorio Commands")
                .AddInlineField("items", "Will show the categories available. You can include it in the command after 'items'")
                .AddInlineField("item + 'item name'", "Shows info about the item you include");

            await ReplyAsync("", false, factorioHelp.Build());
        }

        [Group("items")]
        public class FactorioItemsCat : ModuleBase<SocketCommandContext>
        { 
            [Command]
            public async Task ItemsList()
            {
                EmbedBuilder itemCategories = new EmbedBuilder();

                itemCategories.WithTitle("Item Categories")
                    .AddInlineField("Logistics", "Storage \nBelt Transport System \nInserters \nEnergy & Pipe Distribution \nTransport \nLogistic Network " +
                                                 "\nCircuit Network \nTerrain \nNavigation")
                    .AddInlineField("Production", "<Add Sub-Categories>")
                    .AddInlineField("Intermediate Products", "<Add Sub-Categories>")
                    .AddInlineField("Combat", "<Add Sub-Categories>")
                    .WithColor(Color.Blue);

                await ReplyAsync("", false, itemCategories.Build());
            }

            [Command("logistics")]
            public async Task LogisticsList()
            {
                EmbedBuilder logItems= new EmbedBuilder();

                logItems.WithTitle("List of Logistic Items")
                    .AddInlineField("Storage", "Wooden Chest \nIron Chest \nSteel Chest \nStorage Tank")
                    .AddInlineField("Belt Transport System", "Transport Belt \nFast Transport Belt \nExpress Transport Belt \nUnderground Belt \nFast Underground Belt " +
                                    "\nExpress Underground Belt \nSplitter \nFast Splitter \nExpress Splitter")
                    .AddInlineField("Inserters", "Burner Inserter \nInserter \nLong Handed Inserted \nFast Inserter \nFilter Inserter \nStack Inserter " +
                                    "\nStack Filter Inserter")
                    .AddInlineField("Energy & Pipe Distribution", "Small Electric Pole \nMedium Electric Pole \nBig Electric Pole \nSubstation \nPipe " +
                                    "\nPipe to Ground \nPump")
                    .AddInlineField("Transport", " \nTrain Stop \nRail Signal \nRail Chain Signal \nLocomotive \nCargo Wagon \nFluid Wagon \nArtillery Wagon \nCar \nTank")
                    .AddInlineField("Logistic Network", "<Enter Items>")
                    .AddInlineField("Circuit Network", "<Enter Items>")
                    .AddInlineField("Terrain", "<Enter Items>")
                    .AddInlineField("Navigation", "<Enter Items>")
                    .WithColor(Color.Blue);

                await ReplyAsync("", false, logItems.Build());
            }

            [Command("production")]
            public async Task ProductionList()
            {
                EmbedBuilder prodItems = new EmbedBuilder();

                prodItems.WithTitle("List of Production Items")
                    .AddInlineField("Tools", "Axe, Iron \nAxe, Steel \nRepair Pack \nBlueprint \nDeconstruction Planner \nBlueprint Book")
                    .WithColor(Color.Green);

                await ReplyAsync("", false, prodItems.Build());
            }

            [Command("intermediate products")]
            public async Task IntermediateList()
            {
                EmbedBuilder intermediateItems = new EmbedBuilder();

                await ReplyAsync("", false, intermediateItems.Build());
            }

            [Command("combat")]
            public async Task CombatList()
            {
                EmbedBuilder combatItems = new EmbedBuilder();

                await ReplyAsync("", false, combatItems.Build());
            }
        }

        [Group("item")]
        public class FactorioItems : ModuleBase<SocketCommandContext>
        {
            [Command]
            public async Task DefaultItem()
            {
                // Possibly add the function to wait for user input
                await ReplyAsync("Include the name of the item you want info on!");
            }

            // Storage
            [Command("Wooden Chest")]
            public async Task WoodenChest()
            {
                _Storage woodenChest = new _Storage
                {
                    name = "Wooden Chest",
                    description = "Used to store materials",
                    recipe = ".5s + Wood(x4)",
                    totalRaw = "1.5s + Raw Wood(x2)",
                    storageSize = 16,
                    health = 100,
                    stackSize = 50,
                    dimensions = "1x1",
                    fuelValue = "4 MJ",
                    vehicleAccel = 100,
                    internalName = "wooden-chest",
                    prototypeType = "container",
                    requiredTech = "None",
                    producedBy = "Manual Crafting \nAssembly Machine 1=3",
                    usedAsFuelBy = "Burner Inserter \nBurner Mining Drill \nBoiler \nStone Furnace \nSteel Furnace" +
                                   "\nLocomotive \nCar \nTank"

                };

                EmbedBuilder _woodenChest = new EmbedBuilder();

                _woodenChest.WithTitle(woodenChest.name)
                    .WithThumbnailUrl("https://wiki.factorio.com/images/Wooden_chest.png")
                    .AddInlineField("Description", woodenChest.description)
                    .AddInlineField("Recipe", woodenChest.recipe)
                    .AddInlineField("Total Raw", woodenChest.totalRaw)
                    .AddInlineField("Storage Size", woodenChest.storageSize)
                    .AddInlineField("Health", woodenChest.health)
                    .AddInlineField("Stack Size", woodenChest.stackSize)
                    .AddInlineField("Dimension", woodenChest.dimensions)
                    .AddInlineField("Fuel Value", woodenChest.fuelValue)
                    .AddInlineField("Vehicle Acceleration", woodenChest.vehicleAccel)
                    .AddInlineField("Internal Name", woodenChest.internalName)
                    .AddInlineField("Prototype Type", woodenChest.prototypeType)
                    .AddInlineField("Produced By", woodenChest.producedBy)
                    .AddInlineField("Used as Fuel By", woodenChest.usedAsFuelBy)
                    .WithColor(Color.Gold);

                await ReplyAsync("", false, _woodenChest.Build());
            }

            [Command("iron chest")]
            public async Task IronChest()
            {
                _Storage ironChest = new _Storage
                {
                    name = "Iron Chest",
                    description = "Used to store items.",
                    recipe = ".5s + Iron Plate(x8)",
                    totalRaw = ".5s + Iron Plate (x8)",
                    storageSize = 32,
                    health = 200,
                    stackSize = 50,
                    dimensions = "1x1",
                    internalName = "iron-chest",
                    prototypeType = "container",
                    requiredTech = "None",
                    producedBy = "Manual Crafting \nAssembly Machine 1-3"                    
                };

                EmbedBuilder _ironChest = new EmbedBuilder();

                _ironChest.WithTitle(ironChest.name)
                    .WithThumbnailUrl("https://wiki.factorio.com/images/Iron_chest.png")
                    .AddInlineField("Description", ironChest.description)
                    .AddInlineField("Recipe", ironChest.recipe)
                    .AddInlineField("Total Raw",ironChest.totalRaw)
                    .AddInlineField("Storage Size", ironChest.storageSize)
                    .AddInlineField("Health", ironChest.health)
                    .AddInlineField("Stack Size", ironChest.stackSize)
                    .AddInlineField("Dimension", ironChest.dimensions)
                    .AddInlineField("Internal Name", ironChest.internalName)
                    .AddInlineField("Prototype Type", ironChest.prototypeType)
                    .AddInlineField("Produced By", ironChest.producedBy)
                    .WithColor(Color.DarkerGrey);

                await ReplyAsync("", false, _ironChest.Build());
            }
            
            [Command("steel chest")]
            public async Task SteelChest()
            {
                _Storage steelChest = new _Storage
                {
                    name = "Steel Chest",
                    description = "Used to store items.",
                    recipe = ".5s + Steel Plate(x8)",
                    totalRaw = ".5s + Steel Plate (x8)",
                    storageSize = 48,
                    health = 350,
                    stackSize = 50,
                    dimensions = "1x1",
                    internalName = "steel-chest",
                    prototypeType = "container",
                    requiredTech = "Steel Processing",
                    producedBy = "Manual Crafting \nAssembly Machine 1-3",
                    consumedBy = "Active Provider Chest \nBuffer Chest \nPassive Provider Chest " +
                                "\nRequestor Chest \nStorage Chest"
                };

                EmbedBuilder _steelChest = new EmbedBuilder();

                _steelChest.WithTitle(steelChest.name)
                    .WithThumbnailUrl("https://wiki.factorio.com/images/Steel_chest.png")
                    .AddInlineField("Description", steelChest.description)
                    .AddInlineField("Recipe", steelChest.recipe)
                    .AddInlineField("Total Raw", steelChest.totalRaw)
                    .AddInlineField("Storage Size", steelChest.storageSize)
                    .AddInlineField("Health", steelChest.health)
                    .AddInlineField("Stack Size", steelChest.stackSize)
                    .AddInlineField("Dimension", steelChest.dimensions)
                    .AddInlineField("Internal Name", steelChest.internalName)
                    .AddInlineField("Prototype Type", steelChest.prototypeType)
                    .AddInlineField("Produced By", steelChest.producedBy)
                    .AddInlineField("Consumed By", steelChest.consumedBy)
                    .WithColor(Color.DarkerGrey);

                await ReplyAsync("", false, _steelChest.Build());
            }

            [Command("storage tank")]
            public async Task StorageTank()
            {
                _Storage storageTank = new _Storage
                {
                    name = "Storage Tank",
                    description = "Used to store fluids",
                    recipe = "3s + Iron Plate(x20) + Steel Plate (x5)",
                    totalRaw = "3s + Iron Plate(x20) + Steel Plate (x5)",
                    storageSize = 25000,
                    health = 500,
                    stackSize = 50,
                    dimensions = "3x3",
                    internalName = "storage-tank",
                    prototypeType = "storage-tank",
                    requiredTech = "Fluid Handling",
                    producedBy = "Manual Crafting \nAssembly Machine 1-3",
                    consumedBy = "Fluid Wagon"
                };

                EmbedBuilder _storageTank = new EmbedBuilder();
                _storageTank.WithTitle(storageTank.name)
                    .WithThumbnailUrl("https://wiki.factorio.com/images/Storage_tank.png")
                    .AddInlineField("Description", storageTank.description)
                    .AddInlineField("Recipe", storageTank.recipe)
                    .AddInlineField("Total Raw", storageTank.totalRaw)
                    .AddInlineField("Storage Size", storageTank.storageSize)
                    .AddInlineField("Health", storageTank.health)
                    .AddInlineField("Stack Size", storageTank.stackSize)
                    .AddInlineField("Dimensions", storageTank.dimensions)
                    .AddInlineField("Internal Name", storageTank.internalName)
                    .AddInlineField("Prototype Type", storageTank.prototypeType)
                    .AddInlineField("Required Tech", storageTank.requiredTech)
                    .AddInlineField("Produced By", storageTank.producedBy)
                    .AddInlineField("Consumed By", storageTank.consumedBy)
                    .WithColor(Color.DarkBlue);

                await ReplyAsync("", false, _storageTank.Build());
            }

            // Belt Transport Systems
            [Command("transport belt")]
            public async Task TransportBelt()
            {
                _TransportBeltSys transportBelt = new _TransportBeltSys
                {
                    name = "Transport Belt",
                    description = "Tier 1 Transport Belt",
                    recipe = ".5s + Iron Gear Wheel(x1) + Iron Plate(x1)",
                    totalRaw = "1s + Iron Plate(x3 normal, x5 expensive)",
                    health = 150,
                    stackSize = 100,
                    dimensions = "1x1",
                    beltSpeed = "13.33 Items/s",
                    internalName = "transport-belt",
                    prototypeType = "transport-belt",
                    requiredTech = "None",
                    producedBy = "Manual Crafting \nAssembly Machines 1-3",
                    consumedBy = "Fast Transport Belt \nLab \nScience Pack 2 \nSplitter \nUnderground Belt"                    
                };

                EmbedBuilder _transportBelt = new EmbedBuilder();
                _transportBelt.WithTitle(transportBelt.name)
                    .WithThumbnailUrl("https://wiki.factorio.com/images/Transport_belt.png")
                    .AddInlineField("Description", transportBelt.description)
                    .AddInlineField("Recipe", transportBelt.recipe)
                    .AddInlineField("Total Raw", transportBelt.totalRaw)
                    .AddInlineField("Health", transportBelt.health)
                    .AddInlineField("Stack Size", transportBelt.stackSize)
                    .AddInlineField("Dimensions", transportBelt.dimensions)
                    .AddInlineField("Belt Speed", transportBelt.beltSpeed)
                    .AddInlineField("Internal Name", transportBelt.internalName)
                    .AddInlineField("Prototype Type", transportBelt.prototypeType)
                    .AddInlineField("Required Tech", transportBelt.requiredTech)
                    .AddInlineField("Produced By", transportBelt.producedBy)
                    .AddInlineField("Consumed By", transportBelt.consumedBy)
                    .WithColor(Color.Gold);

                await ReplyAsync("", false, _transportBelt.Build());
            }

            [Command("fast transport belt")]
            public async Task FastTransportBelt()
            {
                _TransportBeltSys fastBelt = new _TransportBeltSys
                {
                    name = "Fast Transport Belt",
                    description = "Transport twice as fast",
                    recipe = ".5s + Iron Gear Wheel(x5) + Transport Belt(x1)",
                    totalRaw = "3.5s + Iron Plate(x11.5 normal, x22.5 expensive)",
                    health = 160,
                    stackSize = 100,
                    dimensions = "1x1",
                    beltSpeed = "26.67 Items/s",
                    internalName = "fast-transport-belt",
                    prototypeType = "transport-belt",
                    requiredTech = "Logistics 2",
                    producedBy = "Manual Crafting \nAssembly Machine 1-3",
                    consumedBy = "Express Transport Belt"
                };

                EmbedBuilder _fastBelt = new EmbedBuilder();
                _fastBelt.WithTitle(fastBelt.name)
                    .WithThumbnailUrl("https://wiki.factorio.com/images/Fast_transport_belt.png")
                    .AddInlineField("Description", fastBelt.description)
                    .AddInlineField("Recipe", fastBelt.recipe)
                    .AddInlineField("Total Raw", fastBelt.totalRaw)
                    .AddInlineField("Health", fastBelt.health)
                    .AddInlineField("Stack Size", fastBelt.stackSize)
                    .AddInlineField("Dimensions", fastBelt.dimensions)
                    .AddInlineField("Belt Speed", fastBelt.beltSpeed)
                    .AddInlineField("Internal Name", fastBelt.internalName)
                    .AddInlineField("Prototype Name", fastBelt.prototypeType)
                    .AddInlineField("Required Tech", fastBelt.requiredTech)
                    .AddInlineField("Produced By", fastBelt.producedBy)
                    .AddInlineField("Consumed By", fastBelt.consumedBy)
                    .WithColor(Color.DarkOrange);

                await ReplyAsync("", false, _fastBelt.Build());
            }

            [Command("express transport belt")]
            public async Task ExpressBelt()
            {
                _TransportBeltSys expressBelt = new _TransportBeltSys
                {
                    name = "Express Transport Belt",
                    description = "Travels thrice as fast",
                    recipe = ".5s + Fast Transport Belt(x1) + Iron Gear Wheel(x10 normal, x20 expensive) + Lubricant (x20)",
                    totalRaw = "9s(14s expensive) + Iron Plate(x31.5 normal, x102.5 expensive) + Lubricant(x20)",
                    health = 170,
                    stackSize = 100,
                    dimensions = "1x1",
                    beltSpeed = " 40 Items/s",
                    internalName = "express-transport-belt",
                    prototypeType = "transport-belt",
                    requiredTech = "Logistics 3",
                    producedBy = "Assembly Machine 2-3"
                };

                EmbedBuilder _expressBelt = new EmbedBuilder();
                _expressBelt.WithTitle(expressBelt.name)
                    .WithThumbnailUrl("https://wiki.factorio.com/images/Express_transport_belt.png")
                    .AddInlineField("Description", expressBelt.description)
                    .AddInlineField("Recipe", expressBelt.recipe)
                    .AddInlineField("Total Raw", expressBelt.totalRaw)
                    .AddInlineField("Health", expressBelt.health)
                    .AddInlineField("Stack Size", expressBelt.stackSize)
                    .AddInlineField("Dimensions", expressBelt.dimensions)
                    .AddInlineField("Belt Speed", expressBelt.beltSpeed)
                    .AddInlineField("Internal name", expressBelt.internalName)
                    .AddInlineField("Prototype Type", expressBelt.prototypeType)
                    .AddInlineField("Required Tech", expressBelt.requiredTech)
                    .AddInlineField("Produced By", expressBelt.producedBy)
                    .WithColor(Color.DarkBlue);

                await ReplyAsync("", false, _expressBelt.Build());
            }

            // Inserters


            // Energy & Pipe Distribution


            // Transport


            // Logistic Network


            // Terrain


            //Navigation
        }
    }
}
