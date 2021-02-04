Public Class Main

#Region "Declaratii"
    Public Class step_proprety
        Public delay As New Integer
        Public read_DM As Integer
        Public visual_control As New Boolean
        Public RW_param As Integer
        Public adr_param As String
        Public val_param As Integer
        Public DataBase As Integer
        Public serial As Integer
    End Class

    Public STEPS(45) As step_proprety

    'memmory for interupts for button
    Public Buton_press As Boolean

    'step number
    Public Step_Number As Integer

    'flash Next
    Public Next_flash As Integer = 1

    'wait for signal from PLC
    Public wait_for_sygnal As Boolean

    '1:OK ar 2:NOK part
    Public ok_nok As Integer
    Public number_of_mesure As Integer

    'Messages form main screen
    Public Mesaje As String() = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
    Public Messages_ini As String = "..\..\INI\Mesages.ini"
    Public Messages_ini2 As String = "..\..\INI\Mesages2.ini"
    Public Setari As String() = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
    Public Setari_ini As String = "..\..\INI\Settings.ini"

#End Region

    Public Function GetSettingItem(ByVal File As String, ByVal indentifier As String) As String
        Dim s As New IO.StreamReader(File) : Dim Result As String = ""
        Do While (s.Peek <> -1)
            Dim line As String = s.ReadLine
            If line.ToLower.StartsWith(indentifier.ToLower & ":") Then
                Result = line.Substring(indentifier.Length + 2)
            End If
        Loop
        s.Close()
        Return Result

    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Settings.Show()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Step_Number > 0 Then
            If STEPS(Step_Number - 1).visual_control Then
                Buton_press = 1

            End If
        Else
            Buton_press = 1
        End If

    End Sub

#Region "Load"

    '/////////////////////////////LOAD FORM
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Buton_press = 0
        Step_Number = 0
        InitApp.Show()
        InitApp.BringToFront()
        InitApp.Top = (My.Computer.Screen.WorkingArea.Height \ 2) - (Me.Height \ 2)
        InitApp.Left = (My.Computer.Screen.WorkingArea.Width \ 2) - (Me.Width \ 2)

        Dim i As Integer
        For i = 0 To 40
            STEPS(i) = New step_proprety
        Next

        InitApp.ProgressBar1.Value = 0
        InitApp.Label1.Text = "Loading Messages"
        Wait_ms(200)
        MessageBox.Text = "Load Messages..."
        Mesaje(0) = GetSettingItem(Messages_ini, "mesaj0")
        Mesaje(1) = GetSettingItem(Messages_ini, "mesaj1")
        Mesaje(2) = GetSettingItem(Messages_ini, "mesaj2")
        Mesaje(3) = GetSettingItem(Messages_ini, "mesaj3")
        Mesaje(4) = GetSettingItem(Messages_ini, "mesaj4")
        Mesaje(5) = GetSettingItem(Messages_ini, "mesaj5")
        Mesaje(6) = GetSettingItem(Messages_ini, "mesaj6")
        Mesaje(7) = GetSettingItem(Messages_ini, "mesaj7")
        Mesaje(8) = GetSettingItem(Messages_ini, "mesaj8")
        Mesaje(9) = GetSettingItem(Messages_ini, "mesaj9")
        Mesaje(10) = GetSettingItem(Messages_ini, "mesaj10")
        Mesaje(11) = GetSettingItem(Messages_ini, "mesaj11")
        Mesaje(12) = GetSettingItem(Messages_ini, "mesaj12")
        Mesaje(13) = GetSettingItem(Messages_ini, "mesaj13")
        Mesaje(14) = GetSettingItem(Messages_ini, "mesaj14")
        Mesaje(15) = GetSettingItem(Messages_ini, "mesaj15")
        Mesaje(16) = GetSettingItem(Messages_ini, "mesaj16")
        Mesaje(17) = GetSettingItem(Messages_ini, "mesaj17")
        Mesaje(18) = GetSettingItem(Messages_ini, "mesaj18")
        Mesaje(19) = GetSettingItem(Messages_ini, "mesaj19")
        Mesaje(20) = GetSettingItem(Messages_ini, "mesaj20")
        Mesaje(21) = GetSettingItem(Messages_ini2, "mesaj21")
        Mesaje(22) = GetSettingItem(Messages_ini2, "mesaj22")
        Mesaje(23) = GetSettingItem(Messages_ini2, "mesaj23")
        Mesaje(24) = GetSettingItem(Messages_ini2, "mesaj24")
        Mesaje(25) = GetSettingItem(Messages_ini2, "mesaj25")
        Mesaje(26) = GetSettingItem(Messages_ini2, "mesaj26")
        Mesaje(27) = GetSettingItem(Messages_ini2, "mesaj27")
        Mesaje(28) = GetSettingItem(Messages_ini2, "mesaj28")
        Mesaje(29) = GetSettingItem(Messages_ini2, "mesaj29")
        Mesaje(30) = GetSettingItem(Messages_ini2, "mesaj30")
        Mesaje(31) = GetSettingItem(Messages_ini2, "mesaj31")
        Mesaje(32) = GetSettingItem(Messages_ini2, "mesaj32")
        Mesaje(33) = GetSettingItem(Messages_ini2, "mesaj33")
        Mesaje(34) = GetSettingItem(Messages_ini2, "mesaj34")
        Mesaje(35) = GetSettingItem(Messages_ini2, "mesaj35")
        Mesaje(36) = GetSettingItem(Messages_ini2, "mesaj36")
        Mesaje(37) = GetSettingItem(Messages_ini2, "mesaj37")
        Mesaje(38) = GetSettingItem(Messages_ini2, "mesaj38")
        Mesaje(39) = GetSettingItem(Messages_ini2, "mesaj39")
        Mesaje(40) = GetSettingItem(Messages_ini2, "mesaj40")

        InitApp.ProgressBar1.Value = 25
        InitApp.Label1.Text = "Load Settings ..."
        Setari(0) = GetSettingItem(Setari_ini, "set0")
        Setari(1) = GetSettingItem(Setari_ini, "set1")
        Setari(2) = GetSettingItem(Setari_ini, "set2")
        'Setari(3) = GetSettingItem(Setari_ini, "set3")
        'Setari(4) = GetSettingItem(Setari_ini, "set4")
        'Setari(5) = GetSettingItem(Setari_ini, "set5")
        'Setari(6) = GetSettingItem(Setari_ini, "set6")
        'Setari(7) = GetSettingItem(Setari_ini, "set7")
        'Setari(8) = GetSettingItem(Setari_ini, "set8")
        'Setari(9) = GetSettingItem(Setari_ini, "set9")
        'Setari(10) = GetSettingItem(Setari_ini, "set10")
        'Setari(11) = GetSettingItem(Setari_ini, "set11")
        'Setari(12) = GetSettingItem(Setari_ini, "set12")
        'Setari(13) = GetSettingItem(Setari_ini, "set13")
        'Setari(14) = GetSettingItem(Setari_ini, "set14")
        'Setari(15) = GetSettingItem(Setari_ini, "set15")
        'Setari(16) = GetSettingItem(Setari_ini, "set16")
        'Setari(17) = GetSettingItem(Setari_ini, "set17")
        'Setari(18) = GetSettingItem(Setari_ini, "set18")
        'Setari(19) = GetSettingItem(Setari_ini, "set19")
        Wait_ms(100)
        Label1.Text = "OP" + Setari(0)
        Label2.Text = Setari(1)



        InitApp.ProgressBar1.Value = 50
        InitApp.Label1.Text = "Loading RTS..."
        RTS.Show()
        RTS.Hide()
        Wait_ms(200)

        InitApp.ProgressBar1.Value = 75
        InitApp.Label1.Text = "Loading Steps..."
        Settings.Show()
        Settings.Hide()
        Settings2.Show()
        Settings2.Hide()
        Wait_ms(100)

        PLCactive.Show()
        InitApp.ProgressBar1.Value = 85
        InitApp.Label1.Text = "PLC comunication Load..."
        PLCactive.Hide()
        Wait_ms(200)

        CVII.Show()
        InitApp.ProgressBar1.Value = 100
        InitApp.Label1.Text = "Loading Complet..."
        CVII.Hide()
        Wait_ms(200)


        MessageBox.Text = "Loading Complet... Press Init"

        InitApp.Close()
        Panel1.BackColor = Color.LightGray
        ComboBox2.SelectedIndex = 0


    End Sub
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property

#End Region

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'timer 100ms for program/messajes
        If Buton_press = True Then
            Buton_press = False
            Timer1.Enabled = False
            NewMethod()
            Timer1.Enabled = True

        End If

        If Step_Number > 0 Then

            If STEPS(Step_Number - 1).RW_param <> 0 Then
                wait_for_sygnal = True


                If STEPS(Step_Number - 1).RW_param = 1 Then
                    If STEPS(Step_Number - 1).val_param = PLCactive.Valoare_citita Then
                        Buton_press = True
                        wait_for_sygnal = False

                    End If
                End If

                If STEPS(Step_Number - 1).RW_param = 2 Then
                    If PLCactive.Valoare_de_scris >= 0 Then
                        Buton_press = True
                        PLCactive.Valoare_de_scris = -4
                        wait_for_sygnal = False
                    End If
                End If

                If STEPS(Step_Number - 1).RW_param = 3 Then
                    If PLCactive.Valoare_citita >= 0 Then
                        Buton_press = True
                        PLCactive.Valoare_citita = -4
                    End If
                End If

                If STEPS(Step_Number - 1).RW_param = 4 Then
                    If PLCactive.Valoare_de_scris >= 0 Then
                        Buton_press = True
                        PLCactive.Valoare_de_scris = -4
                        wait_for_sygnal = False
                    End If
                End If
            End If

            'wait for datas from srawdriver
            If STEPS(Step_Number - 1).serial <> 0 Then
                If CVII.Angle_Fastener_NR <> 0 And CVII.Torque_Fastener_NR <> 0 Then
                    'number_of_mesure = number_of_mesure + 1
                    Buton_press = True
                End If
            ElseIf STEPS(Step_Number - 1).serial = 0 And CVII.Torque_Fastener_NR <> 0 Then
                CVII.Clear_Measure = True
            End If
        End If

        If Step_Number > 0 Then
            If number_of_mesure > 11 And STEPS(Step_Number - 1).DataBase = 12 Then
                Buton_press = True
            End If
        End If



    End Sub

#Region "Init all values"
    Public Sub init_values()
        'measures
        number_of_mesure = 0
        ComboBox2.SelectedIndex = 0
        'texts in main
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""

        'texts in RTS
        RTS.serie = ""
        RTS.TextBox2.Text = ""
        RTS.TextBox4.Text = ""
        RTS.TextBox8.Text = ""
        RTS.TextBox12.Text = ""
        RTS.TextBox35.Text = ""
        RTS.TextBox36.Text = ""
        RTS.TextBox37.Text = ""

        'texts for MES
        RTS.Buffer1 = ""
        RTS.Buffer41 = ""
        RTS.Buffer42 = ""
        RTS.Buffer43 = ""
        RTS.Buffer44 = ""
        RTS.Buffer45 = ""
        RTS.Buffer46 = ""
        RTS.Buffer47 = ""
        RTS.Buffer48 = ""
        RTS.Buffer49 = ""
        RTS.Buffer410 = ""
        RTS.Buffer411 = ""
        RTS.Buffer412 = ""
        RTS.Buffer61 = ""
        RTS.Buffer62 = ""
        RTS.Buffer63 = ""
        RTS.Buffer64 = ""
    End Sub

#End Region

    Private Sub NewMethod()

        Select Case Step_Number
            Case 0 : MessageBox.Text = "Step 0: " + Mesaje(0)
                init_values()
                Step_Number = 1
            Case 1 : MessageBox.Text = "Step 1: " + Mesaje(1)
                ok_nok = 1
                TextBox2.Text = ""
                Panel1.BackColor = Color.LightGray
                Step_Number = 2
            Case 2 : MessageBox.Text = "Step 2: " + Mesaje(2)
                Step_Number = 3
            Case 3 : MessageBox.Text = "Step 3: " + Mesaje(3)
                Step_Number = 4
            Case 4 : MessageBox.Text = "Step 4: " + Mesaje(4)
                Step_Number = 5
            Case 5 : MessageBox.Text = "Step 5: " + Mesaje(5)
                Step_Number = 6
            Case 6 : MessageBox.Text = "Step 6: " + Mesaje(6)
                Step_Number = 7
            Case 7 : MessageBox.Text = "Step 7: " + Mesaje(7)
                Step_Number = 8
            Case 8 : MessageBox.Text = "Step 8: " + Mesaje(8)
                Step_Number = 9
            Case 9 : MessageBox.Text = "Step 9: " + Mesaje(9)
                Step_Number = 10
            Case 10 : MessageBox.Text = "Step 10: " + Mesaje(10)
                Step_Number = 11
            Case 11 : MessageBox.Text = "Step 11: " + Mesaje(11)
                Step_Number = 12
            Case 12 : MessageBox.Text = "Step 12: " + Mesaje(12)
                Step_Number = 13
            Case 13 : MessageBox.Text = "Step 13: " + Mesaje(13)
                Step_Number = 14
            Case 14 : MessageBox.Text = "Step 14: " + Mesaje(14)
                Step_Number = 15
            Case 15 : MessageBox.Text = "Step 15: " + Mesaje(15)
                Step_Number = 16
            Case 16 : MessageBox.Text = "Step 16: " + Mesaje(16)
                Step_Number = 17
            Case 17 : MessageBox.Text = "Step 17: " + Mesaje(17)
                Step_Number = 18
            Case 18 : MessageBox.Text = "Step 18: " + Mesaje(18)
                Step_Number = 19
            Case 19 : MessageBox.Text = "Step 19: " + Mesaje(19)
                Step_Number = 20
            Case 20 : MessageBox.Text = "Step 20: " + Mesaje(20)
                Step_Number = 21
            Case 21 : MessageBox.Text = "Step 21: " + Mesaje(21)
                Step_Number = 22
            Case 22 : MessageBox.Text = "Step 22: " + Mesaje(22)
                Step_Number = 23
            Case 23 : MessageBox.Text = "Step 23: " + Mesaje(23)
                Step_Number = 24
            Case 24 : MessageBox.Text = "Step 24: " + Mesaje(24)
                Step_Number = 25
            Case 25 : MessageBox.Text = "Step 25: " + Mesaje(25)
                Step_Number = 26
            Case 26 : MessageBox.Text = "Step 26: " + Mesaje(26)
                Step_Number = 27
            Case 27 : MessageBox.Text = "Step 27: " + Mesaje(27)
                Step_Number = 28
            Case 28 : MessageBox.Text = "Step 28: " + Mesaje(28)
                Step_Number = 29
            Case 29 : MessageBox.Text = "Step 29: " + Mesaje(29)
                Step_Number = 30
            Case 30 : MessageBox.Text = "Step 30: " + Mesaje(30)
                Step_Number = 31
            Case 31 : MessageBox.Text = "Step 31: " + Mesaje(31)
                Step_Number = 32
            Case 32 : MessageBox.Text = "Step 32: " + Mesaje(32)
                Step_Number = 33
            Case 33 : MessageBox.Text = "Step 33: " + Mesaje(33)
                Step_Number = 34
            Case 34 : MessageBox.Text = "Step 34: " + Mesaje(34)
                Step_Number = 35
            Case 35 : MessageBox.Text = "Step 35: " + Mesaje(35)
                Step_Number = 36
            Case 36 : MessageBox.Text = "Step 36: " + Mesaje(36)
                Step_Number = 37
            Case 37 : MessageBox.Text = "Step 37: " + Mesaje(37)
                Step_Number = 38
            Case 38 : MessageBox.Text = "Step 38: " + Mesaje(38)
                Step_Number = 39
            Case 39 : MessageBox.Text = "Step 39: " + Mesaje(39)
                Step_Number = 40
            Case Else : MessageBox.Text = "End"
                Step_Number = 0

        End Select

        If Step_Number > 0 Then
            Step_auto()
        End If

    End Sub

    Private Sub Step_auto()
        Dim result As Integer

        If STEPS(Step_Number - 1).read_DM <> 0 Then
            Citire_PN()
            Buton_press = True
        End If


        'None..
        '1CTRL_ASS_GAMME
        '2VALIDATION_OP
        '3CTRL_GAMME_COMPOSANT_DM_ 1
        '4CTRL_GAMME_COMPOSANT_DM_ 2
        '5CTRL_GAMME_COMPOSANT_DM_ 3
        '6CTRL_GAMME_COMPOSANT_DM_ 4
        '7GENERE_SN_PUMP
        '8LINK_COMPONENT_1
        '9LINK_COMPONENT_2
        '10LINK_COMPONENT_3
        '11LINK_COMPONENT_4
        '12Store Values - Salvare fisier

        If STEPS(Step_Number - 1).DataBase <> 0 Then
            Select Case STEPS(Step_Number - 1).DataBase
                Case 1
                    result = RTS.flow_control()
                    If result = 1 Then
                        Buton_press = True
                    Else
                        MsgBox("PCK_FLOW_CTRL Error RTS: " + RTS.RTSS.Oracle_Error(result, "VALID"), vbOK, "!")
                        Step_Number = Step_Number - 1
                        Buton_press = True
                    End If
                Case 2
                    result = RTS.valid_op()
                    If result = 1 Then
                        Buton_press = True
                    Else
                        MsgBox("PCK_VALIDATION_OP Error RTS: " + RTS.RTSS.Oracle_Error(result, "VALID"), vbOK, "!")
                        Step_Number = Step_Number - 1
                        Buton_press = True
                    End If
                Case 3
                    result = RTS.PCK_CTRL_GAMME_COMPOSANT_DM(1)
                    If result = 1 Then
                        Buton_press = True
                    Else
                        MsgBox("PCK_CTRL_GAMME_COMPOSANT_DM Error RTS: " + RTS.RTSS.Oracle_Error(result, "PFC"), vbOK, "!")
                        Step_Number = Step_Number - 1
                        Buton_press = True
                    End If
                Case 4
                    result = RTS.PCK_CTRL_GAMME_COMPOSANT_DM(2)
                    If result = 1 Then
                        Buton_press = True
                    Else
                        MsgBox("PCK_CTRL_GAMME_COMPOSANT_DM Error RTS: " + RTS.RTSS.Oracle_Error(result, "PFC"), vbOK, "!")
                        Step_Number = Step_Number - 1
                        Buton_press = True
                    End If
                Case 5
                    result = RTS.PCK_CTRL_GAMME_COMPOSANT_DM(3)
                    If result = 1 Then
                        Buton_press = True
                    Else
                        MsgBox("PCK_CTRL_GAMME_COMPOSANT_DM Error RTS: " + RTS.RTSS.Oracle_Error(result, "PFC"), vbOK, "!")
                        Step_Number = Step_Number - 1
                        Buton_press = True
                    End If
                Case 6
                    result = RTS.PCK_CTRL_GAMME_COMPOSANT_DM(4)
                    If result = 1 Then
                        Buton_press = True
                    Else
                        MsgBox("PCK_CTRL_GAMME_COMPOSANT_DM Error RTS: " + RTS.RTSS.Oracle_Error(result, "PFC"), vbOK, "!")
                        Step_Number = Step_Number - 1
                        Buton_press = True
                    End If
                Case 7
                    result = RTS.PCK_SN_PUMP()
                    If result = 1 Then
                        Buton_press = True
                    Else
                        MsgBox("PCK_SN_PUMP Error RTS: " + RTS.RTSS.Oracle_Error(result, "PFC"), vbOK, "!")
                        Step_Number = Step_Number - 1
                        Buton_press = True
                    End If
                Case 8
                    result = RTS.PCK_LINK_COMPONENT(1)
                    ' If result = 1 Then
                    Buton_press = True
                    'Else
                    '    MsgBox("PCK_LINK_COMPONENT Error RTS: " + RTS.RTSS.Oracle_Error(result, "PFC"), vbOK, "!")
                    '    Step_Number = Step_Number - 1
                    '    Buton_press = True
                    'End If
                        Case 9
                    result = RTS.PCK_LINK_COMPONENT(2)
                    '  If result = 1 Then
                    Buton_press = True
                    'Else
                    '    MsgBox("PCK_LINK_COMPONENT Error RTS: " + RTS.RTSS.Oracle_Error(result, "PFC"), vbOK, "!")
                    '    Step_Number = Step_Number - 1
                    '    Buton_press = True
                    'End If
                Case 10
                    result = RTS.PCK_LINK_COMPONENT(3)
                    If result = 1 Then
                        Buton_press = True
                    Else
                        MsgBox("PCK_LINK_COMPONENT Error RTS: " + RTS.RTSS.Oracle_Error(result, "PFC"), vbOK, "!")
                        Step_Number = Step_Number - 1
                        Buton_press = True
                    End If
                Case 11
                    result = RTS.PCK_LINK_COMPONENT(4)
                    If result = 1 Then
                        Buton_press = True
                    Else
                        MsgBox("PCK_LINK_COMPONENT Error RTS: " + RTS.RTSS.Oracle_Error(result, "PFC"), vbOK, "!")
                        Step_Number = Step_Number - 1
                        Buton_press = True
                    End If
                Case 12
                    'salvare valori
                    If number_of_mesure > 11 Then
                        Buton_press = True
                    End If
                Case 13
                    'salvare fisier
                    Dim return_val As String
                    return_val = RTS.RTSS.createfile()
                    RTS.TextBox47.Text = return_val
                    Buton_press = True
            End Select

        End If

        If STEPS(Step_Number - 1).delay <> 0 Then
            MessageBox.Text = MessageBox.Text + " " + STEPS(Step_Number - 1).delay.ToString + " ms"
            Wait_ms(STEPS(Step_Number - 1).delay)
            Buton_press = True
        End If

        If STEPS(Step_Number - 1).visual_control Then
            Next_flash = 1
        Else
            Next_flash = 0
        End If




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Step_Number = 0
        Buton_press = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim result As Integer = MsgBox("Do you want to EXIT?", vbYesNo, "!")
        If result = vbYes Then
            CVII.Close()
            PLCactive.Close()
            RTS.Close()
            Settings.Close()
            RTS.RTSS.Oracle_Disconnexion()
            Me.Close()
        End If
    End Sub

    Private Sub Form_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Leave
        RTS.RTSS.Oracle_Disconnexion()
        Close()
    End Sub

    ' Loops for a specificied period of time (milliseconds)
    Private Sub Wait_ms(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'timer for flashing
        If Next_flash <> 0 Then
            If Next_flash = 1 Then
                Button1.BackColor = Color.DarkGray
                Next_flash = 2
            Else
                Button1.BackColor = Color.Gray
                Next_flash = 1
            End If
        Else
            Button1.BackColor = Color.Gray
        End If

        Button1.Focus()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim userMsg As String
        Dim h = (My.Computer.Screen.WorkingArea.Height \ 2) - (Me.Height \ 2)
        Dim w = (My.Computer.Screen.WorkingArea.Width \ 2) - (Me.Width \ 2)
        userMsg = Microsoft.VisualBasic.InputBox("Enter Bad Part Number", "PFL FLUX", "DefProf...", h + 100, w + 200)
        If userMsg = "" Or userMsg = "DefProf..." Then
            Dim result As Integer = MsgBox("you didn't put any DefProd", vbOK, "!")
            TextBox2.Text = ""
        Else
            '      SEND DAB PART
            ok_nok = 2
            MsgBox("Defect : " + userMsg.ToString + " sent to server!", vbOK, "Put the bad part in the scrap box !")
            TextBox2.Text = userMsg
            Panel1.BackColor = Color.Red
            Step_Number = 0
            Buton_press = 1
        End If
    End Sub

    Private Sub Citire_PN()
        Dim userMsg As String
        Dim h = (My.Computer.Screen.WorkingArea.Height \ 2) - (Me.Height \ 2)
        Dim w = (My.Computer.Screen.WorkingArea.Width \ 2) - (Me.Width \ 2)
        userMsg = Microsoft.VisualBasic.InputBox("Enter Part Number ", "PFL Flux", "Scan Part..", h + 100, w + 200)
        If userMsg = "" Or userMsg = "Scan Part.." Then
            '      MessageBox.Show(userMsg)
            Dim result As Integer = MsgBox("you didn't put any PN", vbOK, "!")
            Step_Number = Step_Number - 1
        Else
            '      SEND PN
            ''MsgBox("Defect : " + userMsg.ToString + " sent to server!", vbOK, "Put the bad part in the scrap box !")

            If STEPS(Step_Number - 1).read_DM = 1 Then
                TextBox1.Text = userMsg
                RTS.DataMatrix(0).valoare = userMsg
            ElseIf STEPS(Step_Number - 1).read_DM = 2 Then
                TextBox3.Text = userMsg
                RTS.DataMatrix(1).valoare = userMsg
            ElseIf STEPS(Step_Number - 1).read_DM = 3 Then
                TextBox4.Text = userMsg
                RTS.DataMatrix(2).valoare = userMsg
            ElseIf STEPS(Step_Number - 1).read_DM = 4 Then
                TextBox5.Text = userMsg
                RTS.DataMatrix(3).valoare = userMsg
            End If


        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        PLCactive.Show()
        Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Hide()
        RTS.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        CVII.Show()
        Hide()
    End Sub

    Public Function serial_port_name() As String
        If Step_Number > 0 Then
            Select Case Step_Number - 1
                Case 0
                    Return Settings.ComboBox64.Text
                Case 1
                    Return Settings.ComboBox65.Text
                Case 2
                    Return Settings.ComboBox66.Text
                Case 3
                    Return Settings.ComboBox67.Text
                Case 4
                    Return Settings.ComboBox68.Text
                Case 5
                    Return Settings.ComboBox69.Text
                Case 6
                    Return Settings.ComboBox70.Text
                Case 7
                    Return Settings.ComboBox71.Text
                Case 8
                    Return Settings.ComboBox72.Text
                Case 9
                    Return Settings.ComboBox73.Text
                Case 10
                    Return Settings.ComboBox74.Text
                Case 11
                    Return Settings.ComboBox75.Text
                Case 12
                    Return Settings.ComboBox76.Text
                Case 13
                    Return Settings.ComboBox77.Text
                Case 14
                    Return Settings.ComboBox78.Text
                Case 15
                    Return Settings.ComboBox79.Text
                Case 16
                    Return Settings.ComboBox80.Text
                Case 17
                    Return Settings.ComboBox81.Text
                Case 18
                    Return Settings.ComboBox82.Text
                Case 19
                    Return Settings.ComboBox83.Text
                Case 20
                    Return Settings.ComboBox84.Text

                Case 21
                    Return Settings2.ComboBox65.Text
                Case 22
                    Return Settings2.ComboBox66.Text
                Case 23
                    Return Settings2.ComboBox67.Text
                Case 24
                    Return Settings2.ComboBox68.Text
                Case 25
                    Return Settings2.ComboBox69.Text
                Case 26
                    Return Settings2.ComboBox70.Text
                Case 27
                    Return Settings2.ComboBox71.Text
                Case 28
                    Return Settings2.ComboBox72.Text
                Case 29
                    Return Settings2.ComboBox73.Text
                Case 30
                    Return Settings2.ComboBox74.Text
                Case 31
                    Return Settings2.ComboBox75.Text
                Case 32
                    Return Settings2.ComboBox76.Text
                Case 33
                    Return Settings2.ComboBox77.Text
                Case 34
                    Return Settings2.ComboBox78.Text
                Case 35
                    Return Settings2.ComboBox79.Text
                Case 36
                    Return Settings2.ComboBox80.Text
                Case 37
                    Return Settings2.ComboBox81.Text
                Case 38
                    Return Settings2.ComboBox82.Text
                Case 39
                    Return Settings2.ComboBox83.Text
                Case 40
                    Return Settings2.ComboBox84.Text
                Case Else
                    Return "No COM port!"
            End Select
        Else
            Return Settings.ComboBox64.Text
        End If

    End Function


End Class
