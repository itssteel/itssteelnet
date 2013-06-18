Imports System.Data.SqlClient
Imports System.Data

﻿Public Class Training
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
Dim ds As New DataSet
        ds = DisplayMentorList()
        gvMentorList.DataSource = ds
        gvMentorList.DataBind()
    End Sub
    
    Function DisplayMentorList() As DataSet
        Dim sql As String = "select distinct Top 30 [SenderEmail] Mentors from [TTSLSMS].[dbo].[V_SMS]"
        ' select [SenderEmail] from [TTSLSMS].[dbo].[V_SMS] where Row_number between 1 and 30
        Dim dt As New DataTable
        'Using smsconn As New SqlConnection(ConfigurationManager.ConnectionStrings("CNS_SMSTEST").ConnectionString.ToString.Trim)
        '    smsconn.Open()
        '    Using sql_adap As New SqlDataAdapter(sql, smsconn)
        '        sql_adap.Fill(dt)

        '    End Using
        '    smsconn.Close()
        'End Using
        Dim smsconn As New SqlConnection(ConfigurationManager.ConnectionStrings("CNS_SMSTEST").ConnectionString.ToString.Trim)
        If smsconn.State = ConnectionState.Closed Then
            smsconn.Open()
        End If
        Dim sql_CMD As SqlCommand = New SqlCommand(sql, smsconn)
        Dim sql_adap As SqlDataAdapter
        Dim ds As New DataSet
        Try
            sql_adap = New SqlDataAdapter(sql_CMD)
            sql_adap.Fill(ds)
        Catch ex As Exception
            Throw
        Finally
            sql_CMD.Dispose()
            sql_adap.Dispose()
            smsconn.Close()

        End Try
        Return ds
    End Function

End Class

