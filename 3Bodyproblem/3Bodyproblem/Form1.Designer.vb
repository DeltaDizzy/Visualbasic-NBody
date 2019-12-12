<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmrIntegrator = New System.Windows.Forms.Timer(Me.components)
        Me.lblCOords = New System.Windows.Forms.Label()
        Me.lblzoom = New System.Windows.Forms.Label()
        Me.tbScroll = New System.Windows.Forms.TrackBar()
        CType(Me.tbScroll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrIntegrator
        '
        Me.tmrIntegrator.Enabled = True
        Me.tmrIntegrator.Interval = 50
        '
        'lblCOords
        '
        Me.lblCOords.AutoSize = True
        Me.lblCOords.Location = New System.Drawing.Point(12, 9)
        Me.lblCOords.Name = "lblCOords"
        Me.lblCOords.Size = New System.Drawing.Size(39, 13)
        Me.lblCOords.TabIndex = 0
        Me.lblCOords.Text = "Label1"
        '
        'lblzoom
        '
        Me.lblzoom.AutoSize = True
        Me.lblzoom.Location = New System.Drawing.Point(164, 9)
        Me.lblzoom.Name = "lblzoom"
        Me.lblzoom.Size = New System.Drawing.Size(39, 13)
        Me.lblzoom.TabIndex = 1
        Me.lblzoom.Text = "Label1"
        '
        'tbScroll
        '
        Me.tbScroll.Enabled = False
        Me.tbScroll.Location = New System.Drawing.Point(420, 12)
        Me.tbScroll.Maximum = 100
        Me.tbScroll.Minimum = 1
        Me.tbScroll.Name = "tbScroll"
        Me.tbScroll.Size = New System.Drawing.Size(368, 45)
        Me.tbScroll.TabIndex = 2
        Me.tbScroll.TickFrequency = 10
        Me.tbScroll.Value = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.tbScroll)
        Me.Controls.Add(Me.lblzoom)
        Me.Controls.Add(Me.lblCOords)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.tbScroll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tmrIntegrator As Timer
    Friend WithEvents lblCOords As Label
    Friend WithEvents lblzoom As Label
    Friend WithEvents tbScroll As TrackBar
End Class
