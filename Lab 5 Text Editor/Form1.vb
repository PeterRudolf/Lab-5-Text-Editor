Option Strict On

Imports System.IO

Public Class frmTextEditor
    Private Sub frmTextEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ''' <summary>
    ''' Closes the form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Application.Exit()
    End Sub

    ''' <summary>
    ''' Opens a file browser to allow the user to
    ''' select a file to edit
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Try
                Dim reader As New StreamReader(OpenFileDialog1.FileName)
                txtDisplay.Text() = reader.ReadToEnd()
                reader.Close()
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Saves the text from the text editor in a text
    ''' file that user names
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.Filter = "TXT FILES (*.txt*)|*.txt"
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, txtDisplay.Text(), False)
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Copies the user's selected text to the clipboard, 
    ''' and deletes the selected text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(txtDisplay.SelectedText)
        txtDisplay.SelectedText = ""
    End Sub

    ''' <summary>
    ''' Copies the user's selected text to the clipboard
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(txtDisplay.SelectedText)
    End Sub

    ''' <summary>
    ''' Pastes the text from the clipboard to the current
    ''' position of the user's cursor
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        txtDisplay.SelectedText = My.Computer.Clipboard.GetText()
    End Sub

    ''' <summary>
    ''' Creates a new text editor
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        txtDisplay.Text = ""
        OpenFileDialog1.FileName() = ""
    End Sub

    ''' <summary>
    ''' Saves the current text file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.Filter = "TXT FILES (*.txt*)|*.txt"
        Try
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, txtDisplay.Text(), True)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
End Class
