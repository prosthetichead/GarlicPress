# GarlicPress
[![]((https://discordapp.com/api/guilds/1132086906935590942/widget.png?style=shield))](https://discord.gg/MsSxZcDTGk)

GarlicPress is a companion application for the RG35xx running [GarlicOS](https://www.patreon.com/posts/garlicos-for-76561333). The main aim of the application is to never require you to remove the SDCards from your device.
![image](https://github.com/prosthetichead/GarlicPress/assets/1934681/ffbb4831-1ea3-422a-abed-daaa2c980bf0)

![Bulk Art Updating](https://github.com/prosthetichead/GarlicPress/assets/1934681/00c546b7-679e-4ce4-a974-154dd761e12b)

## Features
* Easily view files stored in the Roms folders for each system and SD Card
* Scrape game art from [screenscraper.fr](https://screenscraper.fr)
* Edit game art layouts using layers
* Copy file to System Folders using drag and drop
* Delete and Rename files
* Edit the skin configuration and preview (not all features enabled yet)
* Simple console for executing commands on the device
* Backup save game files

## How to Setup GarlicPress 
GarlicPress uses ADB to comunicate with the RG35xx and GarlicOS over usb. By default garlicOS disables ADB but it can be enabled very easily.
### Enabling ADB
* Insert the main SD card into a PC
* On the Misc partition (not the larger partition with Roms foldeer) create a text file in the root of the drive. Rename this new file to "enableADB" making sure to remove the .txt file extention.
![image](https://github.com/prosthetichead/GarlicPress/assets/1934681/1660fb56-bc68-4bbd-85cf-1bd56529c855)
* Reinsert the SD Card into the RG35xx and GarlicPress should now be able to connect to the device over USB if it is turned on (not on the battery charging screen).
* Alternately the app "[Toggle ADB](https://www.rg35xx.com/en/apps/mods-for-garlicos/)" can be added to the device Roms/APPS folder for a way on device to enable and disable ADB. This could be a good option for people who need to disable ADB to use external controllers.   
  
