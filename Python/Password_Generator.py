# Password Generator v1
# Author: Ronny Arellano
# Purpose: Create temporary passwords and autosave them to a text file.

import random
import os

alphaNum = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()-_=+"

length = input("Enter length of the password: ")
pwdGen = ""

for i in range(int(length)):
    pwdGen = pwdGen + random.choice(alphaNum)

print(pwdGen)

save = input("\nWould you like to save it? Y/N: ")
if save == 'y':
    saveName = input("Name the file: ")
    saveName = saveName + ".txt"

    file = open(saveName, "w+")
    file.write(pwdGen)
    file.close()

else:
    print("Thank you for using this Password Generator. Good bye.")
