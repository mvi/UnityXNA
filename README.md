UnityXNA
========

Proof of concept demo'ing the execution of a 2D XNA game sample in the Unity3D engine with zero code changes to game source code.

Added feature
========
The change made in Visual C# 2010 Express will be reflected in linked Content and XNAGame folder in Unity and vice versa.

Steps
========
1. You first open Unity project and open Assets/scene.unity file and have Unity upgraded this project.
2. Select Windows>Layout>Tall so that you can view full screen of XNA plaformer sample game.
3. Select Edit>Project Settins>Editor and select 2D Default Behavior Mode dropdown in Editor Settings.
4. Run cmd.exe as Administrator and execute linksource.cmd in the project root folder.
5. Wait for Unity to load all resouces and scripts
6. click Play button


Other Info
========
1. You can modify, compile and run this game in Visual Studio 2010 via the solutin project, Platformer_4_0\Platformer (Windows).sln. Your change will be reflected in Unity project as well. 
2. You should not add any XNA code not supported by XNAEmulator. See Scripts/XNAEmualtor under Unity Project folder. 
3.Below two command batch files are provided to enable/disable linking function. You must run one of the below command via cmd.exe under project root folder with Admin right.

- linksource.cmd 
- unlinksource.cmd


Disclaimer from original author
========

**Disclaimer: I've received a lot of emails asking if UnityXNA is suitable for porting an existing XNA game to Unity. The short answer is: it is, if you're prepared to do the leg work yourself. UnityXNA only implements the bare minimum of the XNA API in order to get the Platformer sample working. If your project uses any parts of the XNA API that the Platformer sample does not, you will need to add support for this yourself. Due to personal time constraints and the nature of this project as a tech demo only, I can offer no support for UnityXNA. Source code is provided for the curious and as a nice starting point for more serious emulation of XNA in Unity.**
