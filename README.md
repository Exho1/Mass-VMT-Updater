# Mass VMT Updater
A Visual C# application to batch update the "$basetexture" parameter of VMT files based on where the file is located. I wrote 
this simply because its annoying to manually change that parameter if you move your vmt file and its near impossible with large
quantities. There is a precompiled exe in bin/Debug but this includes the Visual Studio project files so you can compile it 
yourself.

## Use
1. Select a folder of Valve texture and material files that are exactly where you want them
2. Make a backup of the folder just to be on the safe side
3. Hit the "Convert" button
4. Wait while the program updates them (it might freeze in which case you can check the log.txt file created where the .exe
is located to make sure its still running
5. You are finished!
6. If you plan on doing it again on a different directory without closing the application, hit the reset button

## Todo
- Multithreading so I'm not doing all the work on the GUI thread and causing it to freeze
- Fixing the mysterious stopping bug
- Getting a better folder browser

## Bugs
With large numbers of vmt files, sometimes the application won't finish the job and will stop most of the way through. 
Like so: "Updated wood_plank_a.vmt! 6625/6730"
