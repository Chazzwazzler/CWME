The CW Mod Engine (CWME) is a mod engine using [mcs-ICodeCompiler](https://github.com/JakubNei/mcs-ICodeCompiler) to run C# code at runtime, long with some utilities and file loading/conversion scripts to make it more useful for modding.

**CWME has to be added to the actual unity project of the game. This is meant as a way for developers to officially add mod support to their games.**

## Installing & Setting Up CWME

CD into where you wish to download the folder for CWME, and run the following command (git must be installed): `git clone https://github.com/Chazzwazzler/CW-Mod.git`

You should probably download CWME into the Assets folder of your Unity project.

If you do not wish to install git or use the command line, you can download the main branch as a zip folder from [this link](https://github.com/Chazzwazzler/CW-Mod/archive/refs/heads/main.zip).

### If adding CWME to your project gives you errors

Set the API compatibility level to .Net Framework in the Player category of your project settings for mcs-ICodeCompiler to work properly. This should resolve any errors coming from the compiler scripts.

## Suggestions, issues, and contributions

If you have any feedback for things that should be added to CWME please email me at chazzwazzlerdev@gmail.com with your suggestions, that is where I will be most likely to see it. It's best to post issues on the issues page on the repository so that other people can see it.

I, and I'm sure anyone using CWME, would be very grateful if you were to contribute to CWME. It takes a load off my shoulders and improves the mod engine for everyone, including me, since I am going to be using it in my current game project.


