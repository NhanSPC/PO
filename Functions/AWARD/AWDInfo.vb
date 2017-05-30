
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation

Namespace PO

    <Serializable()> _
    Public Class AWDInfo
        Inherits Csla.ReadOnlyBase(Of AWDInfo)
        Implements IComparable
        Implements IInfo
        Implements IDocLink
        'Implements IInfoStatus


#Region " Business Properties and Methods "


        Private _lineNo As Integer
        Public ReadOnly Property LineNo() As String
            Get
                Return _lineNo
            End Get
        End Property

        Private _awardType As String = String.Empty
        Public ReadOnly Property AwardType() As String
            Get
                Return _awardType
            End Get
        End Property

        Private _awardNo As String = String.Empty
        Public ReadOnly Property AwardNo() As String
            Get
                Return _awardNo
            End Get
        End Property

        Private _itemNo As String = String.Empty
        Public ReadOnly Property ItemNo() As String
            Get
                Return _itemNo
            End Get
        End Property

        Private _itemCode As String = String.Empty
        Public ReadOnly Property ItemCode() As String
            Get
                Return _itemCode
            End Get
        End Property

        Private _suppDesc As String = String.Empty
        Public ReadOnly Property SuppDesc() As String
            Get
                Return _suppDesc
            End Get
        End Property

        Private _suppItemCode As String = String.Empty
        Public ReadOnly Property SuppItemCode() As String
            Get
                Return _suppItemCode
            End Get
        End Property

        Private _itemNotes As String = String.Empty
        Public ReadOnly Property ItemNotes() As String
            Get
                Return _itemNotes
            End Get
        End Property

        Private _purchQty As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property PurchQty() As String
            Get
                Return _purchQty.Text
            End Get
        End Property

        Private _purchUnit As String = String.Empty
        Public ReadOnly Property PurchUnit() As String
            Get
                Return _purchUnit
            End Get
        End Property

        Private _stockQty As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property StockQty() As String
            Get
                Return _stockQty.Text
            End Get
        End Property

        Private _location As String = String.Empty
        Public ReadOnly Property Location() As String
            Get
                Return _location
            End Get
        End Property

        Private _stockUpd As String = String.Empty
        Public ReadOnly Property StockUpd() As String
            Get
                Return _stockUpd
            End Get
        End Property

        Private _baseCost As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property BaseCost() As String
            Get
                Return _baseCost.Text
            End Get
        End Property

        Private _value1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value1() As String
            Get
                Return _value1.Text
            End Get
        End Property

        Private _value2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value2() As String
            Get
                Return _value2.Text
            End Get
        End Property

        Private _value3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value3() As String
            Get
                Return _value3.Text
            End Get
        End Property

        Private _value4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value4() As String
            Get
                Return _value4.Text
            End Get
        End Property

        Private _value5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value5() As String
            Get
                Return _value5.Text
            End Get
        End Property

        Private _value6 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value6() As String
            Get
                Return _value6.Text
            End Get
        End Property

        Private _value7 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value7() As String
            Get
                Return _value7.Text
            End Get
        End Property

        Private _value8 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value8() As String
            Get
                Return _value8.Text
            End Get
        End Property

        Private _value9 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value9() As String
            Get
                Return _value9.Text
            End Get
        End Property

        Private _value10 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value10() As String
            Get
                Return _value10.Text
            End Get
        End Property

        Private _value11 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value11() As String
            Get
                Return _value11.Text
            End Get
        End Property

        Private _value12 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value12() As String
            Get
                Return _value12.Text
            End Get
        End Property

        Private _value13 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value13() As String
            Get
                Return _value13.Text
            End Get
        End Property

        Private _value14 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value14() As String
            Get
                Return _value14.Text
            End Get
        End Property

        Private _value15 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value15() As String
            Get
                Return _value15.Text
            End Get
        End Property

        Private _value16 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value16() As String
            Get
                Return _value16.Text
            End Get
        End Property

        Private _value17 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value17() As String
            Get
                Return _value17.Text
            End Get
        End Property

        Private _lineVal As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property LineVal() As String
            Get
                Return _lineVal.Text
            End Get
        End Property

        Private _convCode As String = String.Empty
        Public ReadOnly Property ConvCode() As String
            Get
                Return _convCode
            End Get
        End Property

        Private _budgetCode As String = String.Empty
        Public ReadOnly Property BudgetCode() As String
            Get
                Return _budgetCode
            End Get
        End Property

        Private _bdgCheckVal As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property BdgCheckVal() As String
            Get
                Return _bdgCheckVal.Text
            End Get
        End Property

        Private _expCheckVal As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExpCheckVal() As String
            Get
                Return _expCheckVal.Text
            End Get
        End Property

        Private _accntCode As String = String.Empty
        Public ReadOnly Property AccntCode() As String
            Get
                Return _accntCode
            End Get
        End Property

        Private _assetCode As String = String.Empty
        Public ReadOnly Property AssetCode() As String
            Get
                Return _assetCode
            End Get
        End Property

        Private _assetSub As String = String.Empty
        Public ReadOnly Property AssetSub() As String
            Get
                Return _assetSub
            End Get
        End Property

        Private _assetInd As String = String.Empty
        Public ReadOnly Property AssetInd() As String
            Get
                Return _assetInd
            End Get
        End Property

        Private _analM0 As String = String.Empty
        Public ReadOnly Property AnalM0() As String
            Get
                Return _analM0
            End Get
        End Property

        Private _analM1 As String = String.Empty
        Public ReadOnly Property AnalM1() As String
            Get
                Return _analM1
            End Get
        End Property

        Private _analM2 As String = String.Empty
        Public ReadOnly Property AnalM2() As String
            Get
                Return _analM2
            End Get
        End Property

        Private _analM3 As String = String.Empty
        Public ReadOnly Property AnalM3() As String
            Get
                Return _analM3
            End Get
        End Property

        Private _analM4 As String = String.Empty
        Public ReadOnly Property AnalM4() As String
            Get
                Return _analM4
            End Get
        End Property

        Private _analM5 As String = String.Empty
        Public ReadOnly Property AnalM5() As String
            Get
                Return _analM5
            End Get
        End Property

        Private _analM6 As String = String.Empty
        Public ReadOnly Property AnalM6() As String
            Get
                Return _analM6
            End Get
        End Property

        Private _analM7 As String = String.Empty
        Public ReadOnly Property AnalM7() As String
            Get
                Return _analM7
            End Get
        End Property

        Private _analM8 As String = String.Empty
        Public ReadOnly Property AnalM8() As String
            Get
                Return _analM8
            End Get
        End Property

        Private _analM9 As String = String.Empty
        Public ReadOnly Property AnalM9() As String
            Get
                Return _analM9
            End Get
        End Property

        Private _estDelDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property EstDelDate() As String
            Get
                Return _estDelDate.DateViewFormat
            End Get
        End Property

        Private _apprDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ApprDate() As String
            Get
                Return _apprDate.DateViewFormat
            End Get
        End Property

        Private _apprBy As String = String.Empty
        Public ReadOnly Property ApprBy() As String
            Get
                Return _apprBy
            End Get
        End Property

        Private _apprNote As String = String.Empty
        Public ReadOnly Property ApprNote() As String
            Get
                Return _apprNote
            End Get
        End Property

        Private _updatedBy As String = String.Empty
        Public ReadOnly Property UpdatedBy() As String
            Get
                Return _updatedBy
            End Get
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.DateViewFormat
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

        Public ReadOnly Property Code As String Implements IInfo.Code
            Get
                Return _lineNo
            End Get
        End Property

        Public ReadOnly Property LookUp As String Implements IInfo.LookUp
            Get
                Return _lineNo
            End Get
        End Property

        Public ReadOnly Property Description As String Implements IInfo.Description
            Get
                Return String.Format("{0}{1}", _awardNo, _itemNo)
            End Get
        End Property


        Public Sub InvalidateCache() Implements IInfo.InvalidateCache
            AWDInfoList.InvalidateCache()
        End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

        Friend Shared Function GetAWDInfo(ByVal dr As SafeDataReader) As AWDInfo
            Return New AWDInfo(dr)
        End Function

        Friend Shared Function EmptyAWDInfo(Optional ByVal pLineNo As String = "") As AWDInfo
            Dim info As AWDInfo = New AWDInfo
            With info
                ._lineNo = pLineNo.ToInteger

            End With
            Return info
        End Function

        Private Sub New(ByVal dr As SafeDataReader)
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

        Private Sub New()
        End Sub


#End Region ' Factory Methods

#Region "IDoclink"
        Public Function Get_DOL_Reference() As String Implements IDocLink.Get_DOL_Reference
            Return String.Format("{0}#{1}", Get_TransType, _lineNo)
        End Function

        Public Function Get_TransType() As String Implements IDocLink.Get_TransType
            Return Me.GetType.ToClassSchemaName.Leaf
        End Function
#End Region

    End Class

End Namespace