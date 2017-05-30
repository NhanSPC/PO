
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation

Namespace PO

    <Serializable()> _
    Public Class AWHInfo
        Inherits Csla.ReadOnlyBase(Of AWHInfo)
        Implements IComparable
        Implements IInfo
        Implements IDocLink
        'Implements IInfoStatus


#Region " Business Properties and Methods "


        Private _awardNo As String = String.Empty
        Public ReadOnly Property AwardNo() As String
            Get
                Return _awardNo
            End Get
        End Property

        Private _awardDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property AwardDate() As String
            Get
                Return _awardDate.DateViewFormat
            End Get
        End Property

        Private _awardPrd As SmartPeriod = New pbs.Helper.SmartPeriod()
        Public ReadOnly Property AwardPrd() As String
            Get
                Return _awardPrd.Text
            End Get
        End Property

        Private _awardVal As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property AwardVal() As String
            Get
                Return _awardVal.Text
            End Get
        End Property

        Private _awardQty As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property AwardQty() As String
            Get
                Return _awardQty.Text
            End Get
        End Property

        Private _suppCode As String = String.Empty
        Public ReadOnly Property SuppCode() As String
            Get
                Return _suppCode
            End Get
        End Property

        Private _contact As String = String.Empty
        Public ReadOnly Property Contact() As String
            Get
                Return _contact
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

        Private _status As String = String.Empty
        Public ReadOnly Property Status() As String
            Get
                Return _status
            End Get
        End Property

        Private _orderType As String = String.Empty
        Public ReadOnly Property OrderType() As String
            Get
                Return _orderType
            End Get
        End Property

        Private _descriptn As String = String.Empty
        Public ReadOnly Property Descriptn() As String
            Get
                Return _descriptn
            End Get
        End Property

        Private _convCode As String = String.Empty
        Public ReadOnly Property ConvCode() As String
            Get
                Return _convCode
            End Get
        End Property

        Private _convRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ConvRate() As String
            Get
                Return _convRate.Text
            End Get
        End Property

        Private _prNo As String = String.Empty
        Public ReadOnly Property PrNo() As String
            Get
                Return _prNo
            End Get
        End Property

        Private _notes As String = String.Empty
        Public ReadOnly Property Notes() As String
            Get
                Return _notes
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

        Private _exText1 As String = String.Empty
        Public ReadOnly Property ExText1() As String
            Get
                Return _exText1
            End Get
        End Property

        Private _exText2 As String = String.Empty
        Public ReadOnly Property ExText2() As String
            Get
                Return _exText2
            End Get
        End Property

        Private _exText3 As String = String.Empty
        Public ReadOnly Property ExText3() As String
            Get
                Return _exText3
            End Get
        End Property

        Private _exText4 As String = String.Empty
        Public ReadOnly Property ExText4() As String
            Get
                Return _exText4
            End Get
        End Property

        Private _exText5 As String = String.Empty
        Public ReadOnly Property ExText5() As String
            Get
                Return _exText5
            End Get
        End Property

        Private _exText6 As String = String.Empty
        Public ReadOnly Property ExText6() As String
            Get
                Return _exText6
            End Get
        End Property

        Private _exText7 As String = String.Empty
        Public ReadOnly Property ExText7() As String
            Get
                Return _exText7
            End Get
        End Property

        Private _exVal1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExVal1() As String
            Get
                Return _exVal1.Text
            End Get
        End Property

        Private _exVal2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExVal2() As String
            Get
                Return _exVal2.Text
            End Get
        End Property

        Private _exVal3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExVal3() As String
            Get
                Return _exVal3.Text
            End Get
        End Property

        Private _exVal4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExVal4() As String
            Get
                Return _exVal4.Text
            End Get
        End Property

        Private _exVal5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExVal5() As String
            Get
                Return _exVal5.Text
            End Get
        End Property

        Private _exDate1 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExDate1() As String
            Get
                Return _exDate1.DateViewFormat
            End Get
        End Property

        Private _exDate2 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExDate2() As String
            Get
                Return _exDate2.DateViewFormat
            End Get
        End Property

        Private _exDate3 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExDate3() As String
            Get
                Return _exDate3.DateViewFormat
            End Get
        End Property

        Private _exDate4 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExDate4() As String
            Get
                Return _exDate4.DateViewFormat
            End Get
        End Property

        Private _exDate5 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExDate5() As String
            Get
                Return _exDate5.DateViewFormat
            End Get
        End Property

        Private _locked As String = String.Empty
        Public ReadOnly Property Locked() As String
            Get
                Return _locked
            End Get
        End Property

        Private _lockedBy As String = String.Empty
        Public ReadOnly Property LockedBy() As String
            Get
                Return _lockedBy
            End Get
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.DateViewFormat
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
            Return _awardNo
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Dim ID = IDObject.ToString
            Dim pAwardNo As String = id.Trim
            If _awardNo.Trim < pAwardNo Then Return -1
            If _awardNo.Trim > pAwardNo Then Return 1
            Return 0
        End Function

        Public ReadOnly Property Code As String Implements IInfo.Code
            Get
                Return _awardNo
            End Get
        End Property

        Public ReadOnly Property LookUp As String Implements IInfo.LookUp
            Get
                Return _awardNo
            End Get
        End Property

        Public ReadOnly Property Description As String Implements IInfo.Description
            Get
                Return String.Format("Award number: {0}, award date: {1}.", _awardNo, _awardDate)
            End Get
        End Property


        Public Sub InvalidateCache() Implements IInfo.InvalidateCache
            AWHInfoList.InvalidateCache()
        End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

        Friend Shared Function GetAWHInfo(ByVal dr As SafeDataReader) As AWHInfo
            Return New AWHInfo(dr)
        End Function

        Friend Shared Function EmptyAWHInfo(Optional ByVal pAwardNo As String = "") As AWHInfo
            Dim info As AWHInfo = New AWHInfo
            With info
                ._awardNo = pAwardNo

            End With
            Return info
        End Function

        Private Sub New(ByVal dr As SafeDataReader)
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
            _orderType = dr.GetString("AWARD_TYPE").TrimEnd
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

        Private Sub New()
        End Sub


#End Region ' Factory Methods

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