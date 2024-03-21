Imports System.Data.SqlClient
Public Class Citas
    Private Sub Citas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conexion = New SqlConnection("Initial Catalog=BasedeDatos;Data Source=BAYRON\MSSQLSERVER01;Integrated Security=SSPI;")
        Try
            conexion.Open()
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        conexion.Close()
    End Sub

    Private Sub bus_Click(sender As Object, e As EventArgs) Handles bus.Click
        Dim conexion = New SqlConnection("Initial Catalog=BasedeDatos;Data Source=BAYRON\MSSQLSERVER01;Integrated Security=SSPI;")
        Try
            conexion.Open()
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conexion.Close()
        End Try
        Dim instruccionSql As String = "SELECT * FROM agenda WHERE codagenda='" & Txtcod.Text & "'"
        Dim comando As SqlCommand = New SqlCommand(instruccionSql, conexion)
        DataGridView1.DataSource = ""
        Dim adaptador As SqlClient.SqlDataAdapter
        adaptador = New SqlClient.SqlDataAdapter(instruccionSql, conexion)
        Dim set_de_datos As New DataSet()
        adaptador.Fill(set_de_datos, "agenda")
        DataGridView2.DataSource = set_de_datos.Tables("agenda")
        conexion.Close()
        If DataGridView2.Rows.Count > 1 Then
            Txtcod.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
            MessageBox.Show("Los datos SÍ fueron encontrados", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Los datos NO fueron encontrados", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txtcod.Text = ""
        End If
    End Sub

    Private Sub clear_Click(sender As Object, e As EventArgs) Handles clear.Click
        Txtcod.Text = ""
        txtnomcli.Text = ""
        hora.Text = ""
        precio.Text = ""
        cantidad.Text = ""
        DataGridView1.DataSource = ""
        Txtcod.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
    Private Sub precio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles precio.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not precio.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cantidad.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not precio.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub up_Click(sender As Object, e As EventArgs) Handles up.Click
        Dim conexion = New SqlConnection("Initial Catalog=BasedeDatos;Data Source=BAYRON\MSSQLSERVER01;Integrated Security=SSPI;")
        Try
            conexion.Open()
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conexion.Close()
        End Try
        Dim instruccionSQL As String = "SELEC codacita as CITA, codagenda as CLIENTE, fechacita as FECHA, horacita as HORA, 
            preciocita as PRECIO, cantidadcita as CANTIDAD FROM public.citas WHERE codagenda= '" & Txtcod.Text & "'"
        Dim comando As New SqlDataAdapter(instruccionSQL, conexion)
        DataGridView1.DataSource = ""
        Dim set_de_datos As New DataSet()
        comando.Fill(set_de_datos, "public.Citas")
        DataGridView1.DataSource = set_de_datos.Tables("public.Citas")
    End Sub
End Class