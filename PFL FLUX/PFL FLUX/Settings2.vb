
Imports System.Diagnostics.Tracing

Public Class Settings2
    Dim nume As String = "..\..\INI\Test2.ini"
    Dim SP As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main.Show()
        Hide()
    End Sub
    Private Sub Form_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Leave
        Main.Show()
        Hide()
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property


    Private Sub frmSelectPort_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        GetSerialPortnames()
    End Sub

    Sub GetSerialPortnames()
        ComboBox65.Items.Add("None..")

        For Each SP In My.Computer.Ports.SerialPortNames
            ComboBox65.Items.Add(SP)

        Next

        ComboBox65.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox66.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox67.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox68.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox69.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox70.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox71.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox72.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox73.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox74.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox75.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox76.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox77.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox78.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox79.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox80.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox81.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox82.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox83.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())
        ComboBox84.Items.AddRange(ComboBox65.Items.Cast(Of String).ToArray())

        '(Under button click event) 
        'SP =Listbox1. SelectedItem
        'SerialPort1. PortName=SP 
        'SerialPort1. Open() 

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim file As New IO.StreamWriter(nume)

        'step1
        Main.STEPS(21).delay = TextBox2.Text
        file.WriteLine("step21delay: " + Main.STEPS(21).delay.ToString)
        Main.STEPS(21).read_DM = ComboBox23.SelectedIndex
        file.WriteLine("step21PN: " + Main.STEPS(21).read_DM.ToString)
        Main.STEPS(21).visual_control = CheckBox3.Checked
        file.WriteLine("step21visual: " + Main.STEPS(21).visual_control.ToString)
        Main.STEPS(21).RW_param = ComboBox2.SelectedIndex
        file.WriteLine("step21RWparam: " + Main.STEPS(21).RW_param.ToString)
        Main.STEPS(21).adr_param = TextBox24.Text
        file.WriteLine("step21adrparam: " + Main.STEPS(21).adr_param.ToString)
        Main.STEPS(21).val_param = TextBox83.Text
        file.WriteLine("step21valparam: " + Main.STEPS(21).val_param.ToString)
        Main.STEPS(21).DataBase = ComboBox44.SelectedIndex
        file.WriteLine("step21DB: " + Main.STEPS(21).DataBase.ToString)
        Try
            Main.STEPS(21).serial = ComboBox65.SelectedIndex
            file.WriteLine("step21serial: " + Main.STEPS(21).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step2
        Main.STEPS(22).delay = TextBox3.Text
        file.WriteLine("step22delay: " + Main.STEPS(22).delay.ToString)
        Main.STEPS(22).read_DM = ComboBox24.SelectedIndex
        file.WriteLine("step22PN: " + Main.STEPS(22).read_DM.ToString)
        Main.STEPS(22).visual_control = CheckBox5.Checked
        file.WriteLine("step22visual: " + Main.STEPS(22).visual_control.ToString)
        Main.STEPS(22).RW_param = ComboBox3.SelectedIndex
        file.WriteLine("step22RWparam: " + Main.STEPS(22).RW_param.ToString)
        Main.STEPS(22).adr_param = TextBox25.Text
        file.WriteLine("step22adrparam: " + Main.STEPS(22).adr_param.ToString)
        Main.STEPS(22).val_param = TextBox82.Text
        file.WriteLine("step22valparam: " + Main.STEPS(22).val_param.ToString)
        Main.STEPS(22).DataBase = ComboBox45.SelectedIndex
        file.WriteLine("step22DB: " + Main.STEPS(22).DataBase.ToString)
        Try
            Main.STEPS(22).serial = ComboBox66.SelectedIndex
            file.WriteLine("step22serial: " + Main.STEPS(22).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step3
        Main.STEPS(23).delay = TextBox4.Text
        file.WriteLine("step23delay: " + Main.STEPS(23).delay.ToString)
        Main.STEPS(23).read_DM = ComboBox25.SelectedIndex
        file.WriteLine("step23PN: " + Main.STEPS(23).read_DM.ToString)
        Main.STEPS(23).visual_control = CheckBox7.Checked
        file.WriteLine("step23visual: " + Main.STEPS(23).visual_control.ToString)
        Main.STEPS(23).RW_param = ComboBox4.SelectedIndex
        file.WriteLine("step23RWparam: " + Main.STEPS(23).RW_param.ToString)
        Main.STEPS(23).adr_param = TextBox26.Text
        file.WriteLine("step23adrparam: " + Main.STEPS(23).adr_param.ToString)
        Main.STEPS(23).val_param = TextBox81.Text
        file.WriteLine("step23valparam: " + Main.STEPS(23).val_param.ToString)
        Main.STEPS(23).DataBase = ComboBox46.SelectedIndex
        file.WriteLine("step23DB: " + Main.STEPS(23).DataBase.ToString)
        Try
            Main.STEPS(23).serial = ComboBox67.SelectedIndex
            file.WriteLine("step23serial: " + Main.STEPS(23).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step4
        Main.STEPS(24).delay = TextBox5.Text
        file.WriteLine("step24delay: " + Main.STEPS(24).delay.ToString)
        Main.STEPS(24).read_DM = ComboBox26.SelectedIndex
        file.WriteLine("step24PN: " + Main.STEPS(24).read_DM.ToString)
        Main.STEPS(24).visual_control = CheckBox9.Checked
        file.WriteLine("step24visual: " + Main.STEPS(24).visual_control.ToString)
        Main.STEPS(24).RW_param = ComboBox5.SelectedIndex
        file.WriteLine("step24RWparam: " + Main.STEPS(24).RW_param.ToString)
        Main.STEPS(24).adr_param = TextBox27.Text
        file.WriteLine("step24adrparam: " + Main.STEPS(24).adr_param.ToString)
        Main.STEPS(24).val_param = TextBox80.Text
        file.WriteLine("step24valparam: " + Main.STEPS(24).val_param.ToString)
        Main.STEPS(24).DataBase = ComboBox47.SelectedIndex
        file.WriteLine("step24DB: " + Main.STEPS(24).DataBase.ToString)
        Try
            Main.STEPS(24).serial = ComboBox68.SelectedIndex
            file.WriteLine("step24serial: " + Main.STEPS(24).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step5
        Main.STEPS(25).delay = TextBox6.Text
        file.WriteLine("step25delay: " + Main.STEPS(25).delay.ToString)
        Main.STEPS(25).read_DM = ComboBox27.SelectedIndex
        file.WriteLine("step25PN: " + Main.STEPS(25).read_DM.ToString)
        Main.STEPS(25).visual_control = CheckBox11.Checked
        file.WriteLine("step25visual: " + Main.STEPS(25).visual_control.ToString)
        Main.STEPS(25).RW_param = ComboBox6.SelectedIndex
        file.WriteLine("step25RWparam: " + Main.STEPS(25).RW_param.ToString)
        Main.STEPS(25).adr_param = TextBox28.Text
        file.WriteLine("step25adrparam: " + Main.STEPS(25).adr_param.ToString)
        Main.STEPS(25).val_param = TextBox79.Text
        file.WriteLine("step25valparam: " + Main.STEPS(25).val_param.ToString)
        Main.STEPS(25).DataBase = ComboBox48.SelectedIndex
        file.WriteLine("step25DB: " + Main.STEPS(25).DataBase.ToString)
        Try
            Main.STEPS(25).serial = ComboBox69.SelectedIndex
            file.WriteLine("step25serial: " + Main.STEPS(25).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step6
        Main.STEPS(26).delay = TextBox7.Text
        file.WriteLine("step26delay: " + Main.STEPS(26).delay.ToString)
        Main.STEPS(26).read_DM = ComboBox28.SelectedIndex
        file.WriteLine("step26PN: " + Main.STEPS(26).read_DM.ToString)
        Main.STEPS(26).visual_control = CheckBox13.Checked
        file.WriteLine("step26visual: " + Main.STEPS(26).visual_control.ToString)
        Main.STEPS(26).RW_param = ComboBox7.SelectedIndex
        file.WriteLine("step26RWparam: " + Main.STEPS(26).RW_param.ToString)
        Main.STEPS(26).adr_param = TextBox29.Text
        file.WriteLine("step26adrparam: " + Main.STEPS(26).adr_param.ToString)
        Main.STEPS(26).val_param = TextBox78.Text
        file.WriteLine("step26valparam: " + Main.STEPS(26).val_param.ToString)
        Main.STEPS(26).DataBase = ComboBox49.SelectedIndex
        file.WriteLine("step26DB: " + Main.STEPS(26).DataBase.ToString)
        Try
            Main.STEPS(0).serial = ComboBox70.SelectedIndex
            file.WriteLine("step26serial: " + Main.STEPS(0).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step7
        Main.STEPS(27).delay = TextBox8.Text
        file.WriteLine("step27delay: " + Main.STEPS(27).delay.ToString)
        Main.STEPS(27).read_DM = ComboBox29.SelectedIndex
        file.WriteLine("step27PN: " + Main.STEPS(27).read_DM.ToString)
        Main.STEPS(27).visual_control = CheckBox15.Checked
        file.WriteLine("step27visual: " + Main.STEPS(27).visual_control.ToString)
        Main.STEPS(27).RW_param = ComboBox8.SelectedIndex
        file.WriteLine("step27RWparam: " + Main.STEPS(27).RW_param.ToString)
        Main.STEPS(27).adr_param = TextBox50.Text
        file.WriteLine("step27adrparam: " + Main.STEPS(27).adr_param.ToString)
        Main.STEPS(27).val_param = TextBox77.Text
        file.WriteLine("step27valparam: " + Main.STEPS(27).val_param.ToString)
        Main.STEPS(27).DataBase = ComboBox50.SelectedIndex
        file.WriteLine("step27DB: " + Main.STEPS(27).DataBase.ToString)
        Try
            Main.STEPS(27).serial = ComboBox71.SelectedIndex
            file.WriteLine("step27serial: " + Main.STEPS(27).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step8
        Main.STEPS(28).delay = TextBox9.Text
        file.WriteLine("step28delay: " + Main.STEPS(28).delay.ToString)
        Main.STEPS(28).read_DM = ComboBox30.SelectedIndex
        file.WriteLine("step28PN: " + Main.STEPS(28).read_DM.ToString)
        Main.STEPS(28).visual_control = CheckBox17.Checked
        file.WriteLine("step28visual: " + Main.STEPS(28).visual_control.ToString)
        Main.STEPS(28).RW_param = ComboBox9.SelectedIndex
        file.WriteLine("step28RWparam: " + Main.STEPS(28).RW_param.ToString)
        Main.STEPS(28).adr_param = TextBox51.Text
        file.WriteLine("step28adrparam: " + Main.STEPS(28).adr_param.ToString)
        Main.STEPS(28).val_param = TextBox76.Text
        file.WriteLine("step28valparam: " + Main.STEPS(28).val_param.ToString)
        Main.STEPS(28).DataBase = ComboBox51.SelectedIndex
        file.WriteLine("step28DB: " + Main.STEPS(28).DataBase.ToString)
        Try
            Main.STEPS(28).serial = ComboBox72.SelectedIndex
            file.WriteLine("step28serial: " + Main.STEPS(0).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step9
        Main.STEPS(29).delay = TextBox10.Text
        file.WriteLine("step29delay: " + Main.STEPS(29).delay.ToString)
        Main.STEPS(29).read_DM = ComboBox31.SelectedIndex
        file.WriteLine("step29PN: " + Main.STEPS(29).read_DM.ToString)
        Main.STEPS(29).visual_control = CheckBox19.Checked
        file.WriteLine("step29visual: " + Main.STEPS(29).visual_control.ToString)
        Main.STEPS(29).RW_param = ComboBox10.SelectedIndex
        file.WriteLine("step29RWparam: " + Main.STEPS(29).RW_param.ToString)
        Main.STEPS(29).adr_param = TextBox52.Text
        file.WriteLine("step29adrparam: " + Main.STEPS(29).adr_param.ToString)
        Main.STEPS(29).val_param = TextBox75.Text
        file.WriteLine("step29valparam: " + Main.STEPS(29).val_param.ToString)
        Main.STEPS(29).DataBase = ComboBox52.SelectedIndex
        file.WriteLine("step29DB: " + Main.STEPS(29).DataBase.ToString)
        Try
            Main.STEPS(29).serial = ComboBox73.SelectedIndex
            file.WriteLine("step29serial: " + Main.STEPS(29).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step10
        Main.STEPS(30).delay = TextBox11.Text
        file.WriteLine("step30delay: " + Main.STEPS(30).delay.ToString)
        Main.STEPS(30).read_DM = ComboBox32.SelectedIndex
        file.WriteLine("step30PN: " + Main.STEPS(30).read_DM.ToString)
        Main.STEPS(30).visual_control = CheckBox21.Checked
        file.WriteLine("step30visual: " + Main.STEPS(30).visual_control.ToString)
        Main.STEPS(30).RW_param = ComboBox11.SelectedIndex
        file.WriteLine("step30RWparam: " + Main.STEPS(30).RW_param.ToString)
        Main.STEPS(30).adr_param = TextBox53.Text
        file.WriteLine("step30adrparam: " + Main.STEPS(30).adr_param.ToString)
        Main.STEPS(30).val_param = TextBox74.Text
        file.WriteLine("step30valparam: " + Main.STEPS(30).val_param.ToString)
        Main.STEPS(30).DataBase = ComboBox53.SelectedIndex
        file.WriteLine("step30DB: " + Main.STEPS(30).DataBase.ToString)
        Main.STEPS(30).serial = ComboBox74.SelectedIndex
        file.WriteLine("step30serial: " + Main.STEPS(30).serial.ToString)

        'step11
        Main.STEPS(31).delay = TextBox22.Text
        file.WriteLine("step31delay: " + Main.STEPS(31).delay.ToString)
        Main.STEPS(31).read_DM = ComboBox33.SelectedIndex
        file.WriteLine("step31PN: " + Main.STEPS(31).read_DM.ToString)
        Main.STEPS(31).visual_control = CheckBox43.Checked
        file.WriteLine("step31visual: " + Main.STEPS(31).visual_control.ToString)
        Main.STEPS(31).RW_param = ComboBox12.SelectedIndex
        file.WriteLine("step31RWparam: " + Main.STEPS(31).RW_param.ToString)
        Main.STEPS(31).adr_param = TextBox54.Text
        file.WriteLine("step31adrparam: " + Main.STEPS(31).adr_param.ToString)
        Main.STEPS(31).val_param = TextBox73.Text
        file.WriteLine("step31valparam: " + Main.STEPS(31).val_param.ToString)
        Main.STEPS(31).DataBase = ComboBox54.SelectedIndex
        file.WriteLine("step31DB: " + Main.STEPS(31).DataBase.ToString)
        Main.STEPS(31).serial = ComboBox75.SelectedIndex
        file.WriteLine("step31serial: " + Main.STEPS(31).serial.ToString)

        'step12
        Main.STEPS(32).delay = TextBox21.Text
        file.WriteLine("step32delay: " + Main.STEPS(32).delay.ToString)
        Main.STEPS(32).read_DM = ComboBox34.SelectedIndex
        file.WriteLine("step32PN: " + Main.STEPS(32).read_DM.ToString)
        Main.STEPS(32).visual_control = CheckBox41.Checked
        file.WriteLine("step32visual: " + Main.STEPS(32).visual_control.ToString)
        Main.STEPS(32).RW_param = ComboBox13.SelectedIndex
        file.WriteLine("step32RWparam: " + Main.STEPS(32).RW_param.ToString)
        Main.STEPS(32).adr_param = TextBox55.Text
        file.WriteLine("step32adrparam: " + Main.STEPS(32).adr_param.ToString)
        Main.STEPS(32).val_param = TextBox72.Text
        file.WriteLine("step32valparam: " + Main.STEPS(32).val_param.ToString)
        Main.STEPS(32).DataBase = ComboBox55.SelectedIndex
        file.WriteLine("step32DB: " + Main.STEPS(32).DataBase.ToString)
        Main.STEPS(32).serial = ComboBox76.SelectedIndex
        file.WriteLine("step32serial: " + Main.STEPS(32).serial.ToString)

        'step13
        Main.STEPS(33).delay = TextBox20.Text
        file.WriteLine("step33delay: " + Main.STEPS(33).delay.ToString)
        Main.STEPS(33).read_DM = ComboBox35.SelectedIndex
        file.WriteLine("step33PN: " + Main.STEPS(33).read_DM.ToString)
        Main.STEPS(33).visual_control = CheckBox39.Checked
        file.WriteLine("step33visual: " + Main.STEPS(33).visual_control.ToString)
        Main.STEPS(33).RW_param = ComboBox14.SelectedIndex
        file.WriteLine("step33RWparam: " + Main.STEPS(33).RW_param.ToString)
        Main.STEPS(33).adr_param = TextBox56.Text
        file.WriteLine("step33adrparam: " + Main.STEPS(33).adr_param.ToString)
        Main.STEPS(33).val_param = TextBox71.Text
        file.WriteLine("step33valparam: " + Main.STEPS(33).val_param.ToString)
        Main.STEPS(33).DataBase = ComboBox56.SelectedIndex
        file.WriteLine("step33DB: " + Main.STEPS(33).DataBase.ToString)
        Main.STEPS(33).serial = ComboBox77.SelectedIndex
        file.WriteLine("step33serial: " + Main.STEPS(33).serial.ToString)

        'step14
        Main.STEPS(34).delay = TextBox19.Text
        file.WriteLine("step34delay: " + Main.STEPS(34).delay.ToString)
        Main.STEPS(34).read_DM = ComboBox36.SelectedIndex
        file.WriteLine("step34PN: " + Main.STEPS(34).read_DM.ToString)
        Main.STEPS(34).visual_control = CheckBox37.Checked
        file.WriteLine("step34visual: " + Main.STEPS(34).visual_control.ToString)
        Main.STEPS(34).RW_param = ComboBox15.SelectedIndex
        file.WriteLine("step34RWparam: " + Main.STEPS(34).RW_param.ToString)
        Main.STEPS(34).adr_param = TextBox57.Text
        file.WriteLine("step34adrparam: " + Main.STEPS(34).adr_param.ToString)
        Main.STEPS(34).val_param = TextBox70.Text
        file.WriteLine("step34valparam: " + Main.STEPS(34).val_param.ToString)
        Main.STEPS(34).DataBase = ComboBox57.SelectedIndex
        file.WriteLine("step34DB: " + Main.STEPS(34).DataBase.ToString)
        Main.STEPS(34).serial = ComboBox78.SelectedIndex
        file.WriteLine("step34serial: " + Main.STEPS(34).serial.ToString)

        'step15
        Main.STEPS(35).delay = TextBox18.Text
        file.WriteLine("step35delay: " + Main.STEPS(35).delay.ToString)
        Main.STEPS(35).read_DM = ComboBox37.SelectedIndex
        file.WriteLine("step35PN: " + Main.STEPS(35).read_DM.ToString)
        Main.STEPS(35).visual_control = CheckBox35.Checked
        file.WriteLine("step35visual: " + Main.STEPS(35).visual_control.ToString)
        Main.STEPS(35).RW_param = ComboBox16.SelectedIndex
        file.WriteLine("step35RWparam: " + Main.STEPS(35).RW_param.ToString)
        Main.STEPS(35).adr_param = TextBox58.Text
        file.WriteLine("step35adrparam: " + Main.STEPS(35).adr_param.ToString)
        Main.STEPS(35).val_param = TextBox69.Text
        file.WriteLine("step35valparam: " + Main.STEPS(35).val_param.ToString)
        Main.STEPS(35).DataBase = ComboBox58.SelectedIndex
        file.WriteLine("step35DB: " + Main.STEPS(35).DataBase.ToString)
        Main.STEPS(35).serial = ComboBox79.SelectedIndex
        file.WriteLine("step35serial: " + Main.STEPS(35).serial.ToString)

        'step16
        Main.STEPS(36).delay = TextBox17.Text
        file.WriteLine("step36delay: " + Main.STEPS(36).delay.ToString)
        Main.STEPS(36).read_DM = ComboBox38.SelectedIndex
        file.WriteLine("step36PN: " + Main.STEPS(36).read_DM.ToString)
        Main.STEPS(36).visual_control = CheckBox33.Checked
        file.WriteLine("step36visual: " + Main.STEPS(36).visual_control.ToString)
        Main.STEPS(36).RW_param = ComboBox17.SelectedIndex
        file.WriteLine("step36RWparam: " + Main.STEPS(36).RW_param.ToString)
        Main.STEPS(36).adr_param = TextBox59.Text
        file.WriteLine("step36adrparam: " + Main.STEPS(36).adr_param.ToString)
        Main.STEPS(36).val_param = TextBox68.Text
        file.WriteLine("step36valparam: " + Main.STEPS(36).val_param.ToString)
        Main.STEPS(36).DataBase = ComboBox59.SelectedIndex
        file.WriteLine("step36DB: " + Main.STEPS(36).DataBase.ToString)
        Main.STEPS(36).serial = ComboBox80.SelectedIndex
        file.WriteLine("step36serial: " + Main.STEPS(36).serial.ToString)

        'step17
        Main.STEPS(37).delay = TextBox16.Text
        file.WriteLine("step37delay: " + Main.STEPS(37).delay.ToString)
        Main.STEPS(37).read_DM = ComboBox39.SelectedIndex
        file.WriteLine("step37PN: " + Main.STEPS(37).read_DM.ToString)
        Main.STEPS(37).visual_control = CheckBox31.Checked
        file.WriteLine("step37visual: " + Main.STEPS(37).visual_control.ToString)
        Main.STEPS(37).RW_param = ComboBox18.SelectedIndex
        file.WriteLine("step37RWparam: " + Main.STEPS(37).RW_param.ToString)
        Main.STEPS(37).adr_param = TextBox60.Text
        file.WriteLine("step37adrparam: " + Main.STEPS(37).adr_param.ToString)
        Main.STEPS(37).val_param = TextBox67.Text
        file.WriteLine("step37valparam: " + Main.STEPS(37).val_param.ToString)
        Main.STEPS(37).DataBase = ComboBox60.SelectedIndex
        file.WriteLine("step37DB: " + Main.STEPS(37).DataBase.ToString)
        Main.STEPS(37).serial = ComboBox81.SelectedIndex
        file.WriteLine("step37serial: " + Main.STEPS(37).serial.ToString)

        'step18
        Main.STEPS(38).delay = TextBox15.Text
        file.WriteLine("step38delay: " + Main.STEPS(38).delay.ToString)
        Main.STEPS(38).read_DM = ComboBox40.SelectedIndex
        file.WriteLine("step38PN: " + Main.STEPS(38).read_DM.ToString)
        Main.STEPS(38).visual_control = CheckBox29.Checked
        file.WriteLine("step38visual: " + Main.STEPS(38).visual_control.ToString)
        Main.STEPS(38).RW_param = ComboBox19.SelectedIndex
        file.WriteLine("step38RWparam: " + Main.STEPS(38).RW_param.ToString)
        Main.STEPS(38).adr_param = TextBox61.Text
        file.WriteLine("step38adrparam: " + Main.STEPS(38).adr_param.ToString)
        Main.STEPS(38).val_param = TextBox66.Text
        file.WriteLine("step38valparam: " + Main.STEPS(38).val_param.ToString)
        Main.STEPS(38).DataBase = ComboBox61.SelectedIndex
        file.WriteLine("step38DB: " + Main.STEPS(38).DataBase.ToString)
        Main.STEPS(38).serial = ComboBox82.SelectedIndex
        file.WriteLine("step38serial: " + Main.STEPS(38).serial.ToString)

        'step19
        Main.STEPS(39).delay = TextBox14.Text
        file.WriteLine("step39delay: " + Main.STEPS(39).delay.ToString)
        Main.STEPS(39).read_DM = ComboBox41.SelectedIndex
        file.WriteLine("step39PN: " + Main.STEPS(39).read_DM.ToString)
        Main.STEPS(39).visual_control = CheckBox27.Checked
        file.WriteLine("step39visual: " + Main.STEPS(39).visual_control.ToString)
        Main.STEPS(39).RW_param = ComboBox20.SelectedIndex
        file.WriteLine("step39RWparam: " + Main.STEPS(39).RW_param.ToString)
        Main.STEPS(39).adr_param = TextBox62.Text
        file.WriteLine("step39adrparam: " + Main.STEPS(39).adr_param.ToString)
        Main.STEPS(39).val_param = TextBox65.Text
        file.WriteLine("step39valparam: " + Main.STEPS(39).val_param.ToString)
        Main.STEPS(39).DataBase = ComboBox62.SelectedIndex
        file.WriteLine("step39DB: " + Main.STEPS(39).DataBase.ToString)
        Main.STEPS(39).serial = ComboBox83.SelectedIndex
        file.WriteLine("step39serial: " + Main.STEPS(39).serial.ToString)

        'step20
        Main.STEPS(40).delay = TextBox13.Text
        file.WriteLine("step40delay: " + Main.STEPS(40).delay.ToString)
        Main.STEPS(40).read_DM = ComboBox42.SelectedIndex
        file.WriteLine("step40PN: " + Main.STEPS(40).read_DM.ToString)
        Main.STEPS(40).visual_control = CheckBox25.Checked
        file.WriteLine("step40visual: " + Main.STEPS(40).visual_control.ToString)
        Main.STEPS(40).RW_param = ComboBox21.SelectedIndex
        file.WriteLine("step40RWparam: " + Main.STEPS(40).RW_param.ToString)
        Main.STEPS(40).adr_param = TextBox63.Text
        file.WriteLine("step40adrparam: " + Main.STEPS(40).adr_param.ToString)
        Main.STEPS(40).val_param = TextBox64.Text
        file.WriteLine("step40valparam: " + Main.STEPS(40).val_param.ToString)
        Main.STEPS(40).DataBase = ComboBox63.SelectedIndex
        file.WriteLine("step40DB: " + Main.STEPS(40).DataBase.ToString)
        Main.STEPS(40).serial = ComboBox84.SelectedIndex
        file.WriteLine("step40serial: " + Main.STEPS(40).serial.ToString)

        file.Close()

        Dim file2 As New IO.StreamWriter(Main.Messages_ini2)

        file2.WriteLine("mesaj21: " + TextBox31.Text)
        file2.WriteLine("mesaj22: " + TextBox32.Text)
        file2.WriteLine("mesaj23: " + TextBox33.Text)
        file2.WriteLine("mesaj24: " + TextBox34.Text)
        file2.WriteLine("mesaj25: " + TextBox35.Text)
        file2.WriteLine("mesaj26: " + TextBox36.Text)
        file2.WriteLine("mesaj27: " + TextBox37.Text)
        file2.WriteLine("mesaj28: " + TextBox38.Text)
        file2.WriteLine("mesaj29: " + TextBox39.Text)
        file2.WriteLine("mesaj30: " + TextBox40.Text)
        file2.WriteLine("mesaj31: " + TextBox41.Text)
        file2.WriteLine("mesaj32: " + TextBox42.Text)
        file2.WriteLine("mesaj33: " + TextBox43.Text)
        file2.WriteLine("mesaj34: " + TextBox44.Text)
        file2.WriteLine("mesaj35: " + TextBox45.Text)
        file2.WriteLine("mesaj36: " + TextBox46.Text)
        file2.WriteLine("mesaj37: " + TextBox47.Text)
        file2.WriteLine("mesaj38: " + TextBox48.Text)
        file2.WriteLine("mesaj39: " + TextBox49.Text)
        file2.WriteLine("mesaj40: " + TextBox12.Text)
        file2.Close()

        Main.Mesaje(21) = TextBox31.Text
        Main.Mesaje(22) = TextBox32.Text
        Main.Mesaje(23) = TextBox33.Text
        Main.Mesaje(24) = TextBox34.Text
        Main.Mesaje(25) = TextBox35.Text
        Main.Mesaje(26) = TextBox36.Text
        Main.Mesaje(27) = TextBox37.Text
        Main.Mesaje(28) = TextBox38.Text
        Main.Mesaje(29) = TextBox39.Text
        Main.Mesaje(30) = TextBox40.Text
        Main.Mesaje(31) = TextBox41.Text
        Main.Mesaje(32) = TextBox42.Text
        Main.Mesaje(33) = TextBox43.Text
        Main.Mesaje(34) = TextBox44.Text
        Main.Mesaje(35) = TextBox45.Text
        Main.Mesaje(36) = TextBox46.Text
        Main.Mesaje(37) = TextBox47.Text
        Main.Mesaje(38) = TextBox48.Text
        Main.Mesaje(39) = TextBox49.Text
        Main.Mesaje(40) = TextBox12.Text



    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Top = (My.Computer.Screen.WorkingArea.Height \ 2) - (Me.Height \ 2)
        Me.Left = (My.Computer.Screen.WorkingArea.Width \ 2) - (Me.Width \ 2)

        TextBox31.Text = Main.Mesaje(21)
        TextBox32.Text = Main.Mesaje(22)
        TextBox33.Text = Main.Mesaje(23)
        TextBox34.Text = Main.Mesaje(24)
        TextBox35.Text = Main.Mesaje(25)
        TextBox36.Text = Main.Mesaje(26)
        TextBox37.Text = Main.Mesaje(27)
        TextBox38.Text = Main.Mesaje(28)
        TextBox39.Text = Main.Mesaje(29)
        TextBox40.Text = Main.Mesaje(30)
        TextBox41.Text = Main.Mesaje(31)
        TextBox42.Text = Main.Mesaje(32)
        TextBox43.Text = Main.Mesaje(33)
        TextBox44.Text = Main.Mesaje(34)
        TextBox45.Text = Main.Mesaje(35)
        TextBox46.Text = Main.Mesaje(36)
        TextBox47.Text = Main.Mesaje(37)
        TextBox48.Text = Main.Mesaje(38)
        TextBox49.Text = Main.Mesaje(39)
        TextBox12.Text = Main.Mesaje(40)

        'ComboBox22.Items.AddRange(RTS.ComboBox3.Items.Cast(Of String).ToArray())
        ComboBox23.Items.AddRange(RTS.ComboBox3.Items.Cast(Of String).ToArray())
        ComboBox24.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox25.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox26.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox27.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox28.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox29.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox30.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox31.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox32.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox33.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox34.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox35.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox36.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox37.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox38.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox39.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox40.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox41.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())
        ComboBox42.Items.AddRange(ComboBox23.Items.Cast(Of String).ToArray())


        NewMethod()

    End Sub

    ''' <summary>
    ''' Read values from Ini file
    ''' </summary>
    Public Sub NewMethod()


        Try
            'step1
            Main.STEPS(21).delay = Main.GetSettingItem(nume, "step21delay")
            TextBox2.Text = Main.STEPS(21).delay
            Main.STEPS(21).read_DM = Main.GetSettingItem(nume, "step21PN")
            ComboBox23.SelectedIndex = Main.STEPS(21).read_DM
            Main.STEPS(21).visual_control = Main.GetSettingItem(nume, "step21visual")
            CheckBox3.Checked = Main.STEPS(21).visual_control
            Main.STEPS(21).RW_param = Main.GetSettingItem(nume, "step21RWparam")
            ComboBox2.SelectedIndex = Main.STEPS(21).RW_param
            Main.STEPS(21).adr_param = Main.GetSettingItem(nume, "step21adrparam")
            TextBox24.Text = Main.STEPS(21).adr_param
            Main.STEPS(21).val_param = Main.GetSettingItem(nume, "step21valparam")
            TextBox83.Text = Main.STEPS(21).val_param
            Main.STEPS(21).DataBase = Main.GetSettingItem(nume, "step21DB")
            ComboBox44.SelectedIndex = Main.STEPS(21).DataBase
            Try
                Main.STEPS(21).serial = Main.GetSettingItem(nume, "step21serial")
                ComboBox65.SelectedIndex = Main.STEPS(21).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 21", vbOK, "ERROR COM PORT")
            End Try


            'step2
            Main.STEPS(22).delay = Main.GetSettingItem(nume, "step22delay")
            TextBox3.Text = Main.STEPS(22).delay
            Main.STEPS(22).read_DM = Main.GetSettingItem(nume, "step22PN")
            ComboBox24.SelectedIndex = Main.STEPS(22).read_DM
            Main.STEPS(22).visual_control = Main.GetSettingItem(nume, "step22visual")
            CheckBox5.Checked = Main.STEPS(22).visual_control
            Main.STEPS(22).RW_param = Main.GetSettingItem(nume, "step22RWparam")
            ComboBox3.SelectedIndex = Main.STEPS(22).RW_param
            Main.STEPS(22).adr_param = Main.GetSettingItem(nume, "step22adrparam")
            TextBox25.Text = Main.STEPS(22).adr_param
            Main.STEPS(22).val_param = Main.GetSettingItem(nume, "step22valparam")
            TextBox82.Text = Main.STEPS(22).val_param
            Main.STEPS(22).DataBase = Main.GetSettingItem(nume, "step22DB")
            ComboBox45.SelectedIndex = Main.STEPS(22).DataBase
            Try
                Main.STEPS(22).serial = Main.GetSettingItem(nume, "step22serial")
                ComboBox66.SelectedIndex = Main.STEPS(22).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 22", vbOK, "ERROR COM PORT")
            End Try


            'step3
            Main.STEPS(23).delay = Main.GetSettingItem(nume, "step23delay")
            TextBox4.Text = Main.STEPS(23).delay
            Main.STEPS(23).read_DM = Main.GetSettingItem(nume, "step23PN")
            ComboBox25.SelectedIndex = Main.STEPS(23).read_DM
            Main.STEPS(23).visual_control = Main.GetSettingItem(nume, "step23visual")
            CheckBox7.Checked = Main.STEPS(23).visual_control
            Main.STEPS(23).RW_param = Main.GetSettingItem(nume, "step23RWparam")
            ComboBox4.SelectedIndex = Main.STEPS(23).RW_param
            Main.STEPS(23).adr_param = Main.GetSettingItem(nume, "step23adrparam")
            TextBox26.Text = Main.STEPS(23).adr_param
            Main.STEPS(23).val_param = Main.GetSettingItem(nume, "step23valparam")
            TextBox81.Text = Main.STEPS(23).val_param
            Main.STEPS(23).DataBase = Main.GetSettingItem(nume, "step23DB")
            ComboBox46.SelectedIndex = Main.STEPS(23).DataBase
            Try
                Main.STEPS(23).serial = Main.GetSettingItem(nume, "step23serial")
                ComboBox67.SelectedIndex = Main.STEPS(23).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 23", vbOK, "ERROR COM PORT")
            End Try



            'step4
            Main.STEPS(24).delay = Main.GetSettingItem(nume, "step24delay")
            TextBox5.Text = Main.STEPS(24).delay
            Main.STEPS(24).read_DM = Main.GetSettingItem(nume, "step24PN")
            ComboBox26.SelectedIndex = Main.STEPS(24).read_DM
            Main.STEPS(24).visual_control = Main.GetSettingItem(nume, "step24visual")
            CheckBox9.Checked = Main.STEPS(24).visual_control
            Main.STEPS(24).RW_param = Main.GetSettingItem(nume, "step24RWparam")
            ComboBox5.SelectedIndex = Main.STEPS(24).RW_param
            Main.STEPS(24).adr_param = Main.GetSettingItem(nume, "step24adrparam")
            TextBox27.Text = Main.STEPS(24).adr_param
            Main.STEPS(24).val_param = Main.GetSettingItem(nume, "step24valparam")
            TextBox80.Text = Main.STEPS(24).val_param
            Main.STEPS(24).DataBase = Main.GetSettingItem(nume, "step24DB")
            ComboBox47.SelectedIndex = Main.STEPS(24).DataBase
            Try
                Main.STEPS(24).serial = Main.GetSettingItem(nume, "step24serial")
                ComboBox68.SelectedIndex = Main.STEPS(24).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 24", vbOK, "ERROR COM PORT")
            End Try


            'step5
            Main.STEPS(25).delay = Main.GetSettingItem(nume, "step25delay")
            TextBox6.Text = Main.STEPS(25).delay
            Main.STEPS(25).read_DM = Main.GetSettingItem(nume, "step25PN")
            ComboBox27.SelectedIndex = Main.STEPS(25).read_DM
            Main.STEPS(25).visual_control = Main.GetSettingItem(nume, "step25visual")
            CheckBox11.Checked = Main.STEPS(25).visual_control
            Main.STEPS(25).RW_param = Main.GetSettingItem(nume, "step25RWparam")
            ComboBox6.SelectedIndex = Main.STEPS(25).RW_param
            Main.STEPS(25).adr_param = Main.GetSettingItem(nume, "step25adrparam")
            TextBox28.Text = Main.STEPS(25).adr_param
            Main.STEPS(25).val_param = Main.GetSettingItem(nume, "step25valparam")
            TextBox79.Text = Main.STEPS(25).val_param
            Main.STEPS(25).DataBase = Main.GetSettingItem(nume, "step25DB")
            ComboBox48.SelectedIndex = Main.STEPS(25).DataBase
            Try
                Main.STEPS(25).serial = Main.GetSettingItem(nume, "step25serial")
                ComboBox69.SelectedIndex = Main.STEPS(25).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 25", vbOK, "ERROR COM PORT")
            End Try


            'step6
            Main.STEPS(26).delay = Main.GetSettingItem(nume, "step26delay")
            TextBox7.Text = Main.STEPS(26).delay
            Main.STEPS(26).read_DM = Main.GetSettingItem(nume, "step26PN")
            ComboBox28.SelectedIndex = Main.STEPS(26).read_DM
            Main.STEPS(26).visual_control = Main.GetSettingItem(nume, "step26visual")
            CheckBox13.Checked = Main.STEPS(26).visual_control
            Main.STEPS(26).RW_param = Main.GetSettingItem(nume, "step26RWparam")
            ComboBox7.SelectedIndex = Main.STEPS(26).RW_param
            Main.STEPS(26).adr_param = Main.GetSettingItem(nume, "step26adrparam")
            TextBox29.Text = Main.STEPS(26).adr_param
            Main.STEPS(26).val_param = Main.GetSettingItem(nume, "step26valparam")
            TextBox78.Text = Main.STEPS(26).val_param
            Main.STEPS(26).DataBase = Main.GetSettingItem(nume, "step26DB")
            ComboBox49.SelectedIndex = Main.STEPS(26).DataBase
            Try
                Main.STEPS(26).serial = Main.GetSettingItem(nume, "step26serial")
                ComboBox70.SelectedIndex = Main.STEPS(26).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 26", vbOK, "ERROR COM PORT")
            End Try


            'step7
            Main.STEPS(27).delay = Main.GetSettingItem(nume, "step27delay")
            TextBox8.Text = Main.STEPS(27).delay
            Main.STEPS(27).read_DM = Main.GetSettingItem(nume, "step27PN")
            ComboBox29.SelectedIndex = Main.STEPS(27).read_DM
            Main.STEPS(27).visual_control = Main.GetSettingItem(nume, "step27visual")
            CheckBox15.Checked = Main.STEPS(27).visual_control
            Main.STEPS(27).RW_param = Main.GetSettingItem(nume, "step27RWparam")
            ComboBox8.SelectedIndex = Main.STEPS(27).RW_param
            Main.STEPS(27).adr_param = Main.GetSettingItem(nume, "step27adrparam")
            TextBox50.Text = Main.STEPS(27).adr_param
            Main.STEPS(27).val_param = Main.GetSettingItem(nume, "step27valparam")
            TextBox77.Text = Main.STEPS(27).val_param
            Main.STEPS(27).DataBase = Main.GetSettingItem(nume, "step27DB")
            ComboBox50.SelectedIndex = Main.STEPS(27).DataBase
            Try
                Main.STEPS(27).serial = Main.GetSettingItem(nume, "step27serial")
                ComboBox71.SelectedIndex = Main.STEPS(27).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 27", vbOK, "ERROR COM PORT")
            End Try


            'step8
            Main.STEPS(28).delay = Main.GetSettingItem(nume, "step28delay")
            TextBox9.Text = Main.STEPS(28).delay
            Main.STEPS(28).read_DM = Main.GetSettingItem(nume, "step28PN")
            ComboBox30.SelectedIndex = Main.STEPS(28).read_DM
            Main.STEPS(28).visual_control = Main.GetSettingItem(nume, "step28visual")
            CheckBox17.Checked = Main.STEPS(28).visual_control
            Main.STEPS(28).RW_param = Main.GetSettingItem(nume, "step28RWparam")
            ComboBox9.SelectedIndex = Main.STEPS(28).RW_param
            Main.STEPS(28).adr_param = Main.GetSettingItem(nume, "step28adrparam")
            TextBox51.Text = Main.STEPS(28).adr_param
            Main.STEPS(28).val_param = Main.GetSettingItem(nume, "step28valparam")
            TextBox76.Text = Main.STEPS(28).val_param
            Main.STEPS(28).DataBase = Main.GetSettingItem(nume, "step28DB")
            ComboBox51.SelectedIndex = Main.STEPS(28).DataBase
            Try
                Main.STEPS(28).serial = Main.GetSettingItem(nume, "step28serial")
                ComboBox72.SelectedIndex = Main.STEPS(28).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 28", vbOK, "ERROR COM PORT")
            End Try


            'step9
            Main.STEPS(29).delay = Main.GetSettingItem(nume, "step29delay")
            TextBox10.Text = Main.STEPS(29).delay
            Main.STEPS(29).read_DM = Main.GetSettingItem(nume, "step29PN")
            ComboBox31.SelectedIndex = Main.STEPS(29).read_DM
            Main.STEPS(29).visual_control = Main.GetSettingItem(nume, "step29visual")
            CheckBox19.Checked = Main.STEPS(29).visual_control
            Main.STEPS(29).RW_param = Main.GetSettingItem(nume, "step29RWparam")
            ComboBox10.SelectedIndex = Main.STEPS(29).RW_param
            Main.STEPS(29).adr_param = Main.GetSettingItem(nume, "step29adrparam")
            TextBox52.Text = Main.STEPS(29).adr_param
            Main.STEPS(29).val_param = Main.GetSettingItem(nume, "step29valparam")
            TextBox75.Text = Main.STEPS(29).val_param
            Main.STEPS(29).DataBase = Main.GetSettingItem(nume, "step29DB")
            ComboBox52.SelectedIndex = Main.STEPS(29).DataBase
            Try
                Main.STEPS(29).serial = Main.GetSettingItem(nume, "step29serial")
                ComboBox73.SelectedIndex = Main.STEPS(29).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 29", vbOK, "ERROR COM PORT")
            End Try


            'step10
            Main.STEPS(30).delay = Main.GetSettingItem(nume, "step30delay")
            TextBox11.Text = Main.STEPS(30).delay
            Main.STEPS(30).read_DM = Main.GetSettingItem(nume, "step30PN")
            ComboBox32.SelectedIndex = Main.STEPS(30).read_DM
            Main.STEPS(30).visual_control = Main.GetSettingItem(nume, "step30visual")
            CheckBox21.Checked = Main.STEPS(30).visual_control
            Main.STEPS(30).RW_param = Main.GetSettingItem(nume, "step30RWparam")
            ComboBox11.SelectedIndex = Main.STEPS(30).RW_param
            Main.STEPS(30).adr_param = Main.GetSettingItem(nume, "step30adrparam")
            TextBox53.Text = Main.STEPS(30).adr_param
            Main.STEPS(30).val_param = Main.GetSettingItem(nume, "step30valparam")
            TextBox74.Text = Main.STEPS(30).val_param
            Main.STEPS(30).DataBase = Main.GetSettingItem(nume, "step30DB")
            ComboBox53.SelectedIndex = Main.STEPS(30).DataBase
            Try
                Main.STEPS(30).serial = Main.GetSettingItem(nume, "step30serial")
                ComboBox74.SelectedIndex = Main.STEPS(30).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 30", vbOK, "ERROR COM PORT")
            End Try


            'step11
            Main.STEPS(31).delay = Main.GetSettingItem(nume, "step31delay")
            TextBox22.Text = Main.STEPS(31).delay
            Main.STEPS(31).read_DM = Main.GetSettingItem(nume, "step31PN")
            ComboBox33.SelectedIndex = Main.STEPS(31).read_DM
            Main.STEPS(31).visual_control = Main.GetSettingItem(nume, "step31visual")
            CheckBox43.Checked = Main.STEPS(31).visual_control
            Main.STEPS(31).RW_param = Main.GetSettingItem(nume, "step31RWparam")
            ComboBox12.SelectedIndex = Main.STEPS(31).RW_param
            Main.STEPS(31).adr_param = Main.GetSettingItem(nume, "step31adrparam")
            TextBox54.Text = Main.STEPS(31).adr_param
            Main.STEPS(31).val_param = Main.GetSettingItem(nume, "step31valparam")
            TextBox73.Text = Main.STEPS(31).val_param
            Main.STEPS(31).DataBase = Main.GetSettingItem(nume, "step31DB")
            ComboBox54.SelectedIndex = Main.STEPS(31).DataBase
            Try
                Main.STEPS(31).serial = Main.GetSettingItem(nume, "step31serial")
                ComboBox75.SelectedIndex = Main.STEPS(31).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 31", vbOK, "ERROR COM PORT")
            End Try


            'step12
            Main.STEPS(32).delay = Main.GetSettingItem(nume, "step32delay")
            TextBox21.Text = Main.STEPS(32).delay
            Main.STEPS(32).read_DM = Main.GetSettingItem(nume, "step32PN")
            ComboBox34.SelectedIndex = Main.STEPS(32).read_DM
            Main.STEPS(32).visual_control = Main.GetSettingItem(nume, "step32visual")
            CheckBox41.Checked = Main.STEPS(32).visual_control
            Main.STEPS(32).RW_param = Main.GetSettingItem(nume, "step32RWparam")
            ComboBox13.SelectedIndex = Main.STEPS(32).RW_param
            Main.STEPS(32).adr_param = Main.GetSettingItem(nume, "step32adrparam")
            TextBox55.Text = Main.STEPS(32).adr_param
            Main.STEPS(32).val_param = Main.GetSettingItem(nume, "step32valparam")
            TextBox72.Text = Main.STEPS(32).val_param
            Main.STEPS(32).DataBase = Main.GetSettingItem(nume, "step32DB")
            ComboBox55.SelectedIndex = Main.STEPS(32).DataBase
            Try
                Main.STEPS(32).serial = Main.GetSettingItem(nume, "step32serial")
                ComboBox76.SelectedIndex = Main.STEPS(32).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 32", vbOK, "ERROR COM PORT")
            End Try


            'step13
            Main.STEPS(33).delay = Main.GetSettingItem(nume, "step33delay")
            TextBox20.Text = Main.STEPS(33).delay
            Main.STEPS(33).read_DM = Main.GetSettingItem(nume, "step33PN")
            ComboBox35.SelectedIndex = Main.STEPS(33).read_DM
            Main.STEPS(33).visual_control = Main.GetSettingItem(nume, "step33visual")
            CheckBox39.Checked = Main.STEPS(33).visual_control
            Main.STEPS(33).RW_param = Main.GetSettingItem(nume, "step33RWparam")
            ComboBox14.SelectedIndex = Main.STEPS(33).RW_param
            Main.STEPS(33).adr_param = Main.GetSettingItem(nume, "step33adrparam")
            TextBox56.Text = Main.STEPS(33).adr_param
            Main.STEPS(33).val_param = Main.GetSettingItem(nume, "step33valparam")
            TextBox71.Text = Main.STEPS(33).val_param
            Main.STEPS(33).DataBase = Main.GetSettingItem(nume, "step33DB")
            ComboBox56.SelectedIndex = Main.STEPS(33).DataBase
            Try
                Main.STEPS(33).serial = Main.GetSettingItem(nume, "step33serial")
                ComboBox77.SelectedIndex = Main.STEPS(33).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 33", vbOK, "ERROR COM PORT")
            End Try


            'step14
            Main.STEPS(34).delay = Main.GetSettingItem(nume, "step34delay")
            TextBox19.Text = Main.STEPS(34).delay
            Main.STEPS(34).read_DM = Main.GetSettingItem(nume, "step34PN")
            ComboBox36.SelectedIndex = Main.STEPS(34).read_DM
            Main.STEPS(34).visual_control = Main.GetSettingItem(nume, "step34visual")
            CheckBox37.Checked = Main.STEPS(34).visual_control
            Main.STEPS(34).RW_param = Main.GetSettingItem(nume, "step34RWparam")
            ComboBox15.SelectedIndex = Main.STEPS(34).RW_param
            Main.STEPS(34).adr_param = Main.GetSettingItem(nume, "step34adrparam")
            TextBox57.Text = Main.STEPS(34).adr_param
            Main.STEPS(34).val_param = Main.GetSettingItem(nume, "step34valparam")
            TextBox70.Text = Main.STEPS(34).val_param
            Main.STEPS(34).DataBase = Main.GetSettingItem(nume, "step34DB")
            ComboBox57.SelectedIndex = Main.STEPS(34).DataBase
            Try
                Main.STEPS(34).serial = Main.GetSettingItem(nume, "step34serial")
                ComboBox78.SelectedIndex = Main.STEPS(34).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 34", vbOK, "ERROR COM PORT")
            End Try


            'step15
            Main.STEPS(35).delay = Main.GetSettingItem(nume, "step35delay")
            TextBox18.Text = Main.STEPS(35).delay
            Main.STEPS(35).read_DM = Main.GetSettingItem(nume, "step35PN")
            ComboBox37.SelectedIndex = Main.STEPS(35).read_DM
            Main.STEPS(35).visual_control = Main.GetSettingItem(nume, "step35visual")
            CheckBox35.Checked = Main.STEPS(35).visual_control
            Main.STEPS(35).RW_param = Main.GetSettingItem(nume, "step35RWparam")
            ComboBox16.SelectedIndex = Main.STEPS(35).RW_param
            Main.STEPS(35).adr_param = Main.GetSettingItem(nume, "step35adrparam")
            TextBox58.Text = Main.STEPS(35).adr_param
            Main.STEPS(35).val_param = Main.GetSettingItem(nume, "step35valparam")
            TextBox69.Text = Main.STEPS(35).val_param
            Main.STEPS(35).DataBase = Main.GetSettingItem(nume, "step35DB")
            ComboBox58.SelectedIndex = Main.STEPS(35).DataBase
            Try
                Main.STEPS(35).serial = Main.GetSettingItem(nume, "step35serial")
                ComboBox79.SelectedIndex = Main.STEPS(35).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 35", vbOK, "ERROR COM PORT")
            End Try


            'step16
            Main.STEPS(36).delay = Main.GetSettingItem(nume, "step36delay")
            TextBox17.Text = Main.STEPS(36).delay
            Main.STEPS(36).read_DM = Main.GetSettingItem(nume, "step36PN")
            ComboBox38.SelectedIndex = Main.STEPS(36).read_DM
            Main.STEPS(36).visual_control = Main.GetSettingItem(nume, "step36visual")
            CheckBox33.Checked = Main.STEPS(36).visual_control
            Main.STEPS(36).RW_param = Main.GetSettingItem(nume, "step36RWparam")
            ComboBox17.SelectedIndex = Main.STEPS(36).RW_param
            Main.STEPS(36).adr_param = Main.GetSettingItem(nume, "step36adrparam")
            TextBox59.Text = Main.STEPS(36).adr_param
            Main.STEPS(36).val_param = Main.GetSettingItem(nume, "step36valparam")
            TextBox68.Text = Main.STEPS(36).val_param
            Main.STEPS(36).DataBase = Main.GetSettingItem(nume, "step36DB")
            ComboBox59.SelectedIndex = Main.STEPS(36).DataBase
            Try
                Main.STEPS(36).serial = Main.GetSettingItem(nume, "step36serial")
                ComboBox80.SelectedIndex = Main.STEPS(36).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 36", vbOK, "ERROR COM PORT")
            End Try


            'step17
            Main.STEPS(37).delay = Main.GetSettingItem(nume, "step37delay")
            TextBox16.Text = Main.STEPS(37).delay
            Main.STEPS(37).read_DM = Main.GetSettingItem(nume, "step37PN")
            ComboBox39.SelectedIndex = Main.STEPS(37).read_DM
            Main.STEPS(37).visual_control = Main.GetSettingItem(nume, "step37visual")
            CheckBox31.Checked = Main.STEPS(37).visual_control
            Main.STEPS(37).RW_param = Main.GetSettingItem(nume, "step37RWparam")
            ComboBox18.SelectedIndex = Main.STEPS(37).RW_param
            Main.STEPS(37).adr_param = Main.GetSettingItem(nume, "step37adrparam")
            TextBox60.Text = Main.STEPS(37).adr_param
            Main.STEPS(37).val_param = Main.GetSettingItem(nume, "step37valparam")
            TextBox67.Text = Main.STEPS(37).val_param
            Main.STEPS(37).DataBase = Main.GetSettingItem(nume, "step37DB")
            ComboBox60.SelectedIndex = Main.STEPS(37).DataBase
            Try
                Main.STEPS(37).serial = Main.GetSettingItem(nume, "step37serial")
                ComboBox81.SelectedIndex = Main.STEPS(37).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 37", vbOK, "ERROR COM PORT")
            End Try


            'step18
            Main.STEPS(38).delay = Main.GetSettingItem(nume, "step38delay")
            TextBox15.Text = Main.STEPS(38).delay
            Main.STEPS(38).read_DM = Main.GetSettingItem(nume, "step38PN")
            ComboBox40.SelectedIndex = Main.STEPS(38).read_DM
            Main.STEPS(38).visual_control = Main.GetSettingItem(nume, "step38visual")
            CheckBox29.Checked = Main.STEPS(38).visual_control
            Main.STEPS(38).RW_param = Main.GetSettingItem(nume, "step38RWparam")
            ComboBox19.SelectedIndex = Main.STEPS(38).RW_param
            Main.STEPS(38).adr_param = Main.GetSettingItem(nume, "step38adrparam")
            TextBox61.Text = Main.STEPS(38).adr_param
            Main.STEPS(38).val_param = Main.GetSettingItem(nume, "step38valparam")
            TextBox66.Text = Main.STEPS(38).val_param
            Main.STEPS(38).DataBase = Main.GetSettingItem(nume, "step38DB")
            ComboBox61.SelectedIndex = Main.STEPS(38).DataBase
            Try
                Main.STEPS(38).serial = Main.GetSettingItem(nume, "step38serial")
                ComboBox82.SelectedIndex = Main.STEPS(38).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 38", vbOK, "ERROR COM PORT")
            End Try


            'step19
            Main.STEPS(39).delay = Main.GetSettingItem(nume, "step39delay")
            TextBox14.Text = Main.STEPS(39).delay
            Main.STEPS(39).read_DM = Main.GetSettingItem(nume, "step39PN")
            ComboBox41.SelectedIndex = Main.STEPS(39).read_DM
            Main.STEPS(39).visual_control = Main.GetSettingItem(nume, "step39visual")
            CheckBox27.Checked = Main.STEPS(39).visual_control
            Main.STEPS(39).RW_param = Main.GetSettingItem(nume, "step39RWparam")
            ComboBox20.SelectedIndex = Main.STEPS(39).RW_param
            Main.STEPS(39).adr_param = Main.GetSettingItem(nume, "step39adrparam")
            TextBox62.Text = Main.STEPS(39).adr_param
            Main.STEPS(39).val_param = Main.GetSettingItem(nume, "step39valparam")
            TextBox65.Text = Main.STEPS(39).val_param
            Main.STEPS(39).DataBase = Main.GetSettingItem(nume, "step39DB")
            ComboBox62.SelectedIndex = Main.STEPS(39).DataBase
            Try
                Main.STEPS(39).serial = Main.GetSettingItem(nume, "step39serial")
                ComboBox83.SelectedIndex = Main.STEPS(39).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 39", vbOK, "ERROR COM PORT")
            End Try


            'step20
            Main.STEPS(40).delay = Main.GetSettingItem(nume, "step40delay")
            TextBox13.Text = Main.STEPS(40).delay
            Main.STEPS(40).read_DM = Main.GetSettingItem(nume, "step40PN")
            ComboBox42.SelectedIndex = Main.STEPS(40).read_DM
            Main.STEPS(40).visual_control = Main.GetSettingItem(nume, "step40visual")
            CheckBox25.Checked = Main.STEPS(40).visual_control
            Main.STEPS(40).RW_param = Main.GetSettingItem(nume, "step40RWparam")
            ComboBox21.SelectedIndex = Main.STEPS(40).RW_param
            Main.STEPS(40).adr_param = Main.GetSettingItem(nume, "step40adrparam")
            TextBox63.Text = Main.STEPS(40).adr_param
            Main.STEPS(40).val_param = Main.GetSettingItem(nume, "step40valparam")
            TextBox64.Text = Main.STEPS(40).val_param
            Main.STEPS(40).DataBase = Main.GetSettingItem(nume, "step40DB")
            ComboBox63.SelectedIndex = Main.STEPS(40).DataBase
            Try
                Main.STEPS(40).serial = Main.GetSettingItem(nume, "step40serial")
                ComboBox84.SelectedIndex = Main.STEPS(40).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 40", vbOK, "ERROR COM PORT")
            End Try


        Catch ex As Exception
            MsgBox("Corunpt Ini File !!!! Put backup or contact PFL !", vbOK, "ERROR Reading INI File")
        End Try


    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Settings.Show()
        Close()
    End Sub
End Class