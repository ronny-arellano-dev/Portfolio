package com.redwidow.charactergenerator;

import java.util.Arrays;

public class baseScoreCalc {
    // Global Variables
    static int baseScore;
    static int[] rollResults = new int[4];
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

            // DEBUG
            //System.out.println("Ability Roll " + (x + 1) + " came out to " + abScoreRoll);
        }

        // DEBUG
        //System.out.println("===== ABILITY SCORE ROLLS =====");

        // Sort Results
        Arrays.sort(rollResults);
        String strRollResults = Arrays.toString(rollResults);

        // DEBUG
        //System.out.println("Results are sorted as follows: " + strRollResults);

        baseScore = rollResults[1] + rollResults[2] + rollResults[3];

        // DEBUG
        //System.out.println("Returning baseScore of " + baseScore);

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
}
