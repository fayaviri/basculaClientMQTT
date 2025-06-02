Imports System.Threading
Imports System.IO

Public Class FormPrincipal


    Public ReadOnly Property devolverPeso() As String
        Get
            Return TxtPeso.Text
        End Get
    End Property




#Region "SERIAL PORTS"

    Private ComBuffer As Byte()
    Private Delegate Sub UpdateFormDelegate()
    Private UpdateFormDelegate1 As UpdateFormDelegate

    'Creamos las variables a usar en el procedimiento de UpdateDisplay
    Dim strReturn As String
    Dim strPeso As String
    Dim car As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TraeConfiguracion()
        TLevantarConexion.Interval = 3000 ' Intentar reconectar cada 3 segundos
        TLevantarConexion.Enabled = True
    End Sub

    'Private Sub TraeConfiguracion()
    '    puertoserial.PortName = "COM6" 'puerto de comunicacion
    '    puertoserial.BaudRate = "9600" ' velocidad
    '    puertoserial.DataBits = "8" ' bits  de paridad
    '    puertoserial.StopBits = "1" ' bits de parada
    'End Sub

    Private Sub TraeConfiguracion()
        Try
            If File.Exists("config_serial.txt") Then
                Dim config() As String = File.ReadAllLines("config_serial.txt")
                puertoserial.PortName = config(0)
                puertoserial.BaudRate = Integer.Parse(config(1))
                puertoserial.DataBits = Integer.Parse(config(2))
                puertoserial.Parity = [Enum].Parse(GetType(IO.Ports.Parity), config(3))
                puertoserial.StopBits = [Enum].Parse(GetType(IO.Ports.StopBits), config(4))
            Else
                MsgBox("No se encontró la configuración del puerto. Ve a Configurar primero.")
            End If
        Catch ex As Exception
            MsgBox("Error cargando configuración: " & ex.Message)
        End Try
    End Sub



    Private Sub puertoserial_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles puertoserial.DataReceived
        Dim n As Integer
        Try
            UpdateFormDelegate1 = New UpdateFormDelegate(AddressOf UpdateDisplay)
            n = puertoserial.BytesToRead ' capturamos el numero de bytes leidos
            If n > 50 Then
                ComBuffer = New Byte(n - 1) {} 'redimensionamos
                puertoserial.Read(ComBuffer, 0, n) 'leemos el dato
                Me.Invoke(UpdateFormDelegate1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function ExtraerPeso(ByVal cadenaPeso As String) As String
        Dim car, acu, des As String
        Dim i As Integer

        i = cadenaPeso.Length
        acu = ""
        While (1 <= i)
            car = Mid(cadenaPeso, i, 1)
            des = Mid(cadenaPeso, i - 1, 1)
            If ((car = "g") And (des = "k")) Then
                i -= 3
                car = Mid(cadenaPeso, i, 1)
                While ((1 <= i) And (IsNumeric(car)))
                    acu = Mid(cadenaPeso, i, 1) + acu
                    i -= 1
                    car = Mid(cadenaPeso, i, 1)
                End While
                i = 0 ' para que salga
            End If
            i -= 1
        End While

        Return acu
    End Function
    Private Sub UpdateDisplay()
        'variables locales
        Dim incoming As String = ""
        Dim longBuffer As Long
        Dim i As Integer

        'calcularmos la longitud del buffer y guardamos la información en una variable
        longBuffer = ComBuffer.Length
        For i = 0 To longBuffer - 1
            incoming = incoming & Chr(ComBuffer(i))
        Next
        strReturn = incoming.ToString

        strPeso = ExtraerPeso(strReturn)
        If (strPeso = "0") Then
            Me.TxtPeso.Text = "0"
        Else
            Me.TxtPeso.Text = strPeso
        End If

    End Sub


    Private Sub tmpPrueba_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

#End Region

    Private Sub TLevantarConexion_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TLevantarConexion.Tick
        Try
            If Not puertoserial.IsOpen Then
                puertoserial.Open()
                TxtPeso.Text = "Reconectado"
            End If
        Catch
            ' Puede fallar si el COM no está disponible aún
            TxtPeso.Text = "Buscando conexión..."
        End Try
        ActualizarEstadoConexion()
    End Sub

    Private Sub Talertar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Talertar.Tick
        If TxtPeso.Text = "" Then
            TxtPeso.Text = "NO HAY CEÑAL"
        End If
    End Sub

    Private Sub Conectar()
        Try
            If Not puertoserial.IsOpen Then
                puertoserial.Open()
                TLevantarConexion.Enabled = True
                TBorrar.Enabled = True
                Talertar.Enabled = True
                TxtPeso.Text = "00"
                MsgBox("Conexión establecida correctamente.")
            Else
                MsgBox("Ya está conectado.")
            End If
        Catch ex As Exception
            MsgBox("❌ Error al conectar: " & ex.Message)
        End Try
    End Sub

    Private Sub Desconectar()
        Try
            If puertoserial.IsOpen Then
                puertoserial.Close()
                TLevantarConexion.Enabled = False
                Talertar.Enabled = False
                MsgBox("🔴 Conexión cerrada correctamente.")
            Else
                MsgBox("El puerto ya está cerrado.")
            End If
        Catch ex As Exception
            MsgBox("❌ Error al desconectar: " & ex.Message)
        End Try
    End Sub
    Private Sub BtnConectar_Click(sender As Object, e As EventArgs) Handles BtnConectar.Click
        Conectar()
    End Sub

    Private Sub BtnDesconectar_Click(sender As Object, e As EventArgs) Handles BtnDesconectar.Click
        Desconectar()
    End Sub

    Private Sub ActualizarEstadoConexion()
        If puertoserial.IsOpen Then
            lblEstadoSerial.Text = "🟢 Conectado"
            lblEstadoSerial.ForeColor = Color.Green
        Else
            lblEstadoSerial.Text = "🔴 Desconectado"
            lblEstadoSerial.ForeColor = Color.Red
        End If
    End Sub

    Private Sub ConfigurarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurarToolStripMenuItem.Click
        Dim frm As New FormConfiguracion()
        frm.ShowDialog()
    End Sub
    Private Sub TBorrar_Tick_1(sender As Object, e As EventArgs) Handles TBorrar.Tick
        TxtPeso.Clear()
    End Sub
End Class
