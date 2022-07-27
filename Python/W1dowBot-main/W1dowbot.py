from asyncio import AbstractEventLoopPolicy
from asyncore import write
from email import message
from ntpath import join
import os
from pickle import EMPTY_LIST
from queue import Empty
from turtle import color
import discord
import random
import dbConnect
import mysql.connector
from mysql.connector import errorcode
from discord.ext import commands
from dotenv import load_dotenv

# Connect Bot
load_dotenv()
TOKEN = os.getenv('DISCORD_TOKEN')

client = discord.Client()

bot = commands.Bot(command_prefix='>')

# Connect to database
dbConnectStart = dbConnect.dbConnect()
print(dbConnectStart)

# Client
@client.event
async def on_ready():
    print(f'{client.user} has connected!!')

# GLOBAL VARIABLES
icnPlayerList = []  #I Call Next Player List - needs to load when the bot starts to maintain list memory

# COMMANDS
## Dice Roll
@bot.command(name='dice',help='Enter >dice # #, where the # represent the number of sides and number of dice to roll.')
async def dice_roll(ctx,numSides: int=0,numDice: int=0):
    
    # Command Validation
    
    print(f'The options were numSides - {numSides} and numDice = {numDice}')
    if numSides == 0 and numDice == 0:
        message = 'You need to enter the number of sides and number of dice to roll.'
    elif numSides > 0 and numDice == 0:
        message = f'You forgot to tell me how many d{numSides} to roll.'
    else:
        # local variables
        total = 0
        counter = 0
        rollLog = []
        
        # Loop through the rolls and add the total
        while counter < numDice:
            rollValue = random.randint(1, numSides)
            total = total + rollValue
            counter += 1
            rollLog.append(rollValue)
        
        message = f'Your total roll was {total}! The rolls came out as follows: {rollLog}'
    
         
    await ctx.send(message)
 
 ## Events
@bot.command(name='events',help='View upcoming events.')
async def view_events(ctx,eventType: str=None):
    cmdEntered = 'events'
    eventList = ['list','this']
    print(eventType)
    if eventType is None:
        events = 'What about the events?'        
    else:
        events = eventList
    
    print(eventType)
    await ctx.send(events)

## Magic 8 Ball
@bot.command(name='magic8',help='Type in your question after >magic8')
async def magic_8ball(ctx, question: str=None):
    # Possible Answers
    
    answerList = ['It is certain',
                  'It is decidedly so',
                  'Without a doubt',
                  'Yes definitely',
                  'You may rely on it',
                  'As I see it, yes',
                  'Most likely',
                  'Yes',
                  'Signs point to yes',
                  'Reply Hazy, try again',
                  'Ask again later',
                  'Better not tell you now',
                  'Cannot predict now',
                  'Concentrate and ask again', 
                  'Don\'t count on it',
                  'My reply is no',
                  'My sources say no',
                  'Outlook not so good',
                  'Very doubtful']
    
    if question is None:
        answer = 'You gotta ask a question, ya peasant. Make sure it\'s surrounded with double quotes.'
    else:
        answer = random.choice(answerList)
    
    await ctx.send(answer)

@bot.command(name='icn',help='I Call Next')
async def iCallNext(ctx, cmdList: str=None,cmdExtraOne: str=None,cmdExtraTwo: str=None):

    # Variables
    embedTitle = ''
    embedDesc = ''
    customError = f'You enter a bad command. Type \'>icn help\' to see the available options.'

    # Case statements
    match cmdList:
        case 'help':
            embedTitle = f'Who asks for help???'
            embedDesc = f'Welcome to funky town, bitchachos!'
        case 'list':
            match cmdExtraOne:
                case 'show':
                    embedTitle = f'Current List'
                    if not icnPlayerList:
                        embedDesc = f'The list is currently Empty...'
                    else:
                        embedDesc = f'Current Players on the list: \n{icnPlayerList}'
                case 'clear':
                    embedTitle = f'Clearing List'
                    if not icnPlayerList:
                        embedDesc = f'List is already clear.'
                    else:
                        icnPlayerList.clear()
                        embedDesc = f'We have cleared the List. \n{icnPlayerList}'
                case 'add':
                    embedTitle = f'Adding to List'
                    if cmdExtraTwo is None:
                        embedDesc = f'You need to include the name, bozo.'
                    else:
                        player = cmdExtraTwo.lower()
                        if player in icnPlayerList:
                            embedDesc = f'{cmdExtraTwo} is already on the list'
                        else:
                            multiPlayer = player.split(',')
                            for name in multiPlayer:
                                icnPlayerList.append(name)
                            embedDesc = f'Add {cmdExtraTwo} to the List: \n{icnPlayerList}.'
                case 'remove':
                    embedTitle = f'Removing from List'
                    if cmdExtraTwo is None:
                        embedDesc = f'You need to include the name, bozo.'
                    else:
                        player = cmdExtraTwo.lower()
                        if player in icnPlayerList:
                            icnPlayerList.remove(player)
                            embedDesc = f'Removed {cmdExtraTwo} from the List: \n{icnPlayerList}.'                            
                        else:
                            embedDesc = f'{cmdExtraTwo} is not on the list' 
                case _:
                    embedTitle = f'Who asks for help???'
                    embedDesc = customError
        case 'match':
            embedTitle = f'Matchmaking'
            if not icnPlayerList:
                embedDesc = f'The Player list is empty. Please use the \'>icn list\' commands to create a list first'
            else:
                if cmdExtraOne is None:
                    embedDesc = f'You need to enter the number of players on each team separated by a space. \'1 1\' for a 1v1 or \'2 1\' for a 2v1. Entering a single digit will make both sides the same.'
                else:
                    if cmdExtraTwo is None:
                        cmdExtraTwo = cmdExtraOne

                    matchedPlayers = matchMaker(int(cmdExtraOne), int(cmdExtraTwo))
                    embedDesc = matchedPlayers
        case _:
            embedDesc = customError

    # Send Embeded Message
    embedMsg = discord.Embed(
            title = embedTitle,
            description = embedDesc,
        )

    await ctx.send(embed=embedMsg)

### CUSTOM FUNCTIONS ###

# Team Matchmaker
def matchMaker(tOneSize: int=None,tTwoSize: int=None):
    allPlayers = icnPlayerList
    numPlayers = len(allPlayers)
    teamOne = []
    teamTwo = []
    teamSize = tOneSize + tTwoSize

    if numPlayers < teamSize:
        playersNeeded = teamSize - numPlayers
        matchResults = f'There aren\'t enough players for a {tOneSize}v{tTwoSize}. You need {playersNeeded} more player(s) ' 
    else:
        while len(teamOne) < tOneSize:
            print(f'Team one length({tOneSize}): {len(teamOne)}')
            selPlayer = random.choice(allPlayers)
            teamOne.append(selPlayer)
            allPlayers.remove(selPlayer)
        
        while len(teamTwo) < tTwoSize:
            print(f'Team one length({tTwoSize}): {len(teamOne)}')
            selPlayer = random.choice(allPlayers)
            teamTwo.append(selPlayer)
            allPlayers.remove(selPlayer)

        tOne = ' '.join(teamOne)
        tTwo = ' '.join(teamTwo)
        matchResults = f'Here is the next matchup! \n{tOne} \n VS \n{tTwo}'
            
    return matchResults

bot.run(TOKEN)