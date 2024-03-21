Imports System.Data.SqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conexion = New SqlConnection("Initial Catalog=BasedeDatos;Data Source=BAYRON\MSSQLSERVER01;Integrated Security=SSPI;")
        Try
            conexion.Open()
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        conexion.Close()
    End Sub
    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim conexion = New SqlConnection("Initial Catalog=BasedeDatos;Data Source=BAYRON\MSSQLSERVER01;Integrated Security=SSPI;")
        Try
            conexion.Open()
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conexion.Close()
        End Try
        Dim instruccionSql As String = "INSERT INTO agenda (codagenda, nomagenda, diragenda, edadagenda)
            VALUES('" & Txtcod.Text & "','" & txtnom.Text & "','" & txtdir.Text & "','" & comboedad.Text & "')"
        Dim comando As SqlCommand = New SqlCommand(instruccionSql, conexion)
        comando.ExecuteNonQuery()
        MessageBox.Show("Los datos fueron guardados", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Txtcod.Text = ""
        txtnom.Text = ""
        txtdir.Text = ""
        comboedad.Text = ""
        conexion.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim conexion = New SqlConnection("Initial Catalog=BasedeDatos;Data Source=BAYRON\MSSQLSERVER01;Integrated Security=SSPI;")
        Try
            conexion.Open()
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conexion.Close()
        End Try
        Dim instruccionSql As String = "UPDATE agenda SET codagenda= '" & Txtcod.Text & "', nomagenda= '" & txtnom.Text & "', diragenda= '" & txtdir.Text & "', edadagenda= '" & comboedad.Text & "' WHERE codagenda='" & Txtcod.Text & "'"
        Dim comando As SqlCommand = New SqlCommand(instruccionSql, conexion)
        comando.ExecuteNonQuery()
        MessageBox.Show("Los datos fueron modificados", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Txtcod.Text = ""
        txtnom.Text = ""
        txtdir.Text = ""
        comboedad.Text = ""
        conexion.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conexion = New SqlConnection("Initial Catalog=BasedeDatos;Data Source=BAYRON\MSSQLSERVER01;Integrated Security=SSPI;")
        Try
            conexion.Open()
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conexion.Close()
        End Try
        Dim instruccionSql As String = "DELETE FROM agenda WHERE codagenda='" & Txtcod.Text & "'"
        Dim comando As SqlCommand = New SqlCommand(instruccionSql, conexion)
        comando.ExecuteNonQuery()
        MessageBox.Show("Los datos fueron eliminados", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Txtcod.Text = ""
        txtnom.Text = ""
        txtdir.Text = ""
        comboedad.Text = ""
        conexion.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
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
        DataGridView1.DataSource = set_de_datos.Tables("agenda")
        conexion.Close()
        If DataGridView1.Rows.Count > 1 Then
            Txtcod.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
            txtnom.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value
            txtdir.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value
            comboedad.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(3).Value
            MessageBox.Show("Los datos SÍ fueron encontrados", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Los datos NO fueron encontrados", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txtcod.Text = ""
            txtnom.Text = ""
            txtdir.Text = ""
            comboedad.Text = ""
        End If
    End Sub
End Class
