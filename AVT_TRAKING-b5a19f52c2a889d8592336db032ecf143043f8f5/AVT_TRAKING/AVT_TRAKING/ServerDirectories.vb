Imports System.IO
Imports CrystalDecisions.ReportAppServer
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Module ServerDirectories
    Private _ServerDirectory As String = "\\Desktop-s806jiq\"
    Private _ServerFolderDirectory As String = "\\Desktop-s806jiq\@userName"
    Private _ServerName As String = "Admin"
    Private _UserName As String = ""
    Private _LocalFolderDirectory As String = "C:\TMP\"
    Private _Pass As String = ""
    Private _DB As String = ""
    Private _UserDB As String = ""
    Public Property UserDB() As String
        Get
            Return _UserDB
        End Get
        Set(ByVal value As String)
            _UserDB = value
        End Set
    End Property

    Public Property DBName() As String
        Get
            If _DB = "" Then
                _DB = "VRT_TRAKING"
            End If
            Return _DB
        End Get
        Set(ByVal value As String)
            _DB = value
        End Set
    End Property
    Public Property Pass() As String
        Get

            Return _Pass
        End Get
        Set(ByVal value As String)
            _Pass = value
        End Set
    End Property

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
                            Dim db() As String = arrayText(1).Split("=")
                            DBName = db(1)
                            If arrayText.Length >= 4 Then
                                Dim us() As String = arrayText(2).Split("=")
                                UserDB = us(1)
                                Dim ps() As String = arrayText(3).Split("=")
                                Pass = ps(1)
                            End If
                        Else
                            ServerName = serverName1(1)
                            ServerDirectory = "\\" & serverName1(1)
                            ServerFolderDirectory = "\\" & serverName1(1) & "\tmp\@userName"
                            Dim db() As String = arrayText(1).Split("=")
                            DBName = db(1)
                            If arrayText.Length >= 4 Then
                                Dim us() As String = arrayText(2).Split("=")
                                UserDB = us(1)
                                Dim ps() As String = arrayText(3).Split("=")
                                Pass = ps(1)
                            End If
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

    Public Function connecReport(ByVal reportTs As CrystalDecisions.CrystalReports.Engine.ReportDocument, Optional timeOut As Integer = 0) As Boolean
        Try
            If Not reportTs Is Nothing Then
                Dim crTables As CrystalDecisions.CrystalReports.Engine.Tables
                Dim crTable As CrystalDecisions.CrystalReports.Engine.Table
                Dim crConnInfo As New CrystalDecisions.Shared.ConnectionInfo
                Dim crLogOnInfo As New CrystalDecisions.Shared.TableLogOnInfo

                reportTs.SetDatabaseLogon(UserDB, Pass, ServerName, DBName)

                For Each crTable In reportTs.Database.Tables
                    crConnInfo.ServerName = ServerName
                    crConnInfo.DatabaseName = DBName
                    crConnInfo.UserID = UserDB
                    crConnInfo.Password = Pass
                    crLogOnInfo = crTable.LogOnInfo
                    crLogOnInfo.ConnectionInfo = crConnInfo
                    crTable.ApplyLogOnInfo(crLogOnInfo)
                    crTable.LogOnInfo.ConnectionInfo.Password = Pass
                    crTable.Location = DBName & ".dbo." & crTable.Name

                Next
                'crvReport.ReportSource = reportTs 'Este es el control que muestra el reporte
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

End Module
