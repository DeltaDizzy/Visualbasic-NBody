Imports System.Numerics
Public Class Form1
    Public bodies As List(Of Body) = New List(Of Body)
    Dim b1, b2, sun As Body
    Dim currentBody As Body
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        b1 = New Body(New Vector2(100, 100), New Vector2(0, 0), 104, 20, Brushes.Blue, 1)
        b2 = New Body(New Vector2(300, 90), New Vector2(0, 0), 104, 20, Brushes.Brown, 2)
        sun = New Body(New Vector2(700, 350), New Vector2(0, 0), 130000000000, Brushes.Yellow, 3)
        bodies.Add(b1)
        bodies.Add(b2)
        bodies.Add(sun)
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            tmrIntegrator.Enabled = Not tmrIntegrator.Enabled
        End If
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

        For Each b As Body In bodies
            e.Graphics.FillEllipse(b.color, b.pos.X, b.pos.Y, b.size, b.size)
            b.update(0.001)
        Next
    End Sub

    Private Sub TmrIntegrator_Tick(sender As Object, e As EventArgs) Handles tmrIntegrator.Tick
        lblCOords.Text = Cursor.Position.ToString
        Me.Invalidate()
    End Sub
End Class