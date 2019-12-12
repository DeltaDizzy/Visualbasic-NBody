Imports System.Numerics
Public Class Form1
    Public bodies As List(Of Body) = New List(Of Body)
    Dim b1, b2 As Body
    Dim r As Random = New Random()
    Dim zoom As Single = 1
    Dim comOffset As Vector2
    Dim com As Vector2
    Dim coms As List(Of Vector2)
    Dim center As New Vector2(Me.Width / 2, Me.Height / 2)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        b1 = New Body(New Vector2(300, 300), New Vector2(-4, 3), 200, 70, RndColor(r.Next), 1)
        b2 = New Body(New Vector2(600, 450), New Vector2(4, -1), 200, 70, RndColor(r.Next), 2)
        bodies.Add(b1)
        bodies.Add(b2)
        tbScroll.Minimum = 1
    End Sub
    Function RndColor(seed As Integer)
        Dim red As Integer = r.Next(0, Byte.MaxValue + 1)
        Dim green As Integer = r.Next(0, Byte.MaxValue + 1)
        Dim blue As Integer = r.Next(0, Byte.MaxValue + 1)
        Dim brush As Brush = New SolidBrush(Color.FromArgb(red, green, blue))
        Return brush
    End Function

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
        e.Graphics.ScaleTransform(zoom, zoom)
        e.Graphics.TranslateTransform(comOffset.X, comOffset.Y)
        For Each b As Body In bodies
            e.Graphics.FillEllipse(b.color, b.pos.X, b.pos.Y, b.size, b.size)
            b.update(1)
            e.Graphics.FillEllipse(Brushes.Aquamarine, b.realPos.X, b.realPos.Y, 7, 7)
        Next
    End Sub

    Function GetCOM(bodies As List(Of Body)) As Vector2
        com = Vector2.Zero
        For Each b As Body In bodies
            coms.Add(b.realPos)
        Next
        Dim xmean As Single
        Dim ymean As Single
        For Each v As Vector2 In coms
            xmean += v.X
            ymean += v.Y
        Next
        xmean /= 2
        ymean /= 2
        com = New Vector2(xmean, ymean)
        Return com
    End Function

    Function GetCOMOffset(com As Vector2) As Vector2
        Dim newcom As Vector2 = New Vector2(com.X - center.X, com.Y - center.Y)
        Return newcom
    End Function
    Function GetMidpoint(v1 As Vector2, v2 As Vector2)
        Return New Vector2((v1.X + v2.X) / 2, (v1.Y + v2.Y) / 2)
    End Function

    Private Sub AddBody()
        Dim pos As Point = Cursor.Position
        Dim bnew As Body = New Body(New Vector2(pos.X, pos.Y), New Vector2(r.Next(-5, 5), r.Next(-5, 5)), r.Next(1, 2000), RndColor(r.Next(Integer.MaxValue)), bodies.Count + 1)
        bodies.Add(bnew)
    End Sub

    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        AddBody()
    End Sub

    Private Sub TbScroll_Scroll(sender As Object, e As EventArgs) Handles tbScroll.Scroll
        zoom = tbScroll.Value / 100 ', Single.MinValue, Single.MaxValue)
        Me.Invalidate()
    End Sub

    Private Sub TmrIntegrator_Tick(sender As Object, e As EventArgs) Handles tmrIntegrator.Tick
        lblCOords.Text = Cursor.Position.ToString
        lblzoom.Text = zoom.ToString
        For Each b As Body In bodies
            b.distanceList.Clear()
            For Each c As Body In bodies
                b.distanceList.Add(b.GetDistance(c), c)
            Next
        Next
        Me.Invalidate()
    End Sub

    Function Clamp(value As Single, floor As Single, ceiling As Single) As Single
        If value < floor Then
            value = floor
        ElseIf value > ceiling Then
            value = ceiling
        End If
        Return value
    End Function

    Sub Merge(b1 As Body, b2 As Body)
        Dim b As Body = New Body(b1.pos, b1.vel + b2.vel, b1.mass + b2.mass, Brushes.Black, bodies.Count + 1)
        bodies.Remove(b1)
        bodies.Remove(b2)
        bodies.Add(b)
    End Sub
End Class

' TODO have up to date list of every body's distances to every other body