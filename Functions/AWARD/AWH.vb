Imports pbs.Helper
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Validation
Imports pbs.BO.DataAnnotations
Imports pbs.BO.Script
Imports pbs.BO.BusinessRules


Namespace PO

    <Serializable()> _
    <DB(TableName:="pbs_PO_AWH{XXX}")>
    Public Class AWH
        Inherits Csla.BusinessBase(Of AWH)
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
        Friend _DTB As String = String.Empty

        Friend _awardNo As String = String.Empty
        <System.ComponentModel.DataObjectField(True, False)> _
        <CellInfo(GroupName:="Award Info")>
        Public ReadOnly Property AwardNo() As String
            Get
                Return _awardNo
            End Get
        End Property

        Private _awardDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Award Info")>
        Public Property AwardDate() As String
            Get
                Return _awardDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AwardDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _awardDate.Equals(value) Then
                    _awardDate.Text = value
                    PropertyHasChanged("AwardDate")
                End If
            End Set
        End Property

        Private _awardPrd As SmartPeriod = New pbs.Helper.SmartPeriod()
        <CellInfo(LinkCode.Period, GroupName:="Award Info")>
        Public Property AwardPrd() As String
            Get
                Return _awardPrd.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AwardPrd", True)
                If value Is Nothing Then value = String.Empty
                If Not _awardPrd.Equals(value) Then
                    _awardPrd.Text = value
                    PropertyHasChanged("AwardPrd")
                End If
            End Set
        End Property

        Private _awardVal As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Award Info")>
        Public Property AwardVal() As String
            Get
                Return _awardVal.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AwardVal", True)
                If value Is Nothing Then value = String.Empty
                If Not _awardVal.Equals(value) Then
                    _awardVal.Text = value
                    PropertyHasChanged("AwardVal")
                End If
            End Set
        End Property

        Private _awardQty As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Award Info")>
        Public Property AwardQty() As String
            Get
                Return _awardQty.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AwardQty", True)
                If value Is Nothing Then value = String.Empty
                If Not _awardQty.Equals(value) Then
                    _awardQty.Text = value
                    PropertyHasChanged("AwardQty")
                End If
            End Set
        End Property

        Private _suppCode As String = String.Empty
        <CellInfo(GroupName:="Supplier")>
        Public Property SuppCode() As String
            Get
                Return _suppCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("SuppCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _suppCode.Equals(value) Then
                    _suppCode = value
                    PropertyHasChanged("SuppCode")
                End If
            End Set
        End Property

        Private _contact As String = String.Empty
        <CellInfo(GroupName:="Supplier")>
        Public Property Contact() As String
            Get
                Return _contact
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Contact", True)
                If value Is Nothing Then value = String.Empty
                If Not _contact.Equals(value) Then
                    _contact = value
                    PropertyHasChanged("Contact")
                End If
            End Set
        End Property

        Private _apprDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Approve Info")>
        Public Property ApprDate() As String
            Get
                Return _apprDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ApprDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _apprDate.Equals(value) Then
                    _apprDate.Text = value
                    PropertyHasChanged("ApprDate")
                End If
            End Set
        End Property

        Private _apprBy As String = String.Empty
        <CellInfo(LinkCode.Calendar, GroupName:="Approve Info")>
        Public Property ApprBy() As String
            Get
                Return _apprBy
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ApprBy", True)
                If value Is Nothing Then value = String.Empty
                If Not _apprBy.Equals(value) Then
                    _apprBy = value
                    PropertyHasChanged("ApprBy")
                End If
            End Set
        End Property

        Private _apprNote As String = String.Empty
        <CellInfo(LinkCode.Calendar, GroupName:="Approve Info")>
        Public Property ApprNote() As String
            Get
                Return _apprNote
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ApprNote", True)
                If value Is Nothing Then value = String.Empty
                If Not _apprNote.Equals(value) Then
                    _apprNote = value
                    PropertyHasChanged("ApprNote")
                End If
            End Set
        End Property

        Private _status As String = String.Empty
        <CellInfo(GroupName:="Award Info")>
        Public Property Status() As String
            Get
                Return _status
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Status", True)
                If value Is Nothing Then value = String.Empty
                If Not _status.Equals(value) Then
                    _status = value
                    PropertyHasChanged("Status")
                End If
            End Set
        End Property

        Private _awardType As String = String.Empty
        <CellInfo(GroupName:="Award Info")>
        Public Property AwardType() As String
            Get
                Return _awardType
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AwardType", True)
                If value Is Nothing Then value = String.Empty
                If Not _awardType.Equals(value) Then
                    _awardType = value
                    PropertyHasChanged("AwardType")
                End If
            End Set
        End Property

        Private _descriptn As String = String.Empty
        <CellInfo(GroupName:="Award Info")>
        Public Property Descriptn() As String
            Get
                Return _descriptn
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Descriptn", True)
                If value Is Nothing Then value = String.Empty
                If Not _descriptn.Equals(value) Then
                    _descriptn = value
                    PropertyHasChanged("Descriptn")
                End If
            End Set
        End Property

        Private _convCode As String = String.Empty
        <CellInfo(GroupName:="Award Info")>
        Public Property ConvCode() As String
            Get
                Return _convCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ConvCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _convCode.Equals(value) Then
                    _convCode = value
                    PropertyHasChanged("ConvCode")
                End If
            End Set
        End Property

        Private _convRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Award Info")>
        Public Property ConvRate() As String
            Get
                Return _convRate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ConvRate", True)
                If value Is Nothing Then value = String.Empty
                If Not _convRate.Equals(value) Then
                    _convRate.Text = value
                    PropertyHasChanged("ConvRate")
                End If
            End Set
        End Property

        Private _prNo As String = String.Empty
        <CellInfo(GroupName:="Award Info")>
        Public Property PrNo() As String
            Get
                Return _prNo
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PrNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _prNo.Equals(value) Then
                    _prNo = value
                    PropertyHasChanged("PrNo")
                End If
            End Set
        End Property

        Private _notes As String = String.Empty
        <CellInfo(GroupName:="Award Info")>
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

        Private _analM0 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM0() As String
            Get
                Return _analM0
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM0", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM0.Equals(value) Then
                    _analM0 = value
                    PropertyHasChanged("AnalM0")
                End If
            End Set
        End Property

        Private _analM1 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM1() As String
            Get
                Return _analM1
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM1", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM1.Equals(value) Then
                    _analM1 = value
                    PropertyHasChanged("AnalM1")
                End If
            End Set
        End Property

        Private _analM2 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM2() As String
            Get
                Return _analM2
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM2", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM2.Equals(value) Then
                    _analM2 = value
                    PropertyHasChanged("AnalM2")
                End If
            End Set
        End Property

        Private _analM3 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM3() As String
            Get
                Return _analM3
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM3", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM3.Equals(value) Then
                    _analM3 = value
                    PropertyHasChanged("AnalM3")
                End If
            End Set
        End Property

        Private _analM4 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM4() As String
            Get
                Return _analM4
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM4", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM4.Equals(value) Then
                    _analM4 = value
                    PropertyHasChanged("AnalM4")
                End If
            End Set
        End Property

        Private _analM5 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM5() As String
            Get
                Return _analM5
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM5", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM5.Equals(value) Then
                    _analM5 = value
                    PropertyHasChanged("AnalM5")
                End If
            End Set
        End Property

        Private _analM6 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM6() As String
            Get
                Return _analM6
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM6", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM6.Equals(value) Then
                    _analM6 = value
                    PropertyHasChanged("AnalM6")
                End If
            End Set
        End Property

        Private _analM7 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM7() As String
            Get
                Return _analM7
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM7", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM7.Equals(value) Then
                    _analM7 = value
                    PropertyHasChanged("AnalM7")
                End If
            End Set
        End Property

        Private _analM8 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM8() As String
            Get
                Return _analM8
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM8", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM8.Equals(value) Then
                    _analM8 = value
                    PropertyHasChanged("AnalM8")
                End If
            End Set
        End Property

        Private _analM9 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM9() As String
            Get
                Return _analM9
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM9", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM9.Equals(value) Then
                    _analM9 = value
                    PropertyHasChanged("AnalM9")
                End If
            End Set
        End Property

        Private _exText1 As String = String.Empty
        <CellInfo(GroupName:="Extended text")>
        Public Property ExText1() As String
            Get
                Return _exText1
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExText1", True)
                If value Is Nothing Then value = String.Empty
                If Not _exText1.Equals(value) Then
                    _exText1 = value
                    PropertyHasChanged("ExText1")
                End If
            End Set
        End Property

        Private _exText2 As String = String.Empty
        <CellInfo(GroupName:="Extended text")>
        Public Property ExText2() As String
            Get
                Return _exText2
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExText2", True)
                If value Is Nothing Then value = String.Empty
                If Not _exText2.Equals(value) Then
                    _exText2 = value
                    PropertyHasChanged("ExText2")
                End If
            End Set
        End Property

        Private _exText3 As String = String.Empty
        <CellInfo(GroupName:="Extended text")>
        Public Property ExText3() As String
            Get
                Return _exText3
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExText3", True)
                If value Is Nothing Then value = String.Empty
                If Not _exText3.Equals(value) Then
                    _exText3 = value
                    PropertyHasChanged("ExText3")
                End If
            End Set
        End Property

        Private _exText4 As String = String.Empty
        <CellInfo(GroupName:="Extended text")>
        Public Property ExText4() As String
            Get
                Return _exText4
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExText4", True)
                If value Is Nothing Then value = String.Empty
                If Not _exText4.Equals(value) Then
                    _exText4 = value
                    PropertyHasChanged("ExText4")
                End If
            End Set
        End Property

        Private _exText5 As String = String.Empty
        <CellInfo(GroupName:="Extended text")>
        Public Property ExText5() As String
            Get
                Return _exText5
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExText5", True)
                If value Is Nothing Then value = String.Empty
                If Not _exText5.Equals(value) Then
                    _exText5 = value
                    PropertyHasChanged("ExText5")
                End If
            End Set
        End Property

        Private _exText6 As String = String.Empty
        <CellInfo(GroupName:="Extended text")>
        Public Property ExText6() As String
            Get
                Return _exText6
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExText6", True)
                If value Is Nothing Then value = String.Empty
                If Not _exText6.Equals(value) Then
                    _exText6 = value
                    PropertyHasChanged("ExText6")
                End If
            End Set
        End Property

        Private _exText7 As String = String.Empty
        <CellInfo(GroupName:="Extended text")>
        Public Property ExText7() As String
            Get
                Return _exText7
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExText7", True)
                If value Is Nothing Then value = String.Empty
                If Not _exText7.Equals(value) Then
                    _exText7 = value
                    PropertyHasChanged("ExText7")
                End If
            End Set
        End Property

        Private _exVal1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended value")>
        Public Property ExVal1() As String
            Get
                Return _exVal1.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExVal1", True)
                If value Is Nothing Then value = String.Empty
                If Not _exVal1.Equals(value) Then
                    _exVal1.Text = value
                    PropertyHasChanged("ExVal1")
                End If
            End Set
        End Property

        Private _exVal2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended value")>
        Public Property ExVal2() As String
            Get
                Return _exVal2.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExVal2", True)
                If value Is Nothing Then value = String.Empty
                If Not _exVal2.Equals(value) Then
                    _exVal2.Text = value
                    PropertyHasChanged("ExVal2")
                End If
            End Set
        End Property

        Private _exVal3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended value")>
        Public Property ExVal3() As String
            Get
                Return _exVal3.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExVal3", True)
                If value Is Nothing Then value = String.Empty
                If Not _exVal3.Equals(value) Then
                    _exVal3.Text = value
                    PropertyHasChanged("ExVal3")
                End If
            End Set
        End Property

        Private _exVal4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended value")>
        Public Property ExVal4() As String
            Get
                Return _exVal4.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExVal4", True)
                If value Is Nothing Then value = String.Empty
                If Not _exVal4.Equals(value) Then
                    _exVal4.Text = value
                    PropertyHasChanged("ExVal4")
                End If
            End Set
        End Property

        Private _exVal5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended value")>
        Public Property ExVal5() As String
            Get
                Return _exVal5.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExVal5", True)
                If value Is Nothing Then value = String.Empty
                If Not _exVal5.Equals(value) Then
                    _exVal5.Text = value
                    PropertyHasChanged("ExVal5")
                End If
            End Set
        End Property

        Private _exDate1 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Extended date")>
        Public Property ExDate1() As String
            Get
                Return _exDate1.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExDate1", True)
                If value Is Nothing Then value = String.Empty
                If Not _exDate1.Equals(value) Then
                    _exDate1.Text = value
                    PropertyHasChanged("ExDate1")
                End If
            End Set
        End Property

        Private _exDate2 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Extended date")>
        Public Property ExDate2() As String
            Get
                Return _exDate2.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExDate2", True)
                If value Is Nothing Then value = String.Empty
                If Not _exDate2.Equals(value) Then
                    _exDate2.Text = value
                    PropertyHasChanged("ExDate2")
                End If
            End Set
        End Property

        Private _exDate3 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Extended date")>
        Public Property ExDate3() As String
            Get
                Return _exDate3.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExDate3", True)
                If value Is Nothing Then value = String.Empty
                If Not _exDate3.Equals(value) Then
                    _exDate3.Text = value
                    PropertyHasChanged("ExDate3")
                End If
            End Set
        End Property

        Private _exDate4 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Extended date")>
        Public Property ExDate4() As String
            Get
                Return _exDate4.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExDate4", True)
                If value Is Nothing Then value = String.Empty
                If Not _exDate4.Equals(value) Then
                    _exDate4.Text = value
                    PropertyHasChanged("ExDate4")
                End If
            End Set
        End Property

        Private _exDate5 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Extended date")>
        Public Property ExDate5() As String
            Get
                Return _exDate5.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExDate5", True)
                If value Is Nothing Then value = String.Empty
                If Not _exDate5.Equals(value) Then
                    _exDate5.Text = value
                    PropertyHasChanged("ExDate5")
                End If
            End Set
        End Property

        Private _locked As String = String.Empty
        <CellInfo(GroupName:="Award Info")>
        Public Property Locked() As String
            Get
                Return _locked
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Locked", True)
                If value Is Nothing Then value = String.Empty
                If Not _locked.Equals(value) Then
                    _locked = value
                    PropertyHasChanged("Locked")
                End If
            End Set
        End Property

        Private _lockedBy As String = String.Empty
        <CellInfo(GroupName:="Award Info")>
        Public Property LockedBy() As String
            Get
                Return _lockedBy
            End Get
            Set(ByVal value As String)
                CanWriteProperty("LockedBy", True)
                If value Is Nothing Then value = String.Empty
                If Not _lockedBy.Equals(value) Then
                    _lockedBy = value
                    PropertyHasChanged("LockedBy")
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
            Return _awardNo
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Dim ID = IDObject.ToString
            Dim pAwardNo As String = ID.Trim
            If _awardNo.Trim < pAwardNo Then Return -1
            If _awardNo.Trim > pAwardNo Then Return 1
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

            For Each _field As ClassField In ClassSchema(Of AWH)._fieldList
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

        Public Shared Function BlankAWH() As AWH
            Return New AWH
        End Function

        Public Shared Function NewAWH(ByVal pAwardNo As String) As AWH
            If KeyDuplicated(pAwardNo) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("AWH")))
            Return DataPortal.Create(Of AWH)(New Criteria(pAwardNo))
        End Function

        Public Shared Function NewBO(ByVal ID As String) As AWH
            Dim pAwardNo As String = ID.Trim

            Return NewAWH(pAwardNo)
        End Function

        Public Shared Function GetAWH(ByVal pAwardNo As String) As AWH
            Return DataPortal.Fetch(Of AWH)(New Criteria(pAwardNo))
        End Function

        Public Shared Function GetBO(ByVal ID As String) As AWH
            Dim pAwardNo As String = ID.Trim

            Return GetAWH(pAwardNo)
        End Function

        Public Shared Sub DeleteAWH(ByVal pAwardNo As String)
            DataPortal.Delete(New Criteria(pAwardNo))
        End Sub

        Public Overrides Function Save() As AWH
            If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("AWH")))

            Me.ApplyEdit()
            AWHInfoList.InvalidateCache()
            Return MyBase.Save()
        End Function

        Public Function CloneAWH(ByVal pAwardNo As String) As AWH

            If AWH.KeyDuplicated(pAwardNo) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

            Dim cloningAWH As AWH = MyBase.Clone
            cloningAWH._awardNo = pAwardNo
            cloningAWH._DTB = Context.CurrentBECode

            'Todo:Remember to reset status of the new object here 
            cloningAWH.MarkNew()

            For Each line In cloningAWH.Details
                line.MarkAsNewChildren()
            Next
            cloningAWH.ApplyEdit()

            cloningAWH.ValidationRules.CheckRules()

            Return cloningAWH
        End Function

#End Region ' Factory Methods

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public _awardNo As String = String.Empty

            Public Sub New(ByVal pAwardNo As String)
                _awardNo = pAwardNo

            End Sub
        End Class

        <RunLocal()> _
        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
            _awardNo = criteria._awardNo

            ValidationRules.CheckRules()
        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()
                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>
                                         SELECT * FROM pbs_PO_AWH<%= _DTB %> WHERE AWARD_NO= '<%= criteria._awardNo %>'
                                         SELECT * FROM pbs_PO_AWD<%= _DTB %> WHERE AWARD_NO= '<%= criteria._awardNo %>'
                                     </SqlText>.Value.Trim

                    Using dr As New SafeDataReader(cm.ExecuteReader)
                        If dr.Read Then
                            FetchObject(dr)
                            MarkOld()
                        End If

                        If dr.NextResult Then
                            _details = AWDs.GetAWDs(dr, Me)
                        End If
                    End Using

                End Using
            End Using
        End Sub

        Private Sub FetchObject(ByVal dr As SafeDataReader)
            _awardNo = dr.GetString("AWARD_NO").TrimEnd
            _awardDate.Text = dr.GetInt32("AWARD_DATE")
            _awardPrd.Text = dr.GetInt32("AWARD_PRD")
            _awardVal.Text = dr.GetDecimal("AWARD_VAL")
            _awardQty.Text = dr.GetDecimal("AWARD_QTY")
            _suppCode = dr.GetString("SUPP_CODE").TrimEnd
            _contact = dr.GetString("CONTACT").TrimEnd
            _apprDate.Text = dr.GetInt32("APPR_DATE")
            _apprBy = dr.GetString("APPR_BY").TrimEnd
            _apprNote = dr.GetString("APPR_NOTE").TrimEnd
            _status = dr.GetString("STATUS").TrimEnd
            _awardType = dr.GetString("AWARD_TYPE").TrimEnd
            _descriptn = dr.GetString("DESCRIPTN").TrimEnd
            _convCode = dr.GetString("CONV_CODE").TrimEnd
            _convRate.Text = dr.GetDecimal("CONV_RATE")
            _prNo = dr.GetString("PR_NO").TrimEnd
            _notes = dr.GetString("NOTES").TrimEnd
            _analM0 = dr.GetString("ANAL_M0").TrimEnd
            _analM1 = dr.GetString("ANAL_M1").TrimEnd
            _analM2 = dr.GetString("ANAL_M2").TrimEnd
            _analM3 = dr.GetString("ANAL_M3").TrimEnd
            _analM4 = dr.GetString("ANAL_M4").TrimEnd
            _analM5 = dr.GetString("ANAL_M5").TrimEnd
            _analM6 = dr.GetString("ANAL_M6").TrimEnd
            _analM7 = dr.GetString("ANAL_M7").TrimEnd
            _analM8 = dr.GetString("ANAL_M8").TrimEnd
            _analM9 = dr.GetString("ANAL_M9").TrimEnd
            _exText1 = dr.GetString("EX_TEXT1").TrimEnd
            _exText2 = dr.GetString("EX_TEXT2").TrimEnd
            _exText3 = dr.GetString("EX_TEXT3").TrimEnd
            _exText4 = dr.GetString("EX_TEXT4").TrimEnd
            _exText5 = dr.GetString("EX_TEXT5").TrimEnd
            _exText6 = dr.GetString("EX_TEXT6").TrimEnd
            _exText7 = dr.GetString("EX_TEXT7").TrimEnd
            _exVal1.Text = dr.GetDecimal("EX_VAL1")
            _exVal2.Text = dr.GetDecimal("EX_VAL2")
            _exVal3.Text = dr.GetDecimal("EX_VAL3")
            _exVal4.Text = dr.GetDecimal("EX_VAL4")
            _exVal5.Text = dr.GetDecimal("EX_VAL5")
            _exDate1.Text = dr.GetInt32("EX_DATE1")
            _exDate2.Text = dr.GetInt32("EX_DATE2")
            _exDate3.Text = dr.GetInt32("EX_DATE3")
            _exDate4.Text = dr.GetInt32("EX_DATE4")
            _exDate5.Text = dr.GetInt32("EX_DATE5")
            _locked = dr.GetString("LOCKED").TrimEnd
            _lockedBy = dr.GetString("LOCKED_BY").TrimEnd
            _updated.Text = dr.GetInt32("UPDATED")
            _updatedBy = dr.GetString("UPDATED_BY").TrimEnd

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_PO_AWH{0}_InsertUpdate", _DTB)

                        AddInsertParameters(cm)
                        cm.ExecuteNonQuery()

                    End Using

                    Me.Details.Update(ctx.Connection, Me)
                End Using
            End SyncLock
        End Sub

        Private Sub AddInsertParameters(ByVal cm As SqlCommand)
            cm.Parameters.AddWithValue("@AWARD_NO", _awardNo.Trim)
            cm.Parameters.AddWithValue("@AWARD_DATE", _awardDate.DBValue)
            cm.Parameters.AddWithValue("@AWARD_PRD", _awardPrd.DBValue)
            cm.Parameters.AddWithValue("@AWARD_VAL", _awardVal.DBValue)
            cm.Parameters.AddWithValue("@AWARD_QTY", _awardQty.DBValue)
            cm.Parameters.AddWithValue("@SUPP_CODE", _suppCode.Trim)
            cm.Parameters.AddWithValue("@CONTACT", _contact.Trim)
            cm.Parameters.AddWithValue("@APPR_DATE", _apprDate.DBValue)
            cm.Parameters.AddWithValue("@APPR_BY", _apprBy.Trim)
            cm.Parameters.AddWithValue("@APPR_NOTE", _apprNote.Trim)
            cm.Parameters.AddWithValue("@STATUS", _status.Trim)
            cm.Parameters.AddWithValue("@AWARD_TYPE", _awardType.Trim)
            cm.Parameters.AddWithValue("@DESCRIPTN", _descriptn.Trim)
            cm.Parameters.AddWithValue("@CONV_CODE", _convCode.Trim)
            cm.Parameters.AddWithValue("@CONV_RATE", _convRate.DBValue)
            cm.Parameters.AddWithValue("@PR_NO", _prNo.Trim)
            cm.Parameters.AddWithValue("@NOTES", _notes.Trim)
            cm.Parameters.AddWithValue("@ANAL_M0", _analM0.Trim)
            cm.Parameters.AddWithValue("@ANAL_M1", _analM1.Trim)
            cm.Parameters.AddWithValue("@ANAL_M2", _analM2.Trim)
            cm.Parameters.AddWithValue("@ANAL_M3", _analM3.Trim)
            cm.Parameters.AddWithValue("@ANAL_M4", _analM4.Trim)
            cm.Parameters.AddWithValue("@ANAL_M5", _analM5.Trim)
            cm.Parameters.AddWithValue("@ANAL_M6", _analM6.Trim)
            cm.Parameters.AddWithValue("@ANAL_M7", _analM7.Trim)
            cm.Parameters.AddWithValue("@ANAL_M8", _analM8.Trim)
            cm.Parameters.AddWithValue("@ANAL_M9", _analM9.Trim)
            cm.Parameters.AddWithValue("@EX_TEXT1", _exText1.Trim)
            cm.Parameters.AddWithValue("@EX_TEXT2", _exText2.Trim)
            cm.Parameters.AddWithValue("@EX_TEXT3", _exText3.Trim)
            cm.Parameters.AddWithValue("@EX_TEXT4", _exText4.Trim)
            cm.Parameters.AddWithValue("@EX_TEXT5", _exText5.Trim)
            cm.Parameters.AddWithValue("@EX_TEXT6", _exText6.Trim)
            cm.Parameters.AddWithValue("@EX_TEXT7", _exText7.Trim)
            cm.Parameters.AddWithValue("@EX_VAL1", _exVal1.DBValue)
            cm.Parameters.AddWithValue("@EX_VAL2", _exVal2.DBValue)
            cm.Parameters.AddWithValue("@EX_VAL3", _exVal3.DBValue)
            cm.Parameters.AddWithValue("@EX_VAL4", _exVal4.DBValue)
            cm.Parameters.AddWithValue("@EX_VAL5", _exVal5.DBValue)
            cm.Parameters.AddWithValue("@EX_DATE1", _exDate1.DBValue)
            cm.Parameters.AddWithValue("@EX_DATE2", _exDate2.DBValue)
            cm.Parameters.AddWithValue("@EX_DATE3", _exDate3.DBValue)
            cm.Parameters.AddWithValue("@EX_DATE4", _exDate4.DBValue)
            cm.Parameters.AddWithValue("@EX_DATE5", _exDate5.DBValue)
            cm.Parameters.AddWithValue("@LOCKED", _locked.Trim)
            cm.Parameters.AddWithValue("@LOCKED_BY", _lockedBy.Trim)
            cm.Parameters.AddWithValue("@UPDATED", _updated.DBValue)
            cm.Parameters.AddWithValue("@UPDATED_BY", _updatedBy.Trim)
        End Sub


        Protected Overrides Sub DataPortal_Update()
            DataPortal_Insert()
        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_awardNo))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()

                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>DELETE pbs_PO_AWH<%= _DTB %> WHERE AWARD_NO= '<%= criteria._awardNo %>' </SqlText>.Value.Trim
                    cm.ExecuteNonQuery()

                End Using
            End Using

        End Sub

        'Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
        '    If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
        '        AWHInfoList.InvalidateCache()
        '    End If
        'End Sub


#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal pAwardNo As String) As Boolean
            Return AWHInfoList.ContainsCode(pAwardNo)
        End Function

        Public Shared Function KeyDuplicated(ByVal pAwardNo As String) As Boolean
            Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_PO_AWH<%= Context.CurrentBECode %> WHERE AWARD_NO= '<%= pAwardNo %>'</SqlText>.Value.Trim
            Return SQLCommander.GetScalarInteger(SqlText) > 0
        End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Return CloneAWH(id)
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return pbs.Helper.Action.StandardReferenceCommands
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(AWH).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return GetType(AWH).ToString.Leaf
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return AWHInfoList.GetAWHInfoList
        End Function
#End Region

#Region "IDoclink"
        Public Function Get_DOL_Reference() As String Implements IDocLink.Get_DOL_Reference
            Return String.Format("{0}#{1}", Get_TransType, _awardNo)
        End Function

        Public Function Get_TransType() As String Implements IDocLink.Get_TransType
            Return Me.GetType.ToClassSchemaName.Leaf
        End Function
#End Region


    End Class

End Namespace