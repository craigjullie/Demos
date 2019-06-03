<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OliverMainForm
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
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OliverMainForm))
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ScriptsTreeView = New System.Windows.Forms.TreeView()
    Me.TreeViewImageList = New System.Windows.Forms.ImageList(Me.components)
    Me.OliverTabControl = New System.Windows.Forms.TabControl()
    Me.WelcomeTabPage = New System.Windows.Forms.TabPage()
    Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
    Me.ExecuteTabPage = New System.Windows.Forms.TabPage()
    Me.ExportingLabel = New System.Windows.Forms.Label()
    Me.DelimiterLabel = New System.Windows.Forms.Label()
    Me.DelimiterTextBox = New System.Windows.Forms.TextBox()
    Me.ExportCSVButton = New System.Windows.Forms.Button()
    Me.InstructionsTextbox = New System.Windows.Forms.TextBox()
    Me.ResultsGroupBoxMarker = New System.Windows.Forms.GroupBox()
    Me.RunButtonNoParamsMarker = New System.Windows.Forms.Label()
    Me.RunButtonMarker = New System.Windows.Forms.Label()
    Me.RowsReturnedLabel = New System.Windows.Forms.Label()
    Me.ExportExcelButton = New System.Windows.Forms.Button()
    Me.ScriptNameLabel = New System.Windows.Forms.Label()
    Me.RunProcButton = New System.Windows.Forms.Button()
    Me.ResultsGroupBox = New System.Windows.Forms.GroupBox()
    Me.ResultsTabControl = New System.Windows.Forms.TabControl()
    Me.FirstResultTabPage = New System.Windows.Forms.TabPage()
    Me.ResultsDataGridView = New System.Windows.Forms.DataGridView()
    Me.ParametersGroupBox = New System.Windows.Forms.GroupBox()
    Me.ParametersDataGridView = New System.Windows.Forms.DataGridView()
    Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.TypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ValueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.PickValueColumn = New System.Windows.Forms.DataGridViewButtonColumn()
    Me.ParamBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.PropertiesTabPage = New System.Windows.Forms.TabPage()
    Me.ObjectNameLabel = New System.Windows.Forms.Label()
    Me.PropsDatagridView = New System.Windows.Forms.DataGridView()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DatabaseCombobox = New System.Windows.Forms.ComboBox()
    Me.SaveExcelDialog = New System.Windows.Forms.SaveFileDialog()
    Me.RefreshProcsButton = New System.Windows.Forms.Button()
    Me.ShowConnectionStringButton = New System.Windows.Forms.Button()
    Me.EnvironmentCombobox = New System.Windows.Forms.ComboBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.SaveCSVDialog = New System.Windows.Forms.SaveFileDialog()
    Me.OliverTabControl.SuspendLayout()
    Me.WelcomeTabPage.SuspendLayout()
    Me.ExecuteTabPage.SuspendLayout()
    Me.ResultsGroupBox.SuspendLayout()
    Me.ResultsTabControl.SuspendLayout()
    Me.FirstResultTabPage.SuspendLayout()
    CType(Me.ResultsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ParametersGroupBox.SuspendLayout()
    CType(Me.ParametersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ParamBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.PropertiesTabPage.SuspendLayout()
    CType(Me.PropsDatagridView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ScriptsTreeView
    '
    Me.ScriptsTreeView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.ScriptsTreeView.ImageIndex = 0
    Me.ScriptsTreeView.ImageList = Me.TreeViewImageList
    Me.ScriptsTreeView.Location = New System.Drawing.Point(16, 146)
    Me.ScriptsTreeView.Margin = New System.Windows.Forms.Padding(4)
    Me.ScriptsTreeView.Name = "ScriptsTreeView"
    Me.ScriptsTreeView.SelectedImageIndex = 0
    Me.ScriptsTreeView.Size = New System.Drawing.Size(359, 514)
    Me.ScriptsTreeView.TabIndex = 0
    '
    'TreeViewImageList
    '
    Me.TreeViewImageList.ImageStream = CType(resources.GetObject("TreeViewImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.TreeViewImageList.TransparentColor = System.Drawing.Color.Transparent
    Me.TreeViewImageList.Images.SetKeyName(0, "Arrow.ico")
    Me.TreeViewImageList.Images.SetKeyName(1, "Folder.ico")
    Me.TreeViewImageList.Images.SetKeyName(2, "ArrowSelected.ico")
    Me.TreeViewImageList.Images.SetKeyName(3, "TableImports.ico")
    Me.TreeViewImageList.Images.SetKeyName(4, "Scripts.ico")
    '
    'OliverTabControl
    '
    Me.OliverTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.OliverTabControl.Controls.Add(Me.WelcomeTabPage)
    Me.OliverTabControl.Controls.Add(Me.ExecuteTabPage)
    Me.OliverTabControl.Controls.Add(Me.PropertiesTabPage)
    Me.OliverTabControl.Location = New System.Drawing.Point(383, 16)
    Me.OliverTabControl.Margin = New System.Windows.Forms.Padding(4)
    Me.OliverTabControl.Name = "OliverTabControl"
    Me.OliverTabControl.SelectedIndex = 0
    Me.OliverTabControl.Size = New System.Drawing.Size(832, 646)
    Me.OliverTabControl.TabIndex = 1
    '
    'WelcomeTabPage
    '
    Me.WelcomeTabPage.Controls.Add(Me.WebBrowser1)
    Me.WelcomeTabPage.Location = New System.Drawing.Point(4, 25)
    Me.WelcomeTabPage.Margin = New System.Windows.Forms.Padding(4)
    Me.WelcomeTabPage.Name = "WelcomeTabPage"
    Me.WelcomeTabPage.Padding = New System.Windows.Forms.Padding(4)
    Me.WelcomeTabPage.Size = New System.Drawing.Size(824, 617)
    Me.WelcomeTabPage.TabIndex = 1
    Me.WelcomeTabPage.Text = "Welcome"
    Me.WelcomeTabPage.UseVisualStyleBackColor = True
    '
    'WebBrowser1
    '
    Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.WebBrowser1.Location = New System.Drawing.Point(4, 4)
    Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
    Me.WebBrowser1.Name = "WebBrowser1"
    Me.WebBrowser1.Size = New System.Drawing.Size(816, 609)
    Me.WebBrowser1.TabIndex = 0
    Me.WebBrowser1.Url = New System.Uri("\\survfs01\v1\ClickOnceInstalls\Prod\Oliver\OliverWelcome.htm", System.UriKind.Absolute)
    '
    'ExecuteTabPage
    '
    Me.ExecuteTabPage.Controls.Add(Me.ExportingLabel)
    Me.ExecuteTabPage.Controls.Add(Me.DelimiterLabel)
    Me.ExecuteTabPage.Controls.Add(Me.DelimiterTextBox)
    Me.ExecuteTabPage.Controls.Add(Me.ExportCSVButton)
    Me.ExecuteTabPage.Controls.Add(Me.InstructionsTextbox)
    Me.ExecuteTabPage.Controls.Add(Me.ResultsGroupBoxMarker)
    Me.ExecuteTabPage.Controls.Add(Me.RunButtonNoParamsMarker)
    Me.ExecuteTabPage.Controls.Add(Me.RunButtonMarker)
    Me.ExecuteTabPage.Controls.Add(Me.RowsReturnedLabel)
    Me.ExecuteTabPage.Controls.Add(Me.ExportExcelButton)
    Me.ExecuteTabPage.Controls.Add(Me.ScriptNameLabel)
    Me.ExecuteTabPage.Controls.Add(Me.RunProcButton)
    Me.ExecuteTabPage.Controls.Add(Me.ResultsGroupBox)
    Me.ExecuteTabPage.Controls.Add(Me.ParametersGroupBox)
    Me.ExecuteTabPage.Location = New System.Drawing.Point(4, 25)
    Me.ExecuteTabPage.Margin = New System.Windows.Forms.Padding(4)
    Me.ExecuteTabPage.Name = "ExecuteTabPage"
    Me.ExecuteTabPage.Padding = New System.Windows.Forms.Padding(4)
    Me.ExecuteTabPage.Size = New System.Drawing.Size(824, 617)
    Me.ExecuteTabPage.TabIndex = 0
    Me.ExecuteTabPage.Text = "Execute"
    Me.ExecuteTabPage.UseVisualStyleBackColor = True
    '
    'ExportingLabel
    '
    Me.ExportingLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ExportingLabel.AutoSize = True
    Me.ExportingLabel.ForeColor = System.Drawing.Color.Red
    Me.ExportingLabel.Location = New System.Drawing.Point(128, 582)
    Me.ExportingLabel.Name = "ExportingLabel"
    Me.ExportingLabel.Size = New System.Drawing.Size(177, 16)
    Me.ExportingLabel.TabIndex = 1
    Me.ExportingLabel.Text = "Exporting data, please wait..."
    Me.ExportingLabel.Visible = False
    '
    'DelimiterLabel
    '
    Me.DelimiterLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.DelimiterLabel.AutoSize = True
    Me.DelimiterLabel.Location = New System.Drawing.Point(313, 582)
    Me.DelimiterLabel.Name = "DelimiterLabel"
    Me.DelimiterLabel.Size = New System.Drawing.Size(155, 16)
    Me.DelimiterLabel.TabIndex = 14
    Me.DelimiterLabel.Text = "CSV Delimiter (Optional):"
    '
    'DelimiterTextBox
    '
    Me.DelimiterTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.DelimiterTextBox.Location = New System.Drawing.Point(474, 579)
    Me.DelimiterTextBox.MaxLength = 1
    Me.DelimiterTextBox.Name = "DelimiterTextBox"
    Me.DelimiterTextBox.Size = New System.Drawing.Size(45, 22)
    Me.DelimiterTextBox.TabIndex = 13
    '
    'ExportCSVButton
    '
    Me.ExportCSVButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ExportCSVButton.Location = New System.Drawing.Point(526, 576)
    Me.ExportCSVButton.Margin = New System.Windows.Forms.Padding(4)
    Me.ExportCSVButton.Name = "ExportCSVButton"
    Me.ExportCSVButton.Size = New System.Drawing.Size(131, 28)
    Me.ExportCSVButton.TabIndex = 12
    Me.ExportCSVButton.Text = "Export to CSV..."
    Me.ExportCSVButton.UseVisualStyleBackColor = True
    '
    'InstructionsTextbox
    '
    Me.InstructionsTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.InstructionsTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.InstructionsTextbox.Location = New System.Drawing.Point(25, 45)
    Me.InstructionsTextbox.Multiline = True
    Me.InstructionsTextbox.Name = "InstructionsTextbox"
    Me.InstructionsTextbox.Size = New System.Drawing.Size(635, 37)
    Me.InstructionsTextbox.TabIndex = 11
    '
    'ResultsGroupBoxMarker
    '
    Me.ResultsGroupBoxMarker.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ResultsGroupBoxMarker.BackColor = System.Drawing.Color.DeepSkyBlue
    Me.ResultsGroupBoxMarker.Location = New System.Drawing.Point(19, 325)
    Me.ResultsGroupBoxMarker.Name = "ResultsGroupBoxMarker"
    Me.ResultsGroupBoxMarker.Size = New System.Drawing.Size(16, 243)
    Me.ResultsGroupBoxMarker.TabIndex = 1
    Me.ResultsGroupBoxMarker.TabStop = False
    Me.ResultsGroupBoxMarker.Visible = False
    '
    'RunButtonNoParamsMarker
    '
    Me.RunButtonNoParamsMarker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.RunButtonNoParamsMarker.AutoSize = True
    Me.RunButtonNoParamsMarker.BackColor = System.Drawing.Color.DeepSkyBlue
    Me.RunButtonNoParamsMarker.Location = New System.Drawing.Point(671, 50)
    Me.RunButtonNoParamsMarker.Name = "RunButtonNoParamsMarker"
    Me.RunButtonNoParamsMarker.Size = New System.Drawing.Size(176, 16)
    Me.RunButtonNoParamsMarker.TabIndex = 10
    Me.RunButtonNoParamsMarker.Text = "RunButtonNoParamsMarker"
    Me.RunButtonNoParamsMarker.Visible = False
    '
    'RunButtonMarker
    '
    Me.RunButtonMarker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.RunButtonMarker.AutoSize = True
    Me.RunButtonMarker.BackColor = System.Drawing.Color.DeepSkyBlue
    Me.RunButtonMarker.Location = New System.Drawing.Point(667, 285)
    Me.RunButtonMarker.Name = "RunButtonMarker"
    Me.RunButtonMarker.Size = New System.Drawing.Size(111, 16)
    Me.RunButtonMarker.TabIndex = 9
    Me.RunButtonMarker.Text = "RunButtonMarker"
    Me.RunButtonMarker.Visible = False
    '
    'RowsReturnedLabel
    '
    Me.RowsReturnedLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.RowsReturnedLabel.AutoSize = True
    Me.RowsReturnedLabel.Location = New System.Drawing.Point(25, 588)
    Me.RowsReturnedLabel.Name = "RowsReturnedLabel"
    Me.RowsReturnedLabel.Size = New System.Drawing.Size(97, 16)
    Me.RowsReturnedLabel.TabIndex = 7
    Me.RowsReturnedLabel.Text = "Rows returned:"
    '
    'ExportExcelButton
    '
    Me.ExportExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ExportExcelButton.Location = New System.Drawing.Point(665, 576)
    Me.ExportExcelButton.Margin = New System.Windows.Forms.Padding(4)
    Me.ExportExcelButton.Name = "ExportExcelButton"
    Me.ExportExcelButton.Size = New System.Drawing.Size(131, 28)
    Me.ExportExcelButton.TabIndex = 6
    Me.ExportExcelButton.Text = "Export to Excel..."
    Me.ExportExcelButton.UseVisualStyleBackColor = True
    '
    'ScriptNameLabel
    '
    Me.ScriptNameLabel.AutoSize = True
    Me.ScriptNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ScriptNameLabel.Location = New System.Drawing.Point(21, 18)
    Me.ScriptNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.ScriptNameLabel.Name = "ScriptNameLabel"
    Me.ScriptNameLabel.Size = New System.Drawing.Size(170, 24)
    Me.ScriptNameLabel.TabIndex = 3
    Me.ScriptNameLabel.Text = "Script name here"
    '
    'RunProcButton
    '
    Me.RunProcButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.RunProcButton.Location = New System.Drawing.Point(665, 283)
    Me.RunProcButton.Margin = New System.Windows.Forms.Padding(4)
    Me.RunProcButton.Name = "RunProcButton"
    Me.RunProcButton.Size = New System.Drawing.Size(131, 28)
    Me.RunProcButton.TabIndex = 2
    Me.RunProcButton.Text = "Run"
    Me.RunProcButton.UseVisualStyleBackColor = True
    '
    'ResultsGroupBox
    '
    Me.ResultsGroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ResultsGroupBox.Controls.Add(Me.ResultsTabControl)
    Me.ResultsGroupBox.Location = New System.Drawing.Point(17, 319)
    Me.ResultsGroupBox.Margin = New System.Windows.Forms.Padding(4)
    Me.ResultsGroupBox.Name = "ResultsGroupBox"
    Me.ResultsGroupBox.Padding = New System.Windows.Forms.Padding(4)
    Me.ResultsGroupBox.Size = New System.Drawing.Size(779, 249)
    Me.ResultsGroupBox.TabIndex = 1
    Me.ResultsGroupBox.TabStop = False
    '
    'ResultsTabControl
    '
    Me.ResultsTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ResultsTabControl.Controls.Add(Me.FirstResultTabPage)
    Me.ResultsTabControl.Location = New System.Drawing.Point(7, 22)
    Me.ResultsTabControl.Name = "ResultsTabControl"
    Me.ResultsTabControl.SelectedIndex = 0
    Me.ResultsTabControl.Size = New System.Drawing.Size(765, 206)
    Me.ResultsTabControl.TabIndex = 0
    '
    'FirstResultTabPage
    '
    Me.FirstResultTabPage.Controls.Add(Me.ResultsDataGridView)
    Me.FirstResultTabPage.Location = New System.Drawing.Point(4, 25)
    Me.FirstResultTabPage.Name = "FirstResultTabPage"
    Me.FirstResultTabPage.Padding = New System.Windows.Forms.Padding(3)
    Me.FirstResultTabPage.Size = New System.Drawing.Size(757, 177)
    Me.FirstResultTabPage.TabIndex = 0
    Me.FirstResultTabPage.Text = "Results"
    Me.FirstResultTabPage.UseVisualStyleBackColor = True
    '
    'ResultsDataGridView
    '
    Me.ResultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.ResultsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ResultsDataGridView.Location = New System.Drawing.Point(3, 3)
    Me.ResultsDataGridView.Name = "ResultsDataGridView"
    Me.ResultsDataGridView.Size = New System.Drawing.Size(751, 171)
    Me.ResultsDataGridView.TabIndex = 0
    '
    'ParametersGroupBox
    '
    Me.ParametersGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ParametersGroupBox.Controls.Add(Me.ParametersDataGridView)
    Me.ParametersGroupBox.Location = New System.Drawing.Point(17, 91)
    Me.ParametersGroupBox.Margin = New System.Windows.Forms.Padding(4)
    Me.ParametersGroupBox.Name = "ParametersGroupBox"
    Me.ParametersGroupBox.Padding = New System.Windows.Forms.Padding(4)
    Me.ParametersGroupBox.Size = New System.Drawing.Size(779, 185)
    Me.ParametersGroupBox.TabIndex = 0
    Me.ParametersGroupBox.TabStop = False
    Me.ParametersGroupBox.Text = "Parameters"
    '
    'ParametersDataGridView
    '
    Me.ParametersDataGridView.AllowUserToAddRows = False
    Me.ParametersDataGridView.AllowUserToDeleteRows = False
    Me.ParametersDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ParametersDataGridView.AutoGenerateColumns = False
    Me.ParametersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.ParametersDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameDataGridViewTextBoxColumn, Me.TypeDataGridViewTextBoxColumn, Me.ValueDataGridViewTextBoxColumn, Me.PickValueColumn})
    Me.ParametersDataGridView.DataSource = Me.ParamBindingSource
    Me.ParametersDataGridView.Location = New System.Drawing.Point(12, 23)
    Me.ParametersDataGridView.Margin = New System.Windows.Forms.Padding(4)
    Me.ParametersDataGridView.Name = "ParametersDataGridView"
    Me.ParametersDataGridView.RowHeadersVisible = False
    Me.ParametersDataGridView.Size = New System.Drawing.Size(743, 135)
    Me.ParametersDataGridView.TabIndex = 0
    '
    'NameDataGridViewTextBoxColumn
    '
    Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
    Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
    Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
    Me.NameDataGridViewTextBoxColumn.ReadOnly = True
    Me.NameDataGridViewTextBoxColumn.Width = 150
    '
    'TypeDataGridViewTextBoxColumn
    '
    Me.TypeDataGridViewTextBoxColumn.DataPropertyName = "Type"
    Me.TypeDataGridViewTextBoxColumn.HeaderText = "Type"
    Me.TypeDataGridViewTextBoxColumn.Name = "TypeDataGridViewTextBoxColumn"
    Me.TypeDataGridViewTextBoxColumn.ReadOnly = True
    '
    'ValueDataGridViewTextBoxColumn
    '
    Me.ValueDataGridViewTextBoxColumn.DataPropertyName = "DisplayValue"
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.ValueDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
    Me.ValueDataGridViewTextBoxColumn.HeaderText = "Value"
    Me.ValueDataGridViewTextBoxColumn.MaxInputLength = 100000
    Me.ValueDataGridViewTextBoxColumn.Name = "ValueDataGridViewTextBoxColumn"
    Me.ValueDataGridViewTextBoxColumn.Width = 250
    '
    'PickValueColumn
    '
    Me.PickValueColumn.DataPropertyName = "PickerButtonText"
    Me.PickValueColumn.HeaderText = "Pick"
    Me.PickValueColumn.Name = "PickValueColumn"
    Me.PickValueColumn.Text = "..."
    Me.PickValueColumn.Width = 50
    '
    'ParamBindingSource
    '
    Me.ParamBindingSource.DataSource = GetType(Oliver.Parameter)
    '
    'PropertiesTabPage
    '
    Me.PropertiesTabPage.Controls.Add(Me.ObjectNameLabel)
    Me.PropertiesTabPage.Controls.Add(Me.PropsDatagridView)
    Me.PropertiesTabPage.Location = New System.Drawing.Point(4, 25)
    Me.PropertiesTabPage.Name = "PropertiesTabPage"
    Me.PropertiesTabPage.Size = New System.Drawing.Size(824, 617)
    Me.PropertiesTabPage.TabIndex = 2
    Me.PropertiesTabPage.Text = "Properties"
    Me.PropertiesTabPage.UseVisualStyleBackColor = True
    '
    'ObjectNameLabel
    '
    Me.ObjectNameLabel.AutoSize = True
    Me.ObjectNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ObjectNameLabel.Location = New System.Drawing.Point(21, 12)
    Me.ObjectNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.ObjectNameLabel.Name = "ObjectNameLabel"
    Me.ObjectNameLabel.Size = New System.Drawing.Size(178, 24)
    Me.ObjectNameLabel.TabIndex = 6
    Me.ObjectNameLabel.Text = "Object name here"
    '
    'PropsDatagridView
    '
    Me.PropsDatagridView.AllowUserToAddRows = False
    Me.PropsDatagridView.AllowUserToDeleteRows = False
    Me.PropsDatagridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.PropsDatagridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.PropsDatagridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.PropsDatagridView.Location = New System.Drawing.Point(17, 47)
    Me.PropsDatagridView.Name = "PropsDatagridView"
    Me.PropsDatagridView.ReadOnly = True
    Me.PropsDatagridView.Size = New System.Drawing.Size(783, 534)
    Me.PropsDatagridView.TabIndex = 5
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(13, 122)
    Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(148, 16)
    Me.Label2.TabIndex = 10
    Me.Label2.Text = "Available scripts/procs:"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(13, 69)
    Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(110, 16)
    Me.Label1.TabIndex = 11
    Me.Label1.Text = "Select database:"
    '
    'DatabaseCombobox
    '
    Me.DatabaseCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.DatabaseCombobox.FormattingEnabled = True
    Me.DatabaseCombobox.Location = New System.Drawing.Point(16, 88)
    Me.DatabaseCombobox.Name = "DatabaseCombobox"
    Me.DatabaseCombobox.Size = New System.Drawing.Size(302, 24)
    Me.DatabaseCombobox.TabIndex = 12
    '
    'SaveExcelDialog
    '
    Me.SaveExcelDialog.DefaultExt = "csv"
    Me.SaveExcelDialog.OverwritePrompt = False
    '
    'RefreshProcsButton
    '
    Me.RefreshProcsButton.Image = CType(resources.GetObject("RefreshProcsButton.Image"), System.Drawing.Image)
    Me.RefreshProcsButton.Location = New System.Drawing.Point(318, 115)
    Me.RefreshProcsButton.Name = "RefreshProcsButton"
    Me.RefreshProcsButton.Size = New System.Drawing.Size(30, 23)
    Me.RefreshProcsButton.TabIndex = 14
    Me.RefreshProcsButton.UseVisualStyleBackColor = True
    '
    'ShowConnectionStringButton
    '
    Me.ShowConnectionStringButton.Location = New System.Drawing.Point(327, 89)
    Me.ShowConnectionStringButton.Name = "ShowConnectionStringButton"
    Me.ShowConnectionStringButton.Size = New System.Drawing.Size(20, 22)
    Me.ShowConnectionStringButton.TabIndex = 15
    Me.ShowConnectionStringButton.Text = "?"
    Me.ShowConnectionStringButton.UseVisualStyleBackColor = True
    '
    'EnvironmentCombobox
    '
    Me.EnvironmentCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.EnvironmentCombobox.FormattingEnabled = True
    Me.EnvironmentCombobox.Items.AddRange(New Object() {"Local"})
    Me.EnvironmentCombobox.Location = New System.Drawing.Point(16, 35)
    Me.EnvironmentCombobox.Name = "EnvironmentCombobox"
    Me.EnvironmentCombobox.Size = New System.Drawing.Size(209, 24)
    Me.EnvironmentCombobox.TabIndex = 17
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(13, 16)
    Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(125, 16)
    Me.Label3.TabIndex = 16
    Me.Label3.Text = "Select environment:"
    '
    'SaveCSVDialog
    '
    Me.SaveCSVDialog.DefaultExt = "csv"
    Me.SaveCSVDialog.OverwritePrompt = False
    '
    'OliverMainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1231, 684)
    Me.Controls.Add(Me.EnvironmentCombobox)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.ShowConnectionStringButton)
    Me.Controls.Add(Me.RefreshProcsButton)
    Me.Controls.Add(Me.DatabaseCombobox)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.OliverTabControl)
    Me.Controls.Add(Me.ScriptsTreeView)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.Name = "OliverMainForm"
    Me.Text = "Oliver Data Management Tool"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.OliverTabControl.ResumeLayout(False)
    Me.WelcomeTabPage.ResumeLayout(False)
    Me.ExecuteTabPage.ResumeLayout(False)
    Me.ExecuteTabPage.PerformLayout()
    Me.ResultsGroupBox.ResumeLayout(False)
    Me.ResultsTabControl.ResumeLayout(False)
    Me.FirstResultTabPage.ResumeLayout(False)
    CType(Me.ResultsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ParametersGroupBox.ResumeLayout(False)
    CType(Me.ParametersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ParamBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    Me.PropertiesTabPage.ResumeLayout(False)
    Me.PropertiesTabPage.PerformLayout()
    CType(Me.PropsDatagridView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents ScriptsTreeView As System.Windows.Forms.TreeView
  Friend WithEvents OliverTabControl As System.Windows.Forms.TabControl
  Friend WithEvents ExecuteTabPage As System.Windows.Forms.TabPage
  Friend WithEvents ScriptNameLabel As System.Windows.Forms.Label
  Friend WithEvents RunProcButton As System.Windows.Forms.Button
  Friend WithEvents ResultsGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents ParametersGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents WelcomeTabPage As System.Windows.Forms.TabPage
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ExportExcelButton As System.Windows.Forms.Button
  Friend WithEvents ParametersDataGridView As System.Windows.Forms.DataGridView
  Friend WithEvents ParamBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents TreeViewImageList As System.Windows.Forms.ImageList
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DatabaseCombobox As System.Windows.Forms.ComboBox
  Friend WithEvents SaveExcelDialog As System.Windows.Forms.SaveFileDialog
  Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
  Friend WithEvents RowsReturnedLabel As System.Windows.Forms.Label
  Friend WithEvents RefreshProcsButton As System.Windows.Forms.Button
  Friend WithEvents ShowConnectionStringButton As System.Windows.Forms.Button
  Friend WithEvents ResultsTabControl As System.Windows.Forms.TabControl
  Friend WithEvents FirstResultTabPage As System.Windows.Forms.TabPage
  Friend WithEvents ResultsDataGridView As System.Windows.Forms.DataGridView
  Friend WithEvents RunButtonNoParamsMarker As System.Windows.Forms.Label
  Friend WithEvents RunButtonMarker As System.Windows.Forms.Label
  Friend WithEvents ResultsGroupBoxMarker As System.Windows.Forms.GroupBox
  Friend WithEvents ExportingLabel As System.Windows.Forms.Label
  Friend WithEvents InstructionsTextbox As System.Windows.Forms.TextBox
  Friend WithEvents EnvironmentCombobox As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents TypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ValueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents PickValueColumn As System.Windows.Forms.DataGridViewButtonColumn
  Friend WithEvents ExportCSVButton As System.Windows.Forms.Button
  Friend WithEvents SaveCSVDialog As System.Windows.Forms.SaveFileDialog
  Friend WithEvents PropertiesTabPage As System.Windows.Forms.TabPage
  Friend WithEvents PropsDatagridView As System.Windows.Forms.DataGridView
  Friend WithEvents ObjectNameLabel As System.Windows.Forms.Label
  Friend WithEvents DelimiterLabel As System.Windows.Forms.Label
  Friend WithEvents DelimiterTextBox As System.Windows.Forms.TextBox

End Class
