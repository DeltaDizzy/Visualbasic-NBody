Imports System.Numerics
Public Class Form1
    Public bodies As List(Of Body) = New List(Of Body)
    Dim b1, b2, sun As Body
    Dim currentBody As Body
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        b1 = New Body(New Vector2(300, 300), New Vector2(-4, 3), 200, 70, Brushes.Black, 1)
        b2 = New Body(New Vector2(600, 450), New Vector2(4, -3), 200, 70, Brushes.Brown, 2)
        'sun = New Body(New Vector2(300, 90), New Vector2(0, 0), 130, Brushes.Yellow, 3)
        bodies.Add(b1)
        bodies.Add(b2)
        'bodies.Add(sun)
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            tmrIntegrator.Enabled = Not tmrIntegrator.Enabled
        End If
        If e.KeyCode = Keys.Oemcomma Then
            Try
                tmrIntegrator.Interval *= 10
            Catch ex As Exception
                tmrIntegrator.Interval = 10000
            End Try
        End If
        If e.KeyCode = Keys.OemPeriod Then
            Try
                tmrIntegrator.Interval /= 10
            Catch ex As Exception
                tmrIntegrator.Interval = 1
            End Try
        End If
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

        For Each b As Body In bodies
            e.Graphics.FillEllipse(b.color, b.pos.X, b.pos.Y, b.size, b.size)
            b.update(1)
        Next

    End Sub

    Private Sub TmrIntegrator_Tick(sender As Object, e As EventArgs) Handles tmrIntegrator.Tick
        lblCOords.Text = Cursor.Position.ToString
        Me.Invalidate()
    End Sub

    Sub Merge(b1 As Body, b2 As Body)
        Dim b As Body = New Body(b1.pos, b1.vel + b2.vel, b1.mass + b2.mass, Brushes.Black, bodies.Count + 1)
        bodies.Remove(b1)
        bodies.Remove(b2)
        bodies.Add(b)
    End Sub
End Class

' TODO if body and target collide, they Merge()