<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConfiguracion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.cmbStopBits = New System.Windows.Forms.ComboBox()
        Me.cmbParidad = New System.Windows.Forms.ComboBox()
        Me.txtDataBits = New System.Windows.Forms.TextBox()
        Me.txtBaud = New System.Windows.Forms.TextBox()
        Me.cmbPuertos = New System.Windows.Forms.ComboBox()
        Me.cmbBalanza = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIp = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(65, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Bits de parada:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(97, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Paridad:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(72, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Bits de datos:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Baud Rate (velocidad):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(78, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Puerto COM:"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(149, 223)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(121, 23)
        Me.BtnGuardar.TabIndex = 33
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'cmbStopBits
        '
        Me.cmbStopBits.FormattingEnabled = True
        Me.cmbStopBits.Location = New System.Drawing.Point(149, 129)
        Me.cmbStopBits.Name = "cmbStopBits"
        Me.cmbStopBits.Size = New System.Drawing.Size(121, 21)
        Me.cmbStopBits.TabIndex = 32
        '
        'cmbParidad
        '
        Me.cmbParidad.FormattingEnabled = True
        Me.cmbParidad.Location = New System.Drawing.Point(149, 102)
        Me.cmbParidad.Name = "cmbParidad"
        Me.cmbParidad.Size = New System.Drawing.Size(121, 21)
        Me.cmbParidad.TabIndex = 31
        '
        'txtDataBits
        '
        Me.txtDataBits.Location = New System.Drawing.Point(149, 76)
        Me.txtDataBits.Name = "txtDataBits"
        Me.txtDataBits.Size = New System.Drawing.Size(121, 20)
        Me.txtDataBits.TabIndex = 30
        '
        'txtBaud
        '
        Me.txtBaud.Location = New System.Drawing.Point(149, 50)
        Me.txtBaud.Name = "txtBaud"
        Me.txtBaud.Size = New System.Drawing.Size(121, 20)
        Me.txtBaud.TabIndex = 29
        '
        'cmbPuertos
        '
        Me.cmbPuertos.FormattingEnabled = True
        Me.cmbPuertos.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10"})
        Me.cmbPuertos.Location = New System.Drawing.Point(149, 23)
        Me.cmbPuertos.Name = "cmbPuertos"
        Me.cmbPuertos.Size = New System.Drawing.Size(121, 21)
        Me.cmbPuertos.TabIndex = 28
        '
        'cmbBalanza
        '
        Me.cmbBalanza.FormattingEnabled = True
        Me.cmbBalanza.Location = New System.Drawing.Point(149, 156)
        Me.cmbBalanza.Name = "cmbBalanza"
        Me.cmbBalanza.Size = New System.Drawing.Size(121, 21)
        Me.cmbBalanza.TabIndex = 39
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(95, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Balanza:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(115, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 13)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Ip:"
        '
        'txtIp
        '
        Me.txtIp.Location = New System.Drawing.Point(149, 182)
        Me.txtIp.Name = "txtIp"
        Me.txtIp.Size = New System.Drawing.Size(121, 20)
        Me.txtIp.TabIndex = 42
        '
        'FormConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 275)
        Me.Controls.Add(Me.txtIp)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbBalanza)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.cmbStopBits)
        Me.Controls.Add(Me.cmbParidad)
        Me.Controls.Add(Me.txtDataBits)
        Me.Controls.Add(Me.txtBaud)
        Me.Controls.Add(Me.cmbPuertos)
        Me.Name = "FormConfiguracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormConfiguracion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents cmbStopBits As ComboBox
    Friend WithEvents cmbParidad As ComboBox
    Friend WithEvents txtDataBits As TextBox
    Friend WithEvents txtBaud As TextBox
    Friend WithEvents cmbPuertos As ComboBox
    Friend WithEvents cmbBalanza As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtIp As TextBox
End Class
