Public Class Stats_Page
    Dim objDM As New Database_Manager

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        lblNoBooks.Content = objDM.TotalBooks
        lblNoUsers.Content = objDM.TotalUsers
        lblNoIssuedBooks.Content = objDM.TotalBooksIssued

    End Sub
End Class
