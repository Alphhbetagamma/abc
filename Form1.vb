Public Class Form1
    Private Sub btnViewSubmissions_Click(sender As Object, e As EventArgs) Handles btnViewSubmissions.Click
        Dim viewSubmissionsForm As New ViewSubmissionsForm()
        viewSubmissionsForm.ShowDialog()
    End Sub

    Private Sub btnCreateNewSubmission_Click(sender As Object, e As EventArgs) Handles btnCreateNewSubmission.Click
        Dim createSubmissionForm As New CreateSubmissionForm()
        createSubmissionForm.ShowDialog()
    End Sub
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Replace with your backend URL
        Dim apiUrl As String = "http://localhost:4000"

        ' Example function to fetch data from backend
        Await FetchData(apiUrl)
    End Sub

    Private Async Function FetchData(apiUrl As String) As Task
        Try
            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.GetAsync($"{apiUrl}/ping")

                If response.IsSuccessStatusCode Then
                    Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                    MessageBox.Show($"Backend response: {responseBody}")
                    ' Process responseBody as needed
                Else
                    MessageBox.Show($"Error fetching data: {response.StatusCode}")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Exception: {ex.Message}")
        End Try
    End Function


End Class

