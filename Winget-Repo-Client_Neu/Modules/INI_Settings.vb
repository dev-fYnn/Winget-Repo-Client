Imports System.Runtime.InteropServices
Imports System.Text

Module INI_Settings
    <DllImport("kernel32", CharSet:=CharSet.Auto)>
    Private Function GetPrivateProfileString(
            ByVal lpAppName As String,
            ByVal lpKeyName As String,
            ByVal lpDefault As String,
            ByVal lpReturnedString As StringBuilder,
            ByVal nSize As Integer,
            ByVal lpFileName As String) As Integer
    End Function

    Function IniLesen(sektion As String, schluessel As String, standardwert As String, dateipfad As String) As String
        Dim buffer As New StringBuilder(255)
        GetPrivateProfileString(sektion, schluessel, standardwert, buffer, buffer.Capacity, dateipfad)
        Return buffer.ToString()
    End Function
End Module
