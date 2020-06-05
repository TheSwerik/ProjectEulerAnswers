; Variables:
#define MyAppName "ProjectEulerAnswers"
#define MyAppVersion "1.0.5"
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
SignTool=signtool
SignedUninstaller=yes
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
ChangesEnvironment=yes

[Registry]
Root: HKLM; Subkey: "SYSTEM\CurrentControlSet\Control\Session Manager\Environment"; ValueType: expandsz; ValueName: "Path"; ValueData: "{olddata};{app}\bin"; Check: NeedsAddPath('{app}\bin')

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"

[Files] 
Source: "Publish\bin\*"; DestDir: "{app}\bin"; Excludes:"*.pdb,*/Euler.exe"; Permissions: users-modify; Flags: ignoreversion recursesubdirs
Source: "Publish\bin\Euler.exe"; DestDir: "{app}\bin"; Permissions: users-modify; Flags: ignoreversion sign
Source: "build\jpackage\ProjectEulerAnswers-Java\*"; Excludes:"*/ProjectEulerAnswers-Java.exe"; DestDir: "{app}\bin"; Permissions: users-modify; Flags: ignoreversion recursesubdirs
Source: "build\jpackage\ProjectEulerAnswers-Java\ProjectEulerAnswers-Java.exe"; DestDir: "{app}\bin"; Permissions: users-modify; Flags: ignoreversion sign

[Code]
function NeedsAddPath(Param: string): boolean;
var
  OrigPath: string;
begin
  if not RegQueryStringValue(HKEY_LOCAL_MACHINE,
    'SYSTEM\CurrentControlSet\Control\Session Manager\Environment',
    'Path', OrigPath)
  then begin
    Result := True;
    exit;
  end;
  Result := Pos(';' + Param + ';', ';' + OrigPath + ';') = 0;
end;
