Imports System
Imports System.Threading
Imports System.IO
Imports System.Text
Imports S7.Net
Imports System.Net
Imports Microsoft.VisualBasic.Devices
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports Microsoft.VisualBasic

Public Class PLCactive

    Public IP_celule As String = "192.168.0.99"
    Public plc_celule As S7.Net.Plc
    Public DB_values As Byte

    Dim PLC_ParametersAvaible As Byte
    Public Valoare_citita As Integer
    Public Valoare_de_scris As Integer

    Dim Connection_OPEN, Connection_PING



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        plc_celule = New S7.Net.Plc(S7.Net.CpuType.S71200, IP_celule, 0, 1)
        Connected.Checked = False
        OPEN.Checked = False
        Connection_OPEN = 0
        Connection_PING = 0
        CheckBox1.Checked = Main.Setari(2)

    End Sub


    Private Sub Form1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        Connection_OPEN = 0
        Connection_PING = 0
        plc_celule.Close()

    End Sub

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Main.Show()
        Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Main.Setari(2) = False Then
            Timer1.Enabled = False
            Timer2.Enabled = False
            CheckBox1.Checked = False
        Else
            CheckBox1.Checked = True
            If My.Computer.Network.Ping(IP_celule) Then
                Connected.Checked = True
                Label3.Text = "Connected"
                '      Open.Enabled = True
                Connection_PING = 1
            Else
                Connected.Checked = False
                Label3.Text = "Not Connected to the PLC"
                '     Open.Enabled = False
                Connection_OPEN = 0
                Connection_PING = 0
            End If

            If Connection_OPEN = 0 Then
                Try
                    If Connection_PING = 1 Then
                        Try
                            plc_celule.Open()
                        Catch ex As Exception

                        End Try



                        If (plc_celule.IsConnected = True) Then
                            Label1.Text = "Connection to PLC is Opened OK"
                            OPEN.Checked = True
                            Timer1.Enabled = True
                            Connection_OPEN = 1
                        Else
                            Label1.Text = "Connection to PLC is NOT Opened"
                            OPEN.Checked = False
                            plc_celule.Close()
                        End If
                    End If

                Catch ex As Exception

                End Try
            End If
        End If
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = 1 Then
            Timer1.Enabled = True
            Timer2.Enabled = True
        Else
            Timer1.Enabled = False
            Timer2.Enabled = False
        End If
    End Sub



    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick

        If Connection_OPEN = 1 And Main.Step_Number > 0 Then

            If Main.STEPS(Main.Step_Number - 1).RW_param = 1 Or Main.STEPS(Main.Step_Number - 1).RW_param = 3 Then
                'Data e 1: INPUT sau 3 Read trebuie sa citesc
                Try
                    Valoare_citita = plc_celule.Read(Main.STEPS(Main.Step_Number - 1).adr_param)
                    Valoare_de_scris = -2
                Catch ex As Exception
                    Dim mesaj As String = "PLC ADRESS !!!! Put backup or contact PFL !"
                    mesaj = mesaj + " Read Adress: " + Main.STEPS(Main.Step_Number - 1).adr_param
                    MsgBox(mesaj, vbOK, "ERROR Read PLC DATA !")
                End Try
            End If

            If Main.STEPS(Main.Step_Number - 1).RW_param = 2 Or Main.STEPS(Main.Step_Number - 1).RW_param = 4 Then
                Try
                    plc_celule.Write(Main.STEPS(Main.Step_Number - 1).adr_param, Main.STEPS(Main.Step_Number - 1).val_param)
                    Valoare_de_scris = 1
                    Valoare_citita = -2
                Catch ex As Exception
                    Dim mesaj As String = "PLC ADRESS !!!! Put backup or contact PFL !"
                    mesaj = mesaj + " Write Adress: " + Main.STEPS(Main.Step_Number - 1).adr_param + " Or value: " + Main.STEPS(Main.Step_Number - 1).val_param
                    MsgBox(mesaj, vbOK, "ERROR Write PLC DATA !")
                End Try
            End If

            If Main.STEPS(Main.Step_Number - 1).RW_param = 0 Then
                Valoare_citita = -1
                Valoare_de_scris = -1
            End If

            TextBox1.Text = Valoare_citita
            TextBox2.Text = Valoare_de_scris
            If Valoare_citita >= 0 Then
                Label7.Text = "Citire " + Main.STEPS(Main.Step_Number - 1).adr_param
            End If
            If Valoare_de_scris >= 0 Then
                Dim mesaj As String = "Scris adr: " + Main.STEPS(Main.Step_Number - 1).adr_param.ToString + " value: " + Main.STEPS(Main.Step_Number - 1).val_param.ToString
                Label7.Text = mesaj
            End If

        End If



    End Sub

End Class
