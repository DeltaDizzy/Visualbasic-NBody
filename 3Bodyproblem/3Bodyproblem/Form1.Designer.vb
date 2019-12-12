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
        Me.lblCollide = New System.Windows.Forms.Label()
        Me.lblDistances = New System.Windows.Forms.Label()
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
        Me.lblCOords.Location = New System.Drawing.Point(16, 11)
        Me.lblCOords.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCOords.Name = "lblCOords"
        Me.lblCOords.Size = New System.Drawing.Size(51, 17)
        Me.lblCOords.TabIndex = 0
        Me.lblCOords.Text = "Label1"
        '
        'lblCollide
        '
        Me.lblCollide.AutoSize = True
        Me.lblCollide.Location = New System.Drawing.Point(199, 11)
        Me.lblCollide.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCollide.Name = "lblCollide"
        Me.lblCollide.Size = New System.Drawing.Size(51, 17)
        Me.lblCollide.TabIndex = 1
        Me.lblCollide.Text = "Label1"
        '
        'lblDistances
        '
        Me.lblDistances.AutoSize = True
        Me.lblDistances.Location = New System.Drawing.Point(459, 11)
        Me.lblDistances.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDistances.Name = "lblDistances"
        Me.lblDistances.Size = New System.Drawing.Size(51, 17)
        Me.lblDistances.TabIndex = 2
        Me.lblDistances.Text = "Label1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.lblDistances)
        Me.Controls.Add(Me.lblCollide)
        Me.Controls.Add(Me.lblCOords)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tmrIntegrator As Timer
    Friend WithEvents lblCOords As Label
    Friend WithEvents lblCollide As Label
    Friend WithEvents lblDistances As Label
End Class
