Imports pbs.Helper
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Validation
Imports pbs.BO.DataAnnotations
Imports pbs.BO.Script
Imports pbs.Helper.RegRepository

Imports System.Text.RegularExpressions
Imports pbs.BO.BusinessRules

Namespace PO

    <Serializable()> _
    <DB(TableName:="pbs_PO_SUPPLIER_EVALUATION_{XXX}")>
    Public Class SEV
        Inherits Csla.BusinessBase(Of SEV)
        Implements Interfaces.IGenPartObject
        Implements IComparable
        Implements IDocLink



#Region "Property Changed"
        Protected Overrides Sub OnDeserialized(context As Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            AddHandler Me.PropertyChanged, AddressOf BO_PropertyChanged
        End Sub

        Private Sub BO_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Handles Me.PropertyChanged
            'Select Case e.PropertyName

            '    Case "OrderType"
            '        If Not Me.GetOrderTypeInfo.ManualRef Then
            '            Me._orderNo = POH.AutoReference
            '        End If

            '    Case "OrderDate"
            '        If String.IsNullOrEmpty(Me.OrderPrd) Then Me._orderPrd.Text = Me._orderDate.Date.ToSunPeriod

            '    Case "SuppCode"
            '        For Each line In Lines
            '            line._suppCode = Me.SuppCode
            '        Next

            '    Case "ConvCode"
            '        If String.IsNullOrEmpty(Me.ConvCode) Then
            '            _convRate.Float = 0
            '        Else
            '            Dim conv = pbs.BO.LA.CVInfoList.GetConverter(Me.ConvCode, _orderPrd, String.Empty)
            '            If conv IsNot Nothing Then
            '                _convRate.Float = conv.DefaultRate
            '            End If
            '        End If

            '    Case Else

            'End Select

            pbs.BO.Rules.CalculationRules.Calculator(sender, e)
        End Sub
#End Region

#Region " Business Properties and Methods "
        Private _DTB As String = String.Empty


        Private _supplierCode As String = String.Empty
        <System.ComponentModel.DataObjectField(True, False)> _
        <CellInfo("pbs.BO.CRM.CUS")>
        <Rule(Required:=True)>
        Public ReadOnly Property SupplierCode() As String
            Get
                Return _supplierCode
            End Get
        End Property

        Private _itemCode As String = String.Empty
        <System.ComponentModel.DataObjectField(True, False)> _
        <CellInfo("pbs.BO.PB.IR")>
        <Rule(Required:=True)>
        Public ReadOnly Property ItemCode() As String
            Get
                Return _itemCode
            End Get
        End Property

        Private _effectiveDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar)>
        Public Property EffectiveDate() As String
            Get
                Return _effectiveDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("EffectiveDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _effectiveDate.Equals(value) Then
                    _effectiveDate.Text = value
                    PropertyHasChanged("EffectiveDate")
                End If
            End Set
        End Property

        Private _suspended As String = String.Empty
        Public Property Suspended() As String
            Get
                Return _suspended
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Suspended", True)
                If value Is Nothing Then value = String.Empty
                If Not _suspended.Equals(value) Then
                    _suspended = value
                    PropertyHasChanged("Suspended")
                End If
            End Set
        End Property

        Private _value0 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public Property Value0() As String
            Get
                Return _value0.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value0", True)
                If value Is Nothing Then value = String.Empty
                If Not _value0.Equals(value) Then
                    _value0.Text = value
                    PropertyHasChanged("Value0")
                End If
            End Set
        End Property

        Private _value1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public Property Value1() As String
            Get
                Return _value1.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value1", True)
                If value Is Nothing Then value = String.Empty
                If Not _value1.Equals(value) Then
                    _value1.Text = value
                    PropertyHasChanged("Value1")
                End If
            End Set
        End Property

        Private _value2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public Property Value2() As String
            Get
                Return _value2.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value2", True)
                If value Is Nothing Then value = String.Empty
                If Not _value2.Equals(value) Then
                    _value2.Text = value
                    PropertyHasChanged("Value2")
                End If
            End Set
        End Property

        Private _value3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public Property Value3() As String
            Get
                Return _value3.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value3", True)
                If value Is Nothing Then value = String.Empty
                If Not _value3.Equals(value) Then
                    _value3.Text = value
                    PropertyHasChanged("Value3")
                End If
            End Set
        End Property

        Private _value4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public Property Value4() As String
            Get
                Return _value4.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value4", True)
                If value Is Nothing Then value = String.Empty
                If Not _value4.Equals(value) Then
                    _value4.Text = value
                    PropertyHasChanged("Value4")
                End If
            End Set
        End Property

        Private _value5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public Property Value5() As String
            Get
                Return _value5.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value5", True)
                If value Is Nothing Then value = String.Empty
                If Not _value5.Equals(value) Then
                    _value5.Text = value
                    PropertyHasChanged("Value5")
                End If
            End Set
        End Property

        Private _value6 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public Property Value6() As String
            Get
                Return _value6.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value6", True)
                If value Is Nothing Then value = String.Empty
                If Not _value6.Equals(value) Then
                    _value6.Text = value
                    PropertyHasChanged("Value6")
                End If
            End Set
        End Property

        Private _value7 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public Property Value7() As String
            Get
                Return _value7.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value7", True)
                If value Is Nothing Then value = String.Empty
                If Not _value7.Equals(value) Then
                    _value7.Text = value
                    PropertyHasChanged("Value7")
                End If
            End Set
        End Property

        Private _value8 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public Property Value8() As String
            Get
                Return _value8.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value8", True)
                If value Is Nothing Then value = String.Empty
                If Not _value8.Equals(value) Then
                    _value8.Text = value
                    PropertyHasChanged("Value8")
                End If
            End Set
        End Property

        Private _value9 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public Property Value9() As String
            Get
                Return _value9.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value9", True)
                If value Is Nothing Then value = String.Empty
                If Not _value9.Equals(value) Then
                    _value9.Text = value
                    PropertyHasChanged("Value9")
                End If
            End Set
        End Property

        Private _notes As String = String.Empty
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Notes", True)
                If value Is Nothing Then value = String.Empty
                If Not _notes.Equals(value) Then
                    _notes = value
                    PropertyHasChanged("Notes")
                End If
            End Set
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(Hidden:=True)>
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.Text
            End Get
        End Property

        Private _updatedBy As String = String.Empty
        <CellInfo(Hidden:=True)>
        Public ReadOnly Property UpdatedBy() As String
            Get
                Return _updatedBy
            End Get
        End Property


        'Get ID
        Protected Overrides Function GetIdValue() As Object
            Return String.Format("{0}:{1}", _supplierCode.Trim, _itemCode.Trim)
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Dim ID = IDObject.ToString
            'Dim m As MatchCollection = Regex.Matches(ID, pbsRegex.AlphaNumericExt)
            Dim pSupplierCode As String = Regex.Matches(ID, pbsRegex.AlphaNumericExt2).ToString
            Dim pItemCode As String = Regex.Matches(ID, pbsRegex.AlphaNumericExt2).ToString
            If _supplierCode.Trim < pSupplierCode Then Return -1
            If _supplierCode.Trim > pSupplierCode Then Return 1
            If _itemCode.Trim < pItemCode Then Return -1
            If _itemCode.Trim > pItemCode Then Return 1
            Return 0
        End Function

#End Region 'Business Properties and Methods

#Region "Validation Rules"

        Private Sub AddSharedCommonRules()
            'Sample simple custom rule
            'ValidationRules.AddRule(AddressOf LDInfo.ContainsValidPeriod, "Period", 1)           

            'Sample dependent property. when check one , check the other as well
            'ValidationRules.AddDependantProperty("AccntCode", "AnalT0")
        End Sub

        Protected Overrides Sub AddBusinessRules()
            AddSharedCommonRules()

            For Each _field As ClassField In ClassSchema(Of SEV)._fieldList
                If _field.Required Then
                    ValidationRules.AddRule(AddressOf Csla.Validation.CommonRules.StringRequired, _field.FieldName, 0)
                End If
                If Not String.IsNullOrEmpty(_field.RegexPattern) Then
                    ValidationRules.AddRule(AddressOf Csla.Validation.CommonRules.RegExMatch, New RegExRuleArgs(_field.FieldName, _field.RegexPattern), 1)
                End If
                '----------using lookup, if no user lookup defined, fallback to predefined by developer----------------------------
                If CATMAPInfoList.ContainsCode(_field) Then
                    ValidationRules.AddRule(AddressOf LKUInfoList.ContainsLiveCode, _field.FieldName, 2)
                    'Else
                    '    Select Case _field.FieldName
                    '        Case "LocType"
                    '            ValidationRules.AddRule(Of LOC, AnalRuleArg)(AddressOf LOOKUPInfoList.ContainsSysCode, New AnalRuleArg(_field.FieldName, SysCats.LocationType))
                    '        Case "Status"
                    '            ValidationRules.AddRule(Of LOC, AnalRuleArg)(AddressOf LOOKUPInfoList.ContainsSysCode, New AnalRuleArg(_field.FieldName, SysCats.LocationStatus))
                    '    End Select
                End If
            Next
            Rules.BusinessRules.RegisterBusinessRules(Me)
            MyBase.AddBusinessRules()
        End Sub
#End Region ' Validation

#Region " Factory Methods "

        Private Sub New()
            _DTB = Context.CurrentBECode
        End Sub

        Public Shared Function BlankSEV() As SEV
            Return New SEV
        End Function

        Public Shared Function NewSEV(ByVal pSupplierCode As String, ByVal pItemCode As String) As SEV
            If KeyDuplicated(pSupplierCode, pItemCode) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("SEV")))
            Return DataPortal.Create(Of SEV)(New Criteria(pSupplierCode, pItemCode))
        End Function

        Public Shared Function NewBO(ByVal ID As String) As SEV
            'Dim m As MatchCollection = Regex.Matches(ID, pbsRegex.AlphaNumericExt)
            Dim n = Regex.Matches(ID, pbsRegex.AlphaNumericExt2)
            Dim pSupplierCode As String = Regex.Match(ID, pbsRegex.AlphaNumericExt2).Value.Trim
            Dim pItemCode As String = Regex.Match(ID, pbsRegex.AlphaNumericExt2).NextMatch.Value.Trim

            Return NewSEV(pSupplierCode, pItemCode)
        End Function

        Public Shared Function GetSEV(ByVal pSupplierCode As String, ByVal pItemCode As String) As SEV
            Return DataPortal.Fetch(Of SEV)(New Criteria(pSupplierCode, pItemCode))
        End Function

        Public Shared Function GetBO(ByVal ID As String) As SEV
            'Dim m As MatchCollection = Regex.Matches(ID, pbsRegex.AlphaNumericExt)
            Dim pSupplierCode As String = Regex.Match(ID, pbsRegex.AlphaNumericExt2).Value.Trim
            Dim pItemCode As String = Regex.Match(ID, pbsRegex.AlphaNumericExt2).NextMatch.Value.Trim

            Return GetSEV(pSupplierCode, pItemCode)
        End Function

        Public Shared Sub DeleteSEV(ByVal pSupplierCode As String, ByVal pItemCode As String)
            DataPortal.Delete(New Criteria(pSupplierCode, pItemCode))
        End Sub

        Public Overrides Function Save() As SEV
            If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("SEV")))

            Me.ApplyEdit()
            SEVInfoList.InvalidateCache()
            Return MyBase.Save()
        End Function

        Public Function CloneSEV(ByVal pSupplierCode As String, ByVal pItemCode As String) As SEV

            If SEV.KeyDuplicated(pSupplierCode, pItemCode) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

            Dim cloningSEV As SEV = MyBase.Clone
            cloningSEV._supplierCode = pSupplierCode
            cloningSEV._itemCode = pItemCode
            cloningSEV._DTB = Context.CurrentBECode

            'Todo:Remember to reset status of the new object here 
            cloningSEV.MarkNew()
            cloningSEV.ApplyEdit()

            cloningSEV.ValidationRules.CheckRules()

            Return cloningSEV
        End Function

#End Region ' Factory Methods

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public _supplierCode As String = String.Empty
            Public _itemCode As String = String.Empty

            Public Sub New(ByVal pSupplierCode As String, ByVal pItemCode As String)
                _supplierCode = pSupplierCode
                _itemCode = pItemCode

            End Sub
        End Class

        <RunLocal()> _
        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
            _supplierCode = criteria._supplierCode
            _itemCode = criteria._itemCode

            ValidationRules.CheckRules()
        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()
                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>SELECT * FROM pbs_PO_SUPPLIER_EVALUATION_<%= _DTB %> WHERE SUPPLIER_CODE= '<%= criteria._supplierCode %>' AND ITEM_CODE= '<%= criteria._itemCode %>' </SqlText>.Value.Trim

                    Using dr As New SafeDataReader(cm.ExecuteReader)
                        If dr.Read Then
                            FetchObject(dr)
                            MarkOld()
                        End If
                    End Using

                End Using
            End Using
        End Sub

        Private Sub FetchObject(ByVal dr As SafeDataReader)
            _supplierCode = dr.GetString("SUPPLIER_CODE").TrimEnd
            _itemCode = dr.GetString("ITEM_CODE").TrimEnd
            _effectiveDate.Text = dr.GetInt32("EFFECTIVE_DATE")
            _suspended = dr.GetString("SUSPENDED").TrimEnd
            _value0.Text = dr.GetDecimal("VALUE0")
            _value1.Text = dr.GetDecimal("VALUE1")
            _value2.Text = dr.GetDecimal("VALUE2")
            _value3.Text = dr.GetDecimal("VALUE3")
            _value4.Text = dr.GetDecimal("VALUE4")
            _value5.Text = dr.GetDecimal("VALUE5")
            _value6.Text = dr.GetDecimal("VALUE6")
            _value7.Text = dr.GetDecimal("VALUE7")
            _value8.Text = dr.GetDecimal("VALUE8")
            _value9.Text = dr.GetDecimal("VALUE9")
            _notes = dr.GetString("NOTES").TrimEnd
            _updated.Text = dr.GetInt32("UPDATED")
            _updatedBy = dr.GetString("UPDATED_BY").TrimEnd

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_PO_SUPPLIER_EVALUATION_{0}_InsertUpdate", _DTB)

                        AddInsertParameters(cm)
                        cm.ExecuteNonQuery()

                    End Using
                End Using
            End SyncLock
        End Sub

        Private Sub AddInsertParameters(ByVal cm As SqlCommand)
            cm.Parameters.AddWithValue("@SUPPLIER_CODE", _supplierCode.Trim)
            cm.Parameters.AddWithValue("@ITEM_CODE", _itemCode.Trim)
            cm.Parameters.AddWithValue("@EFFECTIVE_DATE", _effectiveDate.DBValue)
            cm.Parameters.AddWithValue("@SUSPENDED", _suspended.Trim)
            cm.Parameters.AddWithValue("@VALUE0", _value0.DBValue)
            cm.Parameters.AddWithValue("@VALUE1", _value1.DBValue)
            cm.Parameters.AddWithValue("@VALUE2", _value2.DBValue)
            cm.Parameters.AddWithValue("@VALUE3", _value3.DBValue)
            cm.Parameters.AddWithValue("@VALUE4", _value4.DBValue)
            cm.Parameters.AddWithValue("@VALUE5", _value5.DBValue)
            cm.Parameters.AddWithValue("@VALUE6", _value6.DBValue)
            cm.Parameters.AddWithValue("@VALUE7", _value7.DBValue)
            cm.Parameters.AddWithValue("@VALUE8", _value8.DBValue)
            cm.Parameters.AddWithValue("@VALUE9", _value9.DBValue)
            cm.Parameters.AddWithValue("@NOTES", _notes.Trim)
            cm.Parameters.AddWithValue("@UPDATED", _updated.DBValue)
            cm.Parameters.AddWithValue("@UPDATED_BY", _updatedBy.Trim)
        End Sub


        Protected Overrides Sub DataPortal_Update()
            DataPortal_Insert()
        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_supplierCode, _itemCode))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()

                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>DELETE pbs_PO_SUPPLIER_EVALUATION_<%= _DTB %> WHERE SUPPLIER_CODE= '<%= criteria._supplierCode %>' AND ITEM_CODE= '<%= criteria._itemCode %>' </SqlText>.Value.Trim
                    cm.ExecuteNonQuery()

                End Using
            End Using

        End Sub

        'Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
        '    If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
        '        SEVInfoList.InvalidateCache()
        '    End If
        'End Sub


#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal ID As String) As Boolean
            Return SEVInfoList.ContainsID(ID)
        End Function

        Public Shared Function KeyDuplicated(ByVal pSupplierCode As String, ByVal pItemCode As String) As Boolean
            Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_PO_SUPPLIER_EVALUATION_<%= Context.CurrentBECode %> WHERE SUPPLIER_CODE= '<%= pSupplierCode %>' AND ITEM_CODE= '<%= pItemCode %>'</SqlText>.Value.Trim
            Return SQLCommander.GetScalarInteger(SqlText) > 0
        End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Dim pSupplierCode As String = Regex.Match(id, pbsRegex.AlphaNumericExt2).Value.Trim
            Dim pItemCode As String = Regex.Match(id, pbsRegex.AlphaNumericExt2).NextMatch.Value.Trim

            Return CloneSEV(pSupplierCode, pItemCode)
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return pbs.Helper.Action.StandardReferenceCommands
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(SEV).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return GetType(SEV).ToString.Leaf
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return SEVInfoList.GetSEVInfoList
        End Function
#End Region

#Region "IDoclink"
        Public Function Get_DOL_Reference() As String Implements IDocLink.Get_DOL_Reference
            Return String.Format("{0}#{1}", Get_TransType, _supplierCode)
        End Function

        Public Function Get_TransType() As String Implements IDocLink.Get_TransType
            Return Me.GetType.ToClassSchemaName.Leaf
        End Function
#End Region

    End Class

End Namespace