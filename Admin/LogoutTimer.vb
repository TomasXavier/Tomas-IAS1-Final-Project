Public Class LogoutTimer

    Public inactivityTimer As New Timer()
    'Public inactivityLimit As Integer = 5 * 60
    Public maxTime As Integer = 5
    Public remainingTime As Integer = maxTime
    Public label As Label

    Public Sub SetLabel(label As Label)
        Me.label = label
    End Sub

    Public Sub AddActionTimerTracking(currentForm As Form)

        remainingTime = maxTime

        inactivityTimer.Interval = 1000 ' 1 second
        AddHandler inactivityTimer.Tick, AddressOf TimerTick
        inactivityTimer.Start()

        AddHandler currentForm.MouseMove, Sub() ResetTimer()
        AddHandler currentForm.KeyPress, Sub() ResetTimer()

        AddHandlerToTextboxes(currentForm)
    End Sub

    Private Sub AddHandlerToTextboxes(parent As Control)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is TextBox Then
                Dim tb As TextBox = DirectCast(ctrl, TextBox)

                AddHandler tb.TextChanged, Sub() ResetTimer()
                AddHandler tb.KeyPress, Sub() ResetTimer()
                AddHandler tb.MouseDown, Sub() ResetTimer()
            End If

            If ctrl.HasChildren Then
                AddHandlerToTextboxes(ctrl)
            End If
        Next
    End Sub

    Public Sub ResetTimer()
        remainingTime = maxTime
        UpdateLabel()
    End Sub

    Private Sub TimerTick(sender As Object, e As EventArgs)
        remainingTime -= 1
        UpdateLabel()

        If remainingTime <= 0 Then
            inactivityTimer.Stop()
            Logout()
        End If
    End Sub

    Public Sub StopTimer()
        inactivityTimer.Stop()
    End Sub

    Private Sub UpdateLabel()
        If label IsNot Nothing Then
            Dim minutes As Integer = remainingTime \ 60
            Dim seconds As Integer = remainingTime Mod 60
            label.Text = $"Logout timer: {minutes:D2}:{seconds:D2}"
        End If
    End Sub

End Class
