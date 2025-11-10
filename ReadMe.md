# Roll-a-Ball

## Demo
https://drive.google.com/file/d/1yEosRKMylxHZSLhmwANJisCXdobr3o0Y/view?usp=drive_link

## Tutorial source
https://learn.unity.com/course/roll-a-ball/tutorial/setting-up-the-game?version=6.0#66f2da05edbc2a01279b91c9

## Customizations
- Splash (Start/Quit)
- Pause/Options (Esc) with Volume


# Roll-a-ball update V1.1

## Added feature with save and load system
Storage mechanism Considered 
| Method                        | Pros                                                                                    | Cons                                                                 |
| ----------------------------- | --------------------------------------------------------------------------------------- | -------------------------------------------------------------------- |
| **PlayerPrefs**               | Very easy to use                                                                        | Only supports int/float/string. Not safe. Not good for game progress |
| **JSON File Serialization**   | Can save complex data (score + player position). Easy to debug and edit. Cross-platform | File can be modified by user. Needs a data class                     |
| **Binary Serialization**      | Fast and secure. Smaller file size                                                      | Hard to debug. Can break if data format changes                      |

And overall i chose JSON file because i need to save score and player ball pos, and is really easy to test it out most iportantly it can be extended easily after.

## Demo
https://drive.google.com/file/d/193sExEZVrwaiB7a9kFdnOAf5IpbRL0Eb/view?usp=sharing