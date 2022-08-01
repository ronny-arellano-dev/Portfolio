package com.redwidow.charactergenerator;

import java.util.Arrays;

public class baseScoreCalc {
    // Global Variables
    static int baseScore;
    static int[] rollResults = new int[4];
    static int[] prefStatSetup = new int[6];
    static int getScore() {
        // New Dice Roll Object
        diceRoller abScore = new diceRoller();

        // Set parameters to use 4d6, per PHB standard
        abScore.intTotal = 0;
        abScore.numRolls = 0;
        abScore.intSides = 6;

        // Obtain the outcome of the top 3 rolls and return
        for(int x=0;x<4;x++) {
            int abScoreRoll = abScore.getRoll();
            rollResults[x] = abScoreRoll;
        }

        // Sort Results
        Arrays.sort(rollResults);

        baseScore = rollResults[1] + rollResults[2] + rollResults[3];

        // Return base Score
        return baseScore;
    }

    static int getModifier(int baseScore) {
        // Get Base Score
        int scoreModifier;

        // If Base Score is odd, subtract 1.
        if(baseScore % 2 == 0) {
            scoreModifier = (baseScore / 2) - 5;
        }
        else scoreModifier = ((baseScore - 1) / 2) - 5;

        return scoreModifier;
    }

    static int[] sortScore(int sortClass) {
        // Array to represent which class index is preferred. Least to Best
        // 0 STR, 1 DEX, 2 CON, 3 INT, 4 WIS, 5 CHA

        // Set prefStatSetup based on Class
        // 0 Barbarian, 1 Bard, 2 Cleric, 3 Druid, 4 Fighter, 5 Monk, 6 Paladin, 7 Ranger, 8 Rogue, 9 Sorcerer, 10 Warlock, 11 Wizard
        switch (sortClass) {
            case 0: // Barbarian
                //prefStatSetup = {5,4,3,1,2,0};
                prefStatSetup[0] = 5;
                prefStatSetup[1] = 4;
                prefStatSetup[2] = 3;
                prefStatSetup[3] = 1;
                prefStatSetup[4] = 2;
                prefStatSetup[5] = 0;
                break;
            case 1: // Bard
                //prefStatSetup = {0,4,1,2,3,5};
                prefStatSetup[0] = 0;
                prefStatSetup[1] = 4;
                prefStatSetup[2] = 1;
                prefStatSetup[3] = 2;
                prefStatSetup[4] = 3;
                prefStatSetup[5] = 5;
                break;
            case 2: // Cleric
                //prefStatSetup = {0,5,2,1,3,4};
                prefStatSetup[0] = 0;
                prefStatSetup[1] = 5;
                prefStatSetup[2] = 2;
                prefStatSetup[3] = 1;
                prefStatSetup[4] = 3;
                prefStatSetup[5] = 4;
                break;
            case 3: // Druid
                //prefStatSetup = {0,5,1,2,3,4};
                prefStatSetup[0] = 0;
                prefStatSetup[1] = 5;
                prefStatSetup[2] = 1;
                prefStatSetup[3] = 2;
                prefStatSetup[4] = 3;
                prefStatSetup[5] = 4;
                break;
            case 4: // Fighter
                //prefStatSetup = {3,4,2,5,1,0};
                prefStatSetup[0] = 3;
                prefStatSetup[1] = 4;
                prefStatSetup[2] = 2;
                prefStatSetup[3] = 5;
                prefStatSetup[4] = 1;
                prefStatSetup[5] = 0;
                break;
            case 5: // Monk
                //prefStatSetup = {0,2,5,3,1,4};
                prefStatSetup[0] = 0;
                prefStatSetup[1] = 2;
                prefStatSetup[2] = 5;
                prefStatSetup[3] = 3;
                prefStatSetup[4] = 1;
                prefStatSetup[5] = 4;
                break;
            case 6: // Paladin
                //prefStatSetup = {3,1,2,4,5,0};
                prefStatSetup[0] = 3;
                prefStatSetup[1] = 1;
                prefStatSetup[2] = 2;
                prefStatSetup[3] = 4;
                prefStatSetup[4] = 5;
                prefStatSetup[5] = 0;
                break;
            case 7: // Ranger
                //prefStatSetup = {0,5,2,3,1,4};
                prefStatSetup[0] = 0;
                prefStatSetup[1] = 5;
                prefStatSetup[2] = 2;
                prefStatSetup[3] = 3;
                prefStatSetup[4] = 1;
                prefStatSetup[5] = 4;
                break;
            case 8: // Rogue
                //prefStatSetup = {5,0,2,3,4,1};
                prefStatSetup[0] = 5;
                prefStatSetup[1] = 0;
                prefStatSetup[2] = 2;
                prefStatSetup[3] = 3;
                prefStatSetup[4] = 4;
                prefStatSetup[5] = 1;
                break;
            case 9: // Sorcerer
                //prefStatSetup = {0,1,2,3,4,5};
                prefStatSetup[0] = 0;
                prefStatSetup[1] = 1;
                prefStatSetup[2] = 2;
                prefStatSetup[3] = 3;
                prefStatSetup[4] = 4;
                prefStatSetup[5] = 5;
                break;
            case 10: // Warlock
                //prefStatSetup = {1,0,3,2,4,5};
                prefStatSetup[0] = 1;
                prefStatSetup[1] = 0;
                prefStatSetup[2] = 3;
                prefStatSetup[3] = 2;
                prefStatSetup[4] = 4;
                prefStatSetup[5] = 5;
                break;
            case 11: // Wizard
                //prefStatSetup = {0,1,2,5,4,3};
                prefStatSetup[0] = 0;
                prefStatSetup[1] = 1;
                prefStatSetup[2] = 2;
                prefStatSetup[3] = 5;
                prefStatSetup[4] = 4;
                prefStatSetup[5] = 3;
                break;
        }

        return prefStatSetup; 
    }
}
