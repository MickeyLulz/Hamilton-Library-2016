

Imports System.Data.SqlClient
Imports System.Data

Public Class Database_Manager
    Dim Sql As New SqlConnection("Data Source=shar;Initial Catalog=Mickey_2016;Integrated Security=True")
    Dim SqlStr As New SqlCommand
    Dim SqlReader As SqlDataReader
    Dim SqlStat As String

    Public Sub AddBook(BookName As String, Author As String)
        Try
            SqlStr.Connection = Sql
            SqlStat = "Insert into Books(BookName, Author, Available) values(@BookName, @BookAuthor, @Available)"
            Using cmd = New SqlCommand(SqlStat, Sql)
                cmd.Parameters.AddWithValue("@BookName", BookName)
                cmd.Parameters.AddWithValue("@BookAuthor", Author)
                cmd.Parameters.AddWithValue("@Available", "Yes")
                Sql.Open()

                Dim affectedRecords = cmd.ExecuteNonQuery()

                If affectedRecords > 0 Then
                    MsgBox("Book Added")

                End If

                Sql.Close()

            End Using

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error Occured: " & ex.Message)

        End Try

    End Sub

    Public Function SearchBooks(BookName As String) As DataTable
        Dim dt As New DataTable

        Try
            SqlStr.Connection = Sql
            SqlStat = "Select * from Books where BookName like '%' + @BookName + '%'"
            Using cmd = New SqlCommand(SqlStat, Sql)
                cmd.Parameters.AddWithValue("@BookName", BookName)
                Sql.Open()
                SqlReader = cmd.ExecuteReader

                If SqlReader.HasRows Then
                    dt.Load(SqlReader)

                End If

                Sql.Close()

            End Using

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error Occured: " & ex.Message)

        End Try

        Return dt

    End Function

    Public Sub DeleteBook(BookID As Integer)
        Try
            SqlStr.Connection = Sql
            SqlStat = "Delete from Books where BookID = @BookID"
            Using cmd = New SqlCommand(SqlStat, Sql)
                cmd.Parameters.AddWithValue("@BookID", BookID)
                Sql.Open()

                Dim affectedRecords = cmd.ExecuteNonQuery()

                If affectedRecords > 0 Then
                    MsgBox("Book Deleted")
                End If

                Sql.Close()

            End Using

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error Occured: " & ex.Message)

        End Try

    End Sub

    Public Sub EditBooks(BookName As String, Author As String, BookID As Integer)
        Try
            SqlStr.Connection = Sql
            SqlStat = "Update Books set BookName = @BookName, Author = @Author where BookID = @BookID"
            Using cmd = New SqlCommand(SqlStat, Sql)
                cmd.Parameters.AddWithValue("@BookName", BookName)
                cmd.Parameters.AddWithValue("@Author", Author)
                cmd.Parameters.AddWithValue("@BookID", BookID)
                Sql.Open()

                Dim affectedRecords = cmd.ExecuteNonQuery()

                If affectedRecords > 0 Then
                    MsgBox("Book Modified")
                End If

                Sql.Close()

            End Using

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error Occured: " & ex.Message)
        End Try
    End Sub

    Public Function SearchUser(UserName As String) As DataTable
        Dim dt As New DataTable

        Try
            SqlStr.Connection = Sql
            SqlStat = "Select * from Users where UserName like '%' + @UserName + '%'"
            Using cmd = New SqlCommand(SqlStat, Sql)
                cmd.Parameters.AddWithValue("@UserName", UserName)
                Sql.Open()
                SqlReader = cmd.ExecuteReader

                If SqlReader.HasRows Then
                    dt.Load(SqlReader)

                End If

                Sql.Close()

            End Using

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error Occured: " & ex.Message)

        End Try

        Return dt

    End Function

    Public Sub AddBook(FullName As String, Age As Integer, UserName As String)
        Try
            SqlStr.Connection = Sql
            SqlStat = "Insert into Users(FullName, Age, UserName) values(@FullName, @Age, @UserName)"
            Using cmd = New SqlCommand(SqlStat, Sql)
                cmd.Parameters.AddWithValue("@FullName", FullName)
                cmd.Parameters.AddWithValue("@Age", Age)
                cmd.Parameters.AddWithValue("@UserName", UserName)
                Sql.Open()

                Dim affectedRecords = cmd.ExecuteNonQuery()

                If affectedRecords > 0 Then
                    MsgBox("User Added")

                End If

                Sql.Close()

            End Using

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error Occured: " & ex.Message)

        End Try

    End Sub

    Public Function SearchFullName(FullName As String) As DataTable
        Dim dt As New DataTable

        Try
            SqlStr.Connection = Sql
            SqlStat = "Select * from Users where FullName like '%' + @FullName + '%'"
            Using cmd = New SqlCommand(SqlStat, Sql)
                cmd.Parameters.AddWithValue("@FullName", FullName)
                Sql.Open()
                SqlReader = cmd.ExecuteReader

                If SqlReader.HasRows Then
                    dt.Load(SqlReader)

                End If

                Sql.Close()

            End Using

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error Occured: " & ex.Message)

        End Try

        Return dt

    End Function

    Public Sub IssueBook(BookID As Integer, UserID As Integer)
        Try
            SqlStr.Connection = Sql
            SqlStat = "Update Books set Available = 'No', Borrower = @Borrower where BookID = @BookID"

            Using cmd = New SqlCommand(SqlStat, Sql)
                cmd.Parameters.AddWithValue("@Borrower", UserID)
                cmd.Parameters.AddWithValue("@BookID", BookID)
                SqlStr.CommandText = SqlStat
                Sql.Open()

                Dim affectedRecords As Int32 = cmd.ExecuteNonQuery()

                If affectedRecords > 0 Then
                    MsgBox("Book Issued")
                End If

                Sql.Close()

            End Using

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error occured: " & ex.Message)

        End Try

    End Sub

    Public Sub ReturnBook(BookId As Integer)
        Try
            SqlStr.Connection = Sql
            SqlStat = "Update Books set Available = 'Yes', Borrower = null where BookID = @BookID"

            Using cmd = New SqlCommand(SqlStat, Sql)
                cmd.Parameters.AddWithValue("@BookID", BookId)
                SqlStr.CommandText = SqlStat
                Sql.Open()

                Dim affectedRecords As Int32 = cmd.ExecuteNonQuery()

                If affectedRecords > 0 Then
                    MsgBox("Book Returned")

                End If

                Sql.Close()

            End Using

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error occured: " & ex.Message)

        End Try

    End Sub

    Public Function SearchBorrowedBooks(BookName As String) As DataTable
        Dim dt As New DataTable

        Try
            SqlStr.Connection = Sql
            SqlStat = "Select * from Books where Available like 'No'"
            Using cmd = New SqlCommand(SqlStat, Sql)
                'cmd.Parameters.AddWithValue("@BookName", BookName)
                Sql.Open()
                SqlReader = cmd.ExecuteReader

                If SqlReader.HasRows Then
                    dt.Load(SqlReader)

                End If

                Sql.Close()

            End Using

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error Occured: " & ex.Message)

        End Try

        Return dt

    End Function

    Public Function TotalUsers() As Int32
        Dim UserCount As Int32

        Try
            SqlStr.Connection = Sql
            SqlStat = "Select count(*) as UserCount from Users"
            SqlStr.CommandText = SqlStat

            Sql.Open()
            SqlReader = SqlStr.ExecuteReader()

            If SqlReader.HasRows Then
                SqlReader.Read()
                UserCount = SqlReader("UserCount")
            End If

            Sql.Close()

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error occured: " & ex.Message)

        End Try

        Return UserCount

    End Function

    Public Function TotalBooks() As Int32
        Dim BookCount As Int32

        Try
            SqlStr.Connection = Sql
            SqlStat = "Select count(*) as BookCount from Books"
            SqlStr.CommandText = SqlStat

            Sql.Open()
            SqlReader = SqlStr.ExecuteReader()

            If SqlReader.HasRows Then
                SqlReader.Read()
                BookCount = SqlReader("BookCount")
            End If

            Sql.Close()

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error occured: " & ex.Message)

        End Try

        Return BookCount

    End Function

    Public Function TotalBooksIssued() As Int32
        Dim BookCount As Int32

        Try
            SqlStr.Connection = Sql
            SqlStat = "Select count(*) as BookCount from Books where Available = 'No'"
            SqlStr.CommandText = SqlStat

            Sql.Open()
            SqlReader = SqlStr.ExecuteReader()

            If SqlReader.HasRows Then
                SqlReader.Read()
                BookCount = SqlReader("BookCount")
            End If

            Sql.Close()

        Catch ex As Exception
            Sql.Close()
            MsgBox("Error occured: " & ex.Message)

        End Try

        Return BookCount

    End Function



End Class
