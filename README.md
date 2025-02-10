# RoundStartSound

**RoundStartSound** is a simple yet fun plugin designed to enhance the experience of any game by playing sound effects when a round starts. Whether it's an epic "Prepare to Battle!" announcement or a countdown from 5 to 1, this plugin adds a layer of excitement to every new round.

## Features

- Plays a customizable sound effect at the start of each round.
- Optional countdown feature (5, 4, 3, 2, 1) before the round begins.
- Easy to configure and lightweight, perfect for any server setup.

## How It Works

1. When a new round starts, the plugin triggers a predefined sound effect.
2. If the countdown option is enabled, the plugin will play countdown sounds leading up to the round start.
3. You can customize the sound effects to match your game style or mood.

## Dependencies

To run this plugin, you need the following dependencies:

1. **Metamod:Source (2.x)**  
   Download from: [Metamod:Source Official Site](https://www.sourcemm.net/downloads.php/?branch=master)

2. **CounterStrikeSharp**  
   You can get it from: [CounterStrikeSharp GitHub Releases](https://github.com/roflmuffin/CounterStrikeSharp/releases)

3. **MultiAddonManager** *(optional)*  
   Download from: [MultiAddonManager GitHub Releases](https://github.com/Source2ZE/MultiAddonManager/releases)  

   - If you want to play a sound when the round starts, this plugin is required. You can use your own custom sounds, but no detailed tutorial is provided. Feel free to search online for help with adding custom sound files.
   - Alternatively, if you'd like to use pre-configured sounds, visit this link: [Steam Workshop Sounds](https://steamcommunity.com/sharedfiles/filedetails/?id=3420306144).  

   **Setup for Sounds:**
   - To enable the sounds, you must add the `3420306144` ID to the `multiaddonmanager.cfg` file.  
   - Path to file: `game/csgo/cfg/multiaddonmanager/multiaddonmanager.cfg`.  
   - Add the ID under the `mm_extra_addons` section, for example:  
     ```json
     "....,3420306144"
     ```
