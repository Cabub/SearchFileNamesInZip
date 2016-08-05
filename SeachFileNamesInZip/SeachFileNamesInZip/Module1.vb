Imports System.IO
Imports System.IO.Compression
Imports System.Text.RegularExpressions

Module Module1

    Sub Main(ByVal Args() As String)
        Try
            Dim RegX As New Regex(Args(0), RegexOptions.IgnoreCase)
            Dim arch As New ZipArchive(File.Open(Args(1), FileMode.Open))
            For Each f As ZipArchiveEntry In arch.Entries
                If RegX.IsMatch(f.Name) Then
                    Console.WriteLine(Args(1) & "\" & f.FullName)
                End If
            Next
        Catch ex As Exception
            Console.Error.WriteLine("ERROR: " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

End Module
