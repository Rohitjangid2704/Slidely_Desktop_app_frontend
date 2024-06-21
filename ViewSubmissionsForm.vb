Public Class ViewSubmissionsForm
    Private submissions As List(Of Submission)
    Private currentIndex As Integer = 0

    Private Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the form's title
        Me.Text = "Rohit Jangid, Slidely Task 2 - View Submissions"

        ' Load the submissions from the backend
        submissions = LoadSubmissions()

        ' Display the first submission
        DisplaySubmission(currentIndex)
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            DisplaySubmission(currentIndex)
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            DisplaySubmission(currentIndex)
        End If
    End Sub

    Private Sub DisplaySubmission(index As Integer)
        If submissions IsNot Nothing AndAlso submissions.Count > 0 Then
            Dim submission = submissions(index)
            txtName.Text = submission.SubName
            txtEmail.Text = submission.SubEmail
            txtPhoneNum.Text = submission.SubPhone
            txtGithubLink.Text = submission.SubGithubLink
            txtStopwatchTime.Text = submission.SubStopwatchTime
        End If
    End Sub

    Private Function LoadSubmissions() As List(Of Submission)
        ' Implement the logic to load submissions from the backend
        ' For now, return a mock list
        Return New List(Of Submission) From {
            New Submission With {.SubName = "Rohit Jangid", .SubEmail = "rohit@example.com", .SubPhone = "1234567890", .SubGithubLink = "https://github.com/johndoe/repo", .SubStopwatchTime = "00:01:00"}
        }
    End Function

    ' Define keyboard shortcuts
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.P) Then
            btnPrevious.PerformClick()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.N) Then
            btnNext.PerformClick()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class
