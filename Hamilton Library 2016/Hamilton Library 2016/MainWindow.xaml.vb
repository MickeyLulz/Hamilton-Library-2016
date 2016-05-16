

Imports System.Data.SqlClient
Imports System.Data

Class MainWindow
    Dim Username As String
    Dim Password As String

    Dim Sql As New SqlConnection("Data Source=shar;Initial Catalog=Mickey_2016;Integrated Security=True")

    Private Sub btnLogin_Click(sender As Object, e As RoutedEventArgs) Handles btnLogin.Click
        Username = txtUsername.Text
        Password = txtPassword.Password

        ParameterizedLogin()

    End Sub

    Public Sub LoginCheck()
        Dim SqlStr As New SqlCommand
        Dim SqlReader As SqlDataReader
        Dim SqlStat As String

        Try
            SqlStr.Connection = Sql
            'SqlStat = "Select * from Login where username = '" & Username & "' and password = '" & Password & "' "
            SqlStat = "Select FullName, usertype from Login inner join Users on Users.Username = Login.username where Login.username = '" & Username & "' and Login.password = '" & Password & "' "
            SqlStr.CommandText = SqlStat

            Sql.Open()

            SqlReader = SqlStr.ExecuteReader

            If SqlReader.HasRows Then
                MsgBox("Login Successful")

                SqlReader.Read()

                If SqlReader("usertype") = "Admin" Then
                    Dim a As New Admin()
                    a.Show()

                Else
                    Dim dash As New Dashboard()
                    dash.Show()
                    dash.lblMessage.Content = "Hi " + SqlReader("FullName")

                End If

            Else
                MsgBox("Username or Password Incorrect")

            End If

            Sql.Close()

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error" + ex.Message)

        End Try

    End Sub

    Public Sub ParameterizedLogin()
        Dim SqlStr As New SqlCommand
        Dim SqlReader As SqlDataReader
        Dim SqlStat As String

        Try
            SqlStr.Connection = Sql
            'SqlStat = "Select * from Login where username = @username and password = @password"
            SqlStat = "Select FullName, usertype from Login inner join Users on Users.Username = Login.username where Login.username = @username and Login.password = @password"

            Using cmd = New SqlCommand(SqlStat, Sql)
                cmd.Parameters.AddWithValue("@username", Username)
                cmd.Parameters.AddWithValue("@password", Password)

                Sql.Open()
                SqlReader = cmd.ExecuteReader

                If SqlReader.HasRows Then
                    MsgBox("Login Successful")

                    SqlReader.Read()

                    If SqlReader("usertype") = "Admin" Then
                        Dim a As New Admin()
                        a.Show()

                    Else
                        Dim dash As New Dashboard()
                        dash.Show()
                        dash.lblMessage.Content = "Hi " + SqlReader("FullName")

                    End If

                Else
                    MsgBox("Username or Password Incorrect")

                End If

                Sql.Close()

            End Using

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error" + ex.Message)

        End Try

    End Sub


End Class
