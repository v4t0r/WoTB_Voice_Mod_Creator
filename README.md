# WoTB_Voice_Mod_Creator
It is software that automatically creates, builds, and adapts projects without knowing how to use Wwise. <br>
As a bonus, it is equipped with battle BGM creation and a mysterious music player. <br>
Please refer to the Youtube video for how to operate<br>
Please contact SRTTbacon#2395 if you have any bugs, problems, or anything you don't understand! <br>
Since I changed from V1.2.7 to .NetFramework4.6.1, Windows 7 etc. need to be downloaded and installed from Microsoft. <br>
<br>
Download: https://drive.google.com/file/d/1LeF1SLOf7FYvUND4GDYn7IvN63BUfg-n/view<br>
The difference between Wwise_Class/V1 and V2 in the source is that V1 handles .pck files and V2 handles .bnk files. <br>
<br>
# V1.5.3.7<br>
・Added a function that allows you to create voice mods for the PC version of WoT<br>
Added the ability to generate a Wwise project when creating an audio mod<br>
<br>
# V1.5.3<br>
・Added a function that can convert WoWS voice mods to save files (*.wvs format)<br>
・Added a function that allows you to copy and paste the voices added to the list when creating voice mods<br>
-Added a function to change the name of already added songs in the music player<br>
・Added a console application that can update software<br>
・Other minor bug fixes and specification changes<br>
<br>
# V1.5.2<br>
・Corresponds to WoTB's artillery sound specifications that have been changed<br>
・Fixed an issue where the SE settings were strange<br>
・Other specifications changed<br>
<br>
# V1.5.1<br>
-Fixed an issue where SE-related settings could not be made when creating a voice mod<br>
・Changed so that when loading a .bnk file of gunfire sound in Wwise Player, it can be played separately for normal time and zoom time<br>
- Fixed an issue in Wwise Player where the software would crash when performing certain actions<br>
<br>
# V1.5.0<br>
-Added a function that allows you to operate effects, playback time settings, probability, etc. for each sound or event in the sound mod<br>
・Increase the SE that is played during battle (see directly on the Mod Creator or on Discord for details)<br>
- Changed not to connect to the server in preparation for service termination. This entails the following restrictions<br>
--- Removal of some features of Tools V1 for WoTB<br>
--- Removed splitting between vocals and instruments in music player (works when downloaded & run locally)<br>
--- Changed to prevent distribution of mods (download is possible)<br>
--- Deletion of other functions that interact directly with the server, such as checking for updates, messaging, and chat<br>
- Changed the music player to embed 4 thumbnail images in the MP3 file when obtained from Youtube. Also added a function to change the image according to the playback time (only for songs longer than 1 minute)<br>
・Added English version (just modified Google translation)<br>
-Fixed a serious bug related to save files including sounds in the sound mod<br>
・Other minor bug fixes and specification changes<br>
<br>
# V1.4.9.8<br>
-Fixed the problem that even if SE is disabled in voice production, it will be added without permission<br>
・In "Blitz to WoT", changed so that SE is automatically deleted when adding a .bnk file<br>
・In "Blitz to WoT", fixed so that the color of items with voice disabled is changed<br>
・Fixed the problem that the sound lag may occur in the music player (?)<br>
- Fixed a problem that can not be updated normally from within the software (probably)<br>
-Fixed the problem that the track restoration event was not played in the audio mod (sorry...)<br>
・Other small specification changes<br>
<br>
V1.4.9.7<br>
・Added a check that can turn echo on and off in the music player<br>
- Fixed an issue that caused an error in some .bnk files when porting from WoT<br>
<br>
V1.4.9.6<br>
-Added an option to include sound when saving save data on the sound mod creation screen (If you check it, you can start it on another PC or move the sound, and the error will not appear)<br>
-Fixed the problem that playback stopped in a specific environment when changing the sound device in the music player<br>
・In the music player, while pressing the left Ctrl key, the -5 seconds and +5 seconds buttons are changed to -10 seconds and +10 seconds<br>
<br>
V1.4.9.5<br>
・Fixed the problem that it becomes inoperable after downloading data (Occurred in V1.4.9.4)<br>
<br>
V1.4.9.4<br>
・Fixed an issue where mods were not created properly depending on the environment<br>
・Added a function to apply Low (High) Pass Filter and echo to the music player<br>
- Changed so that the playback speed can be initialized with the S + R key on the music player<br>
<br>
V1.4.9.3<br>
- Convert software to 64Bit (may affect operation speed somewhat)<br>
・According to ↑, the version of Bass Audio Library is updated (used for most sound related)<br>
・Improved speed when retrieving from Youtube<br>
- In the music player, you can change the playback speed and volume with the left and right keys, and the S and V keys + left and right keys, just like sound editing.<br>
・Improved the sound lag when changing the playback speed on the music player<br>
-Fixed an issue where the music player would change without permission when switching to another screen and opening the music player again<br>
・Reduced delay when changing playback speed or pitch on music player<br>
・Fixed an issue with the password checkbox when editing mods distributed within the software.<br>
-Fixed a problem that caused a crash in a specific environment when pressing the "Port from FSB" button<br>
・When porting to the PC version of WoT, change so that non-penetrating sound will be added if there is no ricochet sound (same for module damage)<br>
-Fixed an issue where the contents of an FSB file could not be extracted normally, although it is unknown from which version<br>
・Added a function to generate a download link when uploading a file from "Tool for WoTB V1" because the server has excess capacity (You can upload bang bang without permission. ...)<br>
・Some design changes<br>
<br>
V1.4.9.2<br>
・Fixed an issue where voice mods could not be created<br>
-Fixed an issue where an error occurs when there are more than 200 sounds when adjusting the volume in the WoTB tool V2<br>
<br>
V1.4.9<br>
- Supported unsupported features (State, Advanced Setting, etc.) when converting from .bnk to Wwise project<br>
・Adjusted to add SE like noise included in the original voice (can be changed from the preset editing screen)<br>
・Added SE and voice types that can be changed with other sound mods (Thanks to yurina_taki)<br>
-Fixed the problem that the software does not start in some environments<br>
・Some functions deleted<br>
・Change some other specifications and fix minor bugs<br>
<br>
V1.4.8<br>
・Fixed the problem that the battle start timer does not work properly when creating a voice mod (probably from V1.4.6)<br>
・Slightly improved the problem when converting from FSB to BNK<br>
-Fixed a problem that crashes when performing certain actions in the music player<br>
・Fixed the problem that processing may not be completed in the function to separate vocals and instruments<br>
・Change some other specifications and fix minor bugs<br>
<br>
V1.4.7<br>
・Added a function that allows you to create a gunshot sound mod for the PC version of WoT<br>
- Lower the priority of the software so that you can do other work while doing heavy processing<br>
・Fixed other minor bugs<br>
<br>
V1.4.6.4<br>
-Fixed a problem that crashes when performing certain operations in the music player<br>
- Changed to be able to drag and drop sound files on the audio production screen<br>
・Fixed sound separation bug<br>
<br>
V1.4.6<br>
Fixed an issue where the Wwise Player would not function properly<br>
- Changed so that the songs in the list are played evenly during random playback of the music player<br>
(The text turns gray when it has been played.)<br>
・Added a function that can be processed on the client side instead of the server processing by separating the voice part and the instrument part<br>
・Added a function to change the SE sound source<br>
-Fixed an issue where items such as clearing and changing colors would disappear when the window bar was displayed in audio production<br>
・Fixed other minor bugs<br>
<br>
V1.4.5<br>
・Added a function that allows you to check the operation of mods within the software (Wwise functions can now be used within Mod Creator)<br>
・Fixed the problem that sound editing may not be loaded properly<br>
・Added a function to change the volume of .bnk (Thanks to Leo/AMX)<br>
・Improved the sound lag when playing long videos on the music player (Improved contents of V1.4.3)<br>
・When creating a voice mod, added an option to automatically start WoTB after adaptation (Thanks to syuu__)<br>
・Other minor bug fixes and some specification changes<br>
<br>
V1.4.4<br>
・Added a function to create artillery sound (included in the second page of 'Other Sound Mod')<br>
・Specification change of the server<br>
- Changed to be able to create mods even if the Steam version of WoTB is not installed on the PC (the specifications of the FMOD era remained)<br>
・Fixed minor bugs & changed some specifications<br>
<br>
V1.4.3<br>
・Significantly enhanced server security (prevents unauthorized access from third parties)<br>
-Added a function to separate the vocals and instruments of the song in the music player<br>
・Added an option to display the title bar (Thanks to goddy_516)<br>
-Fixed the problem that the sound lag occurred when playing a long video on the music player<br>
・Fixed an issue where the game would freeze for about 0.5 seconds once every 15 seconds<br>
・Fixed an issue where the chat field on the screen was not updated even after sending a chat<br>
<br>
V1.4.2<br>
- When creating a voice mod, added an option to play the standard voice if there is no voice in the item<br>
・Added a function that can create a sound when being hit (you can separate the sound of penetrating and non-penetrating)<br>
・Add sound editing option<br>
・Added chat items on the voice production screen (Thanks to PKF_yoshi)<br>
・Changed the design of the check box on the sound editing settings screen (easier to see)
will be)<br>
- Fixed an issue where shortcut keys for sound editing may work even when the window is not in front<br>
・Added shortcut keys to change speed and volume in sound editing<br>
・Changed to use pre-prepared images when reading files longer than 10 minutes in sound editing, as it takes time to generate waveforms<br>
・Added a function to save and load contents in sound editing<br>
・Some specification changes and minor bug fixes<br>
<br>
V1.4.0<br>
・Added the ability to create a Wwise project file from .bnk + .pck files (first in the world!)<br>
・Added a function to edit sound files (.wav or .mp3) ((Thanks to PKF_yoshi))<br>
-Added a function to notify the taskbar that the work has been completed when time is required, such as when creating audio or converting (the one that makes the icon glow)<br>
・Added a function that automatically loads a .wvs or .wms file by dragging it to the home screen<br>
     Also, if you drag a file with the corresponding extension to the music player, it will be added to the list<br>
・Added a function that allows you to check the change log (ChangeLog) from the home screen<br>
-Fixed the problem that processing stopped when retrieving Youtube videos (There was no problem when only audio was used)<br>
-Fixed the problem that the list is deleted when the software is restarted after retrieving Youtube videos in the music player<br>
-Fixed the problem that when adding a song with the same name in the music player, it was added to the list despite a warning<br>
-Fixed the problem that the software does not start up until Windows is restarted with a probability if the software crashes during processing (Fatal Sugi -)<br>
- Fixed a crash when parsing some .bnk files<br>
・Added an option to specify a folder in the dvpl cancellation and dvpl conversion functions (Thanks to yurina_taki)<br>
     You can also specify whether to delete the files before conversion after conversion. <br>
・Changed to be able to play the voice at the time of the result (Thanks to yurina_taki)<br>
・Added a volume bar that is reflected in WoTB on the Load | Result BGM screen (Thanks to Komiyakaho)<br>
- Changed to save in .mp3 format when downloading from Youtube (Thanks to PKF_yoshi)<br>
・Removed the option to put BGM in reload.bnk because there was a possibility that the battle BGM would be played at an unexpected timing<br>
・Other minor bug fixes and some specification changes<br>
<br>
V1.3.9<br>
・ Changed the layout of the chat (Is it easier to see?)<br>
-Added a function to change the list in the music player (Press Shift + 1 to 9 to switch the list. The list of the end point will be opened at startup.)<br>
Also, if the list of end points is empty and the first list is not empty, the first list is selected. <br>
-Fixed an issue where some uppercase romaji could not be typed due to overlapping shortcut keys when logging in or registering an account<br>
- Fixed an issue where some bnk files were not parsed correctly (ActorMixer could not be acquired)<br>
・Fixed other minor bugs<br>
<br>
V1.3.8<br>
・For advanced users, added a function that can extract files by event ID (Press Shift + E on the home screen to display the screen)<br>
- Fixed an issue where some bnk files could not be parsed<br>
・Added a function that allows you to specify audio_mods.xml when converting from WoT (this will reflect even if the event name has been changed)<br>
-Fixed the problem that the song continues to play when closing the screen with the background playback check off in the music player<br>
-Fixed an issue where videos could not be acquired due to changes in Youtube specifications<br>
- In the music player, change so that you can specify the playback time even during random playback and loop it during that time<br>
・Other minor bug fixes and specification changes<br>
<br>
V1.3.7<br>
・Changed to be able to create BGMMod at the time of result and superiority<br>
・Changed so that multiple selections can be made by clicking while holding down the Ctrl or Shift key in the list on the left side of the "Load | Result BGM" screen (all selected items can be built)<br>
- On the music player screen, press Shift + D to display a dialog to clear the added songs<br>
-Fixed the problem that the sound is not reflected when building with "Equal volume" checked<br>
- Fixed the problem that some bnk files cannot be read (may not be complete)<br>
・Fixed an issue where battle BGM was not reflected in some environments<br>
・Other minor bug fixes and some specification changes<br>
<br>
V1.3.6<br>
・Added a function that allows you to create a load BGMMod before the battle starts within the software<br>
-Changed specifications so that each function cannot be used without registering an account or logging in within the software<br>
(We would like to know the number of users, so please cooperate. You can specify the user name and password as you like.)<br>
・Change some other specifications and fix minor bugs<br>
<br>
V1.3.5<br>
・Added a function that can create a save file dedicated to this software from an FSB or BNK file<br>
(This will allow you to modify existing mods, but please do not distribute it to anyone other than the author.)<br>
-Fixed an issue where the music player could not change the volume or speed when switching to another song from the stopped state<br>
-Fixed an issue where the installation destination to WoT was not correctly acquired when converting from Blitz to WoT<br>
・Other minor bug fixes and specification changes<br>
<br>
V1.3.4<br>
・Changed to include battle BGM in reload.bnk　This will allow the BGM to be played when reloading is completed if the battle is delayed (no duplication)<br>
Also, if you enter the battle within the time, it will be played without waiting for the reload to complete. <br>
-Changed to be able to check the location of the temporary folder with Shift + P key<br>
・Fixed minor bugs<br>
<br>
V1.3.3<br>
・Added a function that allows you to disable the porting of specified voices in "Porting from WoT"<br>
- When porting from WoTB to WoT, add a message to confirm whether to automatically install WoT if it is installed on the PC<br>
・Fixed an issue where the playback device was not properly reflected on the voice production tool & SE settings screen<br>
-Fixed the problem that the color may not change even if selected in the voice production tool<br>
<br>
V1.3.2<br>
・Added a function that allows you to port voice mods from WoTB to the PC version of WoT<br>
-Fixed an issue that caused inoperability when selecting an invalid file on the "Port from WoT" screen<br>
-Fixed an issue where the memory usage rate gradually increased when selecting and playing SE on the screen for setting the presence or absence of SE<br>
- Improved speed and stability when converting to WAV<br>
・Fixed other minor bugs<br>
<br>
V1.3.1<br>
・Added a .bnk file that can be ported from the PC version of WoT<br>
-Fixed an issue that caused a crash when pressing the clear button while no .bnk file was selected on the porting screen from the PC version of WoT<br>
-Added a function that allows you to loop within a specified time on the music player<br>
Specify the playback start position with Shift + S key Specify the playback end position with Shift + E key Cancel time specification with Shift + C<br>
・Unnecessary code deleted<br>
<br>
Changes in V1.3.0<br>
・Added a function to convert the voice of the PC version of WoT to WoTB (it was really hard...)<br>
・Changed to be able to disable SE in Wwise<br>
- Changed to play .bnk files on the device specified in the music player<br>
-Fixed an issue that caused a crash when performing certain operations in the audio production tool<br>
-Fixed the problem that the volume adjustment function does not work when the number of files is large<br>
-Fixed a crash problem when reselecting an FSB file from the already selected state in the FSB conversion tool<br>
・Some specifications changed<br>
・Fixed other minor bugs<br>
<br>
Changes from V1.2.9 to V1.2.9.9<br>
・Changed to be able to increase the number of supported FSBs without software update<br>
・Reduce the weight of the executable file and significantly reduce the time required for updating<br>
・Fixed an issue where you can't publish if you check BGMMod when editing a published Mod (Thanks to yurina_taki)<br>
- Changed to be able to check progress when downloading Wwise project files<br>
-Added an option to synchronize the pitch and speed in the music player<br>
・On the mod distribution screen, change the sound device to be played to the device specified in the music player<br>
-Fixed the problem that the list on the left becomes unselected when adding audio on the audio production screen, and crashes when trying to play audio in that state (occurred from V1.2.9.7)<br>
-Fixed an issue where the volume of the song and voice would be synchronized when going to the voice production screen while playing on the music player<br>
・Fixed other minor bugs<br>
- By request, added an option to change the color of items where no file is selected on the voice mod creation screen to make it easier to understand<br>
・Increase the number of supported FSBs in "Port to Wwise" (changed to recognize if the contents file name is roughly the same)<br>
・Added option to adapt to dvpl and WoTB in "Port to Wwise"<br>
・You can change the screen size with Shift + F key (full screen window size)<br>
*In the case of window size, you can change the position by dragging the mouse. <br>
-Fixed an issue in the music player where the position of the video may continue to change even after the click is released after changing the video position<br>
・Fixed a problem that can not be converted to dvpl if the file size is large (Thanks to yurina_taki!!!)<br>
<br>
Changes in V1.2.9<br>
・Compatible with the new sound engine<br>
・With ↑, added a function to automatically convert audio files to .wem -> adapt to .bnk<br>
However, on the screen for advanced users, voice replacement is the main task, so voice cannot be added. <br>
-Added a function to port Fmod FSB files to Wwise BNK files (limited)<br>
・Added a function to extract the contents of .bnk files<br>
-Added a function that can play sounds in .bnk files (it may take time to expand to files and play)<br>
・Mod distribution specification changed for new sound engine
Since the restoration function in the screen of ↑ is also updated, it will be executed normally. <br>
・Specifications for creating BGM have also been changed for the new sound engine<br>
・When converting to a .wav file, multi-thread
Changed to work (Processing speed significantly increased ↑↑↑ CPU usage rate goes to 100%, but please forgive me.)<br>
-Fixed the problem that another file was canceled when canceling the selected file in the operation of the voice creation screen<br>
・Added a function to display waveforms in the music player<br>
・Fixed other minor bugs<br>
・Some specifications changed<br>
<br>
Changes in V1.2.8<br>
・Added a function that can extract FSB files (supports .aac .flac .mp3 .ogg .wav .webm .wma format)<br>
・Added player for FSB files<br>
Both ↑ are in the FSB conversion tool in the WoTB tool. <br>
・Added a function that can encode DDS to PNG and PNG to DDS (included in the WoTB tool)<br>
.dds (supports BC1 to BC7) .png .jpg .bmp .gif .tiff .exif can be mutually converted. (WoTB's dds is in BC3 format.)<br>
↑ is in the image conversion tool in the tool for WoTB. <br>
・Added a function to convert files extracted from FSB files back to FSB format<br>
↑ is in the FSB creation tool in the WoTB tool. (Extracting from FSB generates a .wfs file, so specify it.)<br>
・You can change the order of the list on the music player and mod distribution screen<br>
(Music player in name order, extension order / Mod distribution screen in name order, distribution order)<br>
・Changed to save the check box check and volume and apply it at startup<br>
-Fixed a bug where the Youtube title could not be saved properly if there were characters that could not be saved as a file name<br>
- Changed to be able to clear the log (Press Shift + L key on the home screen to display the dialog.)<br>
-Fixed an issue where voice mods for Android were not created in some environments<br>
-Fixed an issue where the WoTB DVPL could not be unlocked in all environments<br>
・Change the location of .dll (move to dll folder)<br>
・Fix minor bugs<br>
・Some specifications changed<br>
<br>
Changes in V1.2.7<br>
-Added a function to play FEV files with WoTB tools (does not work if there is no corresponding FSB file)<br>
-Added a function that can be obtained from Youtube in the music player (you can select audio or video.)<br>
・Fixed a crash problem when creating a voice mod when no voice was found<br>
・Changed to output contents to Error_Log.txt when an error occurs (correction based on the log)<br>
・Fixed other minor bugs<br>
<br>
Changes in V1.2.6<br>
・Added a function that can create fsb files for Android ("For Android" must be checked.)<br>
・Add SE to Android mods<br>
-Added a function that allows you to check the progress of downloading updates and mods<br>
・Changed to automatically scroll to the bottom when chat is opened<br>
・Fixed an issue where voice mods could not be created<br>
-Fixed an issue where the audio volume was not changed in some environments<br>
- Fixed a bug in the output device in the music player<br>
. Fixed a crash when files were not found in the music player<br>
・Some design changes<br>
・Change the specification of Fmod_Android_Create.exe<br>
・Other minor bug fixes and specification changes<br>
<br>
Changes in V1.2.5<br>
-Fixed the problem that it could not be installed correctly if the distributed sound mod's sounds.yaml was not converted to dvpl (Thanks to meniya)<br>
・Added software that can create a single FSB for Android (located in the temporary folder Fmod_Android_Create)<br>
Refer to Fmod_Android_Create on Github for how to use ↑. <br>
・Fixed minor bugs<br>
・Some specifications changed<br>
<br>
Changes in V1.2.4<br>
・Added an operation so that you can specify the output device in the music player<br>
-Fixed an issue where audio could not be loaded, saved, or created if the location of the temporary folder was changed<br>
・Fixed other minor bugs<br>
・Some specifications changed<br>
<br>
Changes in V1.2.3<br>
・Fixed the problem that BGMMod created in the software could not be published as BGMMod if it was converted to DVPL<br>
・ Mods published by mod distributors can be edited (delete, add files, etc.)<br>
<br>
Changes in V1.2.2<br>
・Fixed the problem that voice is not created in some environments (Thanks to Yurina_Taki!!!)<br>
・Fixed an issue where dvpl cannot be unlocked if Japanese is included in the path<br>
- You can now uninstall this software within the software (Press Shift + Esc on the home screen to display a message)<br>
- Changed to be able to specify the folder location of temporary files (including cache files) (Press Shift + D on the home screen to display a message)<br>
・ I don't know if there is, but I changed it so that it can be played in the background with a music player<br>
・Releasing a mysterious chat function (Already existed from V1.0, but it was closed for fine adjustment)<br>
・Fine adjustment<br>
<br>
Changes in V1.2.1<br>
・Fix minor bugs<br>
・Some specifications changed<br>
- Delete unnecessary libraries<br>
<br>
Changes in V1.2<br>
・Fixed fatal bugs<br>
(Fixed crashes during battle, FEV + FSB files may not be created, etc.)<br>
- Updates can be done within the software (need to connect and log in to the server)<br>
<br>
Changes in V1.1<br>
-Fixed the problem that the folder cannot be obtained if the WoTB installation location is the same as the Steam installation location (Thanks to yurina_taki)<br>
・Partially opened the server function so that anyone can distribute and download mods by logging in<br>
・The server capacity is 1TB. Please do not upload unnecessary files. <br>
<br>
---using Library---<br>
BASS.ASIO.1.3.1.2<br>
BASS.Native.2.4.12.2<br>
Bass.NetWrapper.2.4.12.5<br>
Costura.Fody.4.1.0<br>
FluentFTP.33.0.3<br>
Fody.6.3.0<br>
Obfuscar.2.2.28<br>
SimpleTCP.1.0.24<br>
K4os.Compression.LZ4.1.2.6<br>
Crc32.NET.1.2.0<br>
System.Buffers.4.5.1<br>
System.Memory.4.5.4<br>
System.Runtime.CompilerServices.Unsafe.5.0.0<br>
Cauldron.FMOD (introduced from V1.1)<br>
YoutubeExplode (introduced from V1.2.7)<br>
DdsFileTypePlusIO (introduced from V1.2.8)<br>
BetterFolderBrowser (introduced from V1.2.8)
