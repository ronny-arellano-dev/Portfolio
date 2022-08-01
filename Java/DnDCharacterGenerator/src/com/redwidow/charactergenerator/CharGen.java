package com.redwidow.charactergenerator;

import java.util.Arrays;

import com.redwidow.charactergenerator.charSheet.savingThrows;

public class CharGen {
    public static void main(String[] args) {
        // Global Variables
        String selRace, selClass;
        String[] baseStat = {"STR","DEX","CON","INT","WIS","CHA"};
        int intLevel, intAge; // Bio
        int baseStr, baseDex, baseCon, baseInt, baseWis, baseCha; // Base Ability Scores
        int modStr, modDex, modCon, modInt, modWis, modCha; // Ability Score Modifier
        
        // ===== BIO =====
        // Set Level
        intLevel = 1;

        // Enter Age
        intAge = 45;

        // Select Race
        bioGenerator newRace = new bioGenerator();
        selRace = newRace.getNewRace();
        int selRaceIndex = newRace.getRaceIndex();

        // Select Class
        bioGenerator newClass = new bioGenerator();
        selClass = newClass.getNewClass();
        int selClassIndex = newClass.getClassIndex();

        // ===== BASE SCORES =====
        // Obtain Base Ability Scores and create pre-set array
        baseScoreCalc newBaseStats = new baseScoreCalc();
        int[] allStats = new int[6]; // 0 STR, 1 DEX, 2 CON, 3 INT, 4 WIS, 5 CHA

        // Get a score and assign it to an index
        for(int x=0;x<6;x++) {
            int rollResults = newBaseStats.getScore();
            allStats[x] = rollResults;
        }

        // Get Race benefits to base scores
        int[] baseBenefits = newRace.getRaceBenefits();
        for (int z=0;z<baseBenefits.length;z++) {
            allStats[z] = allStats[z] + baseBenefits[z];
        }

        // Set scores based on Class Recommendations
        int[] bestScoreSet = newBaseStats.sortScore(selClassIndex);
        int[] sortedBaseScore = allStats;
        int[] sortedStats = new int[6];

        Arrays.sort(sortedBaseScore);

        for(int x=0;x<6;x++) {
            // Get preset
            int prefStat = bestScoreSet[x];

            // Grab to index 0 of sorted base scores and set it to correct index in allStats
            sortedStats[prefStat] = sortedBaseScore[x];
        }
        
        // ===== SCORE MODIFIERS =====
        // Obtain Base Ability Modifiers
        baseScoreCalc newStatMods = new baseScoreCalc();
        int[] allModifiers = new int[6]; // 0 STR, 1 DEX, 2 CON, 3 INT, 4 WIS, 5 CHA

        // Calculate Score modifier
        for(int y=0;y<6;y++) {
            int modResult = newStatMods.getModifier(allStats[y]);
            allModifiers[y] = modResult;
        }

        // ===== SAVING THROWS =====
        // Create new Object
        charSheet savingThrows = new charSheet();

        // Calculate saving throws


        // ===== OUTPUT =====
        System.out.println("===== YOUR NEW CHARACTER =====");
        System.out.println("Character Name: ");
        System.out.println("Class: " + selClass + "\tLevel: " + intLevel);
        System.out.println("Race: " + selRace + "\tAge: " + intAge);
        System.out.println("--Base Stats-- \t|| Mod");
        System.out.println("~~~~~~~~~~~~~~~~~~~~~~");
        // Display Base Stats
        for(int x=0;x<6;x++) {
            System.out.println(baseStat[x] + " - " + sortedStats[x] + "  \t||  " + allModifiers[x]);
        }
    }
}
