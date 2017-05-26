
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation
Imports System.Text.RegularExpressions
Namespace PO

    <Serializable()> _
    Public Class SEVInfo
        Inherits Csla.ReadOnlyBase(Of SEVInfo)
        Implements IComparable
        Implements IInfo
        Implements IDocLink
        'Implements IInfoStatus


#Region " Business Properties and Methods "


        Private _supplierCode As String = String.Empty
        Public ReadOnly Property SupplierCode() As String
            Get
                Return _supplierCode
            End Get
        End Property

        Private _itemCode As String = String.Empty
        Public ReadOnly Property ItemCode() As String
            Get
                Return _itemCode
            End Get
        End Property

        Friend _effectiveDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property EffectiveDate() As String
            Get
                Return _effectiveDate.DateViewFormat
            End Get
        End Property

        Private _suspended As String = String.Empty
        Public ReadOnly Property Suspended() As String
            Get
                Return _suspended
            End Get
        End Property

        Private _value0 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value0() As String
            Get
                Return _value0.Text
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

        Private _notes As String = String.Empty
        Public ReadOnly Property Notes() As String
            Get
                Return _notes
            End Get
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.Text
            End Get
        End Property

        Private _updatedBy As String = String.Empty
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
            Dim pSupplierCode As String = Regex.Match(ID, pbsRegex.AlphaNumericExt2).Value.Trim
            Dim pItemCode As String = Regex.Match(ID, pbsRegex.AlphaNumericExt2).NextMatch.Value.Trim
            If _supplierCode.Trim < pSupplierCode Then Return -1
            If _supplierCode.Trim > pSupplierCode Then Return 1
            If _itemCode.Trim < pItemCode Then Return -1
            If _itemCode.Trim > pItemCode Then Return 1
            Return 0
        End Function

        Public ReadOnly Property Code As String Implements IInfo.Code
            Get
                Return String.Format("{0}.{1}", _supplierCode, _itemCode)
            End Get
        End Property

        Public ReadOnly Property LookUp As String Implements IInfo.LookUp
            Get
                Return _supplierCode
            End Get
        End Property

        Public ReadOnly Property Description As String Implements IInfo.Description
            Get
                Return String.Format("Supplier: {0}, Item Code: {1}", _supplierCode, _itemCode)
            End Get
        End Property


        Public Sub InvalidateCache() Implements IInfo.InvalidateCache
            SEVInfoList.InvalidateCache()
        End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

        Friend Shared Function GetSEVInfo(ByVal dr As SafeDataReader) As SEVInfo
            Return New SEVInfo(dr)
        End Function

        Friend Shared Function EmptySEVInfo(Optional ByVal pSupplierCode As String = "", Optional ByVal pItemCode As String = "") As SEVInfo
            Dim info As SEVInfo = New SEVInfo
            With info
                ._supplierCode = pSupplierCode
                ._itemCode = pItemCode

            End With
            Return info
        End Function

        Private Sub New(ByVal dr As SafeDataReader)
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

        Private Sub New()
        End Sub


#End Region ' Factory Methods

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