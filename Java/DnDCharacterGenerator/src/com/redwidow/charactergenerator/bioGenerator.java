package com.redwidow.charactergenerator;

import java.util.Arrays;
import java.util.Random;

public class bioGenerator {
    // Global Lists
    static String[] lstRace = {"Dwarf","Elf","Halfing","Human","Dragonborn","Gnome","Half-Elf","Half-Orc","Tiefling"};
    static String[] lstClass = {"Barbarian","Bard","Cleric","Druid","Fighter","Monk","Paladin","Ranger","Rogue","Sorcerer","Warlock","Wizard"};

    // Global Variables
    static int raceIndex;
    static int classIndex;

    // Get Race Index
    static int getRaceIndex() {
        return raceIndex;
    }

    // Get Race
    static String getNewRace(){
        Random rollRace = new Random();
        int raceRoll = rollRace.nextInt(lstRace.length);
        raceIndex = raceRoll;
        String pickedRace = lstRace[raceRoll];

        return pickedRace;
    }

    // Get Race Score Benefits
    static int[] getRaceBenefits() {
        int[] raceStatBenefits = new int[6]; // 0 STR, 1 DEX, 2 CON, 3 INT, 4 WIS, 5 CHA
        Arrays.fill(raceStatBenefits, 0); //  0 Dwarf, 1 Elf, 2 Halfing, 3 Human, 4 Dragonborn, 5 Gnome, 6 Half-Elf, 7 Half-Orc, 8 Tiefling

        // Switch Cases
        switch (raceIndex) {
            case 0:
                raceStatBenefits[2] = 2;
                break;
            case 1:
                raceStatBenefits[1] = 2;
                break;
            case 2:
                raceStatBenefits[1] = 2;
                break;
            case 3:
                Arrays.fill(raceStatBenefits, 1);
                break;
            case 4:
                raceStatBenefits[0] = 2;
                raceStatBenefits[5] = 1;
                break;
            case 5:
                raceStatBenefits[3] = 2;
                break;
            case 6:
                raceStatBenefits[0] = 1;
                raceStatBenefits[1] = 1;
                raceStatBenefits[5] = 2;
                break;
            case 7:
                raceStatBenefits[0] = 2;
                raceStatBenefits[2] = 1;
                break;
            case 8:
                raceStatBenefits[3] = 1;
                raceStatBenefits[5] = 2;
                break;
        }

        // Return array of modifiers from Race
        return raceStatBenefits;
    }

    // Get Class Index
    static int getClassIndex() {
        return classIndex;
    }

    // Get Class
    static String getNewClass(){
        Random rollClass = new Random();
        int classRoll = rollClass.nextInt(lstClass.length);
        classIndex = classRoll;
        String pickedClass = lstClass[classRoll];

        return pickedClass;
    }
}
