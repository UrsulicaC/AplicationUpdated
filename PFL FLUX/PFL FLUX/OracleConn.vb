Imports System.IO
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

Public Class OracleConn

    'declare global var
    Private Oracle_CNX As New OracleConnection()
    Dim Oracle_CMD As OracleCommand
    Dim DM As OracleParameter
    Dim OP As OracleParameter
    Dim REF As OracleParameter
    Dim DEF As OracleParameter
    Dim TYPE_PROC As OracleParameter
    Dim PARAM_CHAR As OracleParameter
    Dim TYPE_CONTROL As OracleParameter
    Dim PARAM_NUMBER As OracleParameter
    Dim NB_PASSAGE As OracleParameter
    Dim MCH_FIXTURE As OracleParameter
    Dim MCH_STATION As OracleParameter
    Dim NUM_IMMO As OracleParameter
    Dim PROD_TYPE As OracleParameter
    Dim STAT_PART As OracleParameter
    Dim STATUS As OracleParameter
    Dim DATEOP As OracleParameter
    Dim BF As OracleParameter
    Dim LINE As OracleParameter
    Dim Rtn As OracleParameter
    Dim TypeD As OracleParameter
    Dim DefL As OracleParameter
    Dim OraDB As String
    Dim Buffer() As String
    Dim MessOra As OracleParameter

    Dim IDcomponent As OracleParameter
    Dim TypeComponent As OracleParameter
    Dim PLANT As OracleParameter
    Dim SERIE_POMPA As OracleParameter
    Public Shared RETURN_STAT As Short = -10
    Public Class Ora_Param
        Public Ora_user As String
        Public Ora_password As String
        Public Ora_service As String
    End Class

    Public OraParam As New Ora_Param



    ' Dim Ora_Connection As New OleDbConnection()
    'Dim Ora_Command As New OleDbCommand

#Region "Buffer"

    Public Function Create_Buffer1(ByVal DM As String, ByVal REF As String, ByVal FAB As String, ByVal OFR As String, ByVal Batch As String,
                              ByVal OP As String, ByVal Line As String, ByVal MachineNb As String, ByVal Station As String,
                              ByVal MChead As String, ByVal Date_Time As DateTime, ByVal Err As String)


        Dim Str As String = "1;" + DM.PadRight(33) + ";" + REF.PadRight(15) + ";" + FAB.PadLeft(1) + ";" + OFR.PadLeft(6) + ";" +
                Batch.PadLeft(12) + ";" + OP.PadLeft(5, "0") + ";" + Line.PadLeft(1) + ";" + MachineNb.PadLeft(6) + ";" +
                Station.PadLeft(2) + ";" + MChead.PadLeft(2) + ";" + Date_Time.ToString("ddMMyyyyHHmmss") + ";" + Err.PadLeft(6, "0")
        Return Str

    End Function

    Public Function Buffer_Article4(ByVal DM As String, ByVal OP As Integer,
                                           ByVal IdMeasure As Integer,
                                           ByVal Date_Time As DateTime,
                                           ByVal Line As Integer, ByVal MachineNb As String, ByVal Station As Integer, ByVal MChead As Integer,
                                           ByVal Parameter As String, ByVal Value As Double, ByVal TargetValue As Double,
                                           ByVal ToleranceMin As Double, ByVal ToleranceMax As Double, ByVal Unit As String,
                                           ByVal Err As Integer, Optional ByVal bModeOracle As Boolean = False)

        Dim Str As String


        Str = "4" +
            Left(DM.PadRight(33), 33) + ";" +
            Left(OP.ToString("00000;00000"), 5) + ";" +
            Left(IdMeasure.ToString("00000;00000"), 5) + ";" +
            Date_Time.ToString("ddMMyyyyHHmmss") + ";" +
            Left(Line.ToString("0;0"), 1) + ";" +
            Left(MachineNb.PadLeft(6, "0"), 6) + ";" +
            Left(Station.ToString("00;00"), 2) + ";" +
            Left(MChead.ToString("00;00"), 2) + ";" +
            Left(Parameter.PadRight(6), 6) + ";" +
            MESDouble(Value, bModeOracle) + ";" +
            MESDouble(TargetValue, bModeOracle) + ";" +
            MESDouble(ToleranceMin, bModeOracle) + ";" +
            MESDouble(ToleranceMax, bModeOracle) + ";" +
            Left(Unit.PadRight(6), 6) + ";" +
            Left(Err.ToString("000000;-00000"), 6)

        Return Str

    End Function

    Public Function Create_Buffer6(ByVal DM As String, ByVal OP As String, ByVal Date_Time As DateTime, ByVal DM_Comp As String, ByVal Type_Comp As String)


        Dim Str As String = "6" + ";" + DM.PadRight(33) + ";" + OP.PadLeft(5, "0") + ";" + Date.Now.ToString("ddMMyyyyHHmmss") + ";" + DM_Comp.PadRight(33) + ";" + Type_Comp.PadRight(3)
        Return Str

    End Function
#End Region

#Region "Oracle connexion/disconnection"
    ''' <summary>
    ''' Oracle connextion function. 
    ''' </summary>
    ''' <param name="Return_Value">with or without function return. True: return error connexion value / False: connexion error manages by function</param>
    ''' <returns>value return after connextion</returns>
    ''' <remarks>return "ok" if connected or error string if issue</remarks>
    Friend Function Oracle_Connexion(ByVal Return_Value As Boolean) As String
        Dim Val_Return As String = ""
        'OraDB = "Data Source=(DESCRIPTION=" _
        '    + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + My.Settings.op + ")(PORT=" + My.Settings.Ora_Port + ")))" _
        '    + "(CONNECT_DATA=(SERVICE_NAME=" + My.Settings.Ora_Service + ")));" _
        '    + "User Id=" + "btrcr_user_pp" + ";Password=" + "iasi" + ";"
        OraDB = "User Id=" + OraParam.Ora_user + ";Password=" + OraParam.Ora_password + ";Data Source=" + OraParam.Ora_service
        Oracle_CNX.ConnectionString = OraDB

        Try
            Oracle_CNX.Open()
            Val_Return = "ok"

        Catch ex As Exception
            If Return_Value Then
                Val_Return = ex.ToString
            Else
                Oracle_Connexion_error(ex.ToString)
            End If
        End Try

        Return Val_Return
    End Function

    Friend Sub Oracle_Connexion_error(ByVal except As String)
        Dim result As DialogResult
        result = MessageBox.Show("Database error connexion:" + vbCrLf + except + vbCrLf + vbCrLf + "Continue?", "Oracle Database connexion", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        If result = DialogResult.Cancel Then Application.Exit()
    End Sub


    Friend Sub Oracle_Disconnexion()
        Oracle_CNX.Close()
    End Sub

#End Region





#Region "PACKAGE - PCK_FLOW_CTRL_V1 "

    Public Function PCK_FLOW_CTRL(ByVal DMX As String, ByVal OPERATION As Integer, ByVal REFERENCE As String, ByVal ligne As Integer, ByVal typeproc As String, ByVal typectrl As Integer, ByVal stat As Integer, Optional ByVal ShowMessaboxBox As Boolean = False) As Integer
        'Dim Stat As Integer 'value returned by database
        ' VALIDATION_OP (Buffer, Stat)
        'declare parameters
        Oracle_CMD = New OracleCommand()

        'declare the stored procedure
        Oracle_CMD.CommandType = CommandType.StoredProcedure
        Oracle_CMD.CommandText = "PCK_FLOW_CTRL_V1.CTRL_ASS_GAMME"
        Oracle_CMD.Connection = Oracle_CNX
        ' declare paramters and value of stored procedure
        DM = New OracleParameter("DM", OracleDbType.Varchar2, ParameterDirection.Input)
        DM.Value = DMX
        OP = New OracleParameter("OP", OracleDbType.Int32, ParameterDirection.Input)
        OP.Value = OPERATION
        REF = New OracleParameter("Ref", OracleDbType.Varchar2, ParameterDirection.Input)
        REF.Value = REFERENCE
        LINE = New OracleParameter("Line", OracleDbType.Int32, ParameterDirection.Input)
        LINE.Value = ligne
        TYPE_PROC = New OracleParameter("Type_Proc", OracleDbType.Varchar2, ParameterDirection.Input)
        TYPE_PROC.Value = typeproc
        TYPE_CONTROL = New OracleParameter("Type_Ctrl", OracleDbType.Int32, ParameterDirection.Input)
        TYPE_CONTROL.Value = typectrl
        PARAM_CHAR = New OracleParameter("Param_CHAR", OracleDbType.Varchar2, ParameterDirection.InputOutput)
        PARAM_CHAR.Value = ""
        PARAM_NUMBER = New OracleParameter("Param_NUM", OracleDbType.Int32, ParameterDirection.InputOutput)
        PARAM_NUMBER.Value = 0
        NB_PASSAGE = New OracleParameter("Nb_Passage", OracleDbType.Int32, ParameterDirection.Output)
        NB_PASSAGE.Value = 0
        STAT_PART = New OracleParameter("Stat_Part", OracleDbType.Int32, ParameterDirection.Output)
        STAT_PART.Value = 0
        STATUS = New OracleParameter("Status", OracleDbType.Int32, ParameterDirection.InputOutput)
        STATUS.Value = stat

        'add parameters in stored procedure
        Oracle_CMD.Parameters.Add(DM)
        Oracle_CMD.Parameters.Add(OP)
        Oracle_CMD.Parameters.Add(REF)
        Oracle_CMD.Parameters.Add(LINE)
        Oracle_CMD.Parameters.Add(TYPE_PROC)
        Oracle_CMD.Parameters.Add(TYPE_CONTROL)
        Oracle_CMD.Parameters.Add(PARAM_CHAR)
        Oracle_CMD.Parameters.Add(PARAM_NUMBER)
        Oracle_CMD.Parameters.Add(NB_PASSAGE)
        Oracle_CMD.Parameters.Add(STAT_PART)
        Oracle_CMD.Parameters.Add(STATUS)

        'execute the stored procedure
        Try
            Oracle_CMD.ExecuteNonQuery()
        Catch ex As Exception

            If ShowMessaboxBox Then
                MessageBox.Show("DATABASE CONNEXION ERROR!!!" + vbCrLf + vbCrLf + "The application cycle will be stopped, Check database connexion...", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Return RETURN_STAT
        End Try

        'convert return value to an oracle decimal and convert it to integer
        Dim odec As OracleDecimal = STATUS.Value
        Return Convert.ToInt32(odec.Value)

    End Function


    Public Function PCK_VALIDATION_OP(ByVal DMX As String, ByVal OPERATION As Integer, ByVal REFERENCE As String, ByVal dateoperation As Date, ByVal defect As Integer, ByVal ligne As Integer, ByVal type_prod As String, ByVal station_immo As String, ByVal stat As Integer, Optional ByVal ShowMessaboxBox As Boolean = False) As Integer

        'Dim Stat As Integer 'value returned by database
        ' VALIDATION_OP (Buffer, Stat)
        'declare parameters
        Oracle_CMD = New OracleCommand()

        'declare the stored procedure
        Oracle_CMD.CommandType = CommandType.StoredProcedure
        Oracle_CMD.CommandText = "PCK_FLOW_CTRL_V1.VALIDATION_OP"
        Oracle_CMD.Connection = Oracle_CNX
        ' declare paramters and value of stored procedure
        DM = New OracleParameter("DM", OracleDbType.Varchar2, ParameterDirection.Input)
        DM.Value = DMX
        OP = New OracleParameter("OP", OracleDbType.Int32, ParameterDirection.Input)
        OP.Value = OPERATION
        REF = New OracleParameter("Ref", OracleDbType.Varchar2, ParameterDirection.Input)
        REF.Value = REFERENCE
        DATEOP = New OracleParameter("DateOP", OracleDbType.Date, ParameterDirection.Input)
        DATEOP.Value = dateoperation
        DEF = New OracleParameter("Def", OracleDbType.Int32, ParameterDirection.Input)
        DEF.Value = defect
        LINE = New OracleParameter("Line", OracleDbType.Int32, ParameterDirection.Input)
        LINE.Value = ligne
        PROD_TYPE = New OracleParameter("Type_Man", OracleDbType.Varchar2, ParameterDirection.Input)
        PROD_TYPE.Value = type_prod
        NUM_IMMO = New OracleParameter("Immo", OracleDbType.Varchar2, ParameterDirection.Input)
        NUM_IMMO.Value = station_immo
        MCH_STATION = New OracleParameter("Station", OracleDbType.Int32, ParameterDirection.Input)
        MCH_STATION.Value = 0
        MCH_FIXTURE = New OracleParameter("Fixture", OracleDbType.Int32, ParameterDirection.Input)
        MCH_FIXTURE.Value = 0
        PARAM_CHAR = New OracleParameter("Param_CHAR", OracleDbType.Varchar2, ParameterDirection.InputOutput)
        PARAM_CHAR.Value = ""
        PARAM_NUMBER = New OracleParameter("Param_NUM", OracleDbType.Int32, ParameterDirection.InputOutput)
        PARAM_NUMBER.Value = 0
        STATUS = New OracleParameter("Status", OracleDbType.Int32, ParameterDirection.InputOutput)
        STATUS.Value = stat

        'add parameters in stored procedure
        Oracle_CMD.Parameters.Add(DM)
        Oracle_CMD.Parameters.Add(OP)
        Oracle_CMD.Parameters.Add(REF)
        Oracle_CMD.Parameters.Add(DATEOP)
        Oracle_CMD.Parameters.Add(DEF)
        Oracle_CMD.Parameters.Add(LINE)
        Oracle_CMD.Parameters.Add(PROD_TYPE)
        Oracle_CMD.Parameters.Add(NUM_IMMO)
        Oracle_CMD.Parameters.Add(MCH_STATION)
        Oracle_CMD.Parameters.Add(MCH_FIXTURE)
        Oracle_CMD.Parameters.Add(PARAM_CHAR)
        Oracle_CMD.Parameters.Add(PARAM_NUMBER)
        Oracle_CMD.Parameters.Add(STATUS)

        'execute the stored procedure
        Try
            Oracle_CMD.ExecuteNonQuery()
        Catch ex As Exception

            If ShowMessaboxBox Then
                MessageBox.Show("DATABASE CONNEXION ERROR!!!" + vbCrLf + vbCrLf + "The application cycle will be stopped, Check database connexion...", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Return RETURN_STAT
        End Try


        'convert return value to an oracle decimal and convert it to integer
        Dim odec As OracleDecimal = STATUS.Value
        Return Convert.ToInt32(odec.Value)

    End Function
#End Region

    Public Function PCK_CTRL_GAMME_COMPOSANT_DM(ByVal DMX As String, ByVal OPERATION As Integer, ByVal REFERENCE As String, ByVal ligne As Integer, ByVal stat As Integer, Optional ByVal ShowMessaboxBox As Boolean = False) As Integer

        'Dim Stat As Integer 'value returned by database
        ' VALIDATION_OP (Buffer, Stat)
        'declare parameters

        'Add description for procedure
        Oracle_CMD = New OracleCommand()

        'declare the stored procedure
        Oracle_CMD.CommandType = CommandType.StoredProcedure
        Oracle_CMD.CommandText = "PCK_FLOW_CTRL_V1.CTRL_GAMME_COMPOSANT_DM"
        Oracle_CMD.Connection = Oracle_CNX
        ' declare paramters and value of stored procedure
        DM = New OracleParameter("DM", OracleDbType.Varchar2, ParameterDirection.Input)
        DM.Value = DMX
        OP = New OracleParameter("OP", OracleDbType.Int32, ParameterDirection.Input)
        OP.Value = OPERATION
        REF = New OracleParameter("Ref", OracleDbType.Varchar2, ParameterDirection.Input)
        REF.Value = REFERENCE
        LINE = New OracleParameter("Line", OracleDbType.Int32, ParameterDirection.Input)
        LINE.Value = ligne
        STATUS = New OracleParameter("Status", OracleDbType.Int32, ParameterDirection.InputOutput)
        STATUS.Value = stat

        'add parameters in stored procedure
        Oracle_CMD.Parameters.Add(DM)
        Oracle_CMD.Parameters.Add(OP)
        Oracle_CMD.Parameters.Add(REF)
        Oracle_CMD.Parameters.Add(LINE)
        Oracle_CMD.Parameters.Add(STATUS)

        'execute the stored procedure
        Try
            Oracle_CMD.ExecuteNonQuery()
        Catch ex As Exception

            If ShowMessaboxBox Then
                MessageBox.Show("DATABASE CONNEXION ERROR!!!" + vbCrLf + vbCrLf + "The application cycle will be stopped, Check database connexion...", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Return RETURN_STAT
        End Try


        'convert return value to an oracle decimal and convert it to integer
        Dim odec As OracleDecimal = STATUS.Value
        Return Convert.ToInt32(odec.Value)

    End Function

    Public Function PCK_LINK_COMPONENT(ByVal DMX As String, ByVal OPERATION As Integer, ByVal dateoperation As Date, ByVal DM_Component As String, ByVal Type_Comp As String, ByVal stat As Integer, Optional ByVal ShowMessaboxBox As Boolean = False) As Integer
        'Dim Stat As Integer 'value returned by database
        ' VALIDATION_OP (Buffer, Stat)
        'declare parameters
        Oracle_CMD = New OracleCommand()

        'declare the stored procedure
        Oracle_CMD.CommandType = CommandType.StoredProcedure
        Oracle_CMD.CommandText = "PCK_RECORD_DATA_V1.LINK_COMPONENT"
        Oracle_CMD.Connection = Oracle_CNX
        ' declare paramters and value of stored procedure
        DM = New OracleParameter("IDpart", OracleDbType.Varchar2, ParameterDirection.Input)
        DM.Value = DMX
        OP = New OracleParameter("OP", OracleDbType.Int32, ParameterDirection.Input)
        OP.Value = OPERATION
        DATEOP = New OracleParameter("DateTime", OracleDbType.Date, ParameterDirection.Input)
        DATEOP.Value = dateoperation
        IDcomponent = New OracleParameter("IDcomponent", OracleDbType.Varchar2, ParameterDirection.Input)
        IDcomponent.Value = DM_Component
        TypeComponent = New OracleParameter("TypeComponent", OracleDbType.Varchar2, ParameterDirection.Input)
        TypeComponent.Value = Type_Comp
        STATUS = New OracleParameter("Status", OracleDbType.Int32, ParameterDirection.InputOutput)
        STATUS.Value = stat

        'add parameters in stored procedure
        Oracle_CMD.Parameters.Add(DM)
        Oracle_CMD.Parameters.Add(OP)
        Oracle_CMD.Parameters.Add(DATEOP)
        Oracle_CMD.Parameters.Add(IDcomponent)
        Oracle_CMD.Parameters.Add(TypeComponent)
        Oracle_CMD.Parameters.Add(STATUS)

        'execute the stored procedure
        Try
            Oracle_CMD.ExecuteNonQuery()
        Catch ex As Exception

            If ShowMessaboxBox Then
                MessageBox.Show("DATABASE CONNEXION ERROR!!!" + vbCrLf + vbCrLf + "The application cycle will be stopped, Check database connexion...", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Return RETURN_STAT
        End Try

        'convert return value to an oracle decimal and convert it to integer
        Dim odec As OracleDecimal = STATUS.Value
        Return Convert.ToInt32(odec.Value)

    End Function

    Public Function PCK_SN_PUMP(ByVal Plant_Letter As String, ByRef SN_PP As String, ByVal stat As Integer, Optional ByVal ShowMessaboxBox As Boolean = False) As Integer
        'Dim Stat As Integer 'value returned by database
        ' VALIDATION_OP (Buffer, Stat)
        'declare parameters
        Oracle_CMD = New OracleCommand()

        'declare the stored procedure
        Oracle_CMD.CommandType = CommandType.StoredProcedure
        Oracle_CMD.CommandText = "PCK_PUMP.GENERE_SN_PUMP"
        Oracle_CMD.Connection = Oracle_CNX
        ' declare paramters and value of stored procedure
        PLANT = New OracleParameter("Plant", OracleDbType.Varchar2, ParameterDirection.Input)
        PLANT.Value = Plant_Letter
        SERIE_POMPA = New OracleParameter("VALRETOUR", OracleDbType.Varchar2, 256, Nothing, ParameterDirection.Output)
        SERIE_POMPA.Value = ""
        STATUS = New OracleParameter("Status", OracleDbType.Int32, ParameterDirection.InputOutput)
        STATUS.Value = stat

        'add parameters in stored procedure
        Oracle_CMD.Parameters.Add(PLANT)
        Oracle_CMD.Parameters.Add(SERIE_POMPA)
        Oracle_CMD.Parameters.Add(STATUS)

        'execute the stored procedure
        Try
            Oracle_CMD.ExecuteNonQuery()
        Catch ex As Exception

            If ShowMessaboxBox Then
                MessageBox.Show("DATABASE CONNEXION ERROR!!!" + vbCrLf + vbCrLf + "The application cycle will be stopped, Check database connexion...", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Return RETURN_STAT
        End Try

        If SERIE_POMPA.Value <> OracleString.Null Then
            SN_PP = SERIE_POMPA.Value.ToString()
        Else
            SN_PP = ""
        End If

        'convert return value to an oracle decimal and convert it to integer
        Dim odec As OracleDecimal = STATUS.Value
        Return Convert.ToInt32(odec.Value)




    End Function


    Public Function GET_PUMP_SN_WITH_COMP(ByVal DMX As String, ByVal Type_Comp As String, ByRef DM_Component As String, ByVal stat As Integer, Optional ByVal ShowMessaboxBox As Boolean = False) As Integer

        'Dim Stat As Integer 'value returned by database
        ' VALIDATION_OP (Buffer, Stat)
        'declare parameters
        Oracle_CMD = New OracleCommand()

        'declare the stored procedure
        Oracle_CMD.CommandType = CommandType.StoredProcedure
        Oracle_CMD.CommandText = "TR_RECH_DM_VIA_COMPOSANT"
        Oracle_CMD.Connection = Oracle_CNX

        ' declare paramters and value of stored procedure
        DM = New OracleParameter("DM", OracleDbType.Varchar2, ParameterDirection.Input)
        DM.Value = DMX
        TypeComponent = New OracleParameter("Type_Component", OracleDbType.Varchar2, ParameterDirection.Input)
        TypeComponent.Value = Type_Comp
        IDcomponent = New OracleParameter("DM_COMP", OracleDbType.Varchar2, 256, Nothing, ParameterDirection.Output)
        IDcomponent.Value = ""
        STATUS = New OracleParameter("Status", OracleDbType.Int32, ParameterDirection.InputOutput)
        STATUS.Value = stat

        'add parameters in stored procedure
        Oracle_CMD.Parameters.Add(DM)
        Oracle_CMD.Parameters.Add(TypeComponent)
        Oracle_CMD.Parameters.Add(IDcomponent)
        Oracle_CMD.Parameters.Add(STATUS)

        'execute the stored procedure
        Try
            Oracle_CMD.ExecuteNonQuery()
        Catch ex As Exception

            If ShowMessaboxBox Then
                MessageBox.Show("DATABASE CONNEXION ERROR!!!" + vbCrLf + vbCrLf + "The application cycle will be stopped, Check database connexion...", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Return RETURN_STAT
        End Try

        If IDcomponent.Value <> OracleString.Null Then
            DM_Component = IDcomponent.Value.ToString()
        Else
            DM_Component = ""
        End If

        'convert return value to an oracle decimal and convert it to integer
        Dim odec As OracleDecimal = STATUS.Value
        Return Convert.ToInt32(odec.Value)

    End Function

#Region "Error List"
    ''' <summary>
    ''' Return description of error number
    ''' </summary>
    ''' <param name="err">error number returned by database</param>
    ''' <param name="op">operation ongoing => C:ctrl suivi gamme  |  V:validation_op</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Oracle_Error(ByVal err As Integer, ByVal op As String) As String
        Dim Str_Err As String = ""
        If op.Contains("PFC") Then
            Select Case err
                Case 1
                    Str_Err = "Piesa OK - Incepe verificarea !"
                Case -1
                    Str_Err = "PFC NOK - Operatie incorecta!"
                Case -2
                    Str_Err = "Numarul operatiei este incorect!"
                Case -3
                    Str_Err = "Piesa blocata - Blacklist!"
                Case -4
                    Str_Err = "Operatie necunoscuta in Layout!"
                Case -5
                    Str_Err = "Parametru Type_Proc Nok!"
                Case -10
                    Str_Err = "EROARE BAZA DE DATE Oracle!"
                Case Else
                    Str_Err = "Eroare necunoscuta !"
            End Select

        ElseIf op.Contains("VALID") Then
            Select Case err
                Case 1
                    Str_Err = "OK"
                Case -7
                    Str_Err = "Layout nrgasit pentru FWL"
                Case -2
                    Str_Err = "Exceltie Oracle !"
                Case -10
                    Str_Err = "Oracle Problem !"
                Case Else
                    Str_Err = "Unknow error from database"
            End Select
        End If

        Return Str_Err
    End Function
#End Region

    Friend Function SP_LoadData(ByVal Buffer As String, ByRef MessOraRtn As String, Optional ByVal ShowMessaboxBox As Boolean = False) As Integer
        'declare parameters
        Oracle_CMD = New OracleCommand()

        'declare the stored procedure
        Oracle_CMD.CommandType = CommandType.StoredProcedure
        Oracle_CMD.CommandText = "CHARGE_USI_MESURE"
        Oracle_CMD.Connection = Oracle_CNX

        ' declare paramters and value of stored procedure
        BF = New OracleParameter("Buffer", OracleDbType.Varchar2, ParameterDirection.Input)
        BF.Value = Buffer
        Rtn = New OracleParameter("Stat_Retour", OracleDbType.Int32, ParameterDirection.InputOutput)
        Rtn.Value = 0
        MessOra = New OracleParameter("Mess_Oracle", OracleDbType.Varchar2, 256, Nothing, ParameterDirection.InputOutput)
        MessOra.Value = ""


        'add parameters in stored procedure
        Oracle_CMD.Parameters.Add(BF)
        Oracle_CMD.Parameters.Add(Rtn)
        Oracle_CMD.Parameters.Add(MessOra)

        'execute the stored procedure
        Try
            Oracle_CMD.ExecuteNonQuery()
        Catch ex As Exception

            If ShowMessaboxBox Then
                MessageBox.Show("DATABASE CONNEXION ERROR!!!" + vbCrLf + vbCrLf + "The application cycle will be stopped, Check database connexion...", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Return 0
        End Try


        If MessOra.Value <> OracleString.Null Then
            MessOraRtn = MessOra.Value.ToString()
        Else
            MessOraRtn = ""
        End If

        'convert return value to an oracle decimal and convert it to integer
        Dim odec As OracleDecimal = Rtn.Value
        'Return Convert.ToInt32(odec.Value)
        Return Convert.ToInt16(odec.Value)

    End Function



    Friend Function MESDouble(ByVal dVal As Double, ByVal bModeOracle As Boolean) As String
        Dim sValDbl As String
        Dim sValInt As String


        If bModeOracle Then
            ' Separateur Décimal = AppParam.Ora_Symbol_Decimal
            'sValDbl = Left(dVal.ToString("000000.000;-00000.000").Replace(".", ","), 10)
            sValDbl = Left(dVal.ToString("000000.000;-00000.000"), 10)
            'sValDbl.Replace(".", AppParam.Ora_Symbol_Decimal)
            'sValDbl.Replace(",", AppParam.Ora_Symbol_Decimal)

        Else
            ' Separateur Décimal = .
            sValDbl = Left(dVal.ToString("000000.000;-00000.000").Replace(",", "."), 10)
        End If

        sValInt = Left(dVal.ToString("0000000000;-000000000"), 10)

        If (Right(sValDbl, 4) = ".000") Or (Right(sValDbl, 4) = ",000") Then
            Return sValInt
        Else
            Return sValDbl
        End If

    End Function

#Region "Stored Procedure - Correspondence"
    Public Function Get_Corespondence(ByRef char_1 As String, ByRef char_2 As String, ByRef int_1 As Integer, ByRef int_2 As Integer,
                                      ByRef input_ As String, ByVal param_ As String, ByVal family_ As String, ByVal stat As Integer, Optional ByVal ShowMessaboxBox As Boolean = False) As Integer


        Oracle_CMD = New OracleCommand()

        'declare the stored procedure
        Oracle_CMD.CommandType = CommandType.StoredProcedure
        Oracle_CMD.CommandText = "TR_GET_CORRESPONDENCE"
        Oracle_CMD.Connection = Oracle_CNX
        ' declare paramters and value of stored procedure
        Dim chr_1 = New OracleParameter("char1", OracleDbType.Varchar2, ParameterDirection.InputOutput)
        chr_1.Value = char_1

        Dim chr_2 = New OracleParameter("char2", OracleDbType.Varchar2, ParameterDirection.InputOutput)
        chr_2.Value = char_2

        Dim in_1 = New OracleParameter("int1", OracleDbType.Int32, ParameterDirection.InputOutput)
        in_1.Value = int_1

        Dim in_2 = New OracleParameter("int2", OracleDbType.Int32, ParameterDirection.InputOutput)
        in_2.Value = int_2

        Dim Input = New OracleParameter("input", OracleDbType.Varchar2, ParameterDirection.InputOutput)
        Input.Value = input_

        Dim Param = New OracleParameter("Immo", OracleDbType.Varchar2, ParameterDirection.InputOutput)
        Param.Value = param_

        Dim family = New OracleParameter("Station", OracleDbType.Varchar2, ParameterDirection.InputOutput)
        family.Value = family_

        STATUS = New OracleParameter("Status", OracleDbType.Int32, ParameterDirection.InputOutput)
        STATUS.Value = stat

        'add parameters in stored procedure
        Oracle_CMD.Parameters.Add(chr_1)
        Oracle_CMD.Parameters.Add(chr_2)
        Oracle_CMD.Parameters.Add(in_1)
        Oracle_CMD.Parameters.Add(in_2)
        Oracle_CMD.Parameters.Add(Input)
        Oracle_CMD.Parameters.Add(Param)
        Oracle_CMD.Parameters.Add(family)
        Oracle_CMD.Parameters.Add(STATUS)

        'execute the stored procedure
        Try
            Oracle_CMD.ExecuteNonQuery()
        Catch ex As Exception

            If ShowMessaboxBox Then
                MessageBox.Show("DATABASE CONNEXION ERROR!!!" + vbCrLf + vbCrLf + "The application cycle will be stopped, Check database connexion...", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Return RETURN_STAT
        End Try

        If in_2.Value <> OracleDecimal.Null Then
            int_2 = Convert.ToInt32(in_2.Value.value)
        Else
            in_2.Value = 0
        End If

        ' rts_dest()
        'convert return value to an oracle decimal and convert it to integer
        Dim odec As OracleDecimal = STATUS.Value
        Return Convert.ToInt32(odec.Value)

    End Function
#End Region

    '#Region "Stored Procedure - GET defect list"
    '
    '    Public Function Get_Defect_List(ByVal Refe As String, ByVal Ope As Integer, ByVal TypeDef As String, ByRef data As DataTable, Optional ByVal ShowMessaboxBox As Boolean = False) As Integer
    '
    '        Oracle_CMD = New OracleCommand()
    '        Try
    '            Oracle_CMD.CommandType = CommandType.StoredProcedure
    '            Oracle_CMD.CommandText = "GET_DEFECT_LIST"
    '            Oracle_CMD.Connection = Oracle_CNX
    '            ' declare paramters and value of stored procedure
    '            REF = New OracleParameter("Refe", OracleDbType.Varchar2, ParameterDirection.Input)
    '            REF.Value = Refe
    '            OP = New OracleParameter("Op", OracleDbType.Int32, ParameterDirection.Input)
    '            OP.Value = Ope
    '            TypeD = New OracleParameter("TypeDef", OracleDbType.Varchar2, ParameterDirection.Input)
    '            TypeD.Value = TypeDef
    '            DefL = New OracleParameter("Defect_List", OracleDbType.RefCursor, ParameterDirection.Output)
    '            'DefL.Value = 0
    '            Rtn = New OracleParameter("Stat_Retour", OracleDbType.Int32, ParameterDirection.InputOutput)
    '            Rtn.Value = 0
    '            'add parameters in stored procedure
    '            Oracle_CMD.Parameters.Add(REF)
    '            Oracle_CMD.Parameters.Add(OP)
    '            Oracle_CMD.Parameters.Add(TypeD)
    '            Oracle_CMD.Parameters.Add(DefL)
    '            Oracle_CMD.Parameters.Add(Rtn)
    '
    '            'execute the stored procedure
    '            If Not Oracle_CNX.State = ConnectionState.Open Then Oracle_CNX.Open()
    '            Oracle_CMD.ExecuteNonQuery()
    '
    '            'RETURN_STAT = Rtn.Value
    '
    '            If Rtn.Value = 1 Then
    '
    '                Dim oRef As OracleRefCursor = Oracle_CMD.Parameters("Defect_List").Value
    '                Data.Load(oRef.GetDataReader)
    '
    '                If Data.Rows.Count = 0 Then
    '                    Rtn.Value = -1
    '                    'data = Nothing
    '                End If
    '            End If
    '
    '            Return Convert.ToInt16(Rtn.Value.ToString)
    '
    '        Catch ex As Exception
    '
    '            If ShowMessaboxBox Then
    '                MessageBox.Show("DATABASE CONNEXION ERROR!!!" + vbCrLf + vbCrLf + "The application cycle will be stopped, Check database connexion...", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            End If
    '
    '            Return RETURN_STAT
    '
    '        Finally
    '            Oracle_CNX.Close()
    '
    '        End Try
    '
    '
    '    End Function
    '#End Region

#Region "Stored Procedure - Validation Process"

    Public Function SP_Process_Validation(ByVal Buffer As String) As Integer
        'Dim Stat As Integer 'value returned by database
        ' VALIDATION_OP (Buffer, Stat)
        'declare parameters
        Oracle_CMD = New OracleCommand()

        'declare the stored procedure
        Oracle_CMD.CommandType = CommandType.StoredProcedure
        Oracle_CMD.CommandText = "VALIDATION_OP"
        Oracle_CMD.Connection = Oracle_CNX

        ' declare paramters and value of stored procedure
        BF = New OracleParameter("DM", OracleDbType.Varchar2, ParameterDirection.Input)
        BF.Value = Buffer
        Rtn = New OracleParameter("Stat_Retour", OracleDbType.Int32, ParameterDirection.InputOutput)
        Rtn.Value = 0

        'add parameters in stored procedure
        Oracle_CMD.Parameters.Add(BF)
        Oracle_CMD.Parameters.Add(Rtn)

        'execute the stored procedure
        Oracle_CMD.ExecuteNonQuery()

        'convert return value to an oracle decimal and convert it to integer
        Dim odec As OracleDecimal = Rtn.Value
        Return Convert.ToInt32(odec.Value)

    End Function
#End Region

#Region "Stored Procedure - RECH_REF"

    Public Function SP_Rech_Ref(ByVal DM_nb As String, ByRef REF_nb As String)
        'declare parameters
        'Dim SP_result As Integer = 99 'value returned by database
        Oracle_CMD = New OracleCommand()

        'declare the stored procedure
        Oracle_CMD.CommandType = CommandType.StoredProcedure
        Oracle_CMD.CommandText = "RECH_REF_DM"
        Oracle_CMD.Connection = Oracle_CNX

        ' declare paramters and value of stored procedure
        DM = New OracleParameter("DM", OracleDbType.Varchar2, ParameterDirection.Input)
        DM.Value = DM_nb
        REF = New OracleParameter("Ref", OracleDbType.Varchar2, 256, Nothing, ParameterDirection.Output)
        REF.Value = ""
        Rtn = New OracleParameter("Stat_Retour", OracleDbType.Int16, ParameterDirection.InputOutput)
        Rtn.Value = 0

        'add parameters in stored procedure
        Oracle_CMD.Parameters.Add(DM)
        Oracle_CMD.Parameters.Add(REF)
        Oracle_CMD.Parameters.Add(Rtn)

        'execute the stored procedure
        Oracle_CMD.ExecuteNonQuery()

        If REF.Value <> OracleString.Null Then
            REF_nb = REF.Value.ToString()
        Else
            REF_nb = ""
        End If

        'convert return value to an oracle decimal and convert it to integer
        Dim odec As OracleDecimal = Rtn.Value
        Return Int16.Parse(odec.Value)
    End Function
#End Region
#Region "SQL Query"
    ''' <summary>
    ''' Function to send a SQL query to Oracle Database
    ''' </summary>
    ''' <param name="sql">SQL query</param>
    ''' <remarks>this function returns an Oracle datareader</remarks>
    Friend Function SQLquery(ByVal sql As String, ByRef DS As DataSet) As Boolean
        Try
            'Using 
            Dim Oracle_adapter = New OracleDataAdapter(sql, Oracle_CNX)
            Dim dt As New DataSet("data")
            Oracle_adapter.Fill(dt, "data")

            If dt.Tables.Count > 0 Then
                If dt.Tables(0).Rows.Count <> 0 Then
                    DS = dt
                    Return True
                Else
                    Return (False)
                End If
            End If
            Return True

        Catch
            Return False
        End Try
    End Function
#End Region

#Region "Stored Procedure - FLOW CONTROL"
    ''' <summary>
    ''' Flow Control Procedure
    ''' </summary>
    ''' <param name="DM_nb">Damatrix number</param>
    ''' <param name="OP_nb">operation number</param>
    ''' <param name="REF_nb">reference of pump</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_Flow_Control(ByVal DM_nb As String, ByVal OP_nb As Integer, ByVal REF_nb As String)
        'declare parameters
        'Dim SP_result As Integer = 99 'value returned by database
        Oracle_CMD = New OracleCommand()

        'declare the stored procedure
        Oracle_CMD.CommandType = CommandType.StoredProcedure
        Oracle_CMD.CommandText = "CTRL_SUIVI_GAMME"
        Oracle_CMD.Connection = Oracle_CNX

        ' declare paramters and value of stored procedure
        DM = New OracleParameter("DM", OracleDbType.Varchar2, ParameterDirection.Input)
        DM.Value = DM_nb
        OP = New OracleParameter("OP", OracleDbType.Int16, ParameterDirection.Input)
        OP.Value = OP_nb
        REF = New OracleParameter("Ref", OracleDbType.Varchar2, ParameterDirection.Input)
        REF.Value = REF_nb
        Rtn = New OracleParameter("Stat_Retour", OracleDbType.Int16, ParameterDirection.InputOutput)
        Rtn.Value = 0

        'add parameters in stored procedure
        Oracle_CMD.Parameters.Add(DM)
        Oracle_CMD.Parameters.Add(OP)
        Oracle_CMD.Parameters.Add(REF)
        Oracle_CMD.Parameters.Add(Rtn)

        'execute the stored procedure
        Oracle_CMD.ExecuteNonQuery()



        'convert return value to an oracle decimal and convert it to integer
        Dim odec As OracleDecimal = Rtn.Value
        Return Int16.Parse(odec.Value)
    End Function
#End Region

#Region "MES"

    Public Function createfile() As String 'TExt file for TRI DM table MES
        Dim sRet As String = "ok"
        Dim blockOp As Integer = 2260

        Dim Data(0 To 5) As String
        Data(0) = Main.ComboBox1.Text
        Data(1) = Main.TextBox6.Text
        Data(2) = Main.ok_nok.ToString  'OK:1/NOK:2
        Data(3) = Main.Setari(0).ToString 'rework station number
        Data(4) = Main.TextBox2.Text 'error code
        Data(5) = "5" 'Line number

        Dim fileName As String = Data(1) + "_" + Now.ToString("yyyyMMdd") + "_" + Now.ToString("HHmmss") + ".OP" + Data(3).PadLeft(4, "0")
        Dim monStreamWriter As StreamWriter = Nothing
        Dim fs As FileStream = Nothing

        If Not System.IO.Directory.Exists("C:\MES\") Then
            System.IO.Directory.CreateDirectory("C:\MES\")
        End If

        Try
            'Open File in Exclusive Access (FileShare.None) Toute demande d'ouverture du fichier (par ce processus ou un autre) échouera jusqu'à la fermeture du fichier
            fs = New FileStream("C:\MES\" & fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None)

            'Instanciation du StreamWriter avec passage du nom du fichier 
            monStreamWriter = New StreamWriter(fs)

            'Ecriture du texte dans votre fichier
            monStreamWriter.WriteLine(RTS.Buffer1)
            monStreamWriter.WriteLine(RTS.Buffer41)
            monStreamWriter.WriteLine(RTS.Buffer42)
            monStreamWriter.WriteLine(RTS.Buffer43)
            monStreamWriter.WriteLine(RTS.Buffer44)
            monStreamWriter.WriteLine(RTS.Buffer45)
            monStreamWriter.WriteLine(RTS.Buffer46)
            monStreamWriter.WriteLine(RTS.Buffer47)
            monStreamWriter.WriteLine(RTS.Buffer48)
            monStreamWriter.WriteLine(RTS.Buffer49)
            monStreamWriter.WriteLine(RTS.Buffer410)
            monStreamWriter.WriteLine(RTS.Buffer411)
            monStreamWriter.WriteLine(RTS.Buffer412)
            monStreamWriter.WriteLine(RTS.Buffer61)
            monStreamWriter.WriteLine(RTS.Buffer62)

        Catch ex As Exception
            'Code exécuté en cas d'exception
            sRet = ex.Message
        Finally

            'Fermeture du StreamWriter (Trés important)
            If Not monStreamWriter Is Nothing Then

                Try
                    monStreamWriter.Close()
                Catch exp As Exception
                End Try

            End If

            monStreamWriter = Nothing
            fs = Nothing

        End Try
        Return sRet
    End Function

#End Region


End Class
