# Mass Unzipper v1
# Author: Ronny Arellano
# Purpose: Goes through a folder of Zipped folders and extracts them automatically

import zipfile
import os
from time import sleep
from tqdm import tqdm # Supposed to add progress bar/ Need plugin

#for i in tqdm(range(10)):
    #sleep(3)

#-- Global Varibles--
# File path variables
zipFolder = "Z:/Audio/Humble_Bundles/Big_Music_Bundle/" # /directory housing the zipped folders with / at the end
files_in_dir = [] # Empty array 
delZip = ""

# Make a list of all zip folders
for r, d, f in os.walk(zipFolder):
    for item in f:
        onlyZip = item.split('.')

        if onlyZip[1] == "zip":
            files_in_dir.append(os.path.join(item))

# Ask to delete zipped folder after extract
askToDel = input("Do you want the zip folder to be removed in order to save disk space? (Y/N): ")
askToDel = askToDel.lower()

print(askToDel)

if askToDel == "y":
    print("All the folders will be deleted as they are extracted.")
    delZip = True
else:
    delZip = False

print(delZip) #DEBUG print

# Unzip each folder. TQDM is a progress bar for how many zip folders have been extracted.
for item in tqdm(files_in_dir, desc="Unzipping ",leave=True):
    newDir = item.split('.')
    newPath = zipFolder + newDir[0]
    zipPath = zipFolder + item

    with zipfile.ZipFile(zipPath, 'r') as zip_ref:
        zip_ref.extractall(newPath)
    
    print("\nSecond " + str(delZip)) #DEBUG print

    if delZip == True:
        os.remove(zipPath)
        print("\n\n>>>>>>>>>>>> " + item + " has been extracted and original zip has been removed.")
    else:
        print("\n\n>>>>>>>>>>>> " + item + " has been extracted. Original zip is intact.")

    sleep(0.1)