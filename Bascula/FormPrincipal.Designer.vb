<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrincipal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPrincipal))
        Me.puertoserial = New System.IO.Ports.SerialPort(Me.components)
        Me.TLevantarConexion = New System.Windows.Forms.Timer(Me.components)
        Me.Talertar = New System.Windows.Forms.Timer(Me.components)
        Me.BtnConectar = New System.Windows.Forms.Button()
        Me.BtnDesconectar = New System.Windows.Forms.Button()
        Me.lblEstadoSerial = New System.Windows.Forms.Label()
        Me.TxtPeso = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBorrar = New System.Windows.Forms.Timer(Me.components)
        Me.btnTestMqtt = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPruebaBalanza = New System.Windows.Forms.Button()
        Me.TReintentarMQTT = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'puertoserial
        '
        '
        'TLevantarConexion
        '
        Me.TLevantarConexion.Interval = 3000
        '
        'Talertar
        '
        Me.Talertar.Interval = 4000
        '
        'BtnConectar
        '
        Me.BtnConectar.Location = New System.Drawing.Point(17, 72)
        Me.BtnConectar.Name = "BtnConectar"
        Me.BtnConectar.Size = New System.Drawing.Size(75, 23)
        Me.BtnConectar.TabIndex = 14
        Me.BtnConectar.Text = "Conectar"
        Me.BtnConectar.UseVisualStyleBackColor = True
        '
        'BtnDesconectar
        '
        Me.BtnDesconectar.Location = New System.Drawing.Point(98, 72)
        Me.BtnDesconectar.Name = "BtnDesconectar"
        Me.BtnDesconectar.Size = New System.Drawing.Size(75, 23)
        Me.BtnDesconectar.TabIndex = 15
        Me.BtnDesconectar.Text = "Desconectar"
        Me.BtnDesconectar.UseVisualStyleBackColor = True
        '
        'lblEstadoSerial
        '
        Me.lblEstadoSerial.AutoSize = True
        Me.lblEstadoSerial.Location = New System.Drawing.Point(14, 35)
        Me.lblEstadoSerial.Name = "lblEstadoSerial"
        Me.lblEstadoSerial.Size = New System.Drawing.Size(40, 13)
        Me.lblEstadoSerial.TabIndex = 16
        Me.lblEstadoSerial.Text = "Estado"
        '
        'TxtPeso
        '
        Me.TxtPeso.Location = New System.Drawing.Point(124, 84)
        Me.TxtPeso.Name = "TxtPeso"
        Me.TxtPeso.Size = New System.Drawing.Size(290, 20)
        Me.TxtPeso.TabIndex = 28
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(532, 24)
        Me.MenuStrip1.TabIndex = 29
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurarToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'ConfigurarToolStripMenuItem
        '
        Me.ConfigurarToolStripMenuItem.Name = "ConfigurarToolStripMenuItem"
        Me.ConfigurarToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.ConfigurarToolStripMenuItem.Text = "Configurar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnConectar)
        Me.GroupBox1.Controls.Add(Me.lblEstadoSerial)
        Me.GroupBox1.Controls.Add(Me.BtnDesconectar)
        Me.GroupBox1.Location = New System.Drawing.Point(124, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(290, 137)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Conectar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(121, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Peso obtenido"
        '
        'TBorrar
        '
        Me.TBorrar.Interval = 4000
        '
        'btnTestMqtt
        '
        Me.btnTestMqtt.Location = New System.Drawing.Point(124, 272)
        Me.btnTestMqtt.Name = "btnTestMqtt"
        Me.btnTestMqtt.Size = New System.Drawing.Size(290, 23)
        Me.btnTestMqtt.TabIndex = 32
        Me.btnTestMqtt.Text = "Test MQTT"
        Me.btnTestMqtt.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Balanza"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(97, 26)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'btnPruebaBalanza
        '
        Me.btnPruebaBalanza.Location = New System.Drawing.Point(124, 301)
        Me.btnPruebaBalanza.Name = "btnPruebaBalanza"
        Me.btnPruebaBalanza.Size = New System.Drawing.Size(290, 23)
        Me.btnPruebaBalanza.TabIndex = 34
        Me.btnPruebaBalanza.Text = "Test Balanza"
        Me.btnPruebaBalanza.UseVisualStyleBackColor = True
        '
        'TReintentarMQTT
        '
        '
        'FormPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(532, 363)
        Me.Controls.Add(Me.btnPruebaBalanza)
        Me.Controls.Add(Me.btnTestMqtt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPeso)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistema Bascula Digital"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents puertoserial As System.IO.Ports.SerialPort
    Friend WithEvents TLevantarConexion As System.Windows.Forms.Timer
    Friend WithEvents Talertar As System.Windows.Forms.Timer
    Friend WithEvents BtnConectar As Button
    Friend WithEvents BtnDesconectar As Button
    Friend WithEvents lblEstadoSerial As Label
    Friend WithEvents TxtPeso As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfigurarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TBorrar As Timer
    Friend WithEvents btnTestMqtt As Button
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnPruebaBalanza As Button
    Friend WithEvents TReintentarMQTT As Timer
End Class
