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
#### [Part 1 | Intro to Stand alone Executables](https://youtu.be/5umPshEIty0)
##### - What are they?
##### - Create one using the Script Wizard and explore how they're useful
##### - Briefly discuss how to run them within the Eclipse Environment (more in Part 5)

#### [Part 2 | Incorporating ESAPI into a Stand alone Executable](https://youtu.be/A3kOaI7WECo)
- Incorporate ESAPI into our stand-alone executable
	- Create an example of accessing ESAPI objects via the executable

#### [Part 3 | Intro to ConsoleX](https://youtu.be/LbHeakW3MjU)
##### - Incorporate ConsoleX, a NuGet Package put together by Rex Cardan
##### 	- General introduction and brief example of using it with ESAPI

#### [Part 4 | Adding an Options Dictionary to the Console](https://youtu.be/AnECGMjfiQY)
##### - Add an "options" dictionary to the ConsoleUI object (ConsoleX)

#### [Part 5 | Creating a Plugin Runner to Launch our Executable From Eclipse](https://youtu.be/a9f5ePuPLdI)
##### - Further discuss launching stand-alone executables within the Eclipse environment
##### - Create a plugin runner (single file plugin) that can be run from the normal Eclipse scripts location to launch the stand-alone executable