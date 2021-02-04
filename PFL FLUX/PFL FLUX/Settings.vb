
Imports System.Diagnostics.Tracing

Public Class Settings
    Dim nume As String = "..\..\INI\Test.ini"
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
        ComboBox64.Items.Add("None..")

        For Each SP In My.Computer.Ports.SerialPortNames
            ComboBox64.Items.Add(SP)

        Next

        ComboBox65.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox66.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox67.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox68.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox69.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox70.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox71.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox72.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox73.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox74.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox75.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox76.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox77.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox78.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox79.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox80.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox81.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox82.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox83.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())
        ComboBox84.Items.AddRange(ComboBox64.Items.Cast(Of String).ToArray())

        '(Under button click event) 
        'SP =Listbox1. SelectedItem
        'SerialPort1. PortName=SP 
        'SerialPort1. Open() 

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim file As New IO.StreamWriter(nume)
        'step0
        Main.STEPS(0).delay = TextBox1.Text
        file.WriteLine("step0delay: " + Main.STEPS(0).delay.ToString)
        Main.STEPS(0).read_DM = ComboBox22.SelectedIndex
        file.WriteLine("step0PN: " + Main.STEPS(0).read_DM.ToString)
        Main.STEPS(0).visual_control = CheckBox2.Checked
        file.WriteLine("step0visual: " + Main.STEPS(0).visual_control.ToString)
        Main.STEPS(0).RW_param = ComboBox1.SelectedIndex
        file.WriteLine("step0RWparam: " + Main.STEPS(0).RW_param.ToString)
        Main.STEPS(0).adr_param = TextBox23.Text
        file.WriteLine("step0adrparam: " + Main.STEPS(0).adr_param.ToString)
        Main.STEPS(0).val_param = TextBox84.Text
        file.WriteLine("step0valparam: " + Main.STEPS(0).val_param.ToString)
        Main.STEPS(0).DataBase = ComboBox43.SelectedIndex
        file.WriteLine("step0DB: " + Main.STEPS(0).DataBase.ToString)
        Try
            Main.STEPS(0).serial = ComboBox64.SelectedIndex
            file.WriteLine("step0serial: " + Main.STEPS(0).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step1
        Main.STEPS(1).delay = TextBox2.Text
        file.WriteLine("step1delay: " + Main.STEPS(1).delay.ToString)
        Main.STEPS(1).read_DM = ComboBox23.SelectedIndex
        file.WriteLine("step1PN: " + Main.STEPS(1).read_DM.ToString)
        Main.STEPS(1).visual_control = CheckBox3.Checked
        file.WriteLine("step1visual: " + Main.STEPS(1).visual_control.ToString)
        Main.STEPS(1).RW_param = ComboBox2.SelectedIndex
        file.WriteLine("step1RWparam: " + Main.STEPS(1).RW_param.ToString)
        Main.STEPS(1).adr_param = TextBox24.Text
        file.WriteLine("step1adrparam: " + Main.STEPS(1).adr_param.ToString)
        Main.STEPS(1).val_param = TextBox83.Text
        file.WriteLine("step1valparam: " + Main.STEPS(1).val_param.ToString)
        Main.STEPS(1).DataBase = ComboBox44.SelectedIndex
        file.WriteLine("step1DB: " + Main.STEPS(1).DataBase.ToString)
        Try
            Main.STEPS(1).serial = ComboBox65.SelectedIndex
            file.WriteLine("step1serial: " + Main.STEPS(1).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step2
        Main.STEPS(2).delay = TextBox3.Text
        file.WriteLine("step2delay: " + Main.STEPS(2).delay.ToString)
        Main.STEPS(2).read_DM = ComboBox24.SelectedIndex
        file.WriteLine("step2PN: " + Main.STEPS(2).read_DM.ToString)
        Main.STEPS(2).visual_control = CheckBox5.Checked
        file.WriteLine("step2visual: " + Main.STEPS(2).visual_control.ToString)
        Main.STEPS(2).RW_param = ComboBox3.SelectedIndex
        file.WriteLine("step2RWparam: " + Main.STEPS(2).RW_param.ToString)
        Main.STEPS(2).adr_param = TextBox25.Text
        file.WriteLine("step2adrparam: " + Main.STEPS(2).adr_param.ToString)
        Main.STEPS(2).val_param = TextBox82.Text
        file.WriteLine("step2valparam: " + Main.STEPS(2).val_param.ToString)
        Main.STEPS(2).DataBase = ComboBox45.SelectedIndex
        file.WriteLine("step2DB: " + Main.STEPS(2).DataBase.ToString)
        Try
            Main.STEPS(2).serial = ComboBox66.SelectedIndex
            file.WriteLine("step2serial: " + Main.STEPS(2).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step3
        Main.STEPS(3).delay = TextBox4.Text
        file.WriteLine("step3delay: " + Main.STEPS(3).delay.ToString)
        Main.STEPS(3).read_DM = ComboBox25.SelectedIndex
        file.WriteLine("step3PN: " + Main.STEPS(3).read_DM.ToString)
        Main.STEPS(3).visual_control = CheckBox7.Checked
        file.WriteLine("step3visual: " + Main.STEPS(3).visual_control.ToString)
        Main.STEPS(3).RW_param = ComboBox4.SelectedIndex
        file.WriteLine("step3RWparam: " + Main.STEPS(3).RW_param.ToString)
        Main.STEPS(3).adr_param = TextBox26.Text
        file.WriteLine("step3adrparam: " + Main.STEPS(3).adr_param.ToString)
        Main.STEPS(3).val_param = TextBox81.Text
        file.WriteLine("step3valparam: " + Main.STEPS(3).val_param.ToString)
        Main.STEPS(3).DataBase = ComboBox46.SelectedIndex
        file.WriteLine("step3DB: " + Main.STEPS(3).DataBase.ToString)
        Try
            Main.STEPS(3).serial = ComboBox67.SelectedIndex
            file.WriteLine("step3serial: " + Main.STEPS(3).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step4
        Main.STEPS(4).delay = TextBox5.Text
        file.WriteLine("step4delay: " + Main.STEPS(4).delay.ToString)
        Main.STEPS(4).read_DM = ComboBox26.SelectedIndex
        file.WriteLine("step4PN: " + Main.STEPS(4).read_DM.ToString)
        Main.STEPS(4).visual_control = CheckBox9.Checked
        file.WriteLine("step4visual: " + Main.STEPS(4).visual_control.ToString)
        Main.STEPS(4).RW_param = ComboBox5.SelectedIndex
        file.WriteLine("step4RWparam: " + Main.STEPS(4).RW_param.ToString)
        Main.STEPS(4).adr_param = TextBox27.Text
        file.WriteLine("step4adrparam: " + Main.STEPS(4).adr_param.ToString)
        Main.STEPS(4).val_param = TextBox80.Text
        file.WriteLine("step4valparam: " + Main.STEPS(4).val_param.ToString)
        Main.STEPS(4).DataBase = ComboBox47.SelectedIndex
        file.WriteLine("step4DB: " + Main.STEPS(4).DataBase.ToString)
        Try
            Main.STEPS(4).serial = ComboBox68.SelectedIndex
            file.WriteLine("step4serial: " + Main.STEPS(4).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step5
        Main.STEPS(5).delay = TextBox6.Text
        file.WriteLine("step5delay: " + Main.STEPS(5).delay.ToString)
        Main.STEPS(5).read_DM = ComboBox27.SelectedIndex
        file.WriteLine("step5PN: " + Main.STEPS(5).read_DM.ToString)
        Main.STEPS(5).visual_control = CheckBox11.Checked
        file.WriteLine("step5visual: " + Main.STEPS(5).visual_control.ToString)
        Main.STEPS(5).RW_param = ComboBox6.SelectedIndex
        file.WriteLine("step5RWparam: " + Main.STEPS(5).RW_param.ToString)
        Main.STEPS(5).adr_param = TextBox28.Text
        file.WriteLine("step5adrparam: " + Main.STEPS(5).adr_param.ToString)
        Main.STEPS(5).val_param = TextBox79.Text
        file.WriteLine("step5valparam: " + Main.STEPS(5).val_param.ToString)
        Main.STEPS(5).DataBase = ComboBox48.SelectedIndex
        file.WriteLine("step5DB: " + Main.STEPS(5).DataBase.ToString)
        Try
            Main.STEPS(5).serial = ComboBox69.SelectedIndex
            file.WriteLine("step5serial: " + Main.STEPS(5).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step6
        Main.STEPS(6).delay = TextBox7.Text
        file.WriteLine("step6delay: " + Main.STEPS(6).delay.ToString)
        Main.STEPS(6).read_DM = ComboBox28.SelectedIndex
        file.WriteLine("step6PN: " + Main.STEPS(6).read_DM.ToString)
        Main.STEPS(6).visual_control = CheckBox13.Checked
        file.WriteLine("step6visual: " + Main.STEPS(6).visual_control.ToString)
        Main.STEPS(6).RW_param = ComboBox7.SelectedIndex
        file.WriteLine("step6RWparam: " + Main.STEPS(6).RW_param.ToString)
        Main.STEPS(6).adr_param = TextBox29.Text
        file.WriteLine("step6adrparam: " + Main.STEPS(6).adr_param.ToString)
        Main.STEPS(6).val_param = TextBox78.Text
        file.WriteLine("step6valparam: " + Main.STEPS(6).val_param.ToString)
        Main.STEPS(6).DataBase = ComboBox49.SelectedIndex
        file.WriteLine("step6DB: " + Main.STEPS(6).DataBase.ToString)
        Try
            Main.STEPS(0).serial = ComboBox70.SelectedIndex
            file.WriteLine("step6serial: " + Main.STEPS(0).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step7
        Main.STEPS(7).delay = TextBox8.Text
        file.WriteLine("step7delay: " + Main.STEPS(7).delay.ToString)
        Main.STEPS(7).read_DM = ComboBox29.SelectedIndex
        file.WriteLine("step7PN: " + Main.STEPS(7).read_DM.ToString)
        Main.STEPS(7).visual_control = CheckBox15.Checked
        file.WriteLine("step7visual: " + Main.STEPS(7).visual_control.ToString)
        Main.STEPS(7).RW_param = ComboBox8.SelectedIndex
        file.WriteLine("step7RWparam: " + Main.STEPS(7).RW_param.ToString)
        Main.STEPS(7).adr_param = TextBox50.Text
        file.WriteLine("step7adrparam: " + Main.STEPS(7).adr_param.ToString)
        Main.STEPS(7).val_param = TextBox77.Text
        file.WriteLine("step7valparam: " + Main.STEPS(7).val_param.ToString)
        Main.STEPS(7).DataBase = ComboBox50.SelectedIndex
        file.WriteLine("step7DB: " + Main.STEPS(7).DataBase.ToString)
        Try
            Main.STEPS(7).serial = ComboBox71.SelectedIndex
            file.WriteLine("step7serial: " + Main.STEPS(7).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step8
        Main.STEPS(8).delay = TextBox9.Text
        file.WriteLine("step8delay: " + Main.STEPS(8).delay.ToString)
        Main.STEPS(8).read_DM = ComboBox30.SelectedIndex
        file.WriteLine("step8PN: " + Main.STEPS(8).read_DM.ToString)
        Main.STEPS(8).visual_control = CheckBox17.Checked
        file.WriteLine("step8visual: " + Main.STEPS(8).visual_control.ToString)
        Main.STEPS(8).RW_param = ComboBox9.SelectedIndex
        file.WriteLine("step8RWparam: " + Main.STEPS(8).RW_param.ToString)
        Main.STEPS(8).adr_param = TextBox51.Text
        file.WriteLine("step8adrparam: " + Main.STEPS(8).adr_param.ToString)
        Main.STEPS(8).val_param = TextBox76.Text
        file.WriteLine("step8valparam: " + Main.STEPS(8).val_param.ToString)
        Main.STEPS(8).DataBase = ComboBox51.SelectedIndex
        file.WriteLine("step8DB: " + Main.STEPS(8).DataBase.ToString)
        Try
            Main.STEPS(8).serial = ComboBox72.SelectedIndex
            file.WriteLine("step8serial: " + Main.STEPS(0).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step9
        Main.STEPS(9).delay = TextBox10.Text
        file.WriteLine("step9delay: " + Main.STEPS(9).delay.ToString)
        Main.STEPS(9).read_DM = ComboBox31.SelectedIndex
        file.WriteLine("step9PN: " + Main.STEPS(9).read_DM.ToString)
        Main.STEPS(9).visual_control = CheckBox19.Checked
        file.WriteLine("step9visual: " + Main.STEPS(9).visual_control.ToString)
        Main.STEPS(9).RW_param = ComboBox10.SelectedIndex
        file.WriteLine("step9RWparam: " + Main.STEPS(9).RW_param.ToString)
        Main.STEPS(9).adr_param = TextBox52.Text
        file.WriteLine("step9adrparam: " + Main.STEPS(9).adr_param.ToString)
        Main.STEPS(9).val_param = TextBox75.Text
        file.WriteLine("step9valparam: " + Main.STEPS(9).val_param.ToString)
        Main.STEPS(9).DataBase = ComboBox52.SelectedIndex
        file.WriteLine("step9DB: " + Main.STEPS(9).DataBase.ToString)
        Try
            Main.STEPS(9).serial = ComboBox73.SelectedIndex
            file.WriteLine("step9serial: " + Main.STEPS(9).serial.ToString)
        Catch ex As Exception
            MsgBox("Comport Saved not active ! Step: " + (Main.Step_Number - 1).ToString, vbOK, "ERROR COM PORT")
        End Try


        'step10
        Main.STEPS(10).delay = TextBox11.Text
        file.WriteLine("step10delay: " + Main.STEPS(10).delay.ToString)
        Main.STEPS(10).read_DM = ComboBox32.SelectedIndex
        file.WriteLine("step10PN: " + Main.STEPS(10).read_DM.ToString)
        Main.STEPS(10).visual_control = CheckBox21.Checked
        file.WriteLine("step10visual: " + Main.STEPS(10).visual_control.ToString)
        Main.STEPS(10).RW_param = ComboBox11.SelectedIndex
        file.WriteLine("step10RWparam: " + Main.STEPS(10).RW_param.ToString)
        Main.STEPS(10).adr_param = TextBox53.Text
        file.WriteLine("step10adrparam: " + Main.STEPS(10).adr_param.ToString)
        Main.STEPS(10).val_param = TextBox74.Text
        file.WriteLine("step10valparam: " + Main.STEPS(10).val_param.ToString)
        Main.STEPS(10).DataBase = ComboBox53.SelectedIndex
        file.WriteLine("step10DB: " + Main.STEPS(10).DataBase.ToString)
        Main.STEPS(10).serial = ComboBox74.SelectedIndex
        file.WriteLine("step10serial: " + Main.STEPS(10).serial.ToString)

        'step11
        Main.STEPS(11).delay = TextBox22.Text
        file.WriteLine("step11delay: " + Main.STEPS(11).delay.ToString)
        Main.STEPS(11).read_DM = ComboBox33.SelectedIndex
        file.WriteLine("step11PN: " + Main.STEPS(11).read_DM.ToString)
        Main.STEPS(11).visual_control = CheckBox43.Checked
        file.WriteLine("step11visual: " + Main.STEPS(11).visual_control.ToString)
        Main.STEPS(11).RW_param = ComboBox12.SelectedIndex
        file.WriteLine("step11RWparam: " + Main.STEPS(11).RW_param.ToString)
        Main.STEPS(11).adr_param = TextBox54.Text
        file.WriteLine("step11adrparam: " + Main.STEPS(11).adr_param.ToString)
        Main.STEPS(11).val_param = TextBox73.Text
        file.WriteLine("step11valparam: " + Main.STEPS(11).val_param.ToString)
        Main.STEPS(11).DataBase = ComboBox54.SelectedIndex
        file.WriteLine("step11DB: " + Main.STEPS(11).DataBase.ToString)
        Main.STEPS(11).serial = ComboBox75.SelectedIndex
        file.WriteLine("step11serial: " + Main.STEPS(11).serial.ToString)

        'step12
        Main.STEPS(12).delay = TextBox21.Text
        file.WriteLine("step12delay: " + Main.STEPS(12).delay.ToString)
        Main.STEPS(12).read_DM = ComboBox34.SelectedIndex
        file.WriteLine("step12PN: " + Main.STEPS(12).read_DM.ToString)
        Main.STEPS(12).visual_control = CheckBox41.Checked
        file.WriteLine("step12visual: " + Main.STEPS(12).visual_control.ToString)
        Main.STEPS(12).RW_param = ComboBox13.SelectedIndex
        file.WriteLine("step12RWparam: " + Main.STEPS(12).RW_param.ToString)
        Main.STEPS(12).adr_param = TextBox55.Text
        file.WriteLine("step12adrparam: " + Main.STEPS(12).adr_param.ToString)
        Main.STEPS(12).val_param = TextBox72.Text
        file.WriteLine("step12valparam: " + Main.STEPS(12).val_param.ToString)
        Main.STEPS(12).DataBase = ComboBox55.SelectedIndex
        file.WriteLine("step12DB: " + Main.STEPS(12).DataBase.ToString)
        Main.STEPS(12).serial = ComboBox76.SelectedIndex
        file.WriteLine("step12serial: " + Main.STEPS(12).serial.ToString)

        'step13
        Main.STEPS(13).delay = TextBox20.Text
        file.WriteLine("step13delay: " + Main.STEPS(13).delay.ToString)
        Main.STEPS(13).read_DM = ComboBox35.SelectedIndex
        file.WriteLine("step13PN: " + Main.STEPS(13).read_DM.ToString)
        Main.STEPS(13).visual_control = CheckBox39.Checked
        file.WriteLine("step13visual: " + Main.STEPS(13).visual_control.ToString)
        Main.STEPS(13).RW_param = ComboBox14.SelectedIndex
        file.WriteLine("step13RWparam: " + Main.STEPS(13).RW_param.ToString)
        Main.STEPS(13).adr_param = TextBox56.Text
        file.WriteLine("step13adrparam: " + Main.STEPS(13).adr_param.ToString)
        Main.STEPS(13).val_param = TextBox71.Text
        file.WriteLine("step13valparam: " + Main.STEPS(13).val_param.ToString)
        Main.STEPS(13).DataBase = ComboBox56.SelectedIndex
        file.WriteLine("step13DB: " + Main.STEPS(13).DataBase.ToString)
        Main.STEPS(13).serial = ComboBox77.SelectedIndex
        file.WriteLine("step13serial: " + Main.STEPS(13).serial.ToString)

        'step14
        Main.STEPS(14).delay = TextBox19.Text
        file.WriteLine("step14delay: " + Main.STEPS(14).delay.ToString)
        Main.STEPS(14).read_DM = ComboBox36.SelectedIndex
        file.WriteLine("step14PN: " + Main.STEPS(14).read_DM.ToString)
        Main.STEPS(14).visual_control = CheckBox37.Checked
        file.WriteLine("step14visual: " + Main.STEPS(14).visual_control.ToString)
        Main.STEPS(14).RW_param = ComboBox15.SelectedIndex
        file.WriteLine("step14RWparam: " + Main.STEPS(14).RW_param.ToString)
        Main.STEPS(14).adr_param = TextBox57.Text
        file.WriteLine("step14adrparam: " + Main.STEPS(14).adr_param.ToString)
        Main.STEPS(14).val_param = TextBox70.Text
        file.WriteLine("step14valparam: " + Main.STEPS(14).val_param.ToString)
        Main.STEPS(14).DataBase = ComboBox57.SelectedIndex
        file.WriteLine("step14DB: " + Main.STEPS(14).DataBase.ToString)
        Main.STEPS(14).serial = ComboBox78.SelectedIndex
        file.WriteLine("step14serial: " + Main.STEPS(14).serial.ToString)

        'step15
        Main.STEPS(15).delay = TextBox18.Text
        file.WriteLine("step15delay: " + Main.STEPS(15).delay.ToString)
        Main.STEPS(15).read_DM = ComboBox37.SelectedIndex
        file.WriteLine("step15PN: " + Main.STEPS(15).read_DM.ToString)
        Main.STEPS(15).visual_control = CheckBox35.Checked
        file.WriteLine("step15visual: " + Main.STEPS(15).visual_control.ToString)
        Main.STEPS(15).RW_param = ComboBox16.SelectedIndex
        file.WriteLine("step15RWparam: " + Main.STEPS(15).RW_param.ToString)
        Main.STEPS(15).adr_param = TextBox58.Text
        file.WriteLine("step15adrparam: " + Main.STEPS(15).adr_param.ToString)
        Main.STEPS(15).val_param = TextBox69.Text
        file.WriteLine("step15valparam: " + Main.STEPS(15).val_param.ToString)
        Main.STEPS(15).DataBase = ComboBox58.SelectedIndex
        file.WriteLine("step15DB: " + Main.STEPS(15).DataBase.ToString)
        Main.STEPS(15).serial = ComboBox79.SelectedIndex
        file.WriteLine("step15serial: " + Main.STEPS(15).serial.ToString)

        'step16
        Main.STEPS(16).delay = TextBox17.Text
        file.WriteLine("step16delay: " + Main.STEPS(16).delay.ToString)
        Main.STEPS(16).read_DM = ComboBox38.SelectedIndex
        file.WriteLine("step16PN: " + Main.STEPS(16).read_DM.ToString)
        Main.STEPS(16).visual_control = CheckBox33.Checked
        file.WriteLine("step16visual: " + Main.STEPS(16).visual_control.ToString)
        Main.STEPS(16).RW_param = ComboBox17.SelectedIndex
        file.WriteLine("step16RWparam: " + Main.STEPS(16).RW_param.ToString)
        Main.STEPS(16).adr_param = TextBox59.Text
        file.WriteLine("step16adrparam: " + Main.STEPS(16).adr_param.ToString)
        Main.STEPS(16).val_param = TextBox68.Text
        file.WriteLine("step16valparam: " + Main.STEPS(16).val_param.ToString)
        Main.STEPS(16).DataBase = ComboBox59.SelectedIndex
        file.WriteLine("step16DB: " + Main.STEPS(16).DataBase.ToString)
        Main.STEPS(16).serial = ComboBox80.SelectedIndex
        file.WriteLine("step16serial: " + Main.STEPS(16).serial.ToString)

        'step17
        Main.STEPS(17).delay = TextBox16.Text
        file.WriteLine("step17delay: " + Main.STEPS(17).delay.ToString)
        Main.STEPS(17).read_DM = ComboBox39.SelectedIndex
        file.WriteLine("step17PN: " + Main.STEPS(17).read_DM.ToString)
        Main.STEPS(17).visual_control = CheckBox31.Checked
        file.WriteLine("step17visual: " + Main.STEPS(17).visual_control.ToString)
        Main.STEPS(17).RW_param = ComboBox18.SelectedIndex
        file.WriteLine("step17RWparam: " + Main.STEPS(17).RW_param.ToString)
        Main.STEPS(17).adr_param = TextBox60.Text
        file.WriteLine("step17adrparam: " + Main.STEPS(17).adr_param.ToString)
        Main.STEPS(17).val_param = TextBox67.Text
        file.WriteLine("step17valparam: " + Main.STEPS(17).val_param.ToString)
        Main.STEPS(17).DataBase = ComboBox60.SelectedIndex
        file.WriteLine("step17DB: " + Main.STEPS(17).DataBase.ToString)
        Main.STEPS(17).serial = ComboBox81.SelectedIndex
        file.WriteLine("step17serial: " + Main.STEPS(17).serial.ToString)

        'step18
        Main.STEPS(18).delay = TextBox15.Text
        file.WriteLine("step18delay: " + Main.STEPS(18).delay.ToString)
        Main.STEPS(18).read_DM = ComboBox40.SelectedIndex
        file.WriteLine("step18PN: " + Main.STEPS(18).read_DM.ToString)
        Main.STEPS(18).visual_control = CheckBox29.Checked
        file.WriteLine("step18visual: " + Main.STEPS(18).visual_control.ToString)
        Main.STEPS(18).RW_param = ComboBox19.SelectedIndex
        file.WriteLine("step18RWparam: " + Main.STEPS(18).RW_param.ToString)
        Main.STEPS(18).adr_param = TextBox61.Text
        file.WriteLine("step18adrparam: " + Main.STEPS(18).adr_param.ToString)
        Main.STEPS(18).val_param = TextBox66.Text
        file.WriteLine("step18valparam: " + Main.STEPS(18).val_param.ToString)
        Main.STEPS(18).DataBase = ComboBox61.SelectedIndex
        file.WriteLine("step18DB: " + Main.STEPS(18).DataBase.ToString)
        Main.STEPS(18).serial = ComboBox82.SelectedIndex
        file.WriteLine("step18serial: " + Main.STEPS(18).serial.ToString)

        'step19
        Main.STEPS(19).delay = TextBox14.Text
        file.WriteLine("step19delay: " + Main.STEPS(19).delay.ToString)
        Main.STEPS(19).read_DM = ComboBox41.SelectedIndex
        file.WriteLine("step19PN: " + Main.STEPS(19).read_DM.ToString)
        Main.STEPS(19).visual_control = CheckBox27.Checked
        file.WriteLine("step19visual: " + Main.STEPS(19).visual_control.ToString)
        Main.STEPS(19).RW_param = ComboBox20.SelectedIndex
        file.WriteLine("step19RWparam: " + Main.STEPS(19).RW_param.ToString)
        Main.STEPS(19).adr_param = TextBox62.Text
        file.WriteLine("step19adrparam: " + Main.STEPS(19).adr_param.ToString)
        Main.STEPS(19).val_param = TextBox65.Text
        file.WriteLine("step19valparam: " + Main.STEPS(19).val_param.ToString)
        Main.STEPS(19).DataBase = ComboBox62.SelectedIndex
        file.WriteLine("step19DB: " + Main.STEPS(19).DataBase.ToString)
        Main.STEPS(19).serial = ComboBox83.SelectedIndex
        file.WriteLine("step19serial: " + Main.STEPS(19).serial.ToString)

        'step20
        Main.STEPS(20).delay = TextBox13.Text
        file.WriteLine("step20delay: " + Main.STEPS(20).delay.ToString)
        Main.STEPS(20).read_DM = ComboBox42.SelectedIndex
        file.WriteLine("step20PN: " + Main.STEPS(20).read_DM.ToString)
        Main.STEPS(20).visual_control = CheckBox25.Checked
        file.WriteLine("step20visual: " + Main.STEPS(20).visual_control.ToString)
        Main.STEPS(20).RW_param = ComboBox21.SelectedIndex
        file.WriteLine("step20RWparam: " + Main.STEPS(20).RW_param.ToString)
        Main.STEPS(20).adr_param = TextBox63.Text
        file.WriteLine("step20adrparam: " + Main.STEPS(20).adr_param.ToString)
        Main.STEPS(20).val_param = TextBox64.Text
        file.WriteLine("step20valparam: " + Main.STEPS(20).val_param.ToString)
        Main.STEPS(20).DataBase = ComboBox63.SelectedIndex
        file.WriteLine("step20DB: " + Main.STEPS(20).DataBase.ToString)
        Main.STEPS(20).serial = ComboBox84.SelectedIndex
        file.WriteLine("step20serial: " + Main.STEPS(20).serial.ToString)

        file.Close()

        Dim file2 As New IO.StreamWriter(Main.Messages_ini)

        file2.WriteLine("mesaj0: " + TextBox30.Text)
        file2.WriteLine("mesaj1: " + TextBox31.Text)
        file2.WriteLine("mesaj2: " + TextBox32.Text)
        file2.WriteLine("mesaj3: " + TextBox33.Text)
        file2.WriteLine("mesaj4: " + TextBox34.Text)
        file2.WriteLine("mesaj5: " + TextBox35.Text)
        file2.WriteLine("mesaj6: " + TextBox36.Text)
        file2.WriteLine("mesaj7: " + TextBox37.Text)
        file2.WriteLine("mesaj8: " + TextBox38.Text)
        file2.WriteLine("mesaj9: " + TextBox39.Text)
        file2.WriteLine("mesaj10: " + TextBox40.Text)
        file2.WriteLine("mesaj11: " + TextBox41.Text)
        file2.WriteLine("mesaj12: " + TextBox42.Text)
        file2.WriteLine("mesaj13: " + TextBox43.Text)
        file2.WriteLine("mesaj14: " + TextBox44.Text)
        file2.WriteLine("mesaj15: " + TextBox45.Text)
        file2.WriteLine("mesaj16: " + TextBox46.Text)
        file2.WriteLine("mesaj17: " + TextBox47.Text)
        file2.WriteLine("mesaj18: " + TextBox48.Text)
        file2.WriteLine("mesaj19: " + TextBox49.Text)
        file2.WriteLine("mesaj20: " + TextBox12.Text)
        file2.Close()

        Main.Mesaje(0) = TextBox30.Text
        Main.Mesaje(1) = TextBox31.Text
        Main.Mesaje(2) = TextBox32.Text
        Main.Mesaje(3) = TextBox33.Text
        Main.Mesaje(4) = TextBox34.Text
        Main.Mesaje(5) = TextBox35.Text
        Main.Mesaje(6) = TextBox36.Text
        Main.Mesaje(7) = TextBox37.Text
        Main.Mesaje(8) = TextBox38.Text
        Main.Mesaje(9) = TextBox39.Text
        Main.Mesaje(10) = TextBox40.Text
        Main.Mesaje(11) = TextBox41.Text
        Main.Mesaje(12) = TextBox42.Text
        Main.Mesaje(13) = TextBox43.Text
        Main.Mesaje(14) = TextBox44.Text
        Main.Mesaje(15) = TextBox45.Text
        Main.Mesaje(16) = TextBox46.Text
        Main.Mesaje(17) = TextBox47.Text
        Main.Mesaje(18) = TextBox48.Text
        Main.Mesaje(19) = TextBox49.Text
        Main.Mesaje(20) = TextBox12.Text



    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Top = (My.Computer.Screen.WorkingArea.Height \ 2) - (Me.Height \ 2)
        Me.Left = (My.Computer.Screen.WorkingArea.Width \ 2) - (Me.Width \ 2)

        TextBox30.Text = Main.Mesaje(0)
        TextBox31.Text = Main.Mesaje(1)
        TextBox32.Text = Main.Mesaje(2)
        TextBox33.Text = Main.Mesaje(3)
        TextBox34.Text = Main.Mesaje(4)
        TextBox35.Text = Main.Mesaje(5)
        TextBox36.Text = Main.Mesaje(6)
        TextBox37.Text = Main.Mesaje(7)
        TextBox38.Text = Main.Mesaje(8)
        TextBox39.Text = Main.Mesaje(9)
        TextBox40.Text = Main.Mesaje(10)
        TextBox41.Text = Main.Mesaje(11)
        TextBox42.Text = Main.Mesaje(12)
        TextBox43.Text = Main.Mesaje(13)
        TextBox44.Text = Main.Mesaje(14)
        TextBox45.Text = Main.Mesaje(15)
        TextBox46.Text = Main.Mesaje(16)
        TextBox47.Text = Main.Mesaje(17)
        TextBox48.Text = Main.Mesaje(18)
        TextBox49.Text = Main.Mesaje(19)
        TextBox12.Text = Main.Mesaje(20)

        ComboBox22.Items.AddRange(RTS.ComboBox3.Items.Cast(Of String).ToArray())
        ComboBox23.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox24.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox25.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox26.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox27.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox28.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox29.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox30.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox31.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox32.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox33.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox34.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox35.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox36.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox37.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox38.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox39.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox40.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox41.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())
        ComboBox42.Items.AddRange(ComboBox22.Items.Cast(Of String).ToArray())


        NewMethod()

    End Sub

    ''' <summary>
    ''' Read values from Ini file
    ''' </summary>
    Public Sub NewMethod()


        Try

            'step 0
            Main.STEPS(0).delay = Main.GetSettingItem(nume, "step0delay")
            TextBox1.Text = Main.STEPS(0).delay
            Main.STEPS(0).read_DM = Main.GetSettingItem(nume, "step0PN")
            ComboBox22.SelectedIndex = Main.STEPS(0).read_DM
            Main.STEPS(0).visual_control = Main.GetSettingItem(nume, "step0visual")
            CheckBox2.Checked = Main.STEPS(0).visual_control
            Main.STEPS(0).RW_param = Main.GetSettingItem(nume, "step0RWparam")
            ComboBox1.SelectedIndex = Main.STEPS(0).RW_param
            Main.STEPS(0).adr_param = Main.GetSettingItem(nume, "step0adrparam")
            TextBox23.Text = Main.STEPS(0).adr_param
            Main.STEPS(0).val_param = Main.GetSettingItem(nume, "step0valparam")
            TextBox84.Text = Main.STEPS(0).val_param
            Main.STEPS(0).DataBase = Main.GetSettingItem(nume, "step0DB")
            ComboBox43.SelectedIndex = Main.STEPS(0).DataBase
            Try
                Main.STEPS(0).serial = Main.GetSettingItem(nume, "step0serial")
                ComboBox64.SelectedIndex = Main.STEPS(0).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 0", vbOK, "ERROR COM PORT")
            End Try


            'step1
            Main.STEPS(1).delay = Main.GetSettingItem(nume, "step1delay")
            TextBox2.Text = Main.STEPS(1).delay
            Main.STEPS(1).read_DM = Main.GetSettingItem(nume, "step1PN")
            ComboBox23.SelectedIndex = Main.STEPS(1).read_DM
            Main.STEPS(1).visual_control = Main.GetSettingItem(nume, "step1visual")
            CheckBox3.Checked = Main.STEPS(1).visual_control
            Main.STEPS(1).RW_param = Main.GetSettingItem(nume, "step1RWparam")
            ComboBox2.SelectedIndex = Main.STEPS(1).RW_param
            Main.STEPS(1).adr_param = Main.GetSettingItem(nume, "step1adrparam")
            TextBox24.Text = Main.STEPS(1).adr_param
            Main.STEPS(1).val_param = Main.GetSettingItem(nume, "step1valparam")
            TextBox83.Text = Main.STEPS(1).val_param
            Main.STEPS(1).DataBase = Main.GetSettingItem(nume, "step1DB")
            ComboBox44.SelectedIndex = Main.STEPS(1).DataBase
            Try
                Main.STEPS(1).serial = Main.GetSettingItem(nume, "step1serial")
                ComboBox65.SelectedIndex = Main.STEPS(1).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 1", vbOK, "ERROR COM PORT")
            End Try


            'step2
            Main.STEPS(2).delay = Main.GetSettingItem(nume, "step2delay")
            TextBox3.Text = Main.STEPS(2).delay
            Main.STEPS(2).read_DM = Main.GetSettingItem(nume, "step2PN")
            ComboBox24.SelectedIndex = Main.STEPS(2).read_DM
            Main.STEPS(2).visual_control = Main.GetSettingItem(nume, "step2visual")
            CheckBox5.Checked = Main.STEPS(2).visual_control
            Main.STEPS(2).RW_param = Main.GetSettingItem(nume, "step2RWparam")
            ComboBox3.SelectedIndex = Main.STEPS(2).RW_param
            Main.STEPS(2).adr_param = Main.GetSettingItem(nume, "step2adrparam")
            TextBox25.Text = Main.STEPS(2).adr_param
            Main.STEPS(2).val_param = Main.GetSettingItem(nume, "step2valparam")
            TextBox82.Text = Main.STEPS(2).val_param
            Main.STEPS(2).DataBase = Main.GetSettingItem(nume, "step2DB")
            ComboBox45.SelectedIndex = Main.STEPS(2).DataBase
            Try
                Main.STEPS(2).serial = Main.GetSettingItem(nume, "step2serial")
                ComboBox66.SelectedIndex = Main.STEPS(2).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 2", vbOK, "ERROR COM PORT")
            End Try


            'step3
            Main.STEPS(3).delay = Main.GetSettingItem(nume, "step3delay")
            TextBox4.Text = Main.STEPS(3).delay
            Main.STEPS(3).read_DM = Main.GetSettingItem(nume, "step3PN")
            ComboBox25.SelectedIndex = Main.STEPS(3).read_DM
            Main.STEPS(3).visual_control = Main.GetSettingItem(nume, "step3visual")
            CheckBox7.Checked = Main.STEPS(3).visual_control
            Main.STEPS(3).RW_param = Main.GetSettingItem(nume, "step3RWparam")
            ComboBox4.SelectedIndex = Main.STEPS(3).RW_param
            Main.STEPS(3).adr_param = Main.GetSettingItem(nume, "step3adrparam")
            TextBox26.Text = Main.STEPS(3).adr_param
            Main.STEPS(3).val_param = Main.GetSettingItem(nume, "step3valparam")
            TextBox81.Text = Main.STEPS(3).val_param
            Main.STEPS(3).DataBase = Main.GetSettingItem(nume, "step3DB")
            ComboBox46.SelectedIndex = Main.STEPS(3).DataBase
            Try
                Main.STEPS(3).serial = Main.GetSettingItem(nume, "step3serial")
                ComboBox67.SelectedIndex = Main.STEPS(3).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 3", vbOK, "ERROR COM PORT")
            End Try



            'step4
            Main.STEPS(4).delay = Main.GetSettingItem(nume, "step4delay")
            TextBox5.Text = Main.STEPS(4).delay
            Main.STEPS(4).read_DM = Main.GetSettingItem(nume, "step4PN")
            ComboBox26.SelectedIndex = Main.STEPS(4).read_DM
            Main.STEPS(4).visual_control = Main.GetSettingItem(nume, "step4visual")
            CheckBox9.Checked = Main.STEPS(4).visual_control
            Main.STEPS(4).RW_param = Main.GetSettingItem(nume, "step4RWparam")
            ComboBox5.SelectedIndex = Main.STEPS(4).RW_param
            Main.STEPS(4).adr_param = Main.GetSettingItem(nume, "step4adrparam")
            TextBox27.Text = Main.STEPS(4).adr_param
            Main.STEPS(4).val_param = Main.GetSettingItem(nume, "step4valparam")
            TextBox80.Text = Main.STEPS(4).val_param
            Main.STEPS(4).DataBase = Main.GetSettingItem(nume, "step4DB")
            ComboBox47.SelectedIndex = Main.STEPS(4).DataBase
            Try
                Main.STEPS(4).serial = Main.GetSettingItem(nume, "step4serial")
                ComboBox68.SelectedIndex = Main.STEPS(4).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 4", vbOK, "ERROR COM PORT")
            End Try


            'step5
            Main.STEPS(5).delay = Main.GetSettingItem(nume, "step5delay")
            TextBox6.Text = Main.STEPS(5).delay
            Main.STEPS(5).read_DM = Main.GetSettingItem(nume, "step5PN")
            ComboBox27.SelectedIndex = Main.STEPS(5).read_DM
            Main.STEPS(5).visual_control = Main.GetSettingItem(nume, "step5visual")
            CheckBox11.Checked = Main.STEPS(5).visual_control
            Main.STEPS(5).RW_param = Main.GetSettingItem(nume, "step5RWparam")
            ComboBox6.SelectedIndex = Main.STEPS(5).RW_param
            Main.STEPS(5).adr_param = Main.GetSettingItem(nume, "step5adrparam")
            TextBox28.Text = Main.STEPS(5).adr_param
            Main.STEPS(5).val_param = Main.GetSettingItem(nume, "step5valparam")
            TextBox79.Text = Main.STEPS(5).val_param
            Main.STEPS(5).DataBase = Main.GetSettingItem(nume, "step5DB")
            ComboBox48.SelectedIndex = Main.STEPS(5).DataBase
            Try
                Main.STEPS(5).serial = Main.GetSettingItem(nume, "step5serial")
                ComboBox69.SelectedIndex = Main.STEPS(5).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 5", vbOK, "ERROR COM PORT")
            End Try


            'step6
            Main.STEPS(6).delay = Main.GetSettingItem(nume, "step6delay")
            TextBox7.Text = Main.STEPS(6).delay
            Main.STEPS(6).read_DM = Main.GetSettingItem(nume, "step6PN")
            ComboBox28.SelectedIndex = Main.STEPS(6).read_DM
            Main.STEPS(6).visual_control = Main.GetSettingItem(nume, "step6visual")
            CheckBox13.Checked = Main.STEPS(6).visual_control
            Main.STEPS(6).RW_param = Main.GetSettingItem(nume, "step6RWparam")
            ComboBox7.SelectedIndex = Main.STEPS(6).RW_param
            Main.STEPS(6).adr_param = Main.GetSettingItem(nume, "step6adrparam")
            TextBox29.Text = Main.STEPS(6).adr_param
            Main.STEPS(6).val_param = Main.GetSettingItem(nume, "step6valparam")
            TextBox78.Text = Main.STEPS(6).val_param
            Main.STEPS(6).DataBase = Main.GetSettingItem(nume, "step6DB")
            ComboBox49.SelectedIndex = Main.STEPS(6).DataBase
            Try
                Main.STEPS(6).serial = Main.GetSettingItem(nume, "step6serial")
                ComboBox70.SelectedIndex = Main.STEPS(6).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 6", vbOK, "ERROR COM PORT")
            End Try


            'step7
            Main.STEPS(7).delay = Main.GetSettingItem(nume, "step7delay")
            TextBox8.Text = Main.STEPS(7).delay
            Main.STEPS(7).read_DM = Main.GetSettingItem(nume, "step7PN")
            ComboBox29.SelectedIndex = Main.STEPS(7).read_DM
            Main.STEPS(7).visual_control = Main.GetSettingItem(nume, "step7visual")
            CheckBox15.Checked = Main.STEPS(7).visual_control
            Main.STEPS(7).RW_param = Main.GetSettingItem(nume, "step7RWparam")
            ComboBox8.SelectedIndex = Main.STEPS(7).RW_param
            Main.STEPS(7).adr_param = Main.GetSettingItem(nume, "step7adrparam")
            TextBox50.Text = Main.STEPS(7).adr_param
            Main.STEPS(7).val_param = Main.GetSettingItem(nume, "step7valparam")
            TextBox77.Text = Main.STEPS(7).val_param
            Main.STEPS(7).DataBase = Main.GetSettingItem(nume, "step7DB")
            ComboBox50.SelectedIndex = Main.STEPS(7).DataBase
            Try
                Main.STEPS(7).serial = Main.GetSettingItem(nume, "step7serial")
                ComboBox71.SelectedIndex = Main.STEPS(7).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 7", vbOK, "ERROR COM PORT")
            End Try


            'step8
            Main.STEPS(8).delay = Main.GetSettingItem(nume, "step8delay")
            TextBox9.Text = Main.STEPS(8).delay
            Main.STEPS(8).read_DM = Main.GetSettingItem(nume, "step8PN")
            ComboBox30.SelectedIndex = Main.STEPS(8).read_DM
            Main.STEPS(8).visual_control = Main.GetSettingItem(nume, "step8visual")
            CheckBox17.Checked = Main.STEPS(8).visual_control
            Main.STEPS(8).RW_param = Main.GetSettingItem(nume, "step8RWparam")
            ComboBox9.SelectedIndex = Main.STEPS(8).RW_param
            Main.STEPS(8).adr_param = Main.GetSettingItem(nume, "step8adrparam")
            TextBox51.Text = Main.STEPS(8).adr_param
            Main.STEPS(8).val_param = Main.GetSettingItem(nume, "step8valparam")
            TextBox76.Text = Main.STEPS(8).val_param
            Main.STEPS(8).DataBase = Main.GetSettingItem(nume, "step8DB")
            ComboBox51.SelectedIndex = Main.STEPS(8).DataBase
            Try
                Main.STEPS(8).serial = Main.GetSettingItem(nume, "step8serial")
                ComboBox72.SelectedIndex = Main.STEPS(8).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 8", vbOK, "ERROR COM PORT")
            End Try


            'step9
            Main.STEPS(9).delay = Main.GetSettingItem(nume, "step9delay")
            TextBox10.Text = Main.STEPS(9).delay
            Main.STEPS(9).read_DM = Main.GetSettingItem(nume, "step9PN")
            ComboBox31.SelectedIndex = Main.STEPS(9).read_DM
            Main.STEPS(9).visual_control = Main.GetSettingItem(nume, "step9visual")
            CheckBox19.Checked = Main.STEPS(9).visual_control
            Main.STEPS(9).RW_param = Main.GetSettingItem(nume, "step9RWparam")
            ComboBox10.SelectedIndex = Main.STEPS(9).RW_param
            Main.STEPS(9).adr_param = Main.GetSettingItem(nume, "step9adrparam")
            TextBox52.Text = Main.STEPS(9).adr_param
            Main.STEPS(9).val_param = Main.GetSettingItem(nume, "step9valparam")
            TextBox75.Text = Main.STEPS(9).val_param
            Main.STEPS(9).DataBase = Main.GetSettingItem(nume, "step9DB")
            ComboBox52.SelectedIndex = Main.STEPS(9).DataBase
            Try
                Main.STEPS(9).serial = Main.GetSettingItem(nume, "step9serial")
                ComboBox73.SelectedIndex = Main.STEPS(9).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 9", vbOK, "ERROR COM PORT")
            End Try


            'step10
            Main.STEPS(10).delay = Main.GetSettingItem(nume, "step10delay")
            TextBox11.Text = Main.STEPS(10).delay
            Main.STEPS(10).read_DM = Main.GetSettingItem(nume, "step10PN")
            ComboBox32.SelectedIndex = Main.STEPS(10).read_DM
            Main.STEPS(10).visual_control = Main.GetSettingItem(nume, "step10visual")
            CheckBox21.Checked = Main.STEPS(10).visual_control
            Main.STEPS(10).RW_param = Main.GetSettingItem(nume, "step10RWparam")
            ComboBox11.SelectedIndex = Main.STEPS(10).RW_param
            Main.STEPS(10).adr_param = Main.GetSettingItem(nume, "step10adrparam")
            TextBox53.Text = Main.STEPS(10).adr_param
            Main.STEPS(10).val_param = Main.GetSettingItem(nume, "step10valparam")
            TextBox74.Text = Main.STEPS(10).val_param
            Main.STEPS(10).DataBase = Main.GetSettingItem(nume, "step10DB")
            ComboBox53.SelectedIndex = Main.STEPS(10).DataBase
            Try
                Main.STEPS(10).serial = Main.GetSettingItem(nume, "step10serial")
                ComboBox74.SelectedIndex = Main.STEPS(10).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 10", vbOK, "ERROR COM PORT")
            End Try


            'step11
            Main.STEPS(11).delay = Main.GetSettingItem(nume, "step11delay")
            TextBox22.Text = Main.STEPS(11).delay
            Main.STEPS(11).read_DM = Main.GetSettingItem(nume, "step11PN")
            ComboBox33.SelectedIndex = Main.STEPS(11).read_DM
            Main.STEPS(11).visual_control = Main.GetSettingItem(nume, "step11visual")
            CheckBox43.Checked = Main.STEPS(11).visual_control
            Main.STEPS(11).RW_param = Main.GetSettingItem(nume, "step11RWparam")
            ComboBox12.SelectedIndex = Main.STEPS(11).RW_param
            Main.STEPS(11).adr_param = Main.GetSettingItem(nume, "step11adrparam")
            TextBox54.Text = Main.STEPS(11).adr_param
            Main.STEPS(11).val_param = Main.GetSettingItem(nume, "step11valparam")
            TextBox73.Text = Main.STEPS(11).val_param
            Main.STEPS(11).DataBase = Main.GetSettingItem(nume, "step11DB")
            ComboBox54.SelectedIndex = Main.STEPS(11).DataBase
            Try
                Main.STEPS(11).serial = Main.GetSettingItem(nume, "step11serial")
                ComboBox75.SelectedIndex = Main.STEPS(11).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 11", vbOK, "ERROR COM PORT")
            End Try


            'step12
            Main.STEPS(12).delay = Main.GetSettingItem(nume, "step12delay")
            TextBox21.Text = Main.STEPS(12).delay
            Main.STEPS(12).read_DM = Main.GetSettingItem(nume, "step12PN")
            ComboBox34.SelectedIndex = Main.STEPS(12).read_DM
            Main.STEPS(12).visual_control = Main.GetSettingItem(nume, "step12visual")
            CheckBox41.Checked = Main.STEPS(12).visual_control
            Main.STEPS(12).RW_param = Main.GetSettingItem(nume, "step12RWparam")
            ComboBox13.SelectedIndex = Main.STEPS(12).RW_param
            Main.STEPS(12).adr_param = Main.GetSettingItem(nume, "step12adrparam")
            TextBox55.Text = Main.STEPS(12).adr_param
            Main.STEPS(12).val_param = Main.GetSettingItem(nume, "step12valparam")
            TextBox72.Text = Main.STEPS(12).val_param
            Main.STEPS(12).DataBase = Main.GetSettingItem(nume, "step12DB")
            ComboBox55.SelectedIndex = Main.STEPS(12).DataBase
            Try
                Main.STEPS(12).serial = Main.GetSettingItem(nume, "step12serial")
                ComboBox76.SelectedIndex = Main.STEPS(12).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 11", vbOK, "ERROR COM PORT")
            End Try


            'step13
            Main.STEPS(13).delay = Main.GetSettingItem(nume, "step13delay")
            TextBox20.Text = Main.STEPS(13).delay
            Main.STEPS(13).read_DM = Main.GetSettingItem(nume, "step13PN")
            ComboBox35.SelectedIndex = Main.STEPS(13).read_DM
            Main.STEPS(13).visual_control = Main.GetSettingItem(nume, "step13visual")
            CheckBox39.Checked = Main.STEPS(13).visual_control
            Main.STEPS(13).RW_param = Main.GetSettingItem(nume, "step13RWparam")
            ComboBox14.SelectedIndex = Main.STEPS(13).RW_param
            Main.STEPS(13).adr_param = Main.GetSettingItem(nume, "step13adrparam")
            TextBox56.Text = Main.STEPS(13).adr_param
            Main.STEPS(13).val_param = Main.GetSettingItem(nume, "step13valparam")
            TextBox71.Text = Main.STEPS(13).val_param
            Main.STEPS(13).DataBase = Main.GetSettingItem(nume, "step13DB")
            ComboBox56.SelectedIndex = Main.STEPS(13).DataBase
            Try
                Main.STEPS(13).serial = Main.GetSettingItem(nume, "step13serial")
                ComboBox77.SelectedIndex = Main.STEPS(13).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 11", vbOK, "ERROR COM PORT")
            End Try


            'step14
            Main.STEPS(14).delay = Main.GetSettingItem(nume, "step14delay")
            TextBox19.Text = Main.STEPS(14).delay
            Main.STEPS(14).read_DM = Main.GetSettingItem(nume, "step14PN")
            ComboBox36.SelectedIndex = Main.STEPS(14).read_DM
            Main.STEPS(14).visual_control = Main.GetSettingItem(nume, "step14visual")
            CheckBox37.Checked = Main.STEPS(14).visual_control
            Main.STEPS(14).RW_param = Main.GetSettingItem(nume, "step14RWparam")
            ComboBox15.SelectedIndex = Main.STEPS(14).RW_param
            Main.STEPS(14).adr_param = Main.GetSettingItem(nume, "step14adrparam")
            TextBox57.Text = Main.STEPS(14).adr_param
            Main.STEPS(14).val_param = Main.GetSettingItem(nume, "step14valparam")
            TextBox70.Text = Main.STEPS(14).val_param
            Main.STEPS(14).DataBase = Main.GetSettingItem(nume, "step14DB")
            ComboBox57.SelectedIndex = Main.STEPS(14).DataBase
            Try
                Main.STEPS(14).serial = Main.GetSettingItem(nume, "step14serial")
                ComboBox78.SelectedIndex = Main.STEPS(14).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 11", vbOK, "ERROR COM PORT")
            End Try


            'step15
            Main.STEPS(15).delay = Main.GetSettingItem(nume, "step15delay")
            TextBox18.Text = Main.STEPS(15).delay
            Main.STEPS(15).read_DM = Main.GetSettingItem(nume, "step15PN")
            ComboBox37.SelectedIndex = Main.STEPS(15).read_DM
            Main.STEPS(15).visual_control = Main.GetSettingItem(nume, "step15visual")
            CheckBox35.Checked = Main.STEPS(15).visual_control
            Main.STEPS(15).RW_param = Main.GetSettingItem(nume, "step15RWparam")
            ComboBox16.SelectedIndex = Main.STEPS(15).RW_param
            Main.STEPS(15).adr_param = Main.GetSettingItem(nume, "step15adrparam")
            TextBox58.Text = Main.STEPS(15).adr_param
            Main.STEPS(15).val_param = Main.GetSettingItem(nume, "step15valparam")
            TextBox69.Text = Main.STEPS(15).val_param
            Main.STEPS(15).DataBase = Main.GetSettingItem(nume, "step15DB")
            ComboBox58.SelectedIndex = Main.STEPS(15).DataBase
            Try
                Main.STEPS(15).serial = Main.GetSettingItem(nume, "step15serial")
                ComboBox79.SelectedIndex = Main.STEPS(15).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 11", vbOK, "ERROR COM PORT")
            End Try


            'step16
            Main.STEPS(16).delay = Main.GetSettingItem(nume, "step16delay")
            TextBox17.Text = Main.STEPS(16).delay
            Main.STEPS(16).read_DM = Main.GetSettingItem(nume, "step16PN")
            ComboBox38.SelectedIndex = Main.STEPS(16).read_DM
            Main.STEPS(16).visual_control = Main.GetSettingItem(nume, "step16visual")
            CheckBox33.Checked = Main.STEPS(16).visual_control
            Main.STEPS(16).RW_param = Main.GetSettingItem(nume, "step16RWparam")
            ComboBox17.SelectedIndex = Main.STEPS(16).RW_param
            Main.STEPS(16).adr_param = Main.GetSettingItem(nume, "step16adrparam")
            TextBox59.Text = Main.STEPS(16).adr_param
            Main.STEPS(16).val_param = Main.GetSettingItem(nume, "step16valparam")
            TextBox68.Text = Main.STEPS(16).val_param
            Main.STEPS(16).DataBase = Main.GetSettingItem(nume, "step16DB")
            ComboBox59.SelectedIndex = Main.STEPS(16).DataBase
            Try
                Main.STEPS(16).serial = Main.GetSettingItem(nume, "step16serial")
                ComboBox80.SelectedIndex = Main.STEPS(16).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 11", vbOK, "ERROR COM PORT")
            End Try


            'step17
            Main.STEPS(17).delay = Main.GetSettingItem(nume, "step17delay")
            TextBox16.Text = Main.STEPS(17).delay
            Main.STEPS(17).read_DM = Main.GetSettingItem(nume, "step17PN")
            ComboBox39.SelectedIndex = Main.STEPS(17).read_DM
            Main.STEPS(17).visual_control = Main.GetSettingItem(nume, "step17visual")
            CheckBox31.Checked = Main.STEPS(17).visual_control
            Main.STEPS(17).RW_param = Main.GetSettingItem(nume, "step17RWparam")
            ComboBox18.SelectedIndex = Main.STEPS(17).RW_param
            Main.STEPS(17).adr_param = Main.GetSettingItem(nume, "step17adrparam")
            TextBox60.Text = Main.STEPS(17).adr_param
            Main.STEPS(17).val_param = Main.GetSettingItem(nume, "step17valparam")
            TextBox67.Text = Main.STEPS(17).val_param
            Main.STEPS(17).DataBase = Main.GetSettingItem(nume, "step17DB")
            ComboBox60.SelectedIndex = Main.STEPS(17).DataBase
            Try
                Main.STEPS(17).serial = Main.GetSettingItem(nume, "step17serial")
                ComboBox81.SelectedIndex = Main.STEPS(17).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 11", vbOK, "ERROR COM PORT")
            End Try


            'step18
            Main.STEPS(18).delay = Main.GetSettingItem(nume, "step18delay")
            TextBox15.Text = Main.STEPS(18).delay
            Main.STEPS(18).read_DM = Main.GetSettingItem(nume, "step18PN")
            ComboBox40.SelectedIndex = Main.STEPS(18).read_DM
            Main.STEPS(18).visual_control = Main.GetSettingItem(nume, "step18visual")
            CheckBox29.Checked = Main.STEPS(18).visual_control
            Main.STEPS(18).RW_param = Main.GetSettingItem(nume, "step18RWparam")
            ComboBox19.SelectedIndex = Main.STEPS(18).RW_param
            Main.STEPS(18).adr_param = Main.GetSettingItem(nume, "step18adrparam")
            TextBox61.Text = Main.STEPS(18).adr_param
            Main.STEPS(18).val_param = Main.GetSettingItem(nume, "step18valparam")
            TextBox66.Text = Main.STEPS(18).val_param
            Main.STEPS(18).DataBase = Main.GetSettingItem(nume, "step18DB")
            ComboBox61.SelectedIndex = Main.STEPS(18).DataBase
            Try
                Main.STEPS(18).serial = Main.GetSettingItem(nume, "step18serial")
                ComboBox82.SelectedIndex = Main.STEPS(18).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 11", vbOK, "ERROR COM PORT")
            End Try


            'step19
            Main.STEPS(19).delay = Main.GetSettingItem(nume, "step19delay")
            TextBox14.Text = Main.STEPS(19).delay
            Main.STEPS(19).read_DM = Main.GetSettingItem(nume, "step19PN")
            ComboBox41.SelectedIndex = Main.STEPS(19).read_DM
            Main.STEPS(19).visual_control = Main.GetSettingItem(nume, "step19visual")
            CheckBox27.Checked = Main.STEPS(19).visual_control
            Main.STEPS(19).RW_param = Main.GetSettingItem(nume, "step19RWparam")
            ComboBox20.SelectedIndex = Main.STEPS(19).RW_param
            Main.STEPS(19).adr_param = Main.GetSettingItem(nume, "step19adrparam")
            TextBox62.Text = Main.STEPS(19).adr_param
            Main.STEPS(19).val_param = Main.GetSettingItem(nume, "step19valparam")
            TextBox65.Text = Main.STEPS(19).val_param
            Main.STEPS(19).DataBase = Main.GetSettingItem(nume, "step19DB")
            ComboBox62.SelectedIndex = Main.STEPS(19).DataBase
            Try
                Main.STEPS(19).serial = Main.GetSettingItem(nume, "step19serial")
                ComboBox83.SelectedIndex = Main.STEPS(19).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 11", vbOK, "ERROR COM PORT")
            End Try


            'step20
            Main.STEPS(20).delay = Main.GetSettingItem(nume, "step20delay")
            TextBox13.Text = Main.STEPS(20).delay
            Main.STEPS(20).read_DM = Main.GetSettingItem(nume, "step20PN")
            ComboBox42.SelectedIndex = Main.STEPS(20).read_DM
            Main.STEPS(20).visual_control = Main.GetSettingItem(nume, "step20visual")
            CheckBox25.Checked = Main.STEPS(20).visual_control
            Main.STEPS(20).RW_param = Main.GetSettingItem(nume, "step20RWparam")
            ComboBox21.SelectedIndex = Main.STEPS(20).RW_param
            Main.STEPS(20).adr_param = Main.GetSettingItem(nume, "step20adrparam")
            TextBox63.Text = Main.STEPS(20).adr_param
            Main.STEPS(20).val_param = Main.GetSettingItem(nume, "step20valparam")
            TextBox64.Text = Main.STEPS(20).val_param
            Main.STEPS(20).DataBase = Main.GetSettingItem(nume, "step20DB")
            ComboBox63.SelectedIndex = Main.STEPS(20).DataBase
            Try
                Main.STEPS(20).serial = Main.GetSettingItem(nume, "step20serial")
                ComboBox84.SelectedIndex = Main.STEPS(20).serial
            Catch ex As Exception
                MsgBox("COM port Saved not active ! Step: 11", vbOK, "ERROR COM PORT")
            End Try


        Catch ex As Exception
            MsgBox("Corunpt Ini File !!!! Put backup or contact PFL !", vbOK, "ERROR Reading INI File")
        End Try


    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Settings2.Show()
        Close()
    End Sub
End Class