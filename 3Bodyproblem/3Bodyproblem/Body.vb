Imports System.Drawing.Color
Imports System.Numerics
Public Class Body
    Dim G As Double = 0.6679 ' universal grav constant
    Dim fx, fy As Double ' forces
    Dim mass As Double ' body mass
    Public size As Single = 70
    Dim r2 As Double
    Dim r3 As Double
    Dim color As Color
    Dim ID As Integer
    Dim f As Double
    Public pos As Vector2
    Public vel As Vector2
    Public target As Body
    Dim a As Double
    Dim bound As Rectangle
    Public enabled As Boolean = True
    Public Sub New(pos As Vector2, vel As Vector2, mass As Double, size As Single, color As Color, id As Integer)
        Me.pos = pos
        Me.vel = vel
        Me.mass = mass
        Me.color = color
        Me.size = size
        Me.ID = id
    End Sub

    Public Sub New(pos As Vector2, vel As Vector2, mass As Double, color As Color, id As Integer)
        Me.pos = pos
        Me.vel = vel
        Me.mass = mass
        Me.color = color
        Me.size = size
        Me.ID = id
    End Sub

    Public Sub update(dt As Double)
        If enabled Then
            vel += CalculateAcceleration() * 0.5 * dt
            pos += vel * dt
            vel += CalculateAcceleration() * 0.5 * dt
            If IsColliding(target) Then
                target.enabled = False
            End If
        End If
    End Sub

    Function CalculateAcceleration()
        Return GetNormal(GetDirection(target)) * (G * (Me.mass * target.mass) / Math.Pow(GetDistance(target), 2))
    End Function

    Function CalculateForce(body As Body)
        f = G * ((Me.mass * body.mass) / Math.Pow(GetDistance(body), 2))
        Return f
    End Function

    Function IsColliding(body As Body)
        Dim dist = GetDistance(body)
        Dim targetRadius = body.size
        If Math.Pow(dist, 2) < Math.Pow((Me.size + body.size), 2) Then
            Return True
        Else
            Return False
        End If
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

' TODO: for each body, calculate force and add to current force, then apply