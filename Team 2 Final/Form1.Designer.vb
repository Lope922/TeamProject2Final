<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtBoxCityName = New System.Windows.Forms.TextBox()
        Me.stateComboBox = New System.Windows.Forms.ComboBox()
        Me.btnGetFlickr = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGetWeather = New System.Windows.Forms.Button()
        Me.btnGetMap = New System.Windows.Forms.Button()
        Me.forecastImageBox1 = New System.Windows.Forms.PictureBox()
        Me.forecastImageBox2 = New System.Windows.Forms.PictureBox()
        Me.forecastImageBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.picMap = New System.Windows.Forms.PictureBox()
        Me.lblday = New System.Windows.Forms.Label()
        Me.lblday2 = New System.Windows.Forms.Label()
        Me.lblday3 = New System.Windows.Forms.Label()
        Me.lblDescription1 = New System.Windows.Forms.Label()
        Me.lblDescription2 = New System.Windows.Forms.Label()
        Me.lblDescription3 = New System.Windows.Forms.Label()
        Me.apiBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        CType(Me.forecastImageBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.forecastImageBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.forecastImageBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBoxCityName
        '
        Me.txtBoxCityName.Location = New System.Drawing.Point(101, 29)
        Me.txtBoxCityName.Name = "txtBoxCityName"
        Me.txtBoxCityName.Size = New System.Drawing.Size(155, 20)
        Me.txtBoxCityName.TabIndex = 0
        '
        'stateComboBox
        '
        Me.stateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.stateComboBox.FormattingEnabled = True
        Me.stateComboBox.Items.AddRange(New Object() {"---", "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"})
        Me.stateComboBox.Location = New System.Drawing.Point(172, 58)
        Me.stateComboBox.Name = "stateComboBox"
        Me.stateComboBox.Size = New System.Drawing.Size(84, 21)
        Me.stateComboBox.TabIndex = 1
        '
        'btnGetFlickr
        '
        Me.btnGetFlickr.Location = New System.Drawing.Point(172, 85)
        Me.btnGetFlickr.Name = "btnGetFlickr"
        Me.btnGetFlickr.Size = New System.Drawing.Size(84, 23)
        Me.btnGetFlickr.TabIndex = 2
        Me.btnGetFlickr.Text = "Get Pics"
        Me.btnGetFlickr.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "City:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "State:"
        '
        'btnGetWeather
        '
        Me.btnGetWeather.Location = New System.Drawing.Point(172, 114)
        Me.btnGetWeather.Name = "btnGetWeather"
        Me.btnGetWeather.Size = New System.Drawing.Size(84, 23)
        Me.btnGetWeather.TabIndex = 5
        Me.btnGetWeather.Text = "Get Weather"
        Me.btnGetWeather.UseVisualStyleBackColor = True
        '
        'btnGetMap
        '
        Me.btnGetMap.Location = New System.Drawing.Point(172, 143)
        Me.btnGetMap.Name = "btnGetMap"
        Me.btnGetMap.Size = New System.Drawing.Size(84, 23)
        Me.btnGetMap.TabIndex = 6
        Me.btnGetMap.Text = "Get Map"
        Me.btnGetMap.UseVisualStyleBackColor = True
        '
        'forecastImageBox1
        '
        Me.forecastImageBox1.Location = New System.Drawing.Point(29, 194)
        Me.forecastImageBox1.Name = "forecastImageBox1"
        Me.forecastImageBox1.Size = New System.Drawing.Size(59, 50)
        Me.forecastImageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.forecastImageBox1.TabIndex = 7
        Me.forecastImageBox1.TabStop = False
        '
        'forecastImageBox2
        '
        Me.forecastImageBox2.Location = New System.Drawing.Point(126, 194)
        Me.forecastImageBox2.Name = "forecastImageBox2"
        Me.forecastImageBox2.Size = New System.Drawing.Size(59, 50)
        Me.forecastImageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.forecastImageBox2.TabIndex = 8
        Me.forecastImageBox2.TabStop = False
        '
        'forecastImageBox3
        '
        Me.forecastImageBox3.Location = New System.Drawing.Point(221, 194)
        Me.forecastImageBox3.Name = "forecastImageBox3"
        Me.forecastImageBox3.Size = New System.Drawing.Size(59, 50)
        Me.forecastImageBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.forecastImageBox3.TabIndex = 9
        Me.forecastImageBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(29, 343)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(201, 173)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(301, 343)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(199, 173)
        Me.PictureBox2.TabIndex = 11
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(565, 343)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(214, 173)
        Me.PictureBox3.TabIndex = 12
        Me.PictureBox3.TabStop = False
        '
        'picMap
        '
        Me.picMap.Location = New System.Drawing.Point(355, 30)
        Me.picMap.Name = "picMap"
        Me.picMap.Size = New System.Drawing.Size(424, 307)
        Me.picMap.TabIndex = 13
        Me.picMap.TabStop = False
        '
        'lblday
        '
        Me.lblday.AutoSize = True
        Me.lblday.Location = New System.Drawing.Point(41, 175)
        Me.lblday.Name = "lblday"
        Me.lblday.Size = New System.Drawing.Size(26, 13)
        Me.lblday.TabIndex = 14
        Me.lblday.Text = "Day"
        '
        'lblday2
        '
        Me.lblday2.AutoSize = True
        Me.lblday2.Location = New System.Drawing.Point(144, 175)
        Me.lblday2.Name = "lblday2"
        Me.lblday2.Size = New System.Drawing.Size(26, 13)
        Me.lblday2.TabIndex = 15
        Me.lblday2.Text = "Day"
        '
        'lblday3
        '
        Me.lblday3.AutoSize = True
        Me.lblday3.Location = New System.Drawing.Point(241, 175)
        Me.lblday3.Name = "lblday3"
        Me.lblday3.Size = New System.Drawing.Size(26, 13)
        Me.lblday3.TabIndex = 16
        Me.lblday3.Text = "Day"
        '
        'lblDescription1
        '
        Me.lblDescription1.AutoSize = True
        Me.lblDescription1.Location = New System.Drawing.Point(40, 251)
        Me.lblDescription1.Name = "lblDescription1"
        Me.lblDescription1.Size = New System.Drawing.Size(48, 13)
        Me.lblDescription1.TabIndex = 17
        Me.lblDescription1.Text = "Weather"
        '
        'lblDescription2
        '
        Me.lblDescription2.AutoSize = True
        Me.lblDescription2.Location = New System.Drawing.Point(133, 251)
        Me.lblDescription2.Name = "lblDescription2"
        Me.lblDescription2.Size = New System.Drawing.Size(48, 13)
        Me.lblDescription2.TabIndex = 18
        Me.lblDescription2.Text = "Weather"
        '
        'lblDescription3
        '
        Me.lblDescription3.AutoSize = True
        Me.lblDescription3.Location = New System.Drawing.Point(231, 251)
        Me.lblDescription3.Name = "lblDescription3"
        Me.lblDescription3.Size = New System.Drawing.Size(48, 13)
        Me.lblDescription3.TabIndex = 19
        Me.lblDescription3.Text = "Weather"
        '
        'apiBackgroundWorker
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 528)
        Me.Controls.Add(Me.lblDescription3)
        Me.Controls.Add(Me.lblDescription2)
        Me.Controls.Add(Me.lblDescription1)
        Me.Controls.Add(Me.lblday3)
        Me.Controls.Add(Me.lblday2)
        Me.Controls.Add(Me.lblday)
        Me.Controls.Add(Me.picMap)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.forecastImageBox3)
        Me.Controls.Add(Me.forecastImageBox2)
        Me.Controls.Add(Me.forecastImageBox1)
        Me.Controls.Add(Me.btnGetMap)
        Me.Controls.Add(Me.btnGetWeather)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGetFlickr)
        Me.Controls.Add(Me.stateComboBox)
        Me.Controls.Add(Me.txtBoxCityName)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.forecastImageBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.forecastImageBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.forecastImageBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBoxCityName As System.Windows.Forms.TextBox
    Friend WithEvents stateComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents btnGetFlickr As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnGetWeather As System.Windows.Forms.Button
    Friend WithEvents btnGetMap As System.Windows.Forms.Button
    Friend WithEvents forecastImageBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents forecastImageBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents forecastImageBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents lblday As System.Windows.Forms.Label
    Friend WithEvents lblday2 As System.Windows.Forms.Label
    Friend WithEvents lblday3 As System.Windows.Forms.Label
    Friend WithEvents lblDescription1 As System.Windows.Forms.Label
    Friend WithEvents lblDescription2 As System.Windows.Forms.Label
    Friend WithEvents lblDescription3 As System.Windows.Forms.Label
    Friend WithEvents apiBackgroundWorker As System.ComponentModel.BackgroundWorker

End Class
