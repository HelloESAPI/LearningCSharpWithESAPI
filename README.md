# Learning CSharp with ESAPI

## Projects from video tutorials -- [Hello ESAPI](https://www.youtube.com/channel/UCaIibdaWUN3D_0MCmuCmO-w)

### 1. Intro To CSharp Using ESAPI

- [Value Types](https://www.youtube.com/watch?v=S6XrRCY2A4E&t=13s)
- [Visual Studio Shortcuts](https://www.youtube.com/watch?v=bug6eeHhqKA)
- [Things To Consider When Writing Code](https://www.youtube.com/watch?v=VtZ2bjOo15Y&t=2s)
- [Object-Oriented Programming](https://www.youtube.com/watch?v=4TBed1btXNw)

### 2. [Binary Plug-ins](https://www.youtube.com/watch?v=7gbqSBJiUYM&t=2598s)

- Creating a Binary Plug-in using the Eclipse Script Wizard
- Binary Plug-in vs Class Library -> spoiler...they're the same :)
- Adding a View to a Binary Plug-in/ Class Library project

### 3. [Intro To Conditional Statements - Truth Statements](https://www.youtube.com/watch?v=PRdxSto26ak)

- If, Else If, Else statements
- Switch statements
- Conditional Operators - single-line conditional statements

### 4. [Intro to MVVM using ESAPI and Binary Plug-ins](https://www.youtube.com/watch?v=gBbPA1iq5nI)

- Review the messiness of creating a UI in a single file plug-in for Eclipse
- Create Binary Plug-in
- Review the process of adding a view (like in any WPF project)
- Incorporate the MVVM design pattern in our binary plug-in
- Generate a template that we can use in the future as a starting point

### 5. [MVVM with Binding](https://www.youtube.com/watch?v=BEffjcmY_MU)

- Cover the basic differences between
  - views that use the "code behind" to update/manage its data/interface
  - views that use a viewmodel (i.e., using MVVM, etc.) to update/mange its data/interface
- Review a project with examples of the same interface written both with a view using the "code behind" and a view using a viewmodel
- Show how easy it is to fill something like a DataGrid with a list of objects via Binding

### 6. Stand-alone Executables with ESAPI
#### [Part 1 | Intro to Stand-alone Executables](https://youtu.be/5umPshEIty0)
- What are they?
- Create one using the Script Wizard and explore how they're useful
- Briefly discuss how to run them within the Eclipse Environment (more in Part 5)

#### [Part 2 | Incorporating ESAPI into a Stand-alone Executable](https://youtu.be/A3kOaI7WECo)
- Incorporate ESAPI into our stand-alone executable
	- Create an example of accessing ESAPI objects via the executable

#### [Part 3 | Intro to ConsoleX](https://youtu.be/LbHeakW3MjU)
- Incorporate ConsoleX, a NuGet Package put together by Rex Cardan
	- General introduction and brief example of using it with ESAPI

#### [Part 4 | Adding an Options Dictionary to the Console](https://youtu.be/AnECGMjfiQY)
- Add an "options" dictionary to the ConsoleUI object (ConsoleX)

#### [Part 5 | Creating a Plugin Runner to Launch our Executable From Eclipse](https://youtu.be/a9f5ePuPLdI)
- Further discuss launching stand-alone executables within the Eclipse environment
- Create a plugin runner (single file plugin) that can be run from the normal Eclipse scripts location to launch the stand-alone executable

### 7. IO | Reading and Writing Data From/To Files with CSharp
#### [Part 1 | Reading Data from CSV Files](https://youtu.be/92o2i-BbI1g)
- Ever want to load data for your application from a file or save data by writing it to a file? 
- Cover the basics of reading data from CSV files
- Review an example by creating generic beam objects from the .csv file 
	- Example solution to loading templated beams from external .csv file
	- Cover some examples of validating the data collected from the file

#### [Part 2 | Reading Data from JSON Files](https://youtu.be/IDciyvKT2Bg)
- General overview of what JSON files are
- Review an example by creating generic patient and beam objects from the .json file
- Compare the difference in efficiency between reading the beam data from .csv vs .json

#### [Part 3a | String Addition vs String Concatenation AND Writing Data to JS Files](https://youtu.be/RZO1S98exmw)
- Ever wonder what the difference is between string addition (+=) and string concatenation (using a StringBuilder)?
	- Build and write data of various lengths to JavaScript (.js) files via both string addition and concatenation
	- Investigate the efficiency of each strategy and settle once and for all which one is faster

#### [Part 3b | Loading JS Data Files into Static HTML Pages](https://youtu.be/pSXGfOnXC7o)
- Need or want to display your collected data? 
	- Cover the basics of loading your JavaScript file (.js) data into an HTML document
	- Review an example HTML page and javascript code that displays the data from 3a in a browser 
	- Languages Covered: C#, HTML, and JavaScript

#### [Part 4 | Logging Script Data with Text Files](https://youtu.be/TZsdSCT6HE0)
- Ever want to track when your scripts are used or when users are having issues?
	- Cover a basic example of using text files to log information from your script.