Imports System.Diagnostics

Public Class CreateSubmissionForm
    Private stopwatch As Stopwatch

    Public Sub New()
        InitializeComponent()
        Timer1.Interval = 1000 ' Set interval to 1 second
    End Sub

    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialization delayed until first interaction
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Handle submission logic here
        Dim name As String = txtName.Text
        Dim email As String = txtEmail.Text
        Dim phone As String = txtPhone.Text
        Dim githubLink As String = txtGitHub.Text
        Dim stopwatchTime As String = If(stopwatch IsNot Nothing, stopwatch.Elapsed.ToString(), "00:00:00")

        ' Example: SubmitDataToBackend(name, email, phone, githubLink, stopwatchTime)

        MessageBox.Show("Form submitted successfully!")
    End Sub

    Private Sub btnToggleStopwatch_Click(sender As Object, e As EventArgs) Handles btnToggleStopWatch.Click
        If stopwatch Is Nothing Then
            stopwatch = New Stopwatch()
        End If

        If Not stopwatch.IsRunning Then
            stopwatch.Start()
        Else
            stopwatch.Stop()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If stopwatch IsNot Nothing AndAlso stopwatch.IsRunning Then
            lblStopwatch.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
        End If
    End Sub
    Public Class CreateSubmissionForm

        ' Define variables to hold user input
        Private userInputName As String
        Private userInputEmail As String
        Private userInputPhone As String
        Private userInputGithubLink As String
        Private userInputStopwatchTime As String

        ' Event handler for button click to submit form
        Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
            ' Capture input from text boxes
            userInputName = NameTextBox.Text.Trim()
            userInputEmail = EmailTextBox.Text.Trim()
            userInputPhone = PhoneTextBox.Text.Trim()
            userInputGithubLink = GithubLinkTextBox.Text.Trim()
            userInputStopwatchTime = StopwatchTimeTextBox.Text.Trim()

            ' Validate input (optional)
            If Not ValidateInput() Then
                MessageBox.Show("Please fill in all fields.")
                Return
            End If

            ' Example: Display captured input (replace with your logic)
            MessageBox.Show($"Name: {userInputName}{Environment.NewLine}" &
                        $"Email: {userInputEmail}{Environment.NewLine}" &
                        $"Phone: {userInputPhone}{Environment.NewLine}" &
                        $"Github Link: {userInputGithubLink}{Environment.NewLine}" &
                        $"Stopwatch Time: {userInputStopwatchTime}")

            ' Optionally, you can send this data to your backend using HttpClient
            ' Example: Await SendDataToBackend()
        End Sub

        ' Example function to send data to backend (async)
        Private Async Function SendDataToBackend() As Task
            ' Replace with your backend URL
            Dim apiUrl As String = "http://localhost:4000/submit"

            ' Example JSON payload
            Dim jsonPayload As String = $"{{ ""name"": ""{userInputName}"", ""email"": ""{userInputEmail}"", " &
                                    $" ""phone"": ""{userInputPhone}"", ""github_link"": ""{userInputGithubLink}"", " &
                                    $" ""stopwatch_time"": ""{userInputStopwatchTime}"" }}"

            Try
                Using client As New HttpClient()
                    ' Send POST request to backend
                    Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl,
                                     New StringContent(jsonPayload, Encoding.UTF8, "application/json"))

                    If response.IsSuccessStatusCode Then
                        Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                        MessageBox.Show($"Backend response: {responseBody}")
                        ' Process response as needed
                    Else
                        MessageBox.Show($"Error sending data: {response.StatusCode}")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show($"Exception: {ex.Message}")
            End Try
        End Function

        ' Optional: Validate input fields
        Private Function ValidateInput() As Boolean
            Return Not String.IsNullOrWhiteSpace(userInputName) AndAlso
               Not String.IsNullOrWhiteSpace(userInputEmail) AndAlso
               Not String.IsNullOrWhiteSpace(userInputPhone) AndAlso
               Not String.IsNullOrWhiteSpace(userInputGithubLink) AndAlso
               Not String.IsNullOrWhiteSpace(userInputStopwatchTime)
        End Function

    End Class

End Class
