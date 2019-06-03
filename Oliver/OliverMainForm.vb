Imports FlexCel.XlsAdapter
Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient

Public Class OliverMainForm

  Public ProcParameterList As New List(Of ProcParameters)
  Public CurrentProcParameters As List(Of Parameter)
  Public ProcExtendedPropertyList As New List(Of ProcExtendedProperties)
  Public CurrentProcExtendedProperties As List(Of ExtendedProperty)
  Public ImportTableExtendedPropertyList As New List(Of ImportTableExtendedProperties)
  Public CurrentImportTableExtendedProperties As List(Of ExtendedProperty)
  Public ResultsDataSet As DataSet
  Public CurrentDisplayMode As DisplayMode = DisplayMode.Parameters
  Public Const FOLDER_IMAGE As Integer = 1
  Public Const PROC_IMAGE As Integer = 0
  Public Const SELECTED_PROC_IMAGE As Integer = 2
  Public Const ALLIMPORTABLES_IMAGE As Integer = 3
  Public Const ALLPROCS_IMAGE As Integer = 4

  Public Enum DisplayMode
    Parameters = 0
    NoParameters = 1
  End Enum

  Public Class ProcParameters
    Public ProcName As String
    Public ProcParameters As List(Of Parameter)
  End Class

  Public Class ProcExtendedProperties
    Public ProcName As String
    Public ProcExtendedProps As List(Of ExtendedProperty)
  End Class

  Public Class ImportTableExtendedProperties
    Public ImportTableName As String
    Public ImportTableExtendedProps As List(Of ExtendedProperty)
  End Class

#Region "Event Handlers"

  Private Sub HandleTopLevelError(ex As Exception)
    MessageBox.Show(String.Concat("Unexpected Error: ", ex.Message), "Oliver Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
  End Sub

  Private Sub ShowConnectionStringButton_Click(sender As Object, e As EventArgs) Handles ShowConnectionStringButton.Click
    Try
      If DatabaseCombobox.SelectedIndex >= 0 Then
        ShowConnectionString()
      End If
    Catch ex As Exception
      HandleTopLevelError(ex)
    End Try
  End Sub

  Private Sub OliverMainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Try
      ShowWelcomeViewOnly()
    Catch ex As Exception
      HandleTopLevelError(ex)
    End Try
  End Sub

  Private Sub ScriptsTreeView_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles ScriptsTreeView.AfterSelect
    Try
      Dim Node As TreeNode = CType(e.Node, TreeNode)
      Cursor.Current = Cursors.WaitCursor
      If Node.Tag = "Proc" Then
        InitScriptNameLabel(Node)
        InitObjectNameLabel(Node)
        SetCurrentProcExtendedProperties(CurrentProcName, CurrentProcSchemaName)
        SetCurrentProcParameters(CurrentProcName, CurrentProcSchemaName)
        InitInstructionsLabel(Node)
        InitResultsGrid()
        ShowProcView()
      ElseIf Node.Tag = "Import" Then
        InitObjectNameLabel(Node)
        SetCurrentTableExtendedProperties(CurrentTableName, CurrentTableSchema)
        ShowPropertiesView()
      Else
        ShowNoScript()
      End If
    Catch ex As Exception
      HandleTopLevelError(ex)
    Finally
      Cursor.Current = Cursors.Default
    End Try
  End Sub

  Private Sub RefreshProcsButton_Click(sender As Object, e As EventArgs) Handles RefreshProcsButton.Click
    Try
      If DatabaseCombobox.SelectedIndex >= 0 Then
        InitDatabaseParamsAndExtendedProps()
        InitImportTableExtendedProps()
        LoadScriptsIntoTreeView()
        LoadImportsIntoTreeView()
        ShowNoScript()
      End If
    Catch ex As Exception
      HandleTopLevelError(ex)
    End Try
  End Sub

  Private Sub RunProcButton_Click(sender As Object, e As EventArgs) Handles RunProcButton.Click
    Try
      Cursor.Current = Cursors.WaitCursor
      If AllParamsValid() Then
        If ConfirmOkIfRequired() Then
          RunStoredProc()
          If CanDisplayResults() Then
            DisplayResults()
          Else
            DirectExport()
          End If
        End If
      End If
    Catch ex As Exception
      HandleTopLevelError(ex)
    Finally
      Cursor.Current = Cursors.Default
    End Try
  End Sub

  Private Sub ParametersDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ParametersDataGridView.CellContentClick
    Try
      If e.ColumnIndex = 3 Then 'pick button
        If e.RowIndex >= 0 Then
          Dim Param As Parameter = TryCast(ParametersDataGridView.Rows(e.RowIndex).DataBoundItem, Parameter)
          If Param IsNot Nothing Then
            Dim SqlForLookup As String = GetSingleExtendedPropertyForProc(Param.Name, CurrentProcName)
            SqlForLookup = ReplaceParametersInLookupSQL(SqlForLookup)
            If Not SqlForLookup = String.Empty Then
              SetParamBasedOnLookup(SqlForLookup, Param)
            ElseIf Param.Type.ToLower.StartsWith("date") Then
              SetParamBasedOnCalendar(Param)
            ElseIf Param.Type.ToLower.StartsWith("bit") Then
              SetParamBasedOnYesNo(Param)
            End If
          End If
        End If
      End If
    Catch ex As Exception
      HandleTopLevelError(ex)
    End Try
  End Sub

  Private Function ReplaceParametersInLookupSQL(sql As String) As String
    Dim SqlToReturn As String = sql
    If SqlToReturn.Contains("@") Then
      For Each Param As Parameter In CurrentProcParameters
        Dim ReplaceValue As String = "0"
        If Not Param.Value = String.Empty Then
          ReplaceValue = Param.Value
        End If
        SqlToReturn = SqlToReturn.Replace(Param.Name, ReplaceValue)
      Next
    End If
    Return SqlToReturn
  End Function

  Private Sub DatabaseCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DatabaseCombobox.SelectedIndexChanged
    Try
      Cursor.Current = Cursors.WaitCursor
      If DatabaseCombobox.SelectedIndex >= 0 Then
        InitDatabaseParamsAndExtendedProps()
        InitImportTableExtendedProps()
        LoadScriptsIntoTreeView()
        LoadImportsIntoTreeView()
      End If
    Catch ex As Exception
      HandleTopLevelError(ex)
    Finally
      Cursor.Current = Cursors.Default
    End Try
  End Sub

  Private Sub ExportCSV()
    If ResultsDataSet.Tables.Count > 0 Then
      SaveCSVDialog.FileName = CurrentProcName()
      SaveCSVDialog.Filter = "CSV Files | *.csv"
      Dim Result As DialogResult = SaveCSVDialog.ShowDialog()
      If Result = Windows.Forms.DialogResult.OK Then
        Dim DataTable As DataTable = GetDataToExportCSV()
        Dim ExportFileWriter As New IO.StreamWriter(SaveCSVDialog.FileName)
        Dim TextDelimiter As String = GetDelimiter()
        Dim RowCounter As Integer = 1
        Dim ColCounter As Integer = 1
        'write out a header row
        For Each Col As DataColumn In DataTable.Columns
          ExportFileWriter.Write(Col.ColumnName)
          If ColCounter < DataTable.Columns.Count Then
            ExportFileWriter.Write(TextDelimiter)
          End If
          ColCounter += 1
        Next
        ExportFileWriter.Write(vbCrLf)
        'write the data
        For Each DataRow As DataRow In DataTable.Rows
          ColCounter = 1
          For Each Col As DataColumn In DataTable.Columns
            ExportFileWriter.Write(DataRow(Col.ColumnName))
            If ColCounter < DataTable.Columns.Count Then
              ExportFileWriter.Write(TextDelimiter)
            End If
            ColCounter += 1
          Next
          If RowCounter < DataTable.Rows.Count Then
            ExportFileWriter.Write(vbCrLf)
          End If
          RowCounter += 1
        Next
        ExportFileWriter.Close()
      End If
    End If
  End Sub

  Private Function GetDataToExportCSV() As DataTable
    Dim CSVDataTable As DataTable
    If ResultsDataGridView.RowCount = 0 Then
      CSVDataTable = ResultsDataSet.Tables(0)
    Else
      Dim TabPg As TabPage = ResultsTabControl.SelectedTab
      Dim DataGridView As DataGridView = TryCast(TabPg.Controls(0), DataGridView)
      CSVDataTable = DataGridView.DataSource
    End If
    Return CSVDataTable
  End Function

  Private Sub ExportExcel()
    If ResultsDataSet.Tables.Count > 0 Then
      SaveExcelDialog.FileName = CurrentProcName()
      SaveExcelDialog.Filter = "Excel Files | *.xlsx"
      Dim Result As DialogResult = SaveExcelDialog.ShowDialog()
      If Result = Windows.Forms.DialogResult.OK Then
        Dim Xls As New XlsFile
        Xls.NewFile(ResultsDataSet.Tables.Count)
        For TabPgIndex As Integer = ResultsTabControl.TabPages.Count - 1 To 0 Step -1
          Dim TabPg As TabPage = ResultsTabControl.TabPages(TabPgIndex)
          Dim RowIndex As Integer = 1
          Dim ColIndex As Integer = 1
          Dim DataTable As DataTable = ResultsDataSet.Tables(TabPgIndex)
          Xls.ActiveSheet = (TabPgIndex + 1)
          Xls.SheetName = TabPg.Text
          For Each Col As DataColumn In DataTable.Columns
            Xls.SetCellValue(RowIndex, ColIndex, Col.ColumnName)
            ColIndex += 1
          Next
          Dim PercentComplete As Integer = 0
          For Each DataRow As DataRow In DataTable.Rows
            RowIndex += 1
            ColIndex = 1
            For Each Col As DataColumn In DataTable.Columns
              Xls.SetCellValue(RowIndex, ColIndex, DataRow(Col.ColumnName))
              ColIndex += 1
            Next
            PercentComplete = CInt(((RowIndex - 1) / DataTable.Rows.Count) * 100)
            If ResultsTabControl.TabPages.Count = 1 Then
              ExportingLabel.Text = String.Format("Exporting data: {0}%", PercentComplete)
            Else
              ExportingLabel.Text = String.Format("Exporting data: {0}% of {1}", PercentComplete, TabPg.Text)
            End If
          Next
          Xls.AutofitCol(1, ColIndex, False, 1.1)
        Next
        Xls.AllowOverwritingFiles = True
        Xls.Save(SaveExcelDialog.FileName)
      End If
    End If
  End Sub

  Private Sub AllowOpenCSV()
    If IO.File.Exists(SaveCSVDialog.FileName) Then
      Dim Result As DialogResult
      Result = MessageBox.Show("The export completed, open the file now?", "Export complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If Result = Windows.Forms.DialogResult.Yes Then
        Process.Start("Notepad.Exe", SaveCSVDialog.FileName)
      Else
        Focus()
      End If
    End If
  End Sub

  Private Sub AllowOpenExcel()
    Dim Result As DialogResult
    Result = MessageBox.Show("The export completed, open the file now?", "Export complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    If Result = Windows.Forms.DialogResult.Yes Then
      Process.Start(SaveExcelDialog.FileName)
    Else
      Focus()
    End If
  End Sub

  Private Sub ExportExcelButton_Click(sender As Object, e As EventArgs) Handles ExportExcelButton.Click
    Try
      Cursor.Current = Cursors.WaitCursor
      ExportingLabel.Visible = True
      ExportExcel()
      AllowOpenExcel()
    Catch ex As Exception
      HandleTopLevelError(ex)
    Finally
      ExportingLabel.Visible = False
      Cursor.Current = Cursors.Default
    End Try
  End Sub

  Private Sub ExportCSVButton_Click(sender As Object, e As EventArgs) Handles ExportCSVButton.Click
    Try
      Cursor.Current = Cursors.WaitCursor
      ExportingLabel.Visible = True
      ExportCSV()
      AllowOpenCSV()
    Catch ex As Exception
      HandleTopLevelError(ex)
    Finally
      ExportingLabel.Visible = False
      Cursor.Current = Cursors.Default
    End Try
  End Sub

#End Region
  Private Sub ShowConnectionString()
    Dim ConnectString As Configuration.ConnectionStringSettings = DatabaseCombobox.SelectedItem
    MessageBox.Show(ConnectString.ConnectionString, "Current connection string", MessageBoxButtons.OK, MessageBoxIcon.Information)
  End Sub

  Private Sub LoadDatabases()
    DatabaseCombobox.Items.Clear()
    If EnvironmentCombobox.SelectedItem = String.Empty Then Exit Sub
    DatabaseCombobox.DisplayMember = "name"
    DatabaseCombobox.ValueMember = "connectionString"
    For Each ConnectString As Configuration.ConnectionStringSettings In ConnectionStrings
      If Not ConnectString.Name = "LocalSqlServer" Then
        Dim FindString As String = String.Concat("(", EnvironmentCombobox.SelectedItem, ")")
        If ConnectString.Name.EndsWith(FindString) Then
          DatabaseCombobox.Items.Add(ConnectString)
        End If
      End If
    Next
  End Sub

  Private Function CreateImportsNode() As TreeNode
    Dim NewNode As TreeNode = New TreeNode("Imports")
    NewNode.NodeFont = New Font("Arial", 10)
    NewNode.ImageIndex = ALLIMPORTABLES_IMAGE
    NewNode.SelectedImageIndex = ALLIMPORTABLES_IMAGE
    Return NewNode
  End Function

  Private Function CreateScriptsNode() As TreeNode
    Dim NewNode As TreeNode = New TreeNode("Scripts")
    NewNode.NodeFont = New Font("Arial", 10)
    NewNode.ImageIndex = ALLPROCS_IMAGE
    NewNode.SelectedImageIndex = ALLPROCS_IMAGE
    Return NewNode
  End Function

  Private Function CreateFolderNode(folderName As String) As TreeNode
    Dim NewNode As TreeNode = New TreeNode(folderName)
    NewNode.NodeFont = New Font("Arial", 10)
    NewNode.ImageIndex = FOLDER_IMAGE
    NewNode.SelectedImageIndex = FOLDER_IMAGE
    Return NewNode
  End Function

  Private Function CreateProcNode(text As String) As TreeNode
    Dim NewNode As TreeNode = New TreeNode(text)
    NewNode.Tag = "Proc"
    NewNode.NodeFont = New Font("Arial", 10)
    NewNode.ImageIndex = PROC_IMAGE
    NewNode.SelectedImageIndex = SELECTED_PROC_IMAGE
    Return NewNode
  End Function

  Private Function CreateImportNode(text As String) As TreeNode
    Dim NewNode As TreeNode = New TreeNode(text)
    NewNode.Tag = "Import"
    NewNode.NodeFont = New Font("Arial", 10)
    NewNode.ImageIndex = PROC_IMAGE
    NewNode.SelectedImageIndex = SELECTED_PROC_IMAGE
    Return NewNode
  End Function

  Private Function GetOrCreateFolderBranch(TreeLocation As String, NodeIndex As Integer) As TreeNode
    If TreeLocation = String.Empty Then
      Return ScriptsTreeView.Nodes(NodeIndex)
    Else
      Dim Folders() As String = TreeLocation.Split(".")
      Dim CurrentNode As TreeNode = ScriptsTreeView.Nodes(NodeIndex)
      For LocationIndex As Integer = 0 To Folders.Length - 1
        'if the current node has a subfolder with the right name use it, otherwise create one
        Dim FolderToFind = Folders(LocationIndex)
        Dim FolderFound As Boolean = False
        For Each SubNode As TreeNode In CurrentNode.Nodes
          If SubNode.Text = FolderToFind Then
            CurrentNode = SubNode
            FolderFound = True
          End If
        Next
        If Not FolderFound Then
          Dim NewFolder As TreeNode = CreateFolderNode(FolderToFind)
          CurrentNode.Nodes.Add(NewFolder)
          CurrentNode = NewFolder
        End If
        If LocationIndex = Folders.Length - 1 Then
          Return CurrentNode
        End If
      Next
    End If
    Return Nothing
  End Function

  Private Function CurrentProcSchemaName() As String
    Dim Proc() As String = ScriptNameLabel.Text.Split(".")
    Return Proc(0)
  End Function

  Private Function CurrentProcName() As String
    Dim Proc() As String = ScriptNameLabel.Text.Split(".")
    Return Proc(1)
  End Function

  Private Function CurrentTableSchema() As String
    Dim Table() As String = ObjectNameLabel.Text.Split(".")
    Return Table(0)
  End Function

  Private Function CurrentTableName() As String
    Dim Table() As String = ObjectNameLabel.Text.Split(".")
    Return Table(1)
  End Function

  Private Sub ClearParamAndExtendedPropCollections()
    ProcParameterList.Clear()
    ProcExtendedPropertyList.Clear()
    ImportTableExtendedPropertyList.Clear()
  End Sub

  Private Sub InitDatabaseParamsAndExtendedProps()
    ClearParamAndExtendedPropCollections()
    Dim ProcsTable As DataTable = GetProcsFromDatabase()
    Dim ProcName As String, ProcSchema As String
    For ProcCount = 1 To ProcsTable.Rows.Count
      ProcSchema = ProcsTable.Rows(ProcCount - 1).Item("SchemaName")
      ProcName = ProcsTable.Rows(ProcCount - 1).Item("ProcName")
      AddProcExtendedPropsFromDbToCollection(ProcName, ProcSchema)
      AddProcParamsFromDbToCollection(ProcName, ProcSchema)
    Next
  End Sub

  Private Sub InitImportTableExtendedProps()
    Dim ImportTables As DataTable = GetTablesWithImportFilesFromDatabase()
    Dim TableName As String, TableSchema As String
    For ProcCount = 1 To ImportTables.Rows.Count
      TableSchema = ImportTables.Rows(ProcCount - 1).Item("SchemaName")
      TableName = ImportTables.Rows(ProcCount - 1).Item("TableName")
      AddImportTableExtendedPropsFromDbToCollection(TableName, TableSchema)
    Next
  End Sub

  Private Sub LoadScriptsIntoTreeView()
    ScriptsTreeView.Font = New Font("Arial", 10)
    ScriptsTreeView.Nodes.Clear()
    Dim TopNode As TreeNode = CreateScriptsNode()
    ScriptsTreeView.Nodes.Add(TopNode)
    Dim ProcsTable As DataTable = GetProcsFromDatabase()
    Dim ProcNode As TreeNode, ProcName As String, ProcSchema As String
    For ProcCount = 1 To ProcsTable.Rows.Count
      ProcSchema = ProcsTable.Rows(ProcCount - 1).Item("SchemaName")
      ProcName = ProcsTable.Rows(ProcCount - 1).Item("ProcName")
      ProcNode = CreateProcNode(String.Concat(ProcSchema, ".", ProcName))
      Dim TreeLocation As String = GetSingleExtendedPropertyForProc("TreeLocation", ProcName)
      Dim NodeForProc As TreeNode = GetOrCreateFolderBranch(TreeLocation, 0)
      NodeForProc.Nodes.Add(ProcNode)
    Next
    TopNode.Expand()
  End Sub

  Private Sub LoadImportsIntoTreeView()
    Dim ImportsNode As TreeNode = CreateImportsNode()
    ScriptsTreeView.Nodes.Add(ImportsNode)
    Dim ImportsTable As DataTable = GetTablesWithImportFilesFromDatabase()
    Dim ImportNode As TreeNode, ImportName As String, ImportSchema As String
    For ProcCount = 1 To ImportsTable.Rows.Count
      ImportSchema = ImportsTable.Rows(ProcCount - 1).Item("SchemaName")
      ImportName = ImportsTable.Rows(ProcCount - 1).Item("TableName")
      ImportNode = CreateImportNode(String.Concat(ImportSchema, ".", ImportName))
      Dim TreeLocation As String = GetSingleExtendedPropertyForImportTable("TreeLocation", ImportName)
      Dim NodeForImport As TreeNode = GetOrCreateFolderBranch(TreeLocation, 1)
      NodeForImport.Nodes.Add(ImportNode)
    Next
  End Sub


  Private Function GetProcsFromDatabase() As DataTable
    Dim CommandText As String = "SELECT O.name as ProcName, S.name as SchemaName"
    CommandText += " FROM sys.all_objects O INNER JOIN sys.schemas S "
    CommandText += " on O.schema_id = S.schema_id "
    CommandText += " LEFT JOIN  sys.extended_properties EP"
    CommandText += " on EP.major_id = O.object_id"
    CommandText += " LEFT JOIN sys.columns AS C "
    CommandText += " on EP.major_id = c.object_id AND ep.minor_id = c.column_id"
    CommandText += " Where O.type = 'P' and EP.name = 'IncludeInOliver'"
    CommandText += " ORDER BY o.name"
    Return GetDataTableFromSQL(CommandText)
  End Function

  Private Function GetTablesWithImportFilesFromDatabase() As DataTable
    Dim CommandText As String = "SELECT O.name as TableName, S.name as SchemaName, EP.value as ImportDir"
    CommandText += " FROM sys.all_objects O INNER JOIN sys.schemas S "
    CommandText += " on O.schema_id = S.schema_id "
    CommandText += " LEFT JOIN  sys.extended_properties EP"
    CommandText += " on EP.major_id = O.object_id"
    CommandText += " LEFT JOIN sys.columns AS C "
    CommandText += " on EP.major_id = c.object_id AND ep.minor_id = c.column_id"
    CommandText += " Where O.type = 'U' and EP.name = 'AutoImportFilesDirectory'"
    CommandText += " ORDER BY o.name"
    Return GetDataTableFromSQL(CommandText)
  End Function

  Private Function GetObjectExtendedPropsFromDatabase(procName As String, schemaName As String) As DataTable
    Dim CommandText As String = "SELECT ep.name, ep.value"
    CommandText += " FROM sys.extended_properties EP"
    CommandText += " LEFT JOIN sys.all_objects O ON ep.major_id = O.object_id "
    CommandText += " LEFT JOIN sys.schemas S on O.schema_id = S.schema_id"
    CommandText += " LEFT JOIN sys.columns AS c ON ep.major_id = c.object_id AND ep.minor_id = c.column_id"
    CommandText += String.Format(" Where O.name = '{0}' and S.name='{1}'", procName, schemaName)
    Return GetDataTableFromSQL(CommandText)
  End Function

  Private Function GetProcParametersFromDatabase(procName As String, schemaName As String) As DataTable
    Dim CommandText As String = "SELECT P.name, T.name as type, P.max_length as size"
    CommandText += " FROM sys.all_objects O "
    CommandText += " LEFT JOIN sys.schemas S on O.schema_id = S.schema_id"
    CommandText += " LEFT JOIN sys.all_parameters P on P.object_id = O.object_id"
    CommandText += " LEFT JOIN sys.types T on T.user_type_id = P.user_type_id"
    CommandText += String.Format(" Where O.type = 'P' and O.name = '{0}' and S.name='{1}' ", procName, schemaName)
    Return GetDataTableFromSQL(CommandText)
  End Function

  Private Function GetDelimiter()
    Dim Delimiter As String
    If DelimiterTextBox.Text <> String.Empty Then
      Delimiter = DelimiterTextBox.Text
    Else
      Delimiter = ","
    End If
    Return Delimiter
  End Function

  Private Sub ShowProcView()
    OliverTabControl.TabPages(1).Enabled = True
    OliverTabControl.SelectedTab = ExecuteTabPage
  End Sub

  Private Sub ShowPropertiesView()
    OliverTabControl.TabPages(1).Enabled = False
    OliverTabControl.SelectedTab = PropertiesTabPage
  End Sub

  Private Sub ShowWelcomeViewOnly()
    OliverTabControl.SelectedTab = WelcomeTabPage
    OliverTabControl.TabPages(1).Enabled = False
    ShowNoScript()
  End Sub

  Private Sub ShowNoScript()
    ScriptNameLabel.Text = "No script selected"
    InstructionsTextbox.Text = String.Empty
    ParamBindingSource.DataSource = Nothing
    InitResultsGrid()
  End Sub

  Private Sub ResetTabPages()
    For Each cTabPage As TabPage In ResultsTabControl.TabPages
      cTabPage.Dispose()
    Next
  End Sub

  Private Sub InitResultsGrid()
    ResetTabPages()
    Dim NewTabPage As New TabPage
    NewTabPage.BackColor = Color.DarkGray
    NewTabPage.Text = "Results"
    ResultsTabControl.TabPages.Add(NewTabPage)
    RowsReturnedLabel.Text = "Rows returned:"
  End Sub

  Public Sub InitScriptNameLabel(selectedNode As TreeNode)
    ScriptNameLabel.Text = selectedNode.Text
  End Sub

  Public Sub InitObjectNameLabel(selectedNode As TreeNode)
    ObjectNameLabel.Text = selectedNode.Text
  End Sub


  Public Sub InitInstructionsLabel(selectedNode As TreeNode)
    InstructionsTextbox.Text = GetSingleExtendedPropertyForProc("Instructions", CurrentProcName)
  End Sub

  Private Function GetProcParametersFromCollection(procName As String) As List(Of Parameter)
    For Each Params As ProcParameters In ProcParameterList
      If Params.ProcName = procName Then
        Return Params.ProcParameters
      End If
    Next
    Return Nothing
  End Function

  Private Function GetProcExtendedPropertiesFromCollection(procName As String) As List(Of ExtendedProperty)
    For Each ExtendedProps As ProcExtendedProperties In ProcExtendedPropertyList
      If ExtendedProps.ProcName = procName Then
        Return ExtendedProps.ProcExtendedProps
      End If
    Next
    Return Nothing
  End Function

  Private Function GetImportTableExtendedPropertiesFromCollection(tableName As String) As List(Of ExtendedProperty)
    For Each ExtendedProps As ImportTableExtendedProperties In ImportTableExtendedPropertyList
      If ExtendedProps.ImportTableName = tableName Then
        Return ExtendedProps.ImportTableExtendedProps
      End If
    Next
    Return Nothing
  End Function

  Public Sub SetCurrentProcParameters(procName As String, schemaName As String)
    CurrentProcParameters = GetProcParametersFromCollection(procName)
    ParamBindingSource.DataSource = CurrentProcParameters
    If CurrentProcParameters.Count = 0 Then
      SetDisplayMode(DisplayMode.NoParameters)
    Else
      SetDisplayMode(DisplayMode.Parameters)
    End If
  End Sub

  Private Sub SetDisplayMode(modeToChangeTo As DisplayMode)
    If Not CurrentDisplayMode = modeToChangeTo Then
      Select Case modeToChangeTo
        Case DisplayMode.NoParameters
          ParametersGroupBox.Visible = False
          ResultsGroupBox.Top = ParametersGroupBox.Top
          ResultsGroupBox.Height = ResultsGroupBox.Height + ParametersGroupBox.Height + 50
          RunProcButton.Top = RunButtonNoParamsMarker.Top
          CurrentDisplayMode = DisplayMode.NoParameters
        Case DisplayMode.Parameters
          ParametersGroupBox.Visible = True
          ResultsGroupBox.Top = ResultsGroupBoxMarker.Top
          ResultsGroupBox.Height = ResultsGroupBoxMarker.Height
          RunProcButton.Top = RunButtonMarker.Top
          CurrentDisplayMode = DisplayMode.Parameters
      End Select
    End If
  End Sub

  Private Sub AddProcParamsFromDbToCollection(procName As String, schemaName As String)
    Dim NewParams As New ProcParameters
    NewParams.ProcName = procName
    NewParams.ProcParameters = New List(Of Parameter)
    Dim ParamsTable As DataTable = GetProcParametersFromDatabase(procName, schemaName)
    For Each Row As DataRow In ParamsTable.Rows
      If Not IsDBNull(Row.Item("name")) Then
        Dim NewParam As Parameter = New Parameter
        NewParam.Name = Row.Item("name")
        NewParam.Type = Row.Item("type")
        NewParam.Length = Row.Item("size")
        Dim HasLookup As Boolean = GetSingleExtendedPropertyForProc(NewParam.Name, procName) <> String.Empty
        If HasLookup Then
          NewParam.PickerButtonText = "..."
        Else
          If NewParam.Type.ToLower.StartsWith("date") Then
            NewParam.PickerButtonText = "..."
          ElseIf NewParam.Type.ToLower.StartsWith("bit") Then
            NewParam.PickerButtonText = "..."
          Else
            NewParam.PickerButtonText = "N/A"
          End If
        End If
        NewParams.ProcParameters.Add(NewParam)
      End If
    Next
    ProcParameterList.Add(NewParams)
  End Sub

  Public Sub SetCurrentProcExtendedProperties(procName As String, schemaName As String)
    CurrentProcExtendedProperties = GetProcExtendedPropertiesFromCollection(procName)
    PropsDatagridView.DataSource = CurrentProcExtendedProperties
  End Sub

  Public Sub SetCurrentTableExtendedProperties(tableName As String, schemaName As String)
    CurrentImportTableExtendedProperties = GetImportTableExtendedPropertiesFromCollection(tableName)
    PropsDatagridView.DataSource = CurrentImportTableExtendedProperties
  End Sub

  Private Sub AddProcExtendedPropsFromDbToCollection(procName As String, schemaName As String)
    Dim NewXProps As New ProcExtendedProperties
    NewXProps.ProcName = procName
    NewXProps.ProcExtendedProps = New List(Of ExtendedProperty)
    Dim ExtendedPropsTable As DataTable = GetObjectExtendedPropsFromDatabase(procName, schemaName)
    For Each row As DataRow In ExtendedPropsTable.Rows
      If Not IsDBNull(row.Item("Name")) Then
        Dim NewXProp As ExtendedProperty = New ExtendedProperty
        NewXProp.Name = row.Item("name")
        NewXProp.Value = row.Item("value")
        NewXProps.ProcExtendedProps.Add(NewXProp)
      End If
    Next
    CurrentProcExtendedProperties = NewXProps.ProcExtendedProps
    ProcExtendedPropertyList.Add(NewXProps)
  End Sub

  Private Sub AddImportTableExtendedPropsFromDbToCollection(tableName As String, schemaName As String)
    Dim NewXProps As New ImportTableExtendedProperties
    NewXProps.ImportTableName = tableName
    NewXProps.ImportTableExtendedProps = New List(Of ExtendedProperty)
    Dim ExtendedPropsTable As DataTable = GetObjectExtendedPropsFromDatabase(tableName, schemaName)
    For Each row As DataRow In ExtendedPropsTable.Rows
      If Not IsDBNull(row.Item("Name")) Then
        Dim NewXProp As ExtendedProperty = New ExtendedProperty
        NewXProp.Name = row.Item("name")
        NewXProp.Value = row.Item("value")
        NewXProps.ImportTableExtendedProps.Add(NewXProp)
      End If
    Next
    CurrentImportTableExtendedProperties = NewXProps.ImportTableExtendedProps
    ImportTableExtendedPropertyList.Add(NewXProps)
  End Sub

  Private Function GetSingleExtendedPropertyForProc(propName As String, procName As String) As String
    For Each XPropList In ProcExtendedPropertyList
      If XPropList.ProcName.ToUpper = procName.ToUpper Then
        For Each XProp In XPropList.ProcExtendedProps
          If XProp.Name.ToUpper = propName.ToUpper Then
            Return XProp.Value
          End If
        Next
      End If
    Next
    Return String.Empty
  End Function

  Private Function GetSingleExtendedPropertyForImportTable(propName As String, tableName As String) As String
    For Each XPropList In ImportTableExtendedPropertyList
      If XPropList.ImportTableName.ToUpper = tableName.ToUpper Then
        For Each XProp In XPropList.ImportTableExtendedProps
          If XProp.Name.ToUpper = propName.ToUpper Then
            Return XProp.Value
          End If
        Next
      End If
    Next
    Return String.Empty
  End Function

  Private Function GetDbConnection() As SqlConnection
    Dim SelectedDb As Configuration.ConnectionStringSettings = DatabaseCombobox.SelectedItem
    Dim SysDbConnection As SqlConnection = New SqlConnection(SelectedDb.ConnectionString)
    SysDbConnection.Open()
    Return SysDbConnection
  End Function

  Private Function GetDataTableFromSQL(sql As String) As DataTable
    Dim DataReader As SqlDataReader
    Dim SysDbConnection As SqlConnection = GetDbConnection()
    Using Command As New SqlCommand(sql, SysDbConnection)
      DataReader = Command.ExecuteReader()
    End Using
    Dim DataTable As DataTable = New DataTable
    DataTable.Load(DataReader)
    SysDbConnection.Close()
    Return DataTable
  End Function

  Private Function GetResultsDatasetFromSQL() As DataSet
    Dim DataAdapter As SqlDataAdapter
    Dim DataSet As DataSet
    Dim SysDbConnection As SqlConnection = GetDbConnection()
    Dim CommandText As String = String.Concat(ScriptNameLabel.Text)
    Dim ResultTables As New List(Of DataTable)
    Using Command As New SqlCommand(CommandText, SysDbConnection)
      Command.CommandType = CommandType.StoredProcedure
      Command.CommandTimeout = 1800
      For Each Param As Parameter In CurrentProcParameters
        Dim ValToPass As String = Param.DisplayValue
        If Not Param.Value = String.Empty Then
          ValToPass = Param.Value
        End If
        Command.Parameters.AddWithValue(Param.Name, ValToPass)
      Next
      DataAdapter = New SqlDataAdapter(Command)
      DataSet = New DataSet
      DataAdapter.Fill(DataSet)
    End Using
    SysDbConnection.Close()
    Return DataSet
  End Function

  Private Function AllParamsValid() As Boolean
    For Each Param As Parameter In CurrentProcParameters
      If Param.DisplayValue = String.Empty Then
        MessageBox.Show(String.Format("Parameter {0} is required.", Param.Name))
        Return False
      ElseIf Param.Type.Contains("char") AndAlso Param.Length <> -1 Then
        If Param.DisplayValue.Length > Param.Length Then
          MessageBox.Show(String.Format("Parameter {0} has a max length of {1}.", Param.Name, Param.Length))
          Return False
        End If
      ElseIf Param.Type.Contains("date") Then
        If Not IsDate(Param.DisplayValue) Then
          MessageBox.Show(String.Format("Parameter {0} is not a valid date.", Param.Name, Param.Length))
          Return False
        End If
      End If
    Next
    Return True
  End Function

  Private Function CanDisplayResults() As Boolean
    Dim ExportValue As String = GetSingleExtendedPropertyForProc("DirectExportRowCount", CurrentProcName)
    If ExportValue <> String.Empty AndAlso IsNumeric(ExportValue) Then
      For Each Table As DataTable In ResultsDataSet.Tables
        If Table.Rows.Count >= CInt(ExportValue) Then
          Return False
        End If
      Next
    End If
    Return True
  End Function

  Private Sub DisplayResults()
    ResultsTabControl.TabPages.Clear()
    For ReturnedTableIndex = 0 To ResultsDataSet.Tables.Count - 1
      Dim NewTabPage As New TabPage
      Dim NewDataGridView As New DataGridView
      NewDataGridView.Name = String.Concat("DGVResults", ReturnedTableIndex)
      NewDataGridView.DataSource = ResultsDataSet.Tables(ReturnedTableIndex)
      NewDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
      NewDataGridView.Dock = DockStyle.Fill
      NewTabPage.Controls.Add(NewDataGridView)
      Dim ReturnTabTag As String = GetSingleExtendedPropertyForProc(String.Format("Results{0}Description", ReturnedTableIndex + 1), CurrentProcName)
      Dim ReturnTabText As String = ReturnTabTag
      Dim ReturnTabName As String = String.Format("Results{0}", ReturnedTableIndex + 1)
      If ReturnTabTag.Length > 15 Then
        ReturnTabText = String.Concat(ReturnTabText.Substring(0, 15), "...")
      End If
      If ReturnTabText = String.Empty Then ReturnTabText = String.Format("Results ({0})", ReturnedTableIndex + 1)
      NewTabPage.Text = ReturnTabText
      If ReturnTabTag = String.Empty Then
        NewTabPage.Tag = String.Format("{0} rows returned.", ResultsDataSet.Tables(ReturnedTableIndex).Rows.Count.ToString)
      Else
        NewTabPage.Tag = String.Format("{0} rows returned for result: {1}.", ResultsDataSet.Tables(ReturnedTableIndex).Rows.Count.ToString, ReturnTabTag)
      End If
      NewTabPage.Name = ReturnTabName
      ResultsTabControl.Controls.Add(NewTabPage)
      If ReturnedTableIndex = 0 Then
        RowsReturnedLabel.Text = NewTabPage.Tag
      End If
    Next
    Me.ResumeLayout()
  End Sub

  Private Sub DirectExport()
    RowsReturnedLabel.Text = String.Format("{0} rows returned.", ResultsDataSet.Tables(0).Rows.Count)
    ResultsDataGridView.DataSource = Nothing
    Dim AllowedValues As String() = {"csv", "psv", "xls", "xlsx"}
    Dim ExportType As String
    Dim ExportRowCount As String = GetSingleExtendedPropertyForProc("DirectExportRowCount", CurrentProcName)
    ExportType = InputBox(String.Format("Data exceeded {4} rows.  Enter one of the following values to export:{0}{1} for CSV{0}{2} for pipe delimited CSV{0}{3} for Excel", vbCrLf, "csv", "psv", "xls", ExportRowCount))

    Do Until AllowedValues.Contains(ExportType.ToLower()) Or ExportType = String.Empty
      ExportType = InputBox(String.Format("Invalid export selection.  Enter one of the following values to export:{0}{1} for CSV{0}{2} for pipe delimited CSV{0}{3} for Excel", vbCrLf, "csv", "psv", "xls"))
    Loop

    If ExportType <> String.Empty Then
      Select Case ExportType.ToLower()
        Case "csv"
          DelimiterTextBox.Text = ","
          ExportCSVButton_Click(Nothing, Nothing)
        Case "psv"
          DelimiterTextBox.Text = "|"
          ExportCSVButton_Click(Nothing, Nothing)
        Case "xls", "xlsx"
          ExportExcelButton_Click(Nothing, Nothing)
      End Select
    End If
  End Sub

  Private Sub RunStoredProc()
    ResultsDataSet = GetResultsDatasetFromSQL()
  End Sub

  Private Function ConfirmOkIfRequired() As Boolean
    Dim ConfirmMessage As String = GetSingleExtendedPropertyForProc("ConfirmMessage", CurrentProcName)
    If ConfirmMessage = String.Empty Then
      Return True
    Else
      Dim Result As DialogResult = MessageBox.Show(ConfirmMessage, "Confirm proc run", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      Return Result = Windows.Forms.DialogResult.Yes
    End If
  End Function

  Private Sub SetParamBasedOnLookup(sql As String, param As Parameter)
    Dim LookupDialog As New SelectParamValueForm
    LookupDialog.ParamValueDataGridView.DataSource = GetDataTableFromSQL(sql)
    LookupDialog.ShowDialog()
    If LookupDialog.OkClicked Then
      Dim SelectedRowIndex As Integer = LookupDialog.ParamValueDataGridView.SelectedRows(0).Index
      Dim Value As String = LookupDialog.ParamValueDataGridView.Rows(SelectedRowIndex).Cells(0).Value
      Dim DisplayValue As String = String.Concat("[", LookupDialog.ParamValueDataGridView.Rows(SelectedRowIndex).Cells(1).Value, "]")
      param.SetFromLookup(Value, DisplayValue)
      ParametersDataGridView.Refresh()
    End If
  End Sub

  Private Sub SetParamBasedOnCalendar(param As Parameter)
    Dim LookupDialog As New SelectDateParamForm
    If IsDate(param.Value) Then
      LookupDialog.ParamCalendar.SelectionStart = param.Value
    End If
    LookupDialog.ShowDialog()
    If LookupDialog.OkClicked Then
      param.SetFromLookup(LookupDialog.ParamCalendar.SelectionRange.Start, LookupDialog.ParamCalendar.SelectionRange.Start)
      ParametersDataGridView.Refresh()
    End If
  End Sub

  Private Sub SetParamBasedOnYesNo(param As Parameter)
    Dim LookupDialog As New SelectYesNoParamForm
    LookupDialog.ShowDialog()
    If LookupDialog.OkClicked Then
      param.SetFromLookup(LookupDialog.SelectionValueMade, LookupDialog.SelectionDisplayText)
      ParametersDataGridView.Refresh()
    End If
  End Sub

  Private Sub ResultsTabControl_Click(sender As Object, e As EventArgs) Handles ResultsTabControl.Click
    RowsReturnedLabel.Text = ResultsTabControl.SelectedTab.Tag
  End Sub

  Private Sub EnvironmentCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EnvironmentCombobox.SelectedIndexChanged
    LoadDatabases()
  End Sub

End Class
