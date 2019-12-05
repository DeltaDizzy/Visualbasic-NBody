Imports System.Drawing.Color
Imports System.Numerics
Public Class Body
    Dim G As Double = 0.00000000006679 ' universal grav constant
    Public px, py As Double ' x and y positions
    Dim vx, vy As Double ' x and y velocities
    Dim fx, fy As Double ' forces
    Dim mass As Double ' body mass
    Dim size As Double
    Dim r2 As Double
    Dim r3 As Double
    Dim color As Color
    Dim ID As Integer
    Dim f As Double
    Public pos As Vector2

    Public Sub New(px As Double, py As Double, vx As Double, vy As Double, mass As Double, color As Color, id As Integer)
        Me.px = px
        Me.py = py
        Me.vx = vx
        Me.vy = vy
        Me.mass = mass
        Me.color = color
        Me.ID = id
        pos.X = px
        pos.Y = py
    End Sub

    Public Sub update(dt As Double)
        r2 = px * px + py * py
        r3 = r2 * Math.Sqrt(r2)

        fx = -px / r3
        fy = -py / r3

        px += vx * dt
        py += vy * dt

        vx += fx * dt
        vy += fy * dt

    End Sub

    Function CalculateForce(body As Body)
        f = G * ((Me.mass * body.mass) / Math.Pow(GetDistance(body), 2))
    End Function

    Function GetDistance(body As Body)
        Return Math.Sqrt(Math.Pow((body.px - Me.px), 2) + Math.Pow((body.py - Me.py), 2))
    End Function

    Function GetDirection(body As Body)

    End Function

    Public Shared Operator =(ByVal b1 As Body, ByVal b2 As Body)
        If b1.ID = b2.ID Then
            Return True
        Else
            Return False
        End If
    End Operator

    Public Shared Operator <>(ByVal b1 As Body, ByVal b2 As Body)
        If b1.ID = b2.ID Then
            Return False
        Else
            Return True
        End If
    End Operator
End Class
