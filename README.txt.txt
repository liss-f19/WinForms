Paint - home part

Implement your custom control for displaying images, allowing for canvas resizing with a mouse. Canvas has three handles, a proper cursor is displayed, and a dotted rectangle with a new size is visible when dragging.
Implement operation on bitmap using direct access to the bitmap memory, see this post - this allows for fast operation on a bitmap.
Invert colors should work almost instantly, like in the example app.
Selection part of the canvas with a mouse. The status bar displays information about it. During selection, the rectangle is dashed black. After that, the color changes to blue. Working "Select All" in the menu.
Add custom events for notifying the main window about mouse movement, selection changing, and zooming.
Create an abstract class for tools and implement PenTool, SelectionTool, and LineTool.
Application remembers 10 recently opened files and displays them in the File menu. Use INI files to store them.
Create a custom control for a color palette. It allows for adjusting all colors and quickly picking them later.
Points:
Note: It is not possible to get partial points. The functionality from each listed subsection must work in its entirety to earn points!
Note: All functionality from the lab part (which was not changed during the home part) must be implemented to get any points!
Custom canvas control + canvas resizing - 2 points
Selection - 2 points
Zooming - 2 points
Tools (with proper abstraction): Pen, Selection, Line - 1 point each (3 points in total)
Image invert (quick) - 1 point
Storing a list of recently open/saved files - 1 point
Color palette control - 1 point