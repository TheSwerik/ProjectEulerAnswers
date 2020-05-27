; Variables:
#define MyAppName "ProjectEulerAnswers"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Swerik"
#define MyAppURL "https://github.com/TheSwerik/ProjectEulerAnswers"   
#define MyAppExeName "ProjectEulerAnswers.exe"

[Setup]
AppId={{3EB07062-0F1F-4647-9DDD-C897A0058BB4}
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
OutputBaseFilename={#MyAppName}
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
Source: "Publish\bin\*"; DestDir: "{app}\bin"; Excludes:"*.pdb"; Flags: ignoreversion recursesubdirs

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\bin\{#MyAppExeName}"; Flags: createonlyiffileexists;
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\bin\{#MyAppExeName}"; Tasks: desktopicon; Flags: createonlyiffileexists;
Name: "{app}\{#MyAppName}"; Filename: "{app}\bin\{#MyAppExeName}"; Flags: createonlyiffileexists;