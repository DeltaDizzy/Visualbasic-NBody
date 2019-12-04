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
        Me.SuspendLayout()
        '
        'tmrIntegrator
        '
        Me.tmrIntegrator.Enabled = True
        Me.tmrIntegrator.Interval = 1
        '
        'lblCOords
        '
        Me.lblCOords.AutoSize = True
        Me.lblCOords.Location = New System.Drawing.Point(643, 326)
        Me.lblCOords.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCOords.Name = "lblCOords"
        Me.lblCOords.Size = New System.Drawing.Size(51, 17)
        Me.lblCOords.TabIndex = 0
        Me.lblCOords.Text = "Label1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.lblCOords)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tmrIntegrator As Timer
    Friend WithEvents lblCOords As Label
End Class
