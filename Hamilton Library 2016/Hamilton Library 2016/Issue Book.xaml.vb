Public Class Issue_Book
    Dim objDM As New Database_Manager

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        dgBooks.ItemsSource = objDM.SearchBooks("").DefaultView
        dgUsers.ItemsSource = objDM.SearchFullName("").DefaultView

    End Sub

    Private Sub btnSearchBook_Click(sender As Object, e As RoutedEventArgs) Handles btnSearchBook.Click
        dgBooks.ItemsSource = objDM.SearchBooks(txtBookName.Text).DefaultView

    End Sub

    Private Sub btnSearchCust_Click(sender As Object, e As RoutedEventArgs) Handles btnSearchCust.Click
        dgUsers.ItemsSource = objDM.SearchFullName(txtFullName.Text).DefaultView

    End Sub

    Private Sub btnIssueBook_Click(sender As Object, e As RoutedEventArgs) Handles btnIssueBook.Click
        Try
            If dgBooks.SelectedItem.Item(0) > 0 And dgUsers.SelectedItem.Item(0) > 0 Then
                objDM.IssueBook(dgBooks.SelectedItem.Item(0), dgUsers.SelectedItem.Item(0))

                dgBooks.ItemsSource = objDM.SearchBooks("").DefaultView
                dgUsers.ItemsSource = objDM.SearchFullName("").DefaultView

            End If
        Catch ex As Exception
            MsgBox("Error occured: " & ex.Message)

        End Try

    End Sub

    Private Sub dgBooks_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgBooks.SelectionChanged
        Try
            txtBookName.Text = dgBooks.SelectedItem.Item(1)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgUsers_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgUsers.SelectionChanged
        Try
            txtFullName.Text = dgUsers.SelectedItem.Item(1)

        Catch ex As Exception

        End Try

    End Sub


End Class
