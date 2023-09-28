# Garlic Press Documentation

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Setup](#setup)
- [Usage](#usage)
- [Media Layer Editor](#media-layer-editor)
- [Skin Settings (Edit Skin)](#skin-settings)
---

## **Introduction**
GarlicPress is a companion application for the RG35xx running GarlicOS. It streamlines interactions with your device, reducing the need to frequently remove the SD Cards from your RG35xx.

![GarlicPress Application Image](wwwroot/docs/GarlicPressMain.png)

---

## **Features**

- **File Management:** Browse and manage files in the Roms folders across systems and SD Card.
- **Art Scraper:** Fetch game art from screenscraper.fr automatically.
- **Drag-and-Drop:** Transfer files to System Folders with a simple drag and drop.
- **File Operations:** Rename and delete files with ease.
- **Skin Configuration:** Adjust and preview your RG35xx interface.
- **Command Console:** Directly run commands on your RG35xx.
- **Save Backup:** Backup your game save files.

---

## **Setup**

### **Enabling ADB on RG35xx**

1. Remove the main SD card from the RG35xx and put it into your PC.
2. In the 'Misc' partition, create a file named "enableADB" without ".txt" file extension.

#### If you can't see file extensions:

1. Go to 'Options' in your file explorer.
2. In the 'View' tab, uncheck the 'Hide extensions for known file types' option.
3. Remove the '.txt' extension from 'enableADB'.

Finally, put the SD card back into the RG35xx.

### **Alternatively Using the Toggle ADB App**

* "[Toggle ADB](https://www.rg35xx.com/en/apps/mods-for-garlicos/)" can be added to the device Roms/APPS folder for a way on device to enable and disable ADB. This could be a good option for people who need to disable ADB to use external controllers.
* This may already be installed on your device. So check apps in Consoles if you already have it.

---

## **Usage**

### **Connecting to GarlicPress**

1. Connect your RG35xx to your PC using a USB cable.
2. Open GarlicPress. When connected, the app icon will turn green.
![Connecting](wwwroot/docs/GarlicPressConnecting.gif)

### **Viewing ROMs**

Browse various sections like 'DOS games' to see content from your RG35xx.

![Roms](wwwroot/docs/GarlicPressRoms.gif)

### **Updating Art**

![Update Art](wwwroot/docs/GarlicPressUpdateGameArt.gif)

Enhance or change the visual representation of your games with the 'Update Art' function in GarlicPress. To use this feature, follow the steps below:

1. **Initiating the Update Art**:
   - In the main window, click the 'Update Art' button.
   - This action opens the Update Art window which displays games you've previously selected in the main window.

2. **Selecting Multiple Games in the Main Window**:
   - Utilize standard Windows selection methods to select your games:
     - **Individual Selection**: Hold the **Ctrl** key and click on games to select them one by one.
     - **Range Selection**: Hold the **Shift** key and click on a game to highlight all games between your initial selection and your most recent click.

3. **Navigating the Update Art Window**:
   - Within this window, you can:
     - View the Game Art update status for all the selected games.
     - Preview the game art for the most recently updated game.
     - Choose the desired Media Layer Collection from a single dropdown menu. This will apply to all selected games. 
     - Check the Allow only local media update checkbox if you want to force the update of local media even if game is not found on ScreenScraper.fr. It will only update if you have added local media to the Media Layer Collection.
     - Begin the art update process using the **Start Button**.
     - When the update is complete you can check the status of each game. If any game failed to update you can Clear Completed games and try the failed games again by pressing start. 
     - If game media failed to update, you can change the search text for that game and try again.
     ![GameArtUpdateSearch](wwwroot/docs/GarlicPressGameUpdateSearch.png)

### **ScreenScraper.fr**

1. Create an account on [ScreenScraper.fr](https://www.screenscraper.fr/).
2. Enter your ScreenScraper credentials in GarlicPress's settings, important to use your username and not mail adress.

![ScreenScraper](wwwroot/docs/GarlicPressScreenScraperLogin.png)

---

## **Media Layer Editor**

### **Introduction**

The Media Layer Editor in GarlicPress makes it easy preview and change game art layouts for GarlicOS.
![MediaLayerEditor](wwwroot/docs/GarlicPressMediaLayerEditor.gif)

### **Overview**

With the Media Layer Editor, customize your game visuals within GarlicOS. Create unique game art for each system or collection of games using Media Layer Collections.

### **Features**

1. **Media Layer Collections**:
   - Organize game art into different collections.
   - Each collection consists of list of Media Layers.
![MEdiaLayerCollection](wwwroot/docs/GarlicPressMediaLayerCollection.gif)

2. **Media Layers**:
   - Use media from ScreenScraper, game art and system art, or local files.
   - Apply transformations like resizing, repositioning, or adding filters.

3. **Filters**:
   - Enhance game visuals with filters like saturation, contrast, and more.

4. **Quick Access from Main Window**:
   - Access the editor instantly from the main window.
   - Preloaded game from the main window for faster editing.

5. **Direct Game Art Update**:
   - Update game art directly from the editor or save it and update multiple games with Update Art window.

### **Usage**

1. **Media Layer Collections**:
   - Start by launching the Media Layer Editor. At the top, you'll find a dropdown box for selecting a Media Layer Collection.
   ![MediaLayerCollections](wwwroot/docs/GarlicPressMediaLayerCollections.png)
   - To the right of this selection box, there are three buttons to manage your collections:
     1. **Add Media Layer Collection**: Clicking this will open a dialog where you can:
        - Enter a name for your new collection.
        - Decide if you want this collection to be based on an existing one or if you'd prefer to start from scratch.
![AddMediaLayerCollection](wwwroot/docs/GarlicPressAddMediaLayerCollection.gif)
     2. **Edit Media Layer Collection**: Use this to modify the name of an existing collection.
![EditMediaLayerColloection](wwwroot/docs/GarlicPressUpdateMediaLayerCollection.gif)
     3. **Delete Media Layer Collection**: This allows you to remove a collection entirely.
![DeleteMediaLayerCollection](wwwroot/docs/GarlicPressDeleteMediaLayerCollection.gif)

2. **Too add a new Media Layers**:
   - Click on the media you want to add if there's no media loaded click on the Get Game Media/Get System Media buttons.
   ![AddMEdiaLayer](wwwroot/docs/GarlicPressAddingMedia.gif)
   - Modify size, position, angle, and apply filters.
     1. Select the media layer you want to modify by clicking it in the preview window or by selecting it in Media Layers view.
     2. Transforms :
		- **Position**: Drag the media by click and drag in the preview window. Or by clicking the arrow keys.
        ![MediaLayerPosition](wwwroot/docs/GarlicPressMediaLayerPosition.gif)
		- **Size**: Drag one of the corners of the media layer in the preview.
        ![MediaLayerSize](wwwroot/docs/GarlicPressMediaLayerSize.gif)
		- **Angle**: Drag the sqaure thats on top to either direction and it will rotate the media.
        ![MediaLayerRotation](wwwroot/docs/GarlicPressMediaLayerRotation.gif)
        - **Delete**: Click on the delete button on Media Layers view or by selecting a media layer and pressing the delete key.
        - All of these can also be manupilated from the Media Layer Control View.
        ![MediaLayerControl](wwwroot/docs/GarlicPressEditMediaLayerFromControls.gif)
        - **Draw Order**: Change the draw order by clicking Page Up or Page Down.


4. **Filters**:
   - Pick a filter from the dropdown and click 'Add'.
   - Adjust settings until you achieve the desired effect.

5. **Editing from the Main Window**:
   - Click 'Open Editor' for quick access.
   - Use 'Update Game Art' for individual games or 'Update Art' for multiple games in the main window.

6. **Saving Your Edits**:
   - Remember to click 'Save' before closing the editor to keep your changes.

---
## Skin Settings

![SkinSettings](wwwroot/docs/GarlicPressSkinSettings.png)

Skin Settings provides a user-friendly interface for customizing the look and feel of GalicOS. Here's a breakdown of the functionalities and options available:

1. **Opening the Skin Editor**:
   - Click on `Tools` in the menu strip on the main window and click `Edit Skin Settings`.
   ![OpenSkinSettings](wwwroot/docs/GarlicPressOpenSkinSettings.png)

2. **Skin Settings Customization**:
   - **Text Margin**:
     - Adjust the margin of game list text elements.
     - **Left aligned** the margin will be from the left side of the screen.
     ![LeftAligned](wwwroot/docs/GarlicPressSkinSettingsLeftAligned.png)
      - **Center aligned** the margin will not do anything, the text will always be in center of the screen.
      ![CenterAligned](wwwroot/docs/GarlicPressSkinSettingsCenterAligned.png)
      - **Right aligned** the margin will be from the right side of the screen.
      ![RightAligned](wwwroot/docs/GarlicPressSkinSettingsRightAligned.png)
   - **Game Text Alignment**:
     - Customize the alignment of game list text in GarlicOS. See the `Text Margin` section for more information.
   - **Color Settings**:
     - Customize various color settings to match your preferences:
       - **Active Color**: Color of selected game/element.
       ![ActiveColor](wwwroot/docs/GarlicPressSkinSettingsActiveColor.png)
       - **Inactive Color**: Color of inactive games/elements.
         ![InactiveColor](wwwroot/docs/GarlicPressSkinSettingsInactiveColor.png)
       - **Guide Color**: Color of the GarlicOS buttons NAVIGATE, OPEN, BACK, FAVORITE, VERSION, CLOCK etc.
         ![GuideColor](wwwroot/docs/GarlicPressSkinSettingsGuideColor.png)
       - **Favorite Active Color**: Color of favored games.
     - **Color Picker**:
        - Utilize the color picker tool to easily select and apply colors for different settings.
        - Click on the color box next to each color setting to open the color picker.
        ![ColorPicker](wwwroot/docs/GarlicPressSkinSettingsColorPicker.png)
   - **Text Visibility**:
     - Toggle the visibility of text in the Main Menu (Version text in top left corner) and Guide Button texts.
   - **Label Customization**:
     - Customize the labels for various sections and buttons within the GalicOS:
       - Recent Label, Favorites Label, Consoles Label, Retroarch Label, RTC Label, Navigate Label, Open Label, Back Label, Favorite Label, Remove Label, Empty Label, Save States Unsupported Label, On Label, Off Label, AM Label, PM Label, Year Label, Month Label, Day Label, Hour Label, Minute Label, Meridian Time Label, and Title Label.
       - **Note**: Most of these will not do anything as they come from the selected Language see `Language Settings` for more.

3. **Language Settings**:
   - **Customizing Language Labels**:
     - Customize the language labels for various sections and buttons within GalicOS.
     - These will take precedence over the labels in the `Label Customization` section.
     - **How to change Language in GarlicOS**:
       - On the Main Meny in GarlicOS press the Start button.
       - Select the language under the Clock Settings.
    - **Font Management**:
   ![FontManagement](wwwroot/docs/GarlicPressSkinSettingsFonts.png)
      - **Font Selection**:
         - Select the font to be used for the GalicOS.
      - **Uploading Fonts**:
         - Upload new fonts to the GalicOS to use with your Language skin settings.
      - **Deleting Fonts**:
         - Delete the selected fonts that.

4. **Boot Screen Customization**:
   - **Uploading a New Boot Screen**:
     - Upload a new boot screen image to customize the startup look of the GalicOS.
   - **Preview of the Boot Screen**:
     - Preview is the current boot screen image.

5. **Saving and Applying Changes**:
   - **Saving Customized Settings**:
     - Save your customized settings to apply them to the GalicOS.
   - **Applying Changes**:
     - The settings will be applied to the GalicOS after saving. But they will not show until you restart the GalicOS, this can be done with the `Restart` button in lower left corner.

6. **Troubleshooting**:
   - If skin settings can not be read, you will get as error message when GarlicPress connects to your RG35XX saying settings.json is not valid json. If this happens you have to take out the SD card and edit the settings.json file with a text editor. You can use a json validator to check if the file is valid json.