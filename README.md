# RoundStartSound

**RoundStartSound** is a simple yet fun plugin designed to enhance the experience of any game by playing sound effects when a round starts. Whether it's an epic "Prepare to Battle!" announcement or a countdown from 5 to 1, this plugin adds a layer of excitement to every new round.

## Features

- Plays a customizable sound effect at the start of each round.
- Optional countdown feature (5, 4, 3, 2, 1) before the round begins.
- Choose between male or female voice for the countdown sounds.
- Easy to configure and lightweight, perfect for any server setup.

## How It Works

1. When a new round starts, the plugin triggers a predefined sound effect.
2. If the countdown option is enabled, the plugin will play countdown sounds leading up to the round start.
3. You can choose whether the countdown uses a male or female voice.
4. Customize the sound effects to match your game style or mood.

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
## Configuration Tutorial

Below is a step-by-step guide explaining the available configuration options for **RoundStartSound**. These settings allow you to customize how the plugin behaves and interacts with players.

### General Settings

1. **`enable_roundstart_chat_message`**  
   - **Possible Values**: `true`, `false`  
   - **Description**: If set to `true`, a chat message will be displayed when the round starts.  
     - `true`: Chat message is displayed.  
     - `false`: Chat message is not displayed.

2. **`enable_countdown_chat_message`**  
   - **Possible Values**: `true`, `false`  
   - **Description**: If set to `true`, a countdown message will be displayed in chat before the round starts.  
     - `true`: Countdown message is displayed in chat.  
     - `false`: Countdown message is not displayed.

3. **`enable_countdown_on_freezetime`**  
   - **Possible Values**: `true`, `false`  
   - **Description**: If set to `true`, countdown sounds will play during the freeze time before the round starts.  
     - `true`: Countdown sounds are played.  
     - `false`: Countdown sounds are not played.

4. **`countdown_from_x_to_zero`**  
   - **Possible Values**: Integer (maximum value: 10)  
   - **Description**: Specifies the starting number for the countdown, counting down to zero.  
     - Example: `10` will countdown from 10 to 0.  
     - Note: This is only effective if the freeze time allows the countdown duration.

5. **`use_man_countdown_voice`**  
   - **Possible Values**: `true`, `false`  
   - **Description**: Determines the voice type used for the countdown.  
     - `true`: Male voice is used for the countdown.  
     - `false`: Female voice is used for the countdown.

6. **`sounds`**  
   - **Type**: Array of objects  
   - **Description**: Defines the custom sounds to be played. Each object in the array consists of the following fields:  
     - **`chat_text`**: (String) A key from the `en.json` file used for custom language support. For example, `play.chat` is mapped to its respective translation.  
     - **`path`**: (String) File path to the sound effect.  
     - **`can_play`**: (Boolean) Determines if the sound can be played.  
       - `true`: The sound will be played.  
       - `false`: The sound will not be played.

7. **`male_countdowns`**  
   - **Type**: Array of strings  
   - **Description**: Specifies the file paths for the male countdown sound effects.

8. **`female_countdowns`**  
   - **Type**: Array of strings  
   - **Description**: Specifies the file paths for the female countdown sound effects.
