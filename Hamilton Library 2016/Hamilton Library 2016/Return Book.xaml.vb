Public Class Return_Book
    Dim objDM As New Database_Manager

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        dgBooks.ItemsSource = objDM.SearchBorrowedBooks("").DefaultView

    End Sub

    Private Sub btnSearchBook_Click(sender As Object, e As RoutedEventArgs) Handles btnSearchBook.Click
        dgBooks.ItemsSource = objDM.SearchBorrowedBooks(txtBookName.Text).DefaultView

    End Sub

    Private Sub btnReturnBook_Click(sender As Object, e As RoutedEventArgs) Handles btnReturnBook.Click
        Try
            If dgBooks.SelectedItem.Item(2) <> "" Then
                objDM.ReturnBook(dgBooks.SelectedItem.Item(0))
                dgBooks.ItemsSource = objDM.SearchBorrowedBooks("").DefaultView

            End If

        Catch ex As Exception
            MsgBox("Select a book")

        End Try

    End Sub

    Private Sub dgBooks_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgBooks.SelectionChanged
        Try
            txtBookName.Text = dgBooks.SelectedItem.Item(1)

        Catch ex As Exception

        End Try

    End Sub


End Class
