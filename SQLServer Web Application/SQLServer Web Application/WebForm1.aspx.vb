Imports System.Data.SqlClient

Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim smsconn As New SqlConnection(ConfigurationManager.ConnectionStrings("CNS_SMSTEST").ConnectionString.ToString.Trim)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        insertIntoSMS("Pranab mukherjee", "153259", 83.4)
    End Sub


    Sub insertIntoSMS(ByVal username As String, ByVal personalno As String, ByVal binlevel As Double)
        Dim sql As String
        Dim sysdate As String
        sysdate = System.DateTime.Today
        sql = "Insert into v_sms(Source,SenderEmail,Send_Dt,Priority,Subject, Body, Status, Error, RecType, code) Values ('CSI','" + username + "','" + sysdate + "',"
        sql = sql & "'N','Low Bin Level', 'Alert! IBF Bin Level " + binlevel.ToString + "', 'N', 'NULL', 'E','" + personalno + "')"
        Dim sql_CMD As New SqlCommand(sql, smsconn)
        If smsconn.State = ConnectionState.Closed Then
            smsconn.Open()
        End If
        Dim IEFFACT As Int32 = sql_CMD.ExecuteNonQuery

        If smsconn.State = ConnectionState.Open Then
            smsconn.Close()
        End If
    End Sub

End Class