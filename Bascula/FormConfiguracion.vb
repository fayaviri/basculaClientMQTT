Imports System.IO
Imports System.IO.Ports

Public Class FormConfiguracion

    Private Sub FormConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbPuertos.Items.AddRange(SerialPort.GetPortNames())
        cmbParidad.Items.AddRange([Enum].GetNames(GetType(Parity)))
        cmbStopBits.Items.AddRange([Enum].GetNames(GetType(StopBits)))
        cmbTopic.Items.AddRange(New String() {"topic/peso", "topic/peso/secundario"})

        ' Valores por defecto
        txtBaud.Text = "9600"
        txtDataBits.Text = "8"
        cmbParidad.SelectedItem = "None"
        cmbStopBits.SelectedItem = "One"
        If cmbPuertos.Items.Count > 0 Then cmbPuertos.SelectedIndex = 0
        cmbTopic.SelectedIndex = 0 ' valor por defecto

        ' Cargar configuración si existe
        If File.Exists("config_serial.txt") Then
            Try
                Dim config() As String = File.ReadAllLines("config_serial.txt")

                If config.Length >= 6 Then
                    If cmbPuertos.Items.Contains(config(0)) Then
                        cmbPuertos.SelectedItem = config(0)
                    Else
                        cmbPuertos.Items.Add(config(0))
                        cmbPuertos.SelectedItem = config(0)
                    End If

                    txtBaud.Text = config(1)
                    txtDataBits.Text = config(2)

                    If cmbParidad.Items.Contains(config(3)) Then
                        cmbParidad.SelectedItem = config(3)
                    End If

                    If cmbStopBits.Items.Contains(config(4)) Then
                        cmbStopBits.SelectedItem = config(4)
                    End If

                    If cmbTopic.Items.Contains(config(5)) Then
                        cmbTopic.SelectedItem = config(5)
                    Else
                        cmbTopic.Items.Add(config(5))
                        cmbTopic.SelectedItem = config(5)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error al cargar configuración: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim configLines As String() = {
                cmbPuertos.SelectedItem.ToString(),
                txtBaud.Text,
                txtDataBits.Text,
                cmbParidad.SelectedItem.ToString(),
                cmbStopBits.SelectedItem.ToString(),
                cmbTopic.SelectedItem.ToString()
            }
            File.WriteAllLines("config_serial.txt", configLines)
            MessageBox.Show("Configuración guardada correctamente.")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error al guardar: " & ex.Message)
        End Try
    End Sub
End Class
