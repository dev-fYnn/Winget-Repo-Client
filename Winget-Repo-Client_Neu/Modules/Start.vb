Imports System.IO
Imports System.Net
Imports Winget_Repo_Client_Neu.Server


Module Start
    Public SERVER_URL As String = ""
    Public AUTH_TOKEN As String = ""
    Public REPO_NAME As String = ""
    Public CLOUD As Boolean = False
    Public INI_PATH As String = IO.Path.Combine(Application.StartupPath, "config.ini")

    Public Sub Main()
        SERVER_URL = IniLesen("Settings", "URL", "", INI_PATH)
        AUTH_TOKEN = IniLesen("Settings", "Token", "", INI_PATH)
        REPO_NAME = IniLesen("Settings", "Repo", "", INI_PATH)

        If SERVER_URL.ToLower.Contains("https://cloud.winget-repo.io/") Then
            CLOUD = True
        End If

        RunMainAsync().GetAwaiter().GetResult()
    End Sub

    Private Async Function RunMainAsync() As Task
        Dim args As String() = Environment.GetCommandLineArgs()

        If args.Length > 1 AndAlso args(1).ToLower() = "silent" Then
            Dim packages = Await GetPackagesFromServer(SERVER_URL, AUTH_TOKEN)

            For Each p As Paket In packages
                Await Winget.RunWingetCommandAsync("Update", p.PACKAGE_ID)
            Next

            Environment.Exit(0)
        Else
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New Form1())
        End If
    End Function
End Module
