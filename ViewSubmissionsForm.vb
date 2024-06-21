Public Class ViewSubmissionsForm
    Private currentIndex As Integer = 0
    Private submissions As List(Of Submission)

    Private Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSubmissions()
        If submissions.Count > 0 Then
            DisplaySubmission(currentIndex)
        Else
            MessageBox.Show("No submissions available.")
        End If
    End Sub

    Private Sub LoadSubmissions()
        ' Placeholder for loading submissions from backend (API call)
        submissions = FetchSubmissions()
    End Sub

    Private Function FetchSubmissions() As List(Of Submission)
        ' Placeholder for fetching the submissions from the backend (API call)
        ' Example: GET request to /read endpoint
        ' Return a list of dummy submissions for testing purposes
        Return New List(Of Submission) From {
            New Submission With {.Name = "John Doe", .Email = "john@example.com", .Phone = "1234567890", .GitHub = "https://github.com/johndoe", .StopwatchTime = "00:05:23"},
            New Submission With {.Name = "Jane Smith", .Email = "jane@example.com", .Phone = "0987654321", .GitHub = "https://github.com/janesmith", .StopwatchTime = "00:07:45"}
        }
    End Function

    Private Sub DisplaySubmission(index As Integer)
        If index >= 0 AndAlso index < submissions.Count Then
            Dim submission As Submission = submissions(index)
            txtName.Text = submission.Name
            txtEmail.Text = submission.Email
            txtPhone.Text = submission.Phone
            txtGitHub.Text = submission.GitHub
            txtStopwatch.Text = submission.StopwatchTime
        Else
            MessageBox.Show("Invalid submission index.")
        End If
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
End Class
