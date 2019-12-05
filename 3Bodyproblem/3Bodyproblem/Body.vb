Imports System.Drawing.Color
Imports System.Numerics
Public Class Body
    Dim G As Double = 0.6679 ' universal grav constant
    Dim fx, fy As Double ' forces
    Dim mass As Double ' body mass
    Dim size As Double
    Dim r2 As Double
    Dim r3 As Double
    Dim color As Color
    Dim ID As Integer
    Dim f As Double
    Public pos As Vector2
    Public vel As Vector2
    Public target As Body
    Dim a As Double

    Public Sub New(pos As Vector2, vel As Vector2, mass As Double, color As Color, id As Integer)
        Me.pos = pos
        Me.vel = vel
        Me.mass = mass
        Me.color = color
        Me.ID = id
    End Sub

    Public Sub update(dt As Double)
        vel += CalculateAcceleration() * dt
        pos += vel * dt

    End Sub

    Function CalculateAcceleration()
        Return GetNormal(GetDirection(target)) * (G * (Me.mass * target.mass) / Math.Pow(GetDistance(target), 2))
    End Function

    Function CalculateForce(body As Body)
        f = G * ((Me.mass * body.mass) / Math.Pow(GetDistance(body), 2))
        Return f
    End Function

    Function GetDistance(body As Body)
        Return Vector2.Distance(Me.pos, body.pos)
    End Function

    Function GetDirection(body As Body)
        Dim dir As Vector2
        dir = body.pos - Me.pos
        Return dir
    End Function

    Function GetNormal(v As Vector2)
        Return Vector2.Normalize(v)
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

' TODO: f