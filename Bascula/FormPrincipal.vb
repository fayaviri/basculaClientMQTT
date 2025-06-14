Imports System.Threading
Imports System.IO
Imports MQTTnet
Imports MQTTnet.Client
Imports MQTTnet.Client.Options
Imports System.Threading.Tasks

Public Class FormPrincipal

    ' MQTT variables
    Private mqttClient As IMqttClient
    Private mqttOptions As IMqttClientOptions
    Private balanzaNombre As String = "Balanza # 1" ' Valor por defecto
    Private Ip As String = ""
    Private isReconnectingMQTT As Boolean = False


    Public ReadOnly Property devolverPeso() As String
        Get
            Return TxtPeso.Text
        End Get
    End Property



    Private ComBuffer As Byte()
    Private Delegate Function UpdateFormDelegate() As Task
    Private UpdateFormDelegate1 As UpdateFormDelegate

    Dim strReturn As String
    Dim strPeso As String
    Dim car As String

    Private Async Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TraeConfiguracion()
        TLevantarConexion.Interval = 3000
        TLevantarConexion.Enabled = True

        TReintentarMQTT.Interval = 5000 ' cada 5 segundos
        TReintentarMQTT.Enabled = True

        Await ConectarClienteMQTT()
    End Sub

    Private Sub TraeConfiguracion()
        Try
            If File.Exists("config_serial.txt") Then
                Dim config() As String = File.ReadAllLines("config_serial.txt")
                puertoserial.PortName = config(0)
                puertoserial.BaudRate = Integer.Parse(config(1))
                puertoserial.DataBits = Integer.Parse(config(2))
                puertoserial.Parity = [Enum].Parse(GetType(IO.Ports.Parity), config(3))
                puertoserial.StopBits = [Enum].Parse(GetType(IO.Ports.StopBits), config(4))
                Ip = config(6)

                If config.Length >= 6 Then
                    balanzaNombre = config(5).Trim().ToLower()
                End If
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
            UpdateFormDelegate1 = New UpdateFormDelegate(AddressOf UpdateDisplayAsync)
            n = puertoserial.BytesToRead
            If n > 50 Then
                ComBuffer = New Byte(n - 1) {}
                puertoserial.Read(ComBuffer, 0, n)
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
                i = 0
            End If
            i -= 1
        End While

        Return acu
    End Function

    Private Async Function UpdateDisplayAsync() As Task
        Dim incoming As String = ""
        Dim longBuffer As Long = ComBuffer.Length

        For i = 0 To longBuffer - 1
            incoming &= Chr(ComBuffer(i))
        Next

        strReturn = incoming
        strPeso = ExtraerPeso(strReturn)

        If (strPeso = "0") Then
            TxtPeso.Text = "0"
        Else
            TxtPeso.Text = strPeso
        End If

        ' Publicar en MQTT en formato JSON
        If mqttClient IsNot Nothing AndAlso mqttClient.IsConnected Then
            Dim jsonPayload As String = $"{{ ""balanza"": ""{balanzaNombre}"", ""peso"": ""{strPeso}"" }}"

            Dim mensaje = New MqttApplicationMessageBuilder() _
                .WithTopic("bascula/peso") _
                .WithPayload(jsonPayload) _
                .WithAtLeastOnceQoS() _
                .Build()

            Await mqttClient.PublishAsync(mensaje)
            Console.WriteLine("📤 JSON enviado: " & jsonPayload)
        End If
    End Function

    Private Async Function ConectarClienteMQTT() As Task
        Try
            Dim factory = New MqttFactory()
            mqttClient = factory.CreateMqttClient()

            mqttOptions = New MqttClientOptionsBuilder() _
                .WithTcpServer(Ip, 1883) _
                .Build()

            'mqttOptions = New MqttClientOptionsBuilder() _
            '    .WithTcpServer("192.168.0.201", 1883) _
            '    .Build()

            Await mqttClient.ConnectAsync(mqttOptions)
            '192.168.0.201
            '192.168.0.201
            '127.0.0.1
            If mqttClient.IsConnected Then
                Console.WriteLine("✅ Cliente MQTT conectado.")
            Else
                Console.WriteLine("❌ Error al conectar al servidor MQTT.")
            End If
        Catch ex As Exception
            Console.WriteLine("❌ Error MQTT: " & ex.Message)
        End Try
    End Function

    Private Sub TLevantarConexion_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TLevantarConexion.Tick
        Try
            If Not puertoserial.IsOpen Then
                puertoserial.Open()
                TxtPeso.Text = "Reconectado"
            End If
        Catch
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

    Private Async Sub btnTestMqtt_Click(sender As Object, e As EventArgs) Handles btnTestMqtt.Click

        If mqttClient IsNot Nothing AndAlso mqttClient.IsConnected Then

            Dim rnd As New Random()
            Dim pesoPrueba As String = rnd.Next(22510, 31501).ToString()
            Dim jsonPayload As String = $"{{ ""balanza"": ""{balanzaNombre}"", ""peso"": ""{pesoPrueba}"" }}"
            Dim mensaje = New MqttApplicationMessageBuilder() _
                .WithTopic("bascula/peso") _
                .WithPayload(jsonPayload) _
                .WithAtLeastOnceQoS() _
                .Build()

            Await mqttClient.PublishAsync(mensaje)
            ' MessageBox.Show($"Mensaje de prueba enviado: {jsonPayload}", "✅ MQTT Test")
        Else
            MessageBox.Show("❌ MQTT no está conectado.", "Error")
        End If
    End Sub


    Private Async Sub btnPruebaBalanza_Click(sender As Object, e As EventArgs) Handles btnPruebaBalanza.Click
        If mqttClient IsNot Nothing AndAlso mqttClient.IsConnected Then

            Dim rnd As New Random()
            Dim pesoPrueba As String = rnd.Next(22510, 31501).ToString()

            ' Alternar aleatoriamente entre Balanza # 1 y Balanza # 2
            Dim balanzaNombre As String = If(rnd.Next(0, 2) = 0, "Balanza # 1", "Balanza # 2")

            Dim jsonPayload As String = $"{{ ""balanza"": ""{balanzaNombre}"", ""peso"": ""{pesoPrueba}"" }}"

            Dim mensaje = New MqttApplicationMessageBuilder() _
            .WithTopic("bascula/peso") _
            .WithPayload(jsonPayload) _
            .WithAtLeastOnceQoS _
            .Build()

            Await mqttClient.PublishAsync(mensaje)

        Else
            MessageBox.Show("❌ MQTT no está conectado.", "Error")
        End If
    End Sub


    Private Sub FormPrincipal_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            NotifyIcon1.Visible = True
            NotifyIcon1.BalloonTipTitle = "Servidor MQTT"
            NotifyIcon1.BalloonTipText = "El servidor sigue en ejecución en segundo plano."
            NotifyIcon1.ShowBalloonTip(1000)
        End If
    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        NotifyIcon1.Visible = False
        Application.Exit()
    End Sub

    Private Sub FormPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True ' 🚫 Cancelar el cierre
            Me.Hide()
            NotifyIcon1.BalloonTipTitle = "Servidor MQTT"
            NotifyIcon1.BalloonTipText = "Sigue ejecutándose en segundo plano. Click derecho -> Salir para cerrar."
            NotifyIcon1.ShowBalloonTip(1000)
        End If
    End Sub

    Private Async Sub TReintentarMQTT_Tick(sender As Object, e As EventArgs) Handles TReintentarMQTT.Tick
        If mqttClient Is Nothing OrElse Not mqttClient.IsConnected Then
            If Not isReconnectingMQTT Then
                isReconnectingMQTT = True
                Console.WriteLine("🔁 Intentando reconexión MQTT desde el Timer...")
                Await ConectarClienteMQTT()
                isReconnectingMQTT = False
            Else
                Console.WriteLine("⏳ Ya se está intentando reconectar, esperando...")
            End If
        End If
    End Sub


End Class
