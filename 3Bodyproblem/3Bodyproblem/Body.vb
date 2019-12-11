
Imports System.Numerics
Public Class Body
    Dim G As Double = 0.6679 ' universal grav constant
    Public mass As Double ' body mass
    Public size As Single = 70
    Public color As Brush
    Dim ID As Integer
    Dim f As Double
    Public a As Vector2
    Public pos As Vector2
    Public vel As Vector2
    Public target As Body
    Dim bound As Rectangle
    Public collider As Body
    Public colPos As Vector2
    Public distanceList As New Dictionary(Of Single, Body)
    'Public distanceList As New List(Of Single)
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
        colPos = OffsetPos(pos)
    End Sub

    Function CalculateAcceleration(bodies As List(Of Body))
        a = Vector2.Zero
        For Each b As Body In bodies
            If b <> Me Then
                a += GetNormal(GetDirection(b)) * (G * (Me.mass * b.mass) / Math.Pow(GetDistance(b), 2))
            End If
        Next
        Return a
    End Function

    Function CalculateForce(body As Body)
        f = G * ((Me.mass * body.mass) / Math.Pow(GetDistance(body), 2))
        Return f
    End Function

    Public Function IsColliding()
        collider = distanceList(distanceList.Keys.Min())
        Dim dist As Single = GetDistance(colPos, collider.colPos)
        If dist < Me.size + collider.size Then
            Return True
        Else
            Return False
        End If
    End Function

    Function GetDistance(body As Body)
        Return Vector2.Distance(Me.pos, body.pos)

    End Function

    Function GetDistance(v As Vector2)
        Return Vector2.Distance(Me.pos, v)

    End Function

    Function GetDistance(v1 As Vector2, v2 As Vector2)
        Return Vector2.Distance(v1, v2)

    End Function

    Function GetDirection(body As Body)
        Dim dir As Vector2
        dir = body.pos - Me.pos
        Return dir
    End Function
    Function GetNormal(v As Vector2)
        Return Vector2.Normalize(v)
    End Function

    Function OffsetPos(v As Vector2) As Vector2
        Return New Vector2(v.X + size * 0.5, v.Y + size * 0.5)
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