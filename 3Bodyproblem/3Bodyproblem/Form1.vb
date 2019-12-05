Imports System.Numerics
Public Class Form1
    Dim pen As New System.Drawing.Pen(Brushes.Black)
    Dim bodies As List(Of Body) = New List(Of Body)
    Dim b1, b2, b3 As Body
    Dim currentBody As Body
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        b1 = New Body(New Vector2(100, 100), New Vector2(0, 0), 120, Color.Blue, 1)
        b2 = New Body(New Vector2(700, 350), New Vector2(0, 0), 104, Color.Brown, 2)
        b3 = New Body(New Vector2(300, 90), New Vector2(0, 1), 130, Color.Yellow, 3)
        bodies.Add(b1)
        bodies.Add(b2)
        b1.target = b2
        b2.target = b1
        'bodies.Add(b3)
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

        For Each b As Body In bodies
            e.Graphics.FillEllipse(Brushes.Aqua, CSng(b.pos.X), CSng(b.pos.Y), 70, 70)
            b.update(1)
        Next

    End Sub

    Private Sub TmrIntegrator_Tick(sender As Object, e As EventArgs) Handles tmrIntegrator.Tick
        lblCOords.Text = Cursor.Position.ToString
        Me.Invalidate()
    End Sub
End Class
