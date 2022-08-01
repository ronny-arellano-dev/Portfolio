package com.redwidow.charactergenerator;

import java.util.Random;

public class CharGen {
    public static void main(String[] args) {
        // Global Variables
        String selRace, selClass;
        int intLevel, intAge; // Bio
        int baseStr, baseDex, baseCon, baseInt, baseWis, baseCha; // Base Ability Scores
        int modStr, modDex, modCon, modInt, modWis, modCha; // Ability Score Modifier
        int lstLength, selNum; // List manipulation
        Random rndNum = new Random(); // For all random numbers?

        // Select Level
        intLevel = 1;

        // Select Race
        bioGenerator newRace = new bioGenerator();
        selRace = newRace.getNewRace();

        // Select Class
        bioGenerator newClass = new bioGenerator();
        selClass = newClass.getNewClass();


        // Obtain Base Ability Scores and create pre-set array
        baseScoreCalc newBaseStats = new baseScoreCalc();
        int[] allStats = new int[6]; // 0 STR, 1 DEX, 2 CON, 3 INT, 4 WIS, 5 CHA

        // Get a score and assign it to an index
        for(int x=0;x<6;x++) {
            int rollResults = newBaseStats.getScore();
            allStats[x] = rollResults;

            // DEBUG
            //System.out.println("Roll for index " + x + " is " + rollResults);
        }

        // Get Race benefits to base scores
        int[] baseBenefits = newRace.getRaceBenefits();
        for (int z=0;z<baseBenefits.length;z++) {
            // DEBUG
            //System.out.println(selRace + " stat " + z + " was " + allStats[z]);

            allStats[z] = allStats[z] + baseBenefits[z];

            // DEBUG
            //System.out.println(selRace + " stat " + z + " is now " + allStats[z]);
        }

        // Assign Base Scores to variables
        baseStr = allStats[0];
        baseDex = allStats[1];
        baseCon = allStats[2];
        baseInt = allStats[3];
        baseWis = allStats[4];
        baseCha = allStats[5];

        // Obtain Base Ability Modifiers
        baseScoreCalc newStatMods = new baseScoreCalc();
        int[] allModifiers = new int[6]; // 0 STR, 1 DEX, 2 CON, 3 INT, 4 WIS, 5 CHA

        // Calculate Score modifier
        for(int y=0;y<6;y++) {
            int modResult = newStatMods.getModifier(allStats[y]);
            allModifiers[y] = modResult;

            // DEBUG
            //System.out.println("Modifier for stat " + y + " is " + modResult);
        }

        // Assign modifier Scores to variables
        modStr = allModifiers[0];
        modDex = allModifiers[1];
        modCon = allModifiers[2];
        modInt = allModifiers[3];
        modWis = allModifiers[4];
        modCha = allModifiers[5];

        // Obtain Something else


        // Output
        System.out.println("===== YOUR NEW CHARACTER =====");
        System.out.println("Your starting level is " + intLevel);
        System.out.println("Your selected race is " + selRace);
        System.out.println("Your selected class is " + selClass);
        System.out.println("Your base stats are as follows:");
        System.out.println("\tSTR - " + baseStr);
        System.out.println("\tDEX - " + baseDex);
        System.out.println("\tCON - " + baseCon);
        System.out.println("\tINT - " + baseInt);
        System.out.println("\tWIS - " + baseWis);
        System.out.println("\tCHA - " + baseCha);
        System.out.println("Your Modifier stats are as follows:");
        System.out.println("\tSTR - " + modStr);
        System.out.println("\tDEX - " + modDex);
        System.out.println("\tCON - " + modCon);
        System.out.println("\tINT - " + modInt);
        System.out.println("\tWIS - " + modWis);
        System.out.println("\tCHA - " + modCha);
    }


}
