Public Class Submission
    Public Property Name As String
    Public Property Email As String
    Public Property Phone As String
    Public Property GitHub As String
    Public Property StopwatchTime As String

    Public Sub New()
        ' Default constructor
    End Sub

    ' Optional constructor with parameters
    Public Sub New(name As String, email As String, phone As String, github As String, stopwatchTime As String)
        Me.Name = name
        Me.Email = email
        Me.Phone = phone
        Me.GitHub = github
        Me.StopwatchTime = stopwatchTime
    End Sub
End Class
