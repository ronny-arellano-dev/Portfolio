package com.redwidow.charactergenerator;

import java.util.Random;

public class diceRoller {
    static int intSides=1, intNumDice=1, intTotal, numRolls=0;
    static int[] allRolls;

    static int getRoll() {
        Random dieRollNum = new Random();
        allRolls = new int[intNumDice];

        intTotal = 0;

        // DEBUG
        //System.out.println("\t===== STARTING ROLLS =====");

        // Create separate random rolls and keep track
        for(int x = 0; x < intNumDice; x++){

            // Obtain Die roll result
            int dieRoll = dieRollNum.nextInt(intSides);
            dieRoll = dieRoll + 1;

            // Get the count of rolls
            numRolls = x;

            // Add dieRoll to numRolls based on last count
            allRolls[numRolls] = dieRoll;

            // DEBUG
            //System.out.println("\tRoll " + (numRolls + 1) + " is " + dieRoll + ".");
        }

        // Get Total
        int rollCount = allRolls.length;
        for(int y=0;y<rollCount;y++){
            intTotal = intTotal + allRolls[y];

            // DEBUG
            //System.out.println("\tYour total so far is " + intTotal);
        }

        // DEBUG
        //System.out.println("\tRolled " + rollCount + " times.");

        // Return Roll Total
        return intTotal;
    }

}
