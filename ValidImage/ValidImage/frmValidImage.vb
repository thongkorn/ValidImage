#Region "ABOUT"
' / -----------------------------------------------------------------------------
' / Developer : Mr.Surapon Yodsanga (Thongkorn Tubtimkrob)
' / eMail : thongkorn@hotmail.com
' / URL: http://www.g2gnet.com (Khon Kaen - Thailand)
' / Facebook: https://www.facebook.com/g2gnet (Thailand only)
' / Facebook: https://www.facebook.com/commonindy (Worldwide)
' / More Info: http://www.g2gnet.com/webboard
' / 
' / Purpose: Check if it is a graphic file or not, and read the image scale.
' / Microsoft Visual Basic .NET (2010)
' /
' / This is open source code under @CopyLeft by Thongkorn/Common Tubtimkrob.
' / You can modify and/or distribute without to inform the developer.
' / --------------------------------------------------------------------------
#End Region

Public Class frmValidImage

    Private Sub frmValidImage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label1.Text = ""
        Label2.Text = ""
    End Sub

    ' / --------------------------------------------------------------------------
    Function ValidImage(filename As String) As Boolean
        Try
            Dim img As System.Drawing.Image = System.Drawing.Image.FromFile(filename)
            Return True
        Catch ex As OutOfMemoryException
            Return False
        End Try
    End Function

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        Dim dlgImage As OpenFileDialog = New OpenFileDialog()
        '/ Open File Dialog
        With dlgImage
            .Title = "Select images"
            '/ Image types.
            .Filter = "Images types (*.jpg;*.png;*.gif;*.bmp)|*.jpg;*.png;*.gif;*.bmp"
            .FilterIndex = 1
            .RestoreDirectory = True
        End With
        '/ Select OK after Browse ...
        If dlgImage.ShowDialog() = DialogResult.OK Then
            '/ Valid Images.
            If Not ValidImage(dlgImage.FileName) Then
                MessageBox.Show("The file you selected is not an image file.", "Report Status", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            '/ Get file size.
            Dim info As New System.IO.FileInfo(dlgImage.FileName)
            Label1.Text = "File Size: " & Format(info.Length / 1024, "#,##0.00") & " KB."
            '/ Get the scale.
            Dim img = Image.FromFile(dlgImage.FileName)
            Label2.Text = "Width x Height : " & (Format(Val(img.Width.ToString), "#,##0") & " x " & Format(Val(img.Height.ToString), "#,##0")) & " Pixels."
            '/
            picData.Image = Image.FromFile(dlgImage.FileName)
        End If

    End Sub

End Class
