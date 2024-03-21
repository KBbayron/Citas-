Public Class Menu
    Private Sub AgendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgendaToolStripMenuItem.Click
        Dim a As New Form1
        a.Show()
    End Sub

    Private Sub CitasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CitasToolStripMenuItem.Click
        Dim c As New Citas
        c.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub
End Class