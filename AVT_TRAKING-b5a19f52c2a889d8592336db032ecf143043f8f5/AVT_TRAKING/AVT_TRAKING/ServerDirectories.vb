Imports System.IO
Module ServerDirectories
    Private _ServerDirectory As String = "\\Desktop-s806jiq\"
    Private _ServerFolderDirectory As String = "\\Desktop-s806jiq\@userName"
    Private _ServerName As String = "Admin"
    Private _UserName As String = ""
    Private _LocalFolderDirectory As String = "C:\TMP\"

    Public Property LocalFolderDiretory() As String
        Get
            If Not Directory.Exists(_LocalFolderDirectory) Then
                Directory.CreateDirectory(_LocalFolderDirectory)
            End If
            Return _LocalFolderDirectory
        End Get
        Set(ByVal value As String)
            _LocalFolderDirectory = value
        End Set
    End Property
    Public Property ServerName() As String
        Get
            Return _ServerName
        End Get
        Set(ByVal value As String)
            _ServerName = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property

    Public Property ServerFolderDirectory() As String
        Get
            _ServerFolderDirectory = _ServerFolderDirectory.Replace("@userName", UserName)
            If Not Directory.Exists(_ServerFolderDirectory) Then
                Directory.CreateDirectory(_ServerFolderDirectory)
            End If
            Return _ServerFolderDirectory
        End Get
        Set(ByVal value As String)
            _ServerFolderDirectory = value
        End Set
    End Property
    Public Property ServerDirectory() As String
        Get
            Return _ServerDirectory
        End Get
        Set(ByVal value As String)
            _ServerDirectory = value
        End Set
    End Property

    Public Function findServer(ByVal connText As String) As Boolean
        Try
            If connText IsNot Nothing Then
                If connText <> "" Then
                    Dim arrayText() As String = connText.Split(";")
                    If arrayText.Length > 0 Then
                        Dim serverName1() As String = arrayText(0).Split("=")
                        If serverName1(0) = "localhost" Then
                            ServerName = "localhost"
                            ServerDirectory = "C:"
                            ServerFolderDirectory = "C:\TMP\"
                        Else
                            ServerName = serverName1(1)
                            ServerDirectory = "\\" & serverName1(1)
                            ServerFolderDirectory = "\\" & serverName1(1) & "\tmp\@userName"
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Module
