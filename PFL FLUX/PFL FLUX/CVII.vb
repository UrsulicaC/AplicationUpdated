Imports System.Threading
Public Class CVII
    Public receives_String As String
    Public Torque_Cycle_NR As Integer
    Public Torque_Fastener_NR As Integer
    Public Torque_1_10_Nm As Integer
    Public Angle_Cycle_NR As Integer
    Public Angle_Fastener_NR As Integer
    Public Angle_1_10_Nm As Integer
    Public Torque_Rate_Cycle_NR As Integer
    Public Torque_Rate_Fastener_NR As Integer
    Public Torque_Rate_1_10_Nm As Integer
    Dim SelectedValues As String = "..\..\INI\CVIISelectedValues.ini"

    Dim message As String
    Public readThread As New Thread(AddressOf Read)
    Public Clear_Measure As Boolean
    Public textu As String = ""
    Public timeout_count As Integer = 0

    Public Sub Read()
        While True
            Try
                Dim message As String
                message = SerialPort1.ReadLine
                Console.WriteLine(message)
                If message <> "" Then
                    textu += (message)
                End If

            Catch generatedExceptionName As TimeoutException
                ' Console.WriteLine("time out")
                timeout_count += 1
            End Try
        End While
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main.Show()
        Hide()
    End Sub

    Private Sub Form_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Leave
        Main.Show()
        Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        TextBox1.Text = vbCr + "0109T=+00400" + vbLf + vbCr + "0109A=+01200" + vbLf + vbCr + "0109TR=+00580" + vbLf
        NewMethod()

    End Sub

    Public Sub salvare_date()
        Select Case Main.number_of_mesure
            Case 0
                RTS.Buffer41 = RTS.RTSS.Buffer_Article4(RTS.serie, Main.Setari(0), Main.ComboBox1.Text, Date.Now(), 5, 1,
                                                        1, 1, "MSTQI1", Torque_1_10_Nm, 20.0, TextBox11.Text, TextBox12.Text, "N/m", "0")
                Main.number_of_mesure = Main.number_of_mesure + 1
            Case 1

                RTS.Buffer42 = RTS.RTSS.Buffer_Article4(RTS.serie, Main.Setari(0), Main.ComboBox1.Text, Date.Now(), 5, 1,
                                                        1, 1, "MSANI1", Angle_1_10_Nm, 20.0, TextBox15.Text, TextBox16.Text, "N/m", "0")
                Main.number_of_mesure = Main.number_of_mesure + 1
            Case 2
                RTS.Buffer43 = RTS.RTSS.Buffer_Article4(RTS.serie, Main.Setari(0), Main.ComboBox1.Text, Date.Now(), 5, 1,
                                                        1, 1, "MSTQF1", Torque_1_10_Nm, 20.0, TextBox13.Text, TextBox14.Text, "N/m", "0")
                Main.number_of_mesure = Main.number_of_mesure + 1
            Case 3
                RTS.Buffer44 = RTS.RTSS.Buffer_Article4(RTS.serie, Main.Setari(0), Main.ComboBox1.Text, Date.Now(), 5, 1,
                                                        1, 1, "MSANF1", Angle_1_10_Nm, 20.0, TextBox17.Text, TextBox18.Text, "N/m", "0")
                Main.number_of_mesure = Main.number_of_mesure + 1
            Case 4
                RTS.Buffer45 = RTS.RTSS.Buffer_Article4(RTS.serie, Main.Setari(0), Main.ComboBox1.Text, Date.Now(), 5, 1,
                                                        1, 1, "MSTQI2", Torque_1_10_Nm, 20.0, TextBox11.Text, TextBox12.Text, "N/m", "0")
                Main.number_of_mesure = Main.number_of_mesure + 1
            Case 5
                RTS.Buffer46 = RTS.RTSS.Buffer_Article4(RTS.serie, Main.Setari(0), Main.ComboBox1.Text, Date.Now(), 5, 1,
                                                        1, 1, "MSANI2", Angle_1_10_Nm, 20.0, TextBox15.Text, TextBox16.Text, "N/m", "0")
                Main.number_of_mesure = Main.number_of_mesure + 1
            Case 6
                RTS.Buffer47 = RTS.RTSS.Buffer_Article4(RTS.serie, Main.Setari(0), Main.ComboBox1.Text, Date.Now(), 5, 1,
                                                        1, 1, "MSTQF2", Torque_1_10_Nm, 20.0, TextBox13.Text, TextBox14.Text, "N/m", "0")
                Main.number_of_mesure = Main.number_of_mesure + 1
            Case 7
                RTS.Buffer48 = RTS.RTSS.Buffer_Article4(RTS.serie, Main.Setari(0), Main.ComboBox1.Text, Date.Now(), 5, 1,
                                                        1, 1, "MSANF2", Angle_1_10_Nm, 20.0, TextBox17.Text, TextBox18.Text, "N/m", "0")
                Main.number_of_mesure = Main.number_of_mesure + 1
            Case 8
                RTS.Buffer49 = RTS.RTSS.Buffer_Article4(RTS.serie, Main.Setari(0), Main.ComboBox1.Text, Date.Now(), 5, 1,
                                                        1, 1, "MSTQI3", Torque_1_10_Nm, 20.0, TextBox11.Text, TextBox12.Text, "N/m", "0")
                Main.number_of_mesure = Main.number_of_mesure + 1
            Case 9
                RTS.Buffer410 = RTS.RTSS.Buffer_Article4(RTS.serie, Main.Setari(0), Main.ComboBox1.Text, Date.Now(), 5, 1,
                                                        1, 1, "MSANI3", Angle_1_10_Nm, 20.0, TextBox15.Text, TextBox16.Text, "N/m", "0")
                Main.number_of_mesure = Main.number_of_mesure + 1
            Case 10
                RTS.Buffer411 = RTS.RTSS.Buffer_Article4(RTS.serie, Main.Setari(0), Main.ComboBox1.Text, Date.Now(), 5, 1,
                                                        1, 1, "MSTQF3", Torque_1_10_Nm, 20.0, TextBox13.Text, TextBox14.Text, "N/m", "0")
                Main.number_of_mesure = Main.number_of_mesure + 1
            Case 11
                RTS.Buffer412 = RTS.RTSS.Buffer_Article4(RTS.serie, Main.Setari(0), Main.ComboBox1.Text, Date.Now(), 5, 1,
                                                        1, 1, "MSANF3", Angle_1_10_Nm, 20.0, TextBox17.Text, TextBox18.Text, "N/m", "0")
                Main.number_of_mesure = Main.number_of_mesure + 1

        End Select
        If Main.number_of_mesure > 0 Then
            Main.ComboBox2.SelectedIndex = Main.number_of_mesure
        End If

        If Main.number_of_mesure > 11 Then
            Main.ComboBox2.SelectedIndex = 13
        End If

    End Sub

    Private Sub NewMethod()
        Dim pos As Integer

        receives_String = TextBox1.Text

        pos = InStr(1, receives_String, "T=", CompareMethod.Binary)
        If pos > 0 Then
            Torque_Cycle_NR = Mid(receives_String, pos - 4, 2)
            Torque_Fastener_NR = Mid(receives_String, pos - 2, 2)
            Torque_1_10_Nm = Mid(receives_String, pos + 3, 5)
            TextBox2.Text = Torque_Cycle_NR
            RTS.Values(ComboBox1.SelectedIndex).valoare = Torque_Cycle_NR
            TextBox3.Text = Torque_Fastener_NR
            RTS.Values(ComboBox2.SelectedIndex).valoare = Torque_Fastener_NR
            TextBox4.Text = Torque_1_10_Nm
            RTS.Values(ComboBox3.SelectedIndex).valoare = Torque_1_10_Nm
            salvare_date()
        End If

        pos = InStr(1, receives_String, "A=", CompareMethod.Binary)
        If pos > 0 Then
            Angle_Cycle_NR = Mid(receives_String, pos - 4, 2)
            Angle_Fastener_NR = Mid(receives_String, pos - 2, 2)
            Angle_1_10_Nm = Mid(receives_String, pos + 3, 5)
            TextBox5.Text = Angle_Cycle_NR
            RTS.Values(ComboBox4.SelectedIndex).valoare = Angle_Cycle_NR
            TextBox6.Text = Angle_Fastener_NR
            RTS.Values(ComboBox5.SelectedIndex).valoare = Angle_Fastener_NR
            TextBox7.Text = Angle_1_10_Nm
            RTS.Values(ComboBox6.SelectedIndex).valoare = Angle_1_10_Nm
            salvare_date()
            Clear_Measure = True
        End If


        pos = InStr(1, receives_String, "TR=", CompareMethod.Binary)

        If pos > 0 Then

            Torque_Rate_Cycle_NR = Mid(receives_String, pos - 4, 2)
            Torque_Rate_Fastener_NR = Mid(receives_String, pos - 2, 2)
            Torque_Rate_1_10_Nm = Mid(receives_String, pos + 3, 5)
            TextBox8.Text = Torque_Rate_Cycle_NR
            RTS.Values(ComboBox7.SelectedIndex).valoare = Torque_Rate_Cycle_NR
            TextBox9.Text = Torque_Rate_Fastener_NR
            RTS.Values(ComboBox8.SelectedIndex).valoare = Torque_Rate_Fastener_NR
            TextBox10.Text = Torque_Rate_1_10_Nm
            RTS.Values(ComboBox9.SelectedIndex).valoare = Torque_Rate_1_10_Nm
        End If

    End Sub

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property

    Private Sub CVII_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Top = (My.Computer.Screen.WorkingArea.Height \ 2) - (Me.Height \ 2)
        Me.Left = (My.Computer.Screen.WorkingArea.Width \ 2) - (Me.Width \ 2)

        Dim return_val = Main.serial_port_name

        If return_val <> "None.." Then
            Try
                SerialPort1.PortName = return_val
                SerialPort1.ReadTimeout = 500
                SerialPort1.WriteTimeout = 500
                'open
                SerialPort1.Open()
                readThread.Start()
            Catch ex As Exception
                MsgBox("COM port not active on start CVII form Load ", vbOK, "ERROR COM PORT")
            End Try
        End If

        ComboBox1.Items.AddRange(RTS.ComboBox4.Items.Cast(Of String).ToArray())
        ComboBox2.Items.AddRange(RTS.ComboBox4.Items.Cast(Of String).ToArray())
        ComboBox3.Items.AddRange(RTS.ComboBox4.Items.Cast(Of String).ToArray())
        ComboBox4.Items.AddRange(RTS.ComboBox4.Items.Cast(Of String).ToArray())
        ComboBox5.Items.AddRange(RTS.ComboBox4.Items.Cast(Of String).ToArray())
        ComboBox6.Items.AddRange(RTS.ComboBox4.Items.Cast(Of String).ToArray())
        ComboBox7.Items.AddRange(RTS.ComboBox4.Items.Cast(Of String).ToArray())
        ComboBox8.Items.AddRange(RTS.ComboBox4.Items.Cast(Of String).ToArray())
        ComboBox9.Items.AddRange(RTS.ComboBox4.Items.Cast(Of String).ToArray())

        ComboBox1.SelectedIndex = Main.GetSettingItem(SelectedValues, "val1")
        ComboBox2.SelectedIndex = Main.GetSettingItem(SelectedValues, "val2")
        ComboBox3.SelectedIndex = Main.GetSettingItem(SelectedValues, "val3")
        ComboBox4.SelectedIndex = Main.GetSettingItem(SelectedValues, "val4")
        ComboBox5.SelectedIndex = Main.GetSettingItem(SelectedValues, "val5")
        ComboBox6.SelectedIndex = Main.GetSettingItem(SelectedValues, "val6")
        ComboBox7.SelectedIndex = Main.GetSettingItem(SelectedValues, "val7")
        ComboBox8.SelectedIndex = Main.GetSettingItem(SelectedValues, "val8")
        ComboBox9.SelectedIndex = Main.GetSettingItem(SelectedValues, "val9")

        TextBox11.Text = Main.GetSettingItem(SelectedValues, "val10")
        TextBox12.Text = Main.GetSettingItem(SelectedValues, "val11")
        TextBox13.Text = Main.GetSettingItem(SelectedValues, "val12")
        TextBox14.Text = Main.GetSettingItem(SelectedValues, "val13")
        TextBox15.Text = Main.GetSettingItem(SelectedValues, "val14")
        TextBox16.Text = Main.GetSettingItem(SelectedValues, "val15")
        TextBox17.Text = Main.GetSettingItem(SelectedValues, "val16")
        TextBox18.Text = Main.GetSettingItem(SelectedValues, "val17")

        Label10.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim file As New IO.StreamWriter(SelectedValues)

        file.WriteLine("val1: " + ComboBox1.SelectedIndex.ToString)
        file.WriteLine("val2: " + ComboBox2.SelectedIndex.ToString)
        file.WriteLine("val3: " + ComboBox3.SelectedIndex.ToString)
        file.WriteLine("val4: " + ComboBox4.SelectedIndex.ToString)
        file.WriteLine("val5: " + ComboBox5.SelectedIndex.ToString)
        file.WriteLine("val6: " + ComboBox6.SelectedIndex.ToString)
        file.WriteLine("val7: " + ComboBox7.SelectedIndex.ToString)
        file.WriteLine("val8: " + ComboBox8.SelectedIndex.ToString)
        file.WriteLine("val9: " + ComboBox9.SelectedIndex.ToString)
        file.WriteLine("'limita valori")
        file.WriteLine("val10: " + TextBox11.Text)
        file.WriteLine("val11: " + TextBox12.Text)
        file.WriteLine("val12: " + TextBox13.Text)
        file.WriteLine("val13: " + TextBox14.Text)
        file.WriteLine("val14: " + TextBox15.Text)
        file.WriteLine("val15: " + TextBox16.Text)
        file.WriteLine("val16: " + TextBox17.Text)
        file.WriteLine("val17: " + TextBox18.Text)

        file.Close()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If textu <> "" Then
            TextBox1.Text = textu
            NewMethod()
            timeout_count = 0
            Timer1.Enabled = True
            Label10.Visible = False
        End If

        If timeout_count > 20 Then
            Label10.Visible = True
            textu = ""
        End If

        If Clear_Measure = True Then
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox10.Text = ""

            Torque_Cycle_NR = 0
            Torque_Fastener_NR = 0
            Torque_1_10_Nm = 0
            Angle_Cycle_NR = 0
            Angle_Fastener_NR = 0
            Angle_1_10_Nm = 0
            Torque_Rate_Cycle_NR = 0
            Torque_Rate_Fastener_NR = 0
            Torque_Rate_1_10_Nm = 0

            Clear_Measure = False

        End If



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If textu <> "" Then
            textu = ""
            Timer1.Enabled = False
        End If

        If SerialPort1.IsOpen Then
            Label11.Text = "COM port is OPEN"
            Label11.BackColor = Color.Lime
            Button4.Visible = False
        Else
            Label11.Text = "COM port is NOT OPEN"
            Label11.BackColor = Color.Red
            Button4.Visible = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim return_val As String = Main.serial_port_name()
            If return_val <> "None.." Then
                SerialPort1.PortName = return_val
                SerialPort1.ReadTimeout = 500
                SerialPort1.WriteTimeout = 500
                SerialPort1.Open()
                readThread.Start()
            End If
        Catch ex As Exception
            MsgBox("COM port not active on start CVII form Load ", vbOK, "ERROR COM PORT")
        End Try
    End Sub

End Class