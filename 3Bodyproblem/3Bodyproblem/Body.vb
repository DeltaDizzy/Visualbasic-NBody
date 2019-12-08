Imports System.Drawing.Color
Imports System.Numerics
Public Class Body
    Dim G As Double = 0.0006679 ' universal grav constant
    Dim mass As Double ' body mass
    Public size As Single = 70
    Public color As Brush
    Dim ID As Integer
    Dim f As Double
    Public pos As Vector2
    Public vel As Vector2
    Dim bound As Rectangle

    Public Sub New(pos As Vector2, vel As Vector2, mass As Double, size As Single, color As Brush, id As Integer)
        Me.pos = pos
        Me.vel = vel
        Me.mass = mass
        Me.color = color
        Me.size = size
        Me.ID = id
    End Sub

    Public Sub New(pos As Vector2, vel As Vector2, mass As Double, color As Brush, id As Integer)
        Me.pos = pos
        Me.vel = vel
        Me.mass = mass
        Me.color = color
        Me.size = size
        Me.ID = id
    End Sub

    Public Sub update(dt As Double)
        vel += CalculateAcceleration(Form1.bodies) * 0.5 * dt
        pos += vel * dt
        vel += CalculateAcceleration(Form1.bodies) * 0.5 * dt
        Console.WriteLine($"{Me.color} - vel {vel.ToString}")
        Console.WriteLine($"{Me.color} - acc {CalculateAcceleration(Form1.bodies) * 0.5 * dt}")
    End Sub

    Function CalculateAcceleration(bodies As List(Of Body))
        Dim a As Vector2 = Vector2.Zero
        For Each b As Body In bodies
            If b <> Me Then
                a += (GetNormal(GetDirection(b)) * (G * (Me.mass * b.mass) / Math.Pow(GetDistance(b), 2)))
            End If
        Next
        Return a
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
        Return body.pos - Me.pos
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