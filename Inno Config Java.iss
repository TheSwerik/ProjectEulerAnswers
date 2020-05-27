; Variables:
#define MyAppName "ProjectEulerAnswers"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Swerik"
#define MyAppURL "https://github.com/TheSwerik/ProjectEulerAnswers"   
#define MyAppExeName "ProjectEulerAnswers.exe"

[Setup]
AppId={{3A9D0714-C3DD-4236-A03D-FD3BA46E323C}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL} 
AppVerName={#MyAppName}
DefaultDirName={autopf}\{#MyAppName}   
DefaultGroupName={#MyAppName} 
Compression=lzma2   
SolidCompression=yes   
WizardStyle=modern
OutputBaseFilename={#MyAppName} Java
OutputDir=Installer
ArchitecturesInstallIn64BitMode=x64  
AllowNoIcons=yes  
ShowLanguageDialog=auto
CloseApplications=yes
CloseApplicationsFilter=*.*

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked   

[Files]
Source: "build\jpackage\ProjectEulerAnswers\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Flags: createonlyiffileexists;
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon; Flags: createonlyiffileexists;
Name: "{app}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Flags: createonlyiffileexists;
