basically full credit to https://github.com/JakubNei/mcs-ICodeCompiler, which uses MCS to compile code
I didn't make the compiler or anything myself, just the file related stuff and all that. Basically stuff to make it customized towards my own use case.

Set the API compatibility level to .Net Framework in the player settings for the compiler to work properly. For some reason it breaks and gives a bunch of errors if you don't.

This is largely meant for personal use (because there are like 4 trillion better ways to implement modding into your unity games, I just didn't know about them when I was trying to get this working and sunk-cost fallacy hits HARD) but if anyone is using this I hope it serves you well in your game(s). 

If you have any feedback for things that should be added in by default (utility functions like the image api, menus, etc.) please email me at chazzwazzlerdev@gmail.com with your suggestions, that is where I will be most likely to see it. 

I would like to develop this further to make it easier for modders, developers, and mod users to do things involving mods because I believe modding is a very important part of any games. I use this mod thing, so it is as beneficial for me to have it improved as it is for you. So feedback along with the kind of functions you like giving to modders is very welcome (I am not creative enough nor experienced enough in modding to know what a modder needs to build really good mods). 

CWMod Version 0.1.0b
Read HOWTOUSE.txt to figure out how to mod your games and use the built in functions. 