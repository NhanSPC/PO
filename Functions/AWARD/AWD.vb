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
    <DB(TableName:="pbs_PO_AWD{XXX}")>
    Public Class AWD
        Inherits Csla.BusinessBase(Of AWD)
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


        Friend _lineNo As Integer
        <System.ComponentModel.DataObjectField(True, True)> _
        Public ReadOnly Property LineNo() As String
            Get
                Return _lineNo
            End Get
        End Property

        Private _awardType As String = String.Empty
        <CellInfo(GroupName:="General Info")>
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

        Friend _awardNo As String = String.Empty
        <CellInfo(GroupName:="General Info")>
        Public Property AwardNo() As String
            Get
                Return _awardNo
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AwardNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _awardNo.Equals(value) Then
                    _awardNo = value
                    PropertyHasChanged("AwardNo")
                End If
            End Set
        End Property

        Private _itemNo As String = String.Empty
        <CellInfo(GroupName:="General Info")>
        Public Property ItemNo() As String
            Get
                Return _itemNo
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ItemNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _itemNo.Equals(value) Then
                    _itemNo = value
                    PropertyHasChanged("ItemNo")
                End If
            End Set
        End Property

        Private _itemCode As String = String.Empty
        <CellInfo(GroupName:="General Info")>
        Public Property ItemCode() As String
            Get
                Return _itemCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ItemCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _itemCode.Equals(value) Then
                    _itemCode = value
                    PropertyHasChanged("ItemCode")
                End If
            End Set
        End Property

        Private _suppDesc As String = String.Empty
        <CellInfo(GroupName:="Supplier Info")>
        Public Property SuppDesc() As String
            Get
                Return _suppDesc
            End Get
            Set(ByVal value As String)
                CanWriteProperty("SuppDesc", True)
                If value Is Nothing Then value = String.Empty
                If Not _suppDesc.Equals(value) Then
                    _suppDesc = value
                    PropertyHasChanged("SuppDesc")
                End If
            End Set
        End Property

        Private _suppItemCode As String = String.Empty
        <CellInfo(GroupName:="Supplier Info")>
        Public Property SuppItemCode() As String
            Get
                Return _suppItemCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("SuppItemCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _suppItemCode.Equals(value) Then
                    _suppItemCode = value
                    PropertyHasChanged("SuppItemCode")
                End If
            End Set
        End Property

        Private _itemNotes As String = String.Empty
        <CellInfo(GroupName:="General Info")>
        Public Property ItemNotes() As String
            Get
                Return _itemNotes
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ItemNotes", True)
                If value Is Nothing Then value = String.Empty
                If Not _itemNotes.Equals(value) Then
                    _itemNotes = value
                    PropertyHasChanged("ItemNotes")
                End If
            End Set
        End Property

        Private _purchQty As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="General Info")>
        Public Property PurchQty() As String
            Get
                Return _purchQty.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PurchQty", True)
                If value Is Nothing Then value = String.Empty
                If Not _purchQty.Equals(value) Then
                    _purchQty.Text = value
                    PropertyHasChanged("PurchQty")
                End If
            End Set
        End Property

        Private _purchUnit As String = String.Empty
        <CellInfo(GroupName:="General Info")>
        Public Property PurchUnit() As String
            Get
                Return _purchUnit
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PurchUnit", True)
                If value Is Nothing Then value = String.Empty
                If Not _purchUnit.Equals(value) Then
                    _purchUnit = value
                    PropertyHasChanged("PurchUnit")
                End If
            End Set
        End Property

        Private _stockQty As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="General Info")>
        Public Property StockQty() As String
            Get
                Return _stockQty.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("StockQty", True)
                If value Is Nothing Then value = String.Empty
                If Not _stockQty.Equals(value) Then
                    _stockQty.Text = value
                    PropertyHasChanged("StockQty")
                End If
            End Set
        End Property

        Private _location As String = String.Empty
        <CellInfo(GroupName:="General Info")>
        Public Property Location() As String
            Get
                Return _location
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Location", True)
                If value Is Nothing Then value = String.Empty
                If Not _location.Equals(value) Then
                    _location = value
                    PropertyHasChanged("Location")
                End If
            End Set
        End Property

        Private _stockUpd As String = String.Empty
        <CellInfo(GroupName:="General Info")>
        Public Property StockUpd() As String
            Get
                Return _stockUpd
            End Get
            Set(ByVal value As String)
                CanWriteProperty("StockUpd", True)
                If value Is Nothing Then value = String.Empty
                If Not _stockUpd.Equals(value) Then
                    _stockUpd = value
                    PropertyHasChanged("StockUpd")
                End If
            End Set
        End Property

        Private _baseCost As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="General Info")>
        Public Property BaseCost() As String
            Get
                Return _baseCost.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("BaseCost", True)
                If value Is Nothing Then value = String.Empty
                If Not _baseCost.Equals(value) Then
                    _baseCost.Text = value
                    PropertyHasChanged("BaseCost")
                End If
            End Set
        End Property

        Private _value1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Value")>
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
        <CellInfo(GroupName:="Value")>
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
        <CellInfo(GroupName:="Value")>
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
        <CellInfo(GroupName:="Value")>
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
        <CellInfo(GroupName:="Value")>
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
        <CellInfo(GroupName:="Value")>
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
        <CellInfo(GroupName:="Value")>
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
        <CellInfo(GroupName:="Value")>
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
        <CellInfo(GroupName:="Value")>
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

        Private _value10 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Value")>
        Public Property Value10() As String
            Get
                Return _value10.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value10", True)
                If value Is Nothing Then value = String.Empty
                If Not _value10.Equals(value) Then
                    _value10.Text = value
                    PropertyHasChanged("Value10")
                End If
            End Set
        End Property

        Private _value11 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Value")>
        Public Property Value11() As String
            Get
                Return _value11.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value11", True)
                If value Is Nothing Then value = String.Empty
                If Not _value11.Equals(value) Then
                    _value11.Text = value
                    PropertyHasChanged("Value11")
                End If
            End Set
        End Property

        Private _value12 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Value")>
        Public Property Value12() As String
            Get
                Return _value12.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value12", True)
                If value Is Nothing Then value = String.Empty
                If Not _value12.Equals(value) Then
                    _value12.Text = value
                    PropertyHasChanged("Value12")
                End If
            End Set
        End Property

        Private _value13 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Value")>
        Public Property Value13() As String
            Get
                Return _value13.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value13", True)
                If value Is Nothing Then value = String.Empty
                If Not _value13.Equals(value) Then
                    _value13.Text = value
                    PropertyHasChanged("Value13")
                End If
            End Set
        End Property

        Private _value14 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Value")>
        Public Property Value14() As String
            Get
                Return _value14.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value14", True)
                If value Is Nothing Then value = String.Empty
                If Not _value14.Equals(value) Then
                    _value14.Text = value
                    PropertyHasChanged("Value14")
                End If
            End Set
        End Property

        Private _value15 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Value")>
        Public Property Value15() As String
            Get
                Return _value15.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value15", True)
                If value Is Nothing Then value = String.Empty
                If Not _value15.Equals(value) Then
                    _value15.Text = value
                    PropertyHasChanged("Value15")
                End If
            End Set
        End Property

        Private _value16 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Value")>
        Public Property Value16() As String
            Get
                Return _value16.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value16", True)
                If value Is Nothing Then value = String.Empty
                If Not _value16.Equals(value) Then
                    _value16.Text = value
                    PropertyHasChanged("Value16")
                End If
            End Set
        End Property

        Private _value17 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Value")>
        Public Property Value17() As String
            Get
                Return _value17.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value17", True)
                If value Is Nothing Then value = String.Empty
                If Not _value17.Equals(value) Then
                    _value17.Text = value
                    PropertyHasChanged("Value17")
                End If
            End Set
        End Property

        Private _lineVal As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="General Info")>
        Public Property LineVal() As String
            Get
                Return _lineVal.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("LineVal", True)
                If value Is Nothing Then value = String.Empty
                If Not _lineVal.Equals(value) Then
                    _lineVal.Text = value
                    PropertyHasChanged("LineVal")
                End If
            End Set
        End Property

        Private _convCode As String = String.Empty
        <CellInfo(GroupName:="General Info")>
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

        Private _budgetCode As String = String.Empty
        <CellInfo(GroupName:="General Info")>
        Public Property BudgetCode() As String
            Get
                Return _budgetCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("BudgetCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _budgetCode.Equals(value) Then
                    _budgetCode = value
                    PropertyHasChanged("BudgetCode")
                End If
            End Set
        End Property

        Private _bdgCheckVal As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="General Info")>
        Public Property BdgCheckVal() As String
            Get
                Return _bdgCheckVal.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("BdgCheckVal", True)
                If value Is Nothing Then value = String.Empty
                If Not _bdgCheckVal.Equals(value) Then
                    _bdgCheckVal.Text = value
                    PropertyHasChanged("BdgCheckVal")
                End If
            End Set
        End Property

        Private _expCheckVal As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="General Info")>
        Public Property ExpCheckVal() As String
            Get
                Return _expCheckVal.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExpCheckVal", True)
                If value Is Nothing Then value = String.Empty
                If Not _expCheckVal.Equals(value) Then
                    _expCheckVal.Text = value
                    PropertyHasChanged("ExpCheckVal")
                End If
            End Set
        End Property

        Private _accntCode As String = String.Empty
        <CellInfo(GroupName:="General Info")>
        Public Property AccntCode() As String
            Get
                Return _accntCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AccntCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _accntCode.Equals(value) Then
                    _accntCode = value
                    PropertyHasChanged("AccntCode")
                End If
            End Set
        End Property

        Private _assetCode As String = String.Empty
        <CellInfo(GroupName:="Asset Info")>
        Public Property AssetCode() As String
            Get
                Return _assetCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AssetCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _assetCode.Equals(value) Then
                    _assetCode = value
                    PropertyHasChanged("AssetCode")
                End If
            End Set
        End Property

        Private _assetSub As String = String.Empty
        <CellInfo(GroupName:="Asset Info")>
        Public Property AssetSub() As String
            Get
                Return _assetSub
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AssetSub", True)
                If value Is Nothing Then value = String.Empty
                If Not _assetSub.Equals(value) Then
                    _assetSub = value
                    PropertyHasChanged("AssetSub")
                End If
            End Set
        End Property

        Private _assetInd As String = String.Empty
        <CellInfo(GroupName:="Asset Info")>
        Public Property AssetInd() As String
            Get
                Return _assetInd
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AssetInd", True)
                If value Is Nothing Then value = String.Empty
                If Not _assetInd.Equals(value) Then
                    _assetInd = value
                    PropertyHasChanged("AssetInd")
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

        Private _estDelDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="General Info")>
        Public Property EstDelDate() As String
            Get
                Return _estDelDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("EstDelDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _estDelDate.Equals(value) Then
                    _estDelDate.Text = value
                    PropertyHasChanged("EstDelDate")
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
        <CellInfo(GroupName:="Approve Info")>
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
        <CellInfo(GroupName:="Approve Info")>
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

        Private _updatedBy As String = String.Empty
        <CellInfo(Hidden:=True)>
        Public ReadOnly Property UpdatedBy() As String
            Get
                Return _updatedBy
            End Get
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(Hidden:=True)>
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.Text
            End Get
        End Property


        'Get ID
        Protected Overrides Function GetIdValue() As Object
            Return _lineNo
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Dim ID = IDObject.ToString
            Dim pLineNo As Integer = ID.Trim.ToInteger
            If _lineNo < pLineNo Then Return -1
            If _lineNo > pLineNo Then Return 1
            Return 0
        End Function

#End Region 'Business Properties and Methods

#Region "Validation Rules"

        Sub CheckRules()
            ValidationRules.CheckRules()
        End Sub


        Private Sub AddSharedCommonRules()
            'Sample simple custom rule
            'ValidationRules.AddRule(AddressOf LDInfo.ContainsValidPeriod, "Period", 1)           

            'Sample dependent property. when check one , check the other as well
            'ValidationRules.AddDependantProperty("AccntCode", "AnalT0")
        End Sub

        Protected Overrides Sub AddBusinessRules()
            AddSharedCommonRules()

            For Each _field As ClassField In ClassSchema(Of AWD)._fieldList
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

        Public Shared Function BlankAWD() As AWD
            Return New AWD
        End Function

        Public Shared Function NewAWD(ByVal pLineNo As String) As AWD
            If KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("AWD")))
            Return DataPortal.Create(Of AWD)(New Criteria(pLineNo.ToInteger))
        End Function

        Public Shared Function NewBO(ByVal ID As String) As AWD
            Dim pLineNo As String = ID.Trim

            Return NewAWD(pLineNo)
        End Function

        Public Shared Function GetAWD(ByVal pLineNo As String) As AWD
            Return DataPortal.Fetch(Of AWD)(New Criteria(pLineNo.ToInteger))
        End Function

        Public Shared Function GetBO(ByVal ID As String) As AWD
            Dim pLineNo As String = ID.Trim

            Return GetAWD(pLineNo)
        End Function

        Public Shared Sub DeleteAWD(ByVal pLineNo As String)
            DataPortal.Delete(New Criteria(pLineNo.ToInteger))
        End Sub

        Public Overrides Function Save() As AWD
            If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("AWD")))

            Me.ApplyEdit()
            AWDInfoList.InvalidateCache()
            Return MyBase.Save()
        End Function

        Public Function CloneAWD(ByVal pLineNo As String) As AWD

            If AWD.KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

            Dim cloningAWD As AWD = MyBase.Clone
            cloningAWD._lineNo = pLineNo.ToInteger
            cloningAWD._DTB = Context.CurrentBECode

            'Todo:Remember to reset status of the new object here 
            cloningAWD.MarkNew()
            cloningAWD.ApplyEdit()

            cloningAWD.ValidationRules.CheckRules()

            Return cloningAWD
        End Function

#End Region ' Factory Methods

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public _lineNo As Integer

            Public Sub New(ByVal pLineNo As String)
                _lineNo = pLineNo.ToInteger

            End Sub
        End Class

        <RunLocal()> _
        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
            _lineNo = criteria._lineNo

            ValidationRules.CheckRules()
        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()
                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>SELECT * FROM pbs_PO_AWD<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim

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
            _lineNo = dr.GetInt32("LINE_NO")
            _awardType = dr.GetString("AWARD_TYPE").TrimEnd
            _awardNo = dr.GetString("AWARD_NO").TrimEnd
            _itemNo = dr.GetString("ITEM_NO").TrimEnd
            _itemCode = dr.GetString("ITEM_CODE").TrimEnd
            _suppDesc = dr.GetString("SUPP_DESC").TrimEnd
            _suppItemCode = dr.GetString("SUPP_ITEM_CODE").TrimEnd
            _itemNotes = dr.GetString("ITEM_NOTES").TrimEnd
            _purchQty.Text = dr.GetDecimal("PURCH_QTY")
            _purchUnit = dr.GetString("PURCH_UNIT").TrimEnd
            _stockQty.Text = dr.GetDecimal("STOCK_QTY")
            _location = dr.GetString("LOCATION").TrimEnd
            _stockUpd = dr.GetString("STOCK_UPD").TrimEnd
            _baseCost.Text = dr.GetDecimal("BASE_COST")
            _value1.Text = dr.GetDecimal("VALUE_1")
            _value2.Text = dr.GetDecimal("VALUE_2")
            _value3.Text = dr.GetDecimal("VALUE_3")
            _value4.Text = dr.GetDecimal("VALUE_4")
            _value5.Text = dr.GetDecimal("VALUE_5")
            _value6.Text = dr.GetDecimal("VALUE_6")
            _value7.Text = dr.GetDecimal("VALUE_7")
            _value8.Text = dr.GetDecimal("VALUE_8")
            _value9.Text = dr.GetDecimal("VALUE_9")
            _value10.Text = dr.GetDecimal("VALUE_10")
            _value11.Text = dr.GetDecimal("VALUE_11")
            _value12.Text = dr.GetDecimal("VALUE_12")
            _value13.Text = dr.GetDecimal("VALUE_13")
            _value14.Text = dr.GetDecimal("VALUE_14")
            _value15.Text = dr.GetDecimal("VALUE_15")
            _value16.Text = dr.GetDecimal("VALUE_16")
            _value17.Text = dr.GetDecimal("VALUE_17")
            _lineVal.Text = dr.GetDecimal("LINE_VAL")
            _convCode = dr.GetString("CONV_CODE").TrimEnd
            _budgetCode = dr.GetString("BUDGET_CODE").TrimEnd
            _bdgCheckVal.Text = dr.GetDecimal("BDG_CHECK_VAL")
            _expCheckVal.Text = dr.GetDecimal("EXP_CHECK_VAL")
            _accntCode = dr.GetString("ACCNT_CODE").TrimEnd
            _assetCode = dr.GetString("ASSET_CODE").TrimEnd
            _assetSub = dr.GetString("ASSET_SUB").TrimEnd
            _assetInd = dr.GetString("ASSET_IND").TrimEnd
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
            _estDelDate.Text = dr.GetInt32("EST_DEL_DATE")
            _apprDate.Text = dr.GetInt32("APPR_DATE")
            _apprBy = dr.GetString("APPR_BY").TrimEnd
            _apprNote = dr.GetString("APPR_NOTE").TrimEnd
            _updatedBy = dr.GetString("UPDATED_BY").TrimEnd
            _updated.Text = dr.GetInt32("UPDATED")

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    'Using cm = ctx.Connection.CreateCommand()

                    '    cm.CommandType = CommandType.StoredProcedure
                    '    cm.CommandText = String.Format("pbs_PO_AWD{0}_Insert", _DTB)

                    '    cm.Parameters.AddWithValue("@LINE_NO", _lineNo).Direction = ParameterDirection.Output
                    '    AddInsertParameters(cm)
                    '    cm.ExecuteNonQuery()

                    '    _lineNo = CInt(cm.Parameters("@LINE_NO").Value)
                    'End Using

                    Insert(ctx.Connection)

                End Using
            End SyncLock
        End Sub

        Private Sub AddInsertParameters(ByVal cm As SqlCommand)

            cm.Parameters.AddWithValue("@AWARD_TYPE", _awardType.Trim)
            cm.Parameters.AddWithValue("@AWARD_NO", _awardNo.Trim)
            cm.Parameters.AddWithValue("@ITEM_NO", _itemNo.Trim)
            cm.Parameters.AddWithValue("@ITEM_CODE", _itemCode.Trim)
            cm.Parameters.AddWithValue("@SUPP_DESC", _suppDesc.Trim)
            cm.Parameters.AddWithValue("@SUPP_ITEM_CODE", _suppItemCode.Trim)
            cm.Parameters.AddWithValue("@ITEM_NOTES", _itemNotes.Trim)
            cm.Parameters.AddWithValue("@PURCH_QTY", _purchQty.DBValue)
            cm.Parameters.AddWithValue("@PURCH_UNIT", _purchUnit.Trim)
            cm.Parameters.AddWithValue("@STOCK_QTY", _stockQty.DBValue)
            cm.Parameters.AddWithValue("@LOCATION", _location.Trim)
            cm.Parameters.AddWithValue("@STOCK_UPD", _stockUpd.Trim)
            cm.Parameters.AddWithValue("@BASE_COST", _baseCost.DBValue)
            cm.Parameters.AddWithValue("@VALUE_1", _value1.DBValue)
            cm.Parameters.AddWithValue("@VALUE_2", _value2.DBValue)
            cm.Parameters.AddWithValue("@VALUE_3", _value3.DBValue)
            cm.Parameters.AddWithValue("@VALUE_4", _value4.DBValue)
            cm.Parameters.AddWithValue("@VALUE_5", _value5.DBValue)
            cm.Parameters.AddWithValue("@VALUE_6", _value6.DBValue)
            cm.Parameters.AddWithValue("@VALUE_7", _value7.DBValue)
            cm.Parameters.AddWithValue("@VALUE_8", _value8.DBValue)
            cm.Parameters.AddWithValue("@VALUE_9", _value9.DBValue)
            cm.Parameters.AddWithValue("@VALUE_10", _value10.DBValue)
            cm.Parameters.AddWithValue("@VALUE_11", _value11.DBValue)
            cm.Parameters.AddWithValue("@VALUE_12", _value12.DBValue)
            cm.Parameters.AddWithValue("@VALUE_13", _value13.DBValue)
            cm.Parameters.AddWithValue("@VALUE_14", _value14.DBValue)
            cm.Parameters.AddWithValue("@VALUE_15", _value15.DBValue)
            cm.Parameters.AddWithValue("@VALUE_16", _value16.DBValue)
            cm.Parameters.AddWithValue("@VALUE_17", _value17.DBValue)
            cm.Parameters.AddWithValue("@LINE_VAL", _lineVal.DBValue)
            cm.Parameters.AddWithValue("@CONV_CODE", _convCode.Trim)
            cm.Parameters.AddWithValue("@BUDGET_CODE", _budgetCode.Trim)
            cm.Parameters.AddWithValue("@BDG_CHECK_VAL", _bdgCheckVal.DBValue)
            cm.Parameters.AddWithValue("@EXP_CHECK_VAL", _expCheckVal.DBValue)
            cm.Parameters.AddWithValue("@ACCNT_CODE", _accntCode.Trim)
            cm.Parameters.AddWithValue("@ASSET_CODE", _assetCode.Trim)
            cm.Parameters.AddWithValue("@ASSET_SUB", _assetSub.Trim)
            cm.Parameters.AddWithValue("@ASSET_IND", _assetInd.Trim)
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
            cm.Parameters.AddWithValue("@EST_DEL_DATE", _estDelDate.DBValue)
            cm.Parameters.AddWithValue("@APPR_DATE", _apprDate.DBValue)
            cm.Parameters.AddWithValue("@APPR_BY", _apprBy.Trim)
            cm.Parameters.AddWithValue("@APPR_NOTE", _apprNote.Trim)
            cm.Parameters.AddWithValue("@UPDATED_BY", _updatedBy.Trim)
            cm.Parameters.AddWithValue("@UPDATED", _updated.DBValue)
        End Sub


        Protected Overrides Sub DataPortal_Update()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    'Using cm = ctx.Connection.CreateCommand()

                    '    cm.CommandType = CommandType.StoredProcedure
                    '    cm.CommandText = String.Format("pbs_PO_AWD{0}_Update", _DTB)

                    '    cm.Parameters.AddWithValue("@LINE_NO", _lineNo)
                    '    AddInsertParameters(cm)
                    '    cm.ExecuteNonQuery()

                    'End Using

                    Update(ctx.Connection)

                End Using
            End SyncLock
        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_lineNo))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()

                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>DELETE pbs_PO_AWD<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim
                    cm.ExecuteNonQuery()

                End Using
            End Using

        End Sub

        'Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
        '    If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
        '        AWDInfoList.InvalidateCache()
        '    End If
        'End Sub


#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal pLineNo As String) As Boolean
            Return AWDInfoList.ContainsCode(pLineNo)
        End Function

        Public Shared Function KeyDuplicated(ByVal pLineNo As String) As Boolean
            Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_PO_AWD<%= Context.CurrentBECode %> WHERE LINE_NO= '<%= pLineNo %>'</SqlText>.Value.Trim
            Return SQLCommander.GetScalarInteger(SqlText) > 0
        End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Return CloneAWD(id)
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return pbs.Helper.Action.StandardReferenceCommands
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(AWD).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return GetType(AWD).ToString.Leaf
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return AWDInfoList.GetAWDInfoList
        End Function
#End Region

#Region "IDoclink"
        Public Function Get_DOL_Reference() As String Implements IDocLink.Get_DOL_Reference
            Return String.Format("{0}#{1}", Get_TransType, _lineNo)
        End Function

        Public Function Get_TransType() As String Implements IDocLink.Get_TransType
            Return Me.GetType.ToClassSchemaName.Leaf
        End Function
#End Region

#Region "Child"
        Shared Function NewAWDChild(pParentId As String) As AWD
            Dim ret = New AWD
            ret._awardNo = pParentId
            ret.MarkAsChild()
            Return ret
        End Function

        Shared Function GetChildAWD(dr As SafeDataReader)
            Dim child = New AWD
            child.FetchObject(dr)
            child.MarkAsChild()
            child.MarkOld()
            Return child
        End Function

        Sub DeleteSelf(cn As SqlConnection)
            Using cm = cn.CreateCommand
                cm.CommandType = CommandType.Text
                cm.CommandText = <sqltext>DELETE pbs_PO_AWD<%= _DTB %> WHERE LINE_NO = <%= _lineNo %></sqltext>
                cm.ExecuteNonQuery()
            End Using
        End Sub

        Sub Insert(cn As SqlConnection)
            Using cm = cn.CreateCommand()

                cm.CommandType = CommandType.StoredProcedure
                cm.CommandText = String.Format("pbs_PO_AWD{0}_Insert", _DTB)

                cm.Parameters.AddWithValue("@LINE_NO", _lineNo).Direction = ParameterDirection.Output
                AddInsertParameters(cm)
                cm.ExecuteNonQuery()

                _lineNo = CInt(cm.Parameters("@LINE_NO").Value)
            End Using
        End Sub

        Sub Update(cn As SqlConnection)

            Using cm = cn.CreateCommand()

                cm.CommandType = CommandType.StoredProcedure
                cm.CommandText = String.Format("pbs_PO_AWD{0}_Update", _DTB)

                cm.Parameters.AddWithValue("@LINE_NO", _lineNo)
                AddInsertParameters(cm)
                cm.ExecuteNonQuery()

            End Using

        End Sub

        Sub MarkAsNewChildren()
            MarkNew()
        End Sub
#End Region



    End Class

End Namespace