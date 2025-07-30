Imports System.IO
Imports System.Net
Imports Winget_Repo_Client_Neu.Server


Module Start
    Public SERVER_URL As String = ""
    Public AUTH_TOKEN As String = ""
    Public REPO_NAME As String = ""
    Public INI_PATH As String = IO.Path.Combine(Application.StartupPath, "config.ini")

    Public Sub Main()
        SERVER_URL = IniLesen("Settings", "URL", "", INI_PATH)
        AUTH_TOKEN = IniLesen("Settings", "Token", "", INI_PATH)
        REPO_NAME = IniLesen("Settings", "Repo", "Winget-Repo", INI_PATH)

        RunMainAsync().GetAwaiter().GetResult()
    End Sub

    Private Async Function RunMainAsync() As Task
        Dim checkUpdate As Boolean = Await IsClientUpToDate(My.Application.Info.Version)
        If Not checkUpdate Then
            Dim client As New WebClient()
            Dim tempPath As String = Path.Combine(Path.GetTempPath(), "Winget-Repo_Client.exe")
            client.DownloadFile($"{SERVER_URL}/api/download/Winget-Repo_Client.exe", tempPath)

            Process.Start("Updater.exe", """" & Application.ExecutablePath & """ """ & tempPath & """")
            Environment.Exit(0)
        End If

        Dim args As String() = Environment.GetCommandLineArgs()

        If args.Length > 1 AndAlso args(1).ToLower() = "silent" Then
            Dim packages = Await GetPackagesFromServer(SERVER_URL, AUTH_TOKEN)

            For Each p As Paket In packages
                Await Install_Package(p.PACKAGE_ID, REPO_NAME, AUTH_TOKEN)
            Next

            Environment.Exit(0)
        Else
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New Form1())
        End If
    End Function
End Module
