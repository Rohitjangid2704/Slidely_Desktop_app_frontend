Imports System.Diagnostics
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class CreateSubmissionForm
    Private stopwatch As Stopwatch = New Stopwatch()

    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the form's title
        Me.Text = "Rohit jangid, Slidely Task 2 - Create Submission"
    End Sub

    Private Sub btnToggleStopwatch_Click(sender As Object, e As EventArgs) Handles btnToggleStopwatch.Click
        If stopwatch.IsRunning Then
            stopwatch.Stop()
        Else
            stopwatch.Start()
        End If
        Timer.Enabled = stopwatch.IsRunning
    End Sub

    Private Sub timerStopwatch_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        txtStopwatchTime.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Code to submit the form data to the backend
        Dim name As String = txtName.Text
        Dim email As String = txtEmail.Text
        Dim phone As String = txtPhoneNum.Text
        Dim githubLink As String = txtGithubLink.Text
        Dim stopwatchTime As String = txtStopwatchTime.Text

        ' Call a method to send this data to the backend
        SubmitData(name, email, phone, githubLink, stopwatchTime)
    End Sub

    Private Async Sub SubmitData(subName As String, subEmail As String, subPhone As String, subGithubLink As String, subStopwatchTime As String)
        Dim submission As New Submission() With {
            .SubName = subName,
            .SubEmail = subEmail,
            .SubPhone = subPhone,
            .SubGithubLink = subGithubLink,
            .SubStopwatchTime = subStopwatchTime
        }

        Dim json As String = JsonConvert.SerializeObject(submission)
        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

        Using client As New HttpClient()
            Try
                Dim response As HttpResponseMessage = Await client.PostAsync("http://localhost:3000/submit", content)
                If response.IsSuccessStatusCode Then
                    MessageBox.Show("Submission successful!")
                Else
                    MessageBox.Show("Failed to submit. Please try again.")
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub

    ' Define keyboard shortcuts
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.S) Then
            btnSubmit.PerformClick()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.T) Then
            btnToggleStopwatch.PerformClick()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class


