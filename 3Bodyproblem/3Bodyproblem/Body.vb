Imports System.Drawing.Color
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

    Public Sub New(rx As Double, ry As Double, vx As Double, vy As Double, mass As Double, color As Color)
        Me.px = rx
        Me.py = ry
        Me.vx = vx
        Me.vy = vy
        Me.mass = mass
        Me.color = color
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

    Public Sub distanceTo(b As Body)

    End Sub
End Class
