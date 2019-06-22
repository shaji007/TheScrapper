# TheScrapper
This tool aids in finding the unique locators for web application automation using Selenium.

## Functionality
The tool uses C# Winform application to launch Chrome Browser using Selenium. The selenium is used to scrape through the web page and identify the unique locators (Id, Name, Text, Class, XPath).

### Launch Chrome
This button launches the Chrome Browser using Selenium.

### Frames
This button when clicked tries to find the frames present in the web page and display in a tree view.
The frames when selected from tree view, will help in indentifying the elements inside Iframe dom.

### Scrape
This button when clicked launches a dialog to select the tags which are to be scraped from the page.
Upon closing the dialog, the elements are identified and their unique locators are found and displayed in a list view.

### List view
This shows 4 columns.
  - Name => Variable Name to be assigned. This column is editable.
  - Tag => Tag of the element
  - L. Type => Locator Type
  - Value => Value of the locator

Once double clicked on a list item, the first cell in the row can be edited to pave way to provide variable name.

If clicked once on the list item, the corresponding elememt in browser will be highlighted in red border.
