Imports System.Drawing.Drawing2D
Imports System.Numerics
Imports System.Windows

Public Class Form1
    Public bodies As List(Of Body) = New List(Of Body)
    Dim r As Random = New Random()
    Dim comOffset As Vector2
    Dim coms As List(Of Vector2) = New List(Of Vector2)
    Dim origin As New Vector2(0, 0)
    Dim initMousePos As Vector2
    Dim mousePos As Vector2
    Dim mouseDown As Boolean = False
    Dim forcev As Vector2
    
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
        'e.Graphics.ScaleTransform(zoom, zoom)
        Console.WriteLine($"{comOffset.X} {comOffset.Y}")
        If mouseDown Then
            e.Graphics.DrawLine(Pens.Red, New PointF(initMousePos.X, initMousePos.Y), New PointF(mousePos.X, mousePos.Y))
        End If
        If Vector2.Distance(comOffset, origin) > 20 Then
            'e.Graphics.TranslateTransform(comOffset.X, comOffset.Y)
        End If
        For Each b As Body In bodies
            e.Graphics.FillEllipse(b.color, b.pos.X, b.pos.Y, b.size, b.size)
            b.update(0.1)
            'e.Graphics.FillEllipse(Brushes.Aquamarine, b.realPos.X, b.realPos.Y, 7, 7)
            Dim barrow As AdjustableArrowCap = New AdjustableArrowCap(10, 10)
            Dim p As Pen = New Pen(Brushes.Red)
            p.CustomEndCap = barrow
            Dim draw, velo As Point
            draw.X = b.realPos.X
            draw.Y = b.realPos.Y
            velo.X = b.vel.X
            velo.Y = b.vel.Y
            e.Graphics.DrawLine(p, CSng(draw.X), CSng(draw.Y), CSng(draw.X + velo.X), CSng(draw.Y + velo.Y))
            lblzoom.Text = $"{b.pos.X} {b.pos.Y} {b.a.X / 1000} {b.a.Y / 1000}"
        Next
    End Sub

    Function GetAvgCOM(bodylist As List(Of Body)) As Vector2
        If bodies.Count > 0 Then
            Dim avgcom = Vector2.Zero
            For Each b As Body In bodylist
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
            avgcom = New Vector2(xmean, ymean)
            Return avgcom
        End If
    End Function

    Function GetCOMOffset(com As Vector2) As Vector2
        Dim newcom As Vector2 = Vector2.Subtract(com, origin)
        Return newcom
    End Function

    Private Sub DrawArrow(ByVal g As Graphics, color As Brush)


    End Sub

    Function GetMidpoint(v1 As Vector2, v2 As Vector2)
        Return New Vector2((v1.X + v2.X) / 2, (v1.Y + v2.Y) / 2)
    End Function

    Private Sub AddBody(p As Point, v As Vector2)
        Dim pos As Point = p
        ' TODO: turn the 
        Dim bnew As Body = New Body(New Vector2(pos.X, pos.Y), v, r.Next(1, 2000), 10, RndColor(r.Next(Integer.MaxValue)), bodies.Count + 1)
        bodies.Add(bnew)
    End Sub

    'Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
    '    AddBody()
    ' End Sub
    Private Sub TmrIntegrator_Tick(sender As Object, e As EventArgs) Handles tmrIntegrator.Tick
        lblCOords.Text = Cursor.Position.ToString
        comOffset = GetCOMOffset(GetAvgCOM(bodies))
        'For Each b As Body In bodies
        '    b.distanceList.Clear()
        '    For Each c As Body In bodies
        '        b.distanceList.Add(b.GetDistance(c), c)
        '    Next
        'Next

        Me.Invalidate()
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        initMousePos = New Vector2(Cursor.Position.X, Cursor.Position.Y)
        mouseDown = True
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        mousePos = New Vector2(Cursor.Position.X, Cursor.Position.Y)
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        mousePos = New Vector2(Cursor.Position.X, Cursor.Position.Y)
        AddBody(New Point(mousePos.X, mousePos.Y), GetVector(mousePos, initMousePos))
        mouseDown = False
    End Sub

    Function GetDistance(v1 As Vector2, v2 As Vector2)
        Return Vector2.Distance(v1, v2)
    End Function

    Function GetDistance(p1 As Point, p2 As Point)
        Return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2))
    End Function

    Function GetVector(p1 As Point, p2 As Point)
        Dim v As Vector2 = New Vector2(p2.X - p1.X, p2.Y - p1.Y)
        Return v
    End Function

    Function GetVector(v1 As Vector2, v2 As Vector2)
        Dim v As Vector2 = New Vector2(v2.X - v1.X, v2.Y - v1.Y)
        Return v
    End Function

    Function Clamp(value As Single, floor As Single, ceiling As Single) As Single
        If value < floor Then
            value = floor
        ElseIf value > ceiling Then
            value = ceiling
        End If
        Return value
    End Function
End Class
