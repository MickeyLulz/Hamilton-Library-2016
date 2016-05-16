Public Class Admin
    Dim objDM As New Database_Manager

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        dgBooks.ItemsSource = objDM.SearchBooks("").DefaultView
        dgUsers.ItemsSource = objDM.SearchUser("").DefaultView

    End Sub

    Private Sub btnAddBook_Click(sender As Object, e As RoutedEventArgs) Handles btnAddBook.Click
        If txtBookName.Text <> "" And txtAuthor.Text <> "" Then
            objDM.AddBook(txtBookName.Text, txtAuthor.Text)

        End If

        dgBooks.ItemsSource = objDM.SearchBooks("").DefaultView

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As RoutedEventArgs) Handles btnSearch.Click
        dgBooks.ItemsSource = objDM.SearchBooks(txtSearch.Text).DefaultView

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtSearch.TextChanged
        dgBooks.ItemsSource = objDM.SearchBooks(txtSearch.Text).DefaultView

    End Sub

    Private Sub btnDeleteBook_Click(sender As Object, e As RoutedEventArgs) Handles btnDeleteBook.Click
        If dgBooks.SelectedItems.Count > 0 Then
            If MsgBox("Are you sure you want to delete the book?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                Dim BookID As Integer
                BookID = dgBooks.SelectedItem.Item(0)
                objDM.DeleteBook(BookID)
            End If
        Else
            MsgBox("Select a book")
        End If

        dgBooks.ItemsSource = objDM.SearchBooks("").DefaultView

    End Sub

    Private Sub btnEditBook_Click(sender As Object, e As RoutedEventArgs) Handles btnEditBook.Click
        If txtBookName.Text <> "" And txtAuthor.Text <> "" Then
            Dim BookID As Integer
            BookID = dgBooks.SelectedItem.Item(0)
            objDM.EditBooks(txtBookName.Text, txtAuthor.Text, BookID)

        End If

        dgBooks.ItemsSource = objDM.SearchBooks("").DefaultView

    End Sub

    Private Sub dgBooks_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgBooks.SelectionChanged
        Try
            txtBookName.Text = dgBooks.SelectedItem.Item(1)
            txtAuthor.Text = dgBooks.SelectedItem.Item(2)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtSearchUser_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtSearchUser.TextChanged
        dgUsers.ItemsSource = objDM.SearchUser(txtSearchUser.Text).DefaultView

    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As RoutedEventArgs) Handles btnAddUser.Click
        If txtUserName.Text <> "" And txtFullName.Text <> "" Then
            objDM.AddBook(txtUserName.Text, txtFullName.Text)

        End If

        dgBooks.ItemsSource = objDM.SearchBooks("").DefaultView
    End Sub

    Private Sub btnIssueBook_Click(sender As Object, e As RoutedEventArgs) Handles btnIssueBook.Click
        Dim iWindow As New Issue_Book

        iWindow.ShowDialog()

        'Me.Visibility = Windows.Visibility.Collapsed

        'Me.Visibility = Windows.Visibility.Visible

    End Sub

    Private Sub btnReturnBook_Click(sender As Object, e As RoutedEventArgs) Handles btnReturnBook.Click
        Dim rWindow As New Return_Book

        rWindow.ShowDialog()

    End Sub

    Private Sub btnStatsPage_Click(sender As Object, e As RoutedEventArgs) Handles btnStatsPage.Click
        Dim sWindow As New Stats_Page

        sWindow.ShowDialog()

    End Sub
End Class
