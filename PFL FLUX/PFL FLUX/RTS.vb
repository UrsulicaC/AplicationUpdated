Public Class RTS
    Dim nume As String = "..\..\INI\Values.ini"
    Dim SelectedValues As String = "..\..\INI\SelectedValues.ini"
    Dim Type_prod As Char = "S"
    Dim Station_immo As String = "L5490"
    Public serie As String = ""
    Public Buffer1 As String
    Public Buffer41 As String
    Public Buffer42 As String
    Public Buffer43 As String
    Public Buffer44 As String
    Public Buffer45 As String
    Public Buffer46 As String
    Public Buffer47 As String
    Public Buffer48 As String
    Public Buffer49 As String
    Public Buffer410 As String
    Public Buffer411 As String
    Public Buffer412 As String
    Public Buffer61 As String
    Public Buffer62 As String
    Public Buffer63 As String
    Public Buffer64 As String

    Public Class valori
        Public valoare As Double
        Public nume As String
    End Class

    Public Class DMX
        Public valoare As String
        Public nume As String
    End Class

    Public Values(20) As valori
    Public DataMatrix(10) As DMX

    Public RTSS As New OracleConn

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property

    Private Sub RTS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = False
        Dim i As Integer
        Dim values_nr As Integer = Main.GetSettingItem(nume, "values_nr")
        Dim values_dm As Integer = Main.GetSettingItem(nume, "values_dm")
        'Dim returnn As String = ""

        ComboBox4.Items.Add("None")
        For i = 0 To values_nr
            Values(i) = New valori
            Values(i).nume = Main.GetSettingItem(nume, "value" + i.ToString)
            ComboBox4.Items.Add(Values(i).nume)
        Next

        ComboBox3.Items.Add("None..")
        For i = 0 To values_dm
            DataMatrix(i) = New DMX
            DataMatrix(i).nume = Main.GetSettingItem(nume, "dmx" + i.ToString)
            ComboBox3.Items.Add(DataMatrix(i).nume)
        Next
        Main.Label3.Text = DataMatrix(0).nume
        Main.Label5.Text = DataMatrix(1).nume
        Main.Label6.Text = DataMatrix(2).nume
        Main.Label7.Text = DataMatrix(3).nume

        'For i = 0 To values_dm
        '    ComboBox1.Items.Add(DataMatrix(i).nume)
        'Next

        'For i = 0 To values_nr
        '    ComboBox1.Items.Add(Values(i).nume)
        'Next
        'ComboBox1.Items.AddRange(ComboBox3.Items.Cast(Of String).ToArray())
        'ComboBox2.Items.AddRange(ComboBox3.Items.Cast(Of String).ToArray())
        ComboBox6.Items.AddRange(ComboBox3.Items.Cast(Of String).ToArray())
        ComboBox7.Items.AddRange(ComboBox3.Items.Cast(Of String).ToArray())
        ComboBox8.Items.AddRange(ComboBox3.Items.Cast(Of String).ToArray())
        ComboBox9.Items.AddRange(ComboBox3.Items.Cast(Of String).ToArray())
        ComboBox5.Items.AddRange(ComboBox3.Items.Cast(Of String).ToArray())
        ComboBox10.Items.AddRange(ComboBox3.Items.Cast(Of String).ToArray())
        ComboBox11.Items.AddRange(ComboBox3.Items.Cast(Of String).ToArray())
        ComboBox12.Items.AddRange(ComboBox3.Items.Cast(Of String).ToArray())

        'ComboBox5.Items.AddRange(ComboBox4.Items.Cast(Of String).ToArray())

        loadvalues()



        RTSS.OraParam.Ora_user = Main.GetSettingItem(nume, "RtsUser")
        RTSS.OraParam.Ora_password = Main.GetSettingItem(nume, "RtsPass")
        RTSS.OraParam.Ora_service = Main.GetSettingItem(nume, "RtsService")

        pingu()
        If TextBox1.BackColor = Color.LightGreen Then
            ' TextBox3.Text = RTSS.Oracle_Connexion(True)
        End If

        'open connection RTS
        TextBox3.Text = RTSS.Oracle_Connexion(False)

        'load values
        TextBox17.Text = Type_prod
        TextBox18.Text = Station_immo

        Timer1.Enabled = True
    End Sub
    Public Sub loadvalues()

        Try
            'ComboBox1.SelectedIndex = Main.GetSettingItem(SelectedValues, "flowDM")
            'ComboBox2.SelectedIndex = Main.GetSettingItem(SelectedValues, "validDM")
            ComboBox7.SelectedIndex = Main.GetSettingItem(SelectedValues, "compozant1")
            ComboBox6.SelectedIndex = Main.GetSettingItem(SelectedValues, "compozant2")
            ComboBox8.SelectedIndex = Main.GetSettingItem(SelectedValues, "compozant3")
            ComboBox9.SelectedIndex = Main.GetSettingItem(SelectedValues, "compozant4")
            TextBox19.Text = Main.GetSettingItem(SelectedValues, "op_compozant1")
            TextBox26.Text = Main.GetSettingItem(SelectedValues, "op_compozant2")
            TextBox27.Text = Main.GetSettingItem(SelectedValues, "op_compozant3")
            TextBox28.Text = Main.GetSettingItem(SelectedValues, "op_compozant4")
            TextBox21.Text = Main.GetSettingItem(SelectedValues, "ref_compozant1")
            TextBox29.Text = Main.GetSettingItem(SelectedValues, "ref_compozant2")
            TextBox30.Text = Main.GetSettingItem(SelectedValues, "ref_compozant3")
            TextBox31.Text = Main.GetSettingItem(SelectedValues, "ref_compozant4")
            TextBox11.Text = Main.GetSettingItem(SelectedValues, "op_link1")
            TextBox41.Text = Main.GetSettingItem(SelectedValues, "op_link2")
            TextBox42.Text = Main.GetSettingItem(SelectedValues, "op_link3")
            TextBox43.Text = Main.GetSettingItem(SelectedValues, "op_link4")
            ComboBox5.SelectedIndex = Main.GetSettingItem(SelectedValues, "dmx_link1")
            ComboBox10.SelectedIndex = Main.GetSettingItem(SelectedValues, "dmx_link2")
            ComboBox11.SelectedIndex = Main.GetSettingItem(SelectedValues, "dmx_link3")
            ComboBox12.SelectedIndex = Main.GetSettingItem(SelectedValues, "dmx_link4")

            TextBox5.Text = Main.GetSettingItem(SelectedValues, "op_nr")
            TextBox15.Text = Main.GetSettingItem(SelectedValues, "next_op_nr")
            Type_prod = Main.GetSettingItem(SelectedValues, "type_prod")
            Station_immo = Main.GetSettingItem(SelectedValues, "station_immo")

        Catch ex As Exception
            MsgBox("Invalid SelectedValues.INI file format ", vbOK, "ERROR SelectedValues.ini")
        End Try

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'pingu()
        'If TextBox1.BackColor = Color.LightGreen Then
        TextBox3.Text = RTSS.Oracle_Connexion(True)
        'End If

    End Sub

    Sub pingu()

        Try
            If My.Computer.Network.Ping(TextBox1.Text) Then
                TextBox1.BackColor = Color.LightGreen
                Button1.Text = "Ping OK"
            Else
                TextBox1.BackColor = Color.Red
                Button1.Text = "Ping NOK"
            End If
        Catch ex As Exception
            TextBox1.BackColor = Color.Red
            Button1.Text = "Ping NOK"
        End Try


    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Main.Show()
        Hide()
    End Sub

    Private Sub Form_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Leave
        Main.Show()
        Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button_SAVE.Click

        Dim file As New IO.StreamWriter(SelectedValues)
        'Operation = CInt(TextBox5.Text)
        file.WriteLine("' selected values ")
        'file.WriteLine("flowDM: " + ComboBox1.SelectedIndex.ToString)
        'file.WriteLine("validDM: " + ComboBox2.SelectedIndex.ToString)
        file.WriteLine("compozant1: " + ComboBox7.SelectedIndex.ToString)
        file.WriteLine("compozant2: " + ComboBox6.SelectedIndex.ToString)
        file.WriteLine("compozant3: " + ComboBox8.SelectedIndex.ToString)
        file.WriteLine("compozant4: " + ComboBox9.SelectedIndex.ToString)
        file.WriteLine("' operation ")
        file.WriteLine("op_compozant1: " + TextBox19.Text)
        file.WriteLine("op_compozant2: " + TextBox26.Text)
        file.WriteLine("op_compozant3: " + TextBox27.Text)
        file.WriteLine("op_compozant4: " + TextBox28.Text)
        file.WriteLine("' references ")
        file.WriteLine("ref_compozant1: " + TextBox21.Text)
        file.WriteLine("ref_compozant2: " + TextBox29.Text)
        file.WriteLine("ref_compozant3: " + TextBox30.Text)
        file.WriteLine("ref_compozant4: " + TextBox31.Text)
        file.WriteLine("' operation link")
        file.WriteLine("op_link1: " + TextBox11.Text)
        file.WriteLine("op_link2: " + TextBox41.Text)
        file.WriteLine("op_link3: " + TextBox42.Text)
        file.WriteLine("op_link4: " + TextBox43.Text)
        file.WriteLine("' dmx link")
        file.WriteLine("dmx_link1: " + ComboBox5.SelectedIndex.ToString)
        file.WriteLine("dmx_link2: " + ComboBox10.SelectedIndex.ToString)
        file.WriteLine("dmx_link3: " + ComboBox11.SelectedIndex.ToString)
        file.WriteLine("dmx_link4: " + ComboBox12.SelectedIndex.ToString)
        file.WriteLine("op_nr: " + TextBox5.Text)
        file.WriteLine("next_op_nr: " + TextBox15.Text)
        file.WriteLine("type_prod: " + Type_prod.ToString)
        file.WriteLine("station_immo: " + Station_immo.ToString)

        file.Close()
    End Sub

#Region "MES"


    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click

        'Dim buff As String = RTSS.Create_Buffer1("123456789876543", "28445788", "S", "", "", "", "",
        '             390, 1, "21222", Date.Now, 2)
        TextBox47.Text = RTSS.createfile()

    End Sub

#End Region

#Region "Creare date pentru RTS"

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ''DM flow control
        'If ComboBox1.SelectedIndex > 0 Then
        '    TextBox4.Text = DataMatrix(ComboBox1.SelectedIndex - 1).valoare
        'End If
        ''DM Valid OP
        'If ComboBox2.SelectedIndex > 0 Then
        '    TextBox8.Text = DataMatrix(ComboBox2.SelectedIndex - 1).valoare
        'End If

        'DM compozant
        If ComboBox7.SelectedIndex > 0 Then
            TextBox20.Text = DataMatrix(ComboBox7.SelectedIndex - 1).valoare
        End If

        If ComboBox6.SelectedIndex > 0 Then
            TextBox23.Text = DataMatrix(ComboBox6.SelectedIndex - 1).valoare
        End If

        If ComboBox8.SelectedIndex > 0 Then
            TextBox24.Text = DataMatrix(ComboBox8.SelectedIndex - 1).valoare
        End If

        If ComboBox9.SelectedIndex > 0 Then
            TextBox25.Text = DataMatrix(ComboBox9.SelectedIndex - 1).valoare
        End If

        'LINK

        If ComboBox5.SelectedIndex > 0 Then
            TextBox13.Text = DataMatrix(ComboBox5.SelectedIndex - 1).valoare
        End If
        If ComboBox10.SelectedIndex > 0 Then
            TextBox38.Text = DataMatrix(ComboBox10.SelectedIndex - 1).valoare
        End If

        If ComboBox11.SelectedIndex > 0 Then
            TextBox39.Text = DataMatrix(ComboBox11.SelectedIndex - 1).valoare
        End If

        If ComboBox12.SelectedIndex > 0 Then
            TextBox40.Text = DataMatrix(ComboBox12.SelectedIndex - 1).valoare
        End If

        'operation flow control
        'TextBox5.Text = Operation

        'ref flow control
        TextBox6.Text = Main.ComboBox1.Text

        'ref valid op
        TextBox16.Text = Main.ComboBox1.Text

        Type_prod = TextBox17.Text
        Station_immo = TextBox18.Text

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        valid_op()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' RTSS.SP_Flow_Control(Main.ComboBox1.Text, 590, TextBox2.Text)

        flow_control()

        'TextBox2.Text = RTSS.PCK_FLOW_CTRL("2026902836706111", 490, "28536140", 1, "MULTI_SIMPLE", 0, 0).ToString

        'TextBox10.Text = RTSS.PCK_VALIDATION_OP("1111111111111111", 490, "28536140", Date.Now, 0, 1, "S", "L5490", 0).ToString

        'TextBox11.Text = RTSS.PCK_CTRL_GAMME_COMPOSANT_DM("1234567891111167", 390, "22222222", 1, 0).ToString

        'TextBox13.Text = RTSS.PCK_SN_PUMP("R", serie, 0).ToString

        'TextBox14.Text = serie

        'TextBox12.Text = RTSS.PCK_LINK_COMPONENT(serie, 390, Date.Now, "1111111111111111", 1, 0).ToString

    End Sub
    Public Function flow_control() As Integer
        TextBox7.Text = RTSS.PCK_FLOW_CTRL(TextBox4.Text, TextBox5.Text, Main.ComboBox1.Text, 1, "MULTI_SIMPLE", 0, 0).ToString

        Return CInt(TextBox7.Text)
    End Function

    Public Function valid_op()
        TextBox9.Text = RTSS.PCK_VALIDATION_OP(TextBox8.Text, TextBox15.Text, Main.ComboBox1.Text, Date.Now, 0, 1, "S", "L5490", 0).ToString
        Buffer1 = RTSS.Create_Buffer1(TextBox8.Text, TextBox21.Text, "S", "", "", "", "",
        CInt(TextBox19.Text), 1, "21222", Date.Now, 2)

        Return CInt(TextBox9.Text)
    End Function

    Public Function PCK_CTRL_GAMME_COMPOSANT_DM(ByVal nr_compozant As Integer) As Integer
        Select Case nr_compozant
            Case 1
                TextBox22.Text = RTSS.PCK_CTRL_GAMME_COMPOSANT_DM(DataMatrix(ComboBox7.SelectedIndex - 1).valoare, TextBox19.Text, TextBox21.Text, 1, 0).ToString
                'Buffer41 = RTSS.Create_Buffer1(TextBox20.Text, TextBox21.Text, "S", "", "", "", "",
                'CInt(TextBox19.Text), 1, "21222", Date.Now, 2)

                Return CInt(TextBox22.Text)
            Case 2
                TextBox32.Text = RTSS.PCK_CTRL_GAMME_COMPOSANT_DM(DataMatrix(ComboBox6.SelectedIndex - 1).valoare, TextBox26.Text, TextBox29.Text, 1, 0).ToString
                'Buffer42 = RTSS.Create_Buffer1(TextBox23.Text, TextBox29.Text, "S", "", "", "", "",
                'CInt(TextBox26.Text), 1, "21222", Date.Now, 2)

                Return CInt(TextBox32.Text)
            Case 3
                TextBox33.Text = RTSS.PCK_CTRL_GAMME_COMPOSANT_DM(TextBox24.Text, TextBox27.Text, TextBox30.Text, 1, 0).ToString
                'Buffer43 = RTSS.Create_Buffer1(TextBox24.Text, TextBox30.Text, "S", "", "", "", "",
                'CInt(TextBox27.Text), 1, "21222", Date.Now, 2)

                Return CInt(TextBox33.Text)
            Case 4
                TextBox34.Text = RTSS.PCK_CTRL_GAMME_COMPOSANT_DM(TextBox25.Text, TextBox28.Text, TextBox31.Text, 1, 0).ToString
                'Buffer44 = RTSS.Create_Buffer1(TextBox25.Text, TextBox31.Text, "S", "", "", "", "",
                'CInt(TextBox28.Text), 1, "21222", Date.Now, 2)

                Return CInt(TextBox34.Text)
            Case Else
                MsgBox("PCK_CTRL_GAMME_COMPOSANT_DM invalid number (1..4) ", vbOK, "ERROR PCK_CTRL_GAMME_COMPOSANT_DM")
                Return -100
        End Select

    End Function

    Public Function PCK_SN_PUMP() As Integer
        TextBox10.Text = RTSS.PCK_SN_PUMP("R", serie, 0).ToString()
        Main.TextBox6.Text = serie
        TextBox4.Text = serie
        TextBox8.Text = serie
        TextBox2.Text = serie
        TextBox12.Text = serie
        TextBox35.Text = serie
        TextBox36.Text = serie
        TextBox37.Text = serie

        Return CInt(TextBox10.Text)
    End Function

    Public Function PCK_LINK_COMPONENT(ByVal nr_link As Integer) As Integer
        Select Case nr_link
            Case 1
                TextBox14.Text = RTSS.PCK_LINK_COMPONENT(TextBox12.Text, CInt(TextBox11.Text), Date.Now, TextBox13.Text, ComboBox5.Text, 0).ToString
                Buffer61 = RTSS.Create_Buffer6(TextBox12.Text, TextBox11.Text, Date.Now, TextBox13.Text, ComboBox5.Text)
                Return CInt(TextBox14.Text)
            Case 2
                TextBox44.Text = RTSS.PCK_LINK_COMPONENT(TextBox35.Text, TextBox41.Text, Date.Now, TextBox38.Text, ComboBox10.Text, 0).ToString
                Buffer62 = RTSS.Create_Buffer6(TextBox35.Text, TextBox41.Text, Date.Now, TextBox38.Text, ComboBox10.Text)
                Return CInt(TextBox44.Text)
            Case 3
                TextBox45.Text = RTSS.PCK_LINK_COMPONENT(TextBox36.Text, TextBox42.Text, Date.Now, TextBox39.Text, ComboBox11.Text, 0).ToString
                Buffer63 = RTSS.Create_Buffer6(TextBox36.Text, TextBox42.Text, Date.Now, TextBox39.Text, ComboBox11.Text)
                Return CInt(TextBox45.Text)
            Case 4
                TextBox46.Text = RTSS.PCK_LINK_COMPONENT(TextBox37.Text, TextBox43.Text, Date.Now, TextBox40.Text, ComboBox12.Text, 0).ToString
                Buffer63 = RTSS.Create_Buffer6(TextBox37.Text, TextBox43.Text, Date.Now, TextBox40.Text, ComboBox12.Text)
                Return CInt(TextBox46.Text)
            Case Else
                MsgBox("PCK_CTRL_GAMME_COMPOSANT_DM invalid number (1..4) ", vbOK, "ERROR PCK_CTRL_GAMME_COMPOSANT_DM")
                Return -100
        End Select

    End Function

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        PCK_CTRL_GAMME_COMPOSANT_DM(1)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        PCK_CTRL_GAMME_COMPOSANT_DM(2)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        PCK_CTRL_GAMME_COMPOSANT_DM(3)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        PCK_CTRL_GAMME_COMPOSANT_DM(4)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        PCK_SN_PUMP()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        PCK_LINK_COMPONENT(1)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        PCK_LINK_COMPONENT(2)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        PCK_LINK_COMPONENT(3)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        PCK_LINK_COMPONENT(4)
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        ' TextBox10.Text = RTSS.PCK_SN_PUMP("R", serie, 0).ToString()

        RTSS.GET_PUMP_SN_WITH_COMP("9876543210987654", "FP", serie, 0)
        Main.TextBox6.Text = serie
        TextBox4.Text = serie
        TextBox8.Text = serie
        TextBox2.Text = serie
        TextBox12.Text = serie
        TextBox35.Text = serie
        TextBox36.Text = serie
        TextBox37.Text = serie

    End Sub





#End Region
End Class