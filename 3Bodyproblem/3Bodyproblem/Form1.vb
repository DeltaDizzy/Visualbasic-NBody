Public Class Form1
    Dim graph As Graphics = Me.CreateGraphics()
    Dim pen As New System.Drawing.Pen(Brushes.Black)
    Dim bodies As List(Of Body) = New List(Of Body)
    Dim b1, b2, b3 As Body
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        b1 = New Body(100, 100, 0, 0, 12, Color.Blue)
        b2 = New Body(200, 150, 0, 0, 14, Color.Brown)
        b3 = New Body(300, 90, 0, 0, 13, Color.Yellow)
        bodies.Add(b1)
        bodies.Add(b2)
        bodies.Add(b3)
    End Sub

    Private Sub draw(b As Body)
        graph.FillEllipse(Brushes.Black, CSng(b.px), CSng(b.py), 7, 7)
    End Sub
    Private Sub TmrIntegrator_Tick(sender As Object, e As EventArgs) Handles tmrIntegrator.Tick
        lblCOords.Text = Cursor.Position.ToString
        If bodies.Count > 0 Then
            For Each b As Body In bodies
                draw(b)
            b.update()
            b.Loocation = New Point(b.px, b.py)
            Next
        End If
    End Sub

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles MyBase.Click
    End Sub
End Class
