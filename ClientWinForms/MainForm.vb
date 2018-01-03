
Imports System.Net.Sockets
Imports System.Text

Public Class MainForm
    'This is not test
    Dim _client As TcpClient
    Dim ApplicationDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
    Dim cfgpath = System.IO.Path.Combine(ApplicationDir, "Configuration.txt")
    Dim SL11 As String
    Dim SL12 As String
    Dim SL21 As String
    Dim SL22 As String
    Dim SL23 As String
    Dim SL31 As String
    Dim SL32 As String
    Dim SL33 As String
    Dim SL43 As String
    Dim SR12 As String
    Dim SR13 As String
    Dim SR21 As String
    Dim SR22 As String
    Dim SR23 As String
    Dim SR31 As String
    Dim SR32 As String
    Dim SR33 As String
    Dim SR41 As String
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub

    Private Sub ReceiveMessages(state As Object)
        Try
            While True
                Dim ns As NetworkStream = _client.GetStream()
                Dim toReceive(100000) As Byte
                ns.Read(toReceive, 0, toReceive.Length)
                Dim txt As String = Encoding.ASCII.GetString(toReceive)
                Label1.Text = txt
                If String.Equals(Label1.Text, "R13") Then Process.Start(SR13)
                If String.Equals(Label1.Text, "R12") Then Process.Start(SR12)
                If String.Equals(Label1.Text, "R21") Then Process.Start(SR21)
                If String.Equals(Label1.Text, "R22") Then Process.Start(SR22)
                If String.Equals(Label1.Text, "R23") Then Process.Start(SR23)
                If String.Equals(Label1.Text, "R31") Then Process.Start(SR31)
                If String.Equals(Label1.Text, "R32") Then Process.Start(SR32)
                If String.Equals(Label1.Text, "R33") Then Process.Start(SR33)
                If String.Equals(Label1.Text, "R41") Then Process.Start(SR41)
                If String.Equals(Label1.Text, "L11") Then Process.Start(SL11)
                If String.Equals(Label1.Text, "L12") Then Process.Start(SL12)
                If String.Equals(Label1.Text, "L21") Then Process.Start(SL21)
                If String.Equals(Label1.Text, "L22") Then Process.Start(SL22)
                If String.Equals(Label1.Text, "L23") Then Process.Start(SL23)
                If String.Equals(Label1.Text, "L31") Then Process.Start(SL31)
                If String.Equals(Label1.Text, "L32") Then Process.Start(SL32)
                If String.Equals(Label1.Text, "L33") Then Process.Start(SL33)
                If String.Equals(Label1.Text, "L43") Then Process.Start(SL43)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Connectkey_Click(sender As Object, e As EventArgs) Handles Connectkey.Click
        Try
            Dim ip As String = "192.168.0.100"
            Dim port As Integer = 23
            _client = New TcpClient(ip, port)
            CheckForIllegalCrossThreadCalls = False
            Threading.ThreadPool.QueueUserWorkItem(AddressOf ReceiveMessages)
            AcceptButton = Sendkey
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Sendkey_Click(sender As Object, e As EventArgs) Handles Sendkey.Click
        Try
            Dim ns As NetworkStream = _client.GetStream()
            ns.Write(Encoding.ASCII.GetBytes(TextBox1.Text), 0, TextBox1.Text.Length)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub createfile()
        If Not System.IO.File.Exists(cfgpath) Then
            System.IO.File.Create(cfgpath).Dispose()
        End If
    End Sub
    Private Sub readconfig(path As String)
        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader(path)
        Dim stringReader As String
        stringReader = fileReader.ReadLine()
        SL11 = stringReader
        stringReader = fileReader.ReadLine()
        SL12 = stringReader
        stringReader = fileReader.ReadLine()
        SL21 = stringReader
        stringReader = fileReader.ReadLine()
        SL22 = stringReader
        stringReader = fileReader.ReadLine()
        SL23 = stringReader
        stringReader = fileReader.ReadLine()
        SL31 = stringReader
        stringReader = fileReader.ReadLine()
        SL32 = stringReader
        stringReader = fileReader.ReadLine()
        SL33 = stringReader
        stringReader = fileReader.ReadLine()
        SL43 = stringReader
        stringReader = fileReader.ReadLine()
        SR12 = stringReader
        stringReader = fileReader.ReadLine()
        SR13 = stringReader
        stringReader = fileReader.ReadLine()
        SR21 = stringReader
        stringReader = fileReader.ReadLine()
        SR22 = stringReader
        stringReader = fileReader.ReadLine()
        SR23 = stringReader
        stringReader = fileReader.ReadLine()
        SR31 = stringReader
        stringReader = fileReader.ReadLine()
        SR32 = stringReader
        stringReader = fileReader.ReadLine()
        SR33 = stringReader
        stringReader = fileReader.ReadLine()
        SR41 = stringReader
        fileReader.Close()
    End Sub
    Private Sub writeconfig(path As String)
        System.IO.File.Create(path).Dispose()
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(path, True)
        file.WriteLine(SL11)
        file.WriteLine(SL12)
        file.WriteLine(SL21)
        file.WriteLine(SL22)
        file.WriteLine(SL23)
        file.WriteLine(SL31)
        file.WriteLine(SL32)
        file.WriteLine(SL33)
        file.WriteLine(SL43)
        file.WriteLine(SR12)
        file.WriteLine(SR13)
        file.WriteLine(SR21)
        file.WriteLine(SR22)
        file.WriteLine(SR23)
        file.WriteLine(SR31)
        file.WriteLine(SR32)
        file.WriteLine(SR33)
        file.WriteLine(SR41)
        file.Close()
    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        createfile()
        readconfig(cfgpath)
        'Button1_Click(sender, e)
    End Sub

    Private Sub L11_Click(sender As Object, e As EventArgs) Handles L11.Click
        activekey.Text = "L11"
        fshow.Text = SL11
    End Sub
    Private Sub L12_Click(sender As Object, e As EventArgs) Handles L12.Click
        activekey.Text = "L12"
        fshow.Text = SL12
    End Sub
    Private Sub L21_Click(sender As Object, e As EventArgs) Handles L21.Click
        activekey.Text = "L21"
        fshow.Text = SL21
    End Sub
    Private Sub L22_Click(sender As Object, e As EventArgs) Handles L22.Click
        activekey.Text = "L22"
        fshow.Text = SL22
    End Sub
    Private Sub L23_Click(sender As Object, e As EventArgs) Handles L23.Click
        activekey.Text = "L23"
        fshow.Text = SL23
    End Sub
    Private Sub L31_Click(sender As Object, e As EventArgs) Handles L31.Click
        activekey.Text = "L31"
        fshow.Text = SL31
    End Sub
    Private Sub L32_Click(sender As Object, e As EventArgs) Handles L32.Click
        activekey.Text = "L32"
        fshow.Text = SL32
    End Sub
    Private Sub L33_Click(sender As Object, e As EventArgs) Handles L33.Click
        activekey.Text = "L33"
        fshow.Text = SL33
    End Sub
    Private Sub L43_Click(sender As Object, e As EventArgs) Handles L43.Click
        activekey.Text = "L43"
        fshow.Text = SL43
    End Sub
    Private Sub R13_Click(sender As Object, e As EventArgs) Handles R13.Click
        activekey.Text = "R13"
        fshow.Text = SR13
    End Sub
    Private Sub R12_Click(sender As Object, e As EventArgs) Handles R12.Click
        activekey.Text = "R12"
        fshow.Text = SR12
    End Sub
    Private Sub R21_Click(sender As Object, e As EventArgs) Handles R21.Click
        activekey.Text = "R21"
        fshow.Text = SR21
    End Sub
    Private Sub R22_Click(sender As Object, e As EventArgs) Handles R22.Click
        activekey.Text = "R22"
        fshow.Text = SR22
    End Sub
    Private Sub R23_Click(sender As Object, e As EventArgs) Handles R23.Click
        activekey.Text = "R23"
        fshow.Text = SR23
    End Sub
    Private Sub R31_Click(sender As Object, e As EventArgs) Handles R31.Click
        activekey.Text = "R31"
        fshow.Text = SR31
    End Sub
    Private Sub R32_Click(sender As Object, e As EventArgs) Handles R32.Click
        activekey.Text = "R32"
        fshow.Text = SR32
    End Sub
    Private Sub R33_Click(sender As Object, e As EventArgs) Handles R33.Click
        activekey.Text = "R33"
        fshow.Text = SR33
    End Sub
    Private Sub R41_Click(sender As Object, e As EventArgs) Handles R41.Click
        activekey.Text = "R41"
        fshow.Text = SR41
    End Sub

    Private Sub savekey_Click(sender As Object, e As EventArgs) Handles savekey.Click
        If String.Equals(activekey.Text, "R13") Then SR13 = fshow.Text
        If String.Equals(activekey.Text, "R12") Then SR12 = fshow.Text
        If String.Equals(activekey.Text, "R21") Then SR21 = fshow.Text
        If String.Equals(activekey.Text, "R22") Then SR22 = fshow.Text
        If String.Equals(activekey.Text, "R23") Then SR23 = fshow.Text
        If String.Equals(activekey.Text, "R31") Then SR31 = fshow.Text
        If String.Equals(activekey.Text, "R32") Then SR32 = fshow.Text
        If String.Equals(activekey.Text, "R33") Then SR33 = fshow.Text
        If String.Equals(activekey.Text, "R41") Then SR41 = fshow.Text
        If String.Equals(activekey.Text, "L11") Then SL11 = fshow.Text
        If String.Equals(activekey.Text, "L12") Then SL12 = fshow.Text
        If String.Equals(activekey.Text, "L21") Then SL21 = fshow.Text
        If String.Equals(activekey.Text, "L22") Then SL22 = fshow.Text
        If String.Equals(activekey.Text, "L23") Then SL23 = fshow.Text
        If String.Equals(activekey.Text, "L31") Then SL31 = fshow.Text
        If String.Equals(activekey.Text, "L32") Then SL32 = fshow.Text
        If String.Equals(activekey.Text, "L33") Then SL33 = fshow.Text
        If String.Equals(activekey.Text, "L43") Then SL43 = fshow.Text
    End Sub
    Private Sub Runkey_Click(sender As Object, e As EventArgs) Handles Runkey.Click
        If String.Equals(activekey.Text, "R13") Then Process.Start(SR13)
        If String.Equals(activekey.Text, "R12") Then Process.Start(SR12)
        If String.Equals(activekey.Text, "R21") Then Process.Start(SR21)
        If String.Equals(activekey.Text, "R22") Then Process.Start(SR22)
        If String.Equals(activekey.Text, "R23") Then Process.Start(SR23)
        If String.Equals(activekey.Text, "R31") Then Process.Start(SR31)
        If String.Equals(activekey.Text, "R32") Then Process.Start(SR32)
        If String.Equals(activekey.Text, "R33") Then Process.Start(SR33)
        If String.Equals(activekey.Text, "R41") Then Process.Start(SR41)
        If String.Equals(activekey.Text, "L11") Then Process.Start(SL11)
        If String.Equals(activekey.Text, "L12") Then Process.Start(SL12)
        If String.Equals(activekey.Text, "L21") Then Process.Start(SL21)
        If String.Equals(activekey.Text, "L22") Then Process.Start(SL22)
        If String.Equals(activekey.Text, "L23") Then Process.Start(SL23)
        If String.Equals(activekey.Text, "L31") Then Process.Start(SL31)
        If String.Equals(activekey.Text, "L32") Then Process.Start(SL32)
        If String.Equals(activekey.Text, "L33") Then Process.Start(SL33)
        If String.Equals(activekey.Text, "L43") Then Process.Start(SL43)
    End Sub
    Private Sub Closebutton_Click(sender As Object, e As EventArgs) Handles Closebutton.Click
        Close()
    End Sub
    Private Sub Minimize_Click(sender As Object, e As EventArgs) Handles Minimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub SaveConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveConfigToolStripMenuItem.Click
        writeconfig(cfgpath)
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Credits : G Ravi Kumar")
    End Sub
    Private Sub SaveConfigAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveConfigAsToolStripMenuItem.Click
        SaveFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
        Then
            writeconfig(SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub LoadConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadConfigToolStripMenuItem.Click
        Dim myStream As IO.Stream = Nothing

        OpenFileDialog1.InitialDirectory = ApplicationDir
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    readconfig(OpenFileDialog1.FileName)
                    myStream.Close()
                    activekey.Text = "Select A key..."
                    fshow.Text = ""
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

End Class

