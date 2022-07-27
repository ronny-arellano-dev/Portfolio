# Guessing Game V1
# Author: Ronny Arellano
# Purpose: Guessing Game

import random

# Choose random number and start lists
number = random.randint(1,100)
choices = []
diff = []
closest = []

# Print number - for testing purposes
print(number)

# Ask for number of players and make into an int variable
players = input("Enter the number of players: ")
players = int(players)

# For each player, enter a number
counter = 1
while counter <= players:
    numPick = input(f"Enter the number for player {counter}: ")
    isUnique = choices.count(numPick)

    # Make sure choice is unique
    while isUnique >= 1:
        print("That number is already picked.")
        numPick = input(f"Choose another number for player {counter}: ")
        isUnique = choices.count(numPick)

    # add the unique choice to list
    choices.append(numPick)
    counter = counter + 1

# go through choices and find the winner
for choice in choices:

    # Check the difference between choice and answer
    winPlayer = choices.index(choice)
    winPlayer = winPlayer + 1
    if int(choice) < number:
        delta = number - int(choice)
        diff.append(delta)
        print(f"Choice for Player {winPlayer} was less than {number} by {delta}")
    elif int(choice) > number:
        delta = int(choice) - number
        diff.append(delta)
        print(f"Choice for Player {winPlayer} was greater than {number} by {delta}")
    elif choice == str(number): 
        delta = 0
        diff.append(delta)
        print(f"Choice for Player {winPlayer} was spot on!!!")

lowest = diff.index(min(diff)) + 1
if min(diff) == 0:
    print(f"Player {lowest} is the winner!!!")
elif diff.count(lowest):
    print(f"Closest Player was player {lowest}.")
