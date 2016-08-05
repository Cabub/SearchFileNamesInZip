Imports System.IO
Imports System.IO.Compression
Imports System.Text.RegularExpressions

Module Module1

    Sub Main(ByVal Args() As String)
        Try
            Dim RegX As New Regex(Args(0), RegexOptions.IgnoreCase)
            If Not Args(1).EndsWith("\") Then
                Args(1) = Args(1) & "\"
            End If
            If Directory.Exists(Args(1)) Then
                For Each filename As String In Directory.GetFiles(Args(1))
                    If filename.EndsWith(".zip") Then
                        Dim arch As New ZipArchive(File.Open(filename, FileMode.Open))
                        For Each f As ZipArchiveEntry In arch.Entries
                            If RegX.IsMatch(f.Name) Then
                                Console.WriteLine(Args(1) & filename & "\" & f.FullName)
                            End If
                        Next
                    End If
                Next
            End If
        Catch ex As Exception
            Console.Error.WriteLine("ERROR: " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

End Module
