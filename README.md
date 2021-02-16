this is meant to be used with an external admin tool such as IW4M or B3
you will need to modify teknomw3 parser for respected admin tool

go to iw4m root folder and find plugins folder
edit ParserTeknoMW3.js use your prefered text editor
and find these lines
rconParser.Configuration.CommandPrefixes.Tell = 'tell {0} {1}';

rconParser.Configuration.CommandPrefixes.Say = 'say {0}';

and replace with this below

rconParser.Configuration.CommandPrefixes.Tell = 'set sv_RconExecute tell {0} {1}';

rconParser.Configuration.CommandPrefixes.Say = 'set sv_RconExecute say {0}';

# Rconsay before using script

default dvar values

sv_sayname "^7console:"

sv_pmsayname "^7PM:"

^^^^^^^^^^^ if you dont add dvars to server.cfg these will be default prefixs

you will need to add 2 dvars to your server.cfg file located in players2 folder inside of teknomw3 dedicated server folder

seta sv_sayname "mypublicprefix"

seta sv_pmsayname "myprivateprefix"

with prefix dvars set
![default without setting dvars](https://user-images.githubusercontent.com/68487146/108092381-939d2a00-7074-11eb-9ce6-9ddc27acc0d5.PNG)

without prefix dvars set this is default
https://user-images.githubusercontent.com/68487146/108092381-939d2a00-7074-11eb-9ce6-9ddc27acc0d5.PNG
